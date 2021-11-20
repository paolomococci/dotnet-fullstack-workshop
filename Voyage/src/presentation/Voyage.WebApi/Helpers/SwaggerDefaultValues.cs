using System.Linq;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Voyage.WebApi.Helpers
{
    public class SwaggerDefaultValues : IOperationFilter
    {
        public void Apply(
            OpenApiOperation operation,
            OperationFilterContext context
        )
        {
            var contextApiDescription = context.ApiDescription;
            operation.Deprecated |= contextApiDescription.IsDeprecated();

            if (operation.Parameters == null)
            {
                return;
            }

            foreach (var parameter in operation.Parameters)
            {
                var description = contextApiDescription.ParameterDescriptions.First(
                    apiParameterDescription => apiParameterDescription.Name == parameter.Name
                );

                parameter.Description ??= description.ModelMetadata.Description;

                if (
                    parameter.Schema.Default == null && description.DefaultValue != null
                )
                {
                    parameter.Schema.Default = new OpenApiString(
                        description.DefaultValue.ToString()
                    );
                }

                parameter.Required |= description.IsRequired;
            }
        }
    }
}
