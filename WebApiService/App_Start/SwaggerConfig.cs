using System.Web.Http;
using WebActivatorEx;
using WebApiService;
using Swashbuckle.Application;
using Swashbuckle.Swagger;
using System.Web.Http.Description;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace WebApiService
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;
            GlobalConfiguration.Configuration
                                  .EnableSwagger(c =>
                                  {
                                      c.SingleApiVersion("v1", "A title for your API");
                                      c.OperationFilter<AddAuthorizationHeaderParameterOperationFilter>();
                                  })
                                  .EnableSwaggerUi();
        }
    }

    public class AddAuthorizationHeaderParameterOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            if (operation.parameters != null)
            {
                operation.parameters.Add(new Parameter
                {
                    name = "Authorization",
                    @in = "header",
                    description = "access token",
                    required = false,
                    type = "string"
                });
            }
        }
    }
}