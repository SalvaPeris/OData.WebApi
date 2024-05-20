namespace OData.WebApi.Persistence.Filters
{
    using Microsoft.OpenApi.Models;
    using Swashbuckle.AspNetCore.SwaggerGen;

    public class ODataOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
            {
                operation.Parameters = new List<OpenApiParameter>();
            }

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "$top",
                In = ParameterLocation.Query,
                Description = "Number of records to return",
                Required = false,
                Schema = new OpenApiSchema
                {
                    Type = "integer"
                }
            });

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "$skip",
                In = ParameterLocation.Query,
                Description = "Number of records to skip",
                Required = false,
                Schema = new OpenApiSchema
                {
                    Type = "integer"
                }
            });

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "$count",
                In = ParameterLocation.Query,
                Description = "Include count of total items",
                Required = false,
                Schema = new OpenApiSchema
                {
                    Type = "boolean"
                }
            });
        }
    }

}
