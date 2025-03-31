using Client.Management.API.Data;
using Client.Management.API.DTOs.ResponseDTOs;
using Client.Management.API.ExceptionMiddleware;
using Client.Management.API.Mappers;
using Client.Management.API.Repository.Implementations;
using Client.Management.API.Repository.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

/* Add Logger */
var logger = new LoggerConfiguration().WriteTo.File(path: "GeneratedLogs/ClientManagement_Log.txt", rollingInterval: RollingInterval.Day).MinimumLevel.Information().CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger: logger);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = JwtBearerDefaults.AuthenticationScheme,
        BearerFormat = "JWT",
        Description = "Enter 'Bearer' [SPACE] and then your valid token. \n\nExample: \"Bearer abc123\""
    });

    option.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme()
            {
                Reference = new OpenApiReference()
                {
                    Id = JwtBearerDefaults.AuthenticationScheme,
                    Type = ReferenceType.SecurityScheme
                }
            },
            Array.Empty<string>()
        }
    });
});

/* Register Database Context */
builder.Services.AddDbContext<ClientDataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString(name: "ClientManagementConnectionString"));
});

/* Register Authentication Database Context */
builder.Services.AddDbContext<ClientAuthenticationDataContext>(option => 
{
    option.UseSqlServer(builder.Configuration.GetConnectionString(name: "ClientAuthenticationConnectionString"));
});

/* Register Client Service */
builder.Services.AddScoped<ResponseDto>();
builder.Services.AddScoped<IClientService, ClientServiceImplementation>();
builder.Services.AddScoped<IClientRegisterService, ClientRegisterServiceImplementation>();
builder.Services.AddScoped<IClientTokenService, ClientTokenServiceImplementation>();

/* Register Mapper Service */
builder.Services.AddAutoMapper(typeof(ClientMapperProfiles));

/* Register Identity Package */
builder.Services.AddIdentityCore<IdentityUser>().AddRoles<IdentityRole>().AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>(providerName: "Client.Management.API").AddEntityFrameworkStores<ClientAuthenticationDataContext>().AddDefaultTokenProviders();

/* Password Setting Configuration */
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 8;
    options.Password.RequiredUniqueChars = 1;
});

/* Register Authentication Service */
builder.Services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidAudiences = new[] { builder.Configuration["JWT:Audience"] },
        IssuerSigningKey = new SymmetricSecurityKey(key: Encoding.UTF8.GetBytes(builder.Configuration["JWT:SecreteKey"]))
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

/* Registering Global Exception Handler */
app.UseMiddleware<GlobalExceptionHandler>();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
