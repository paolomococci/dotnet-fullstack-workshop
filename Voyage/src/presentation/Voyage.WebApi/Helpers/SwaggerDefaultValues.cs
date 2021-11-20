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
            throw new System.NotImplementedException();
        }
    }
}
