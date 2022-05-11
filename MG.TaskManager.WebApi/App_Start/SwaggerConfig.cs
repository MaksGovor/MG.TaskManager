using System.Web.Http;
using WebActivatorEx;
using MG.TaskManager.WebApi;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace MG.TaskManager.WebApi
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "MG.TaskManager.WebApi");
                        c.PrettyPrint();
                    })
                .EnableSwaggerUi(c =>
                    {
                    });
        }
    }
}
