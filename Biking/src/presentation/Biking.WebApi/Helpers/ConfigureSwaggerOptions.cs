using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Biking.WebApi.Helpers
{
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _iApiVersionDescriptionProvider;

        public ConfigureSwaggerOptions(
            IApiVersionDescriptionProvider iApiVersionDescriptionProvider
        ) => _iApiVersionDescriptionProvider = iApiVersionDescriptionProvider;

        public void Configure(
            SwaggerGenOptions options
        )
        {
            foreach (var apiVersionDescription in _iApiVersionDescriptionProvider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(
                    apiVersionDescription.GroupName,
                    OpenApiInfoVersioning(apiVersionDescription)
                );
            }
        }

        private static OpenApiInfo OpenApiInfoVersioning(
            ApiVersionDescription apiVersionDescription
        )
        {
            var openApiInfo = new OpenApiInfo
            {
                Title = "Biking",
                Version = apiVersionDescription.ApiVersion.ToString(),
                Description = "Biking web API",
                Contact = new OpenApiContact
                {
                    Name = "ICT Department",
                    Email = "ict@biking.local",
                    Url = new System.Uri("https://biking.local/ict")
                }
            };

            if (apiVersionDescription.IsDeprecated)
            {
                openApiInfo.Description += " <em>this API version of Biking, was deprecated</em>";
            }

            return openApiInfo;
        }
    }
}
