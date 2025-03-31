using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using NZWalk.API.Data;
using NZWalk.API.Mapping;
using NZWalk.API.Repositories.Implementations;
using NZWalk.API.Repositories.Interfaces;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.FileProviders;
using Serilog;
using NZWalk.API.MiddleWares;

var builder = WebApplication.CreateBuilder(args);

/* Adding SeriLog Logger To Application For API */
var logger = new LoggerConfiguration().WriteTo.Console().WriteTo.File(path: "Logs/NZWalks_Log.txt", rollingInterval: RollingInterval.Minute).MinimumLevel.Information().CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

// Add services to the container.

builder.Services.AddControllers();

/* To get the image location we need to inject Http Context Accessor service */
builder.Services.AddHttpContextAccessor();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

/* Configuring Swagger Gen and its options - These are the basic things & steps which are needed to enable Authentication & Authorization in swagger Gen */
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "NZ Walks API", Version = "v1" });

    option.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
    {
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = JwtBearerDefaults.AuthenticationScheme,
        BearerFormat = "JWT",
        Description = "Enter 'Bearer' [space] and then your valid token in the text input below.\n\nExample: \"Bearer abc123\""
    });

    /* We also need to add security requirement in the options for swagger */
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = JwtBearerDefaults.AuthenticationScheme
                }
            },
            Array.Empty<string>()
        }
    });
});

/* Need to inject DbContext<NZWalksDbContext> class */
builder.Services.AddDbContext<NZWalksDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString(name: "NZWalksConnectionString"));
});

/* Need to inject DbContext<NZWalksAuthDbContext> class */
builder.Services.AddDbContext<NZWalksAuthDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString(name: "NZWalksAuthenticationConnectionString"));
});

/* Registering Services, Implementations, AutoMapper which are injected as DI in Repositories */
builder.Services.AddScoped<IRegionService, RegionServiceImplementation>();
builder.Services.AddScoped<IWalkService, WalkServiceImplementation>();
builder.Services.AddScoped<ITokenService, TokenServiceImplementation>();
builder.Services.AddScoped<IImageUploadService, ImageUploadServiceImplementation>();

/* Register Auto Mapper */
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

/* Register Identity Packages */
builder.Services.AddIdentityCore<IdentityUser>()
    .AddRoles<IdentityRole>()
    .AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>("NZWalks")
    .AddEntityFrameworkStores<NZWalksAuthDbContext>()
    .AddDefaultTokenProviders();

/* Password Setting Configuration */
builder.Services.Configure<IdentityOptions>(option =>
{
    option.Password.RequireDigit = true;
    option.Password.RequireLowercase = false;
    option.Password.RequireUppercase = false;
    option.Password.RequireNonAlphanumeric = false;
    option.Password.RequiredLength = 4;
});

/* Add Authentication To The Services */
builder.Services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(option =>
{
    /* Need to pass Token validation parameters */
    option.TokenValidationParameters = new TokenValidationParameters()
    {
        /* Authentication Type */
        AuthenticationType = "JWT",
        /* Validate Issuer */
        ValidateIssuer = true,
        /* Validate Audience */
        ValidateAudience = true,
        /* Validate Life Time */
        ValidateLifetime = true,
        /* Validate Issuer Signing Key */
        ValidateIssuerSigningKey = true,
        /* Initialize Valid Issuer From App Settings JSON */
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        /* Initialize Valid Audience From App Settings JSON */
        //ValidAudience = builder.Configuration["JWT:Audience"],
        ValidAudiences = new[] { builder.Configuration["JWT:Audience"] },
        /* Initialize Issuer Signing Key From App Settings JSON */
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

/* Use Exception Handler MiddleWare */
app.UseMiddleware<ExceptionHandlerMiddleWare>();

app.UseHttpsRedirection();

/* Use Authentication method call before Authorization */
app.UseAuthentication();

app.UseAuthorization();

/* This is to extend the access of using static files with help of URL */
app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Images")),
    RequestPath= "/Images",
});

app.MapControllers();

app.Run();
