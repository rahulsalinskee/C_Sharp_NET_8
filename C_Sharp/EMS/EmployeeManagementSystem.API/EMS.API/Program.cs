using EMS.API.DataContext;
using EMS.API.DTOs.ResponseDTOs;
using EMS.API.GlobalException;
using EMS.API.Mapper;
using EMS.API.Repository.Implementations;
using EMS.API.Repository.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);


var logger = new LoggerConfiguration().WriteTo.File(path: $"GeneratedLogs/EMS_Log_{DateTimeOffset.UtcNow}_.txt", rollingInterval: RollingInterval.Minute).MinimumLevel.Information().CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger: logger);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

/* Registering Database Connection String In MiddleWare */
builder.Services.AddDbContext<EMSDataBaseContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("EMSConnectionString"));
});

/* Register Auto Mapper */
builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddScoped<IPersonService, PersonServiceImplementation>();
builder.Services.AddScoped<ResponseDto>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<GlobalExceptionHandler>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
