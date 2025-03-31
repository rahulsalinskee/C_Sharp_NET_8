using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Versioning.API.Nuget.SwaggerConfiguration
{
    public class ConfigureSwaggerOptions : IConfigureNamedOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _apiVersionDescriptionProvider;

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider apiVersionDescriptionProvider)
        {
            this._apiVersionDescriptionProvider = apiVersionDescriptionProvider;
        }

        public void Configure(string? name, SwaggerGenOptions options)
        {
            Configure(options: options);
        }

        public void Configure(SwaggerGenOptions options)
        {
            foreach (var item in _apiVersionDescriptionProvider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(name: item.GroupName, info: CreateVersionInformation(description: item));
            }
        }

        private static OpenApiInfo CreateVersionInformation(ApiVersionDescription description)
        {
            return new OpenApiInfo()
            {
                Title = "Your API Version",
                Version = description.ApiVersion.ToString(),
            };
        }
    }
}
