using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Versioning.API.Nuget.SwaggerConfiguration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

/* For API Versioning */
builder.Services.AddApiVersioning(option =>
{
    /* This line tells the application to Assume Default Version When Unspecified  */
    option.AssumeDefaultVersionWhenUnspecified = true;

    /* This will tell the application to treat V1 as default version */
    option.DefaultApiVersion = new ApiVersion(majorVersion: 1, minorVersion: 0);
    option.ReportApiVersions = true;
});

builder.Services.AddVersionedApiExplorer(option =>
{
    option.GroupNameFormat = "'v'VVV";
    option.SubstituteApiVersionInUrl = true;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/* Injecting the Swagger Configuration Options */
builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();

var app = builder.Build();

var versionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(option => 
    {
        foreach (var description in versionDescriptionProvider.ApiVersionDescriptions)
        {
            option.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
        }
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
