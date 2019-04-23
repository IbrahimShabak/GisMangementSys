using System.Web.Http;
using WebActivatorEx;
using WebApiService;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace WebApiService
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;
            GlobalConfiguration.Configuration
                                  .EnableSwagger(c => c.SingleApiVersion("v1", "A title for your API"))
                                  .EnableSwaggerUi();

        }
    }
}
