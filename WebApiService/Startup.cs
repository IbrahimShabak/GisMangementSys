using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.OAuth;
using System.Web.Http;
using IdentityServer3.AccessTokenValidation;
using System.Web.Http.Cors;

[assembly: OwinStartup(typeof(WebApiService.Startup))]

namespace WebApiService
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            //enable cors origin requests
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            var myProvider = new MyAuthorizationServerProvider();
            OAuthAuthorizationServerOptions options = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = myProvider
            };
            var config = new HttpConfiguration();

            // HttpConfiguration config = WebApiConfig.Register1();
            app.UseOAuthAuthorizationServer(options);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
            // config.Filters.Add(new AuthorizeAttribute());
            // WebApiConfig.Register(config);
        }

        //public void Configuration1(IAppBuilder app)
        //{
        //    //   app.UseWebApi(WebApiConfig.Register1());

        //    //app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions
        //    //{
        //    //    Authority = "https://localhost:44350",
        //    //    RequiredScopes = new string[] {
        //    //                                        "api1", "quickapp_api"
        //    //                                  },
        //    //    // ClientSecret = "21B5F798-BE55-42BC-8AA8-0025B903DC3B",
        //    //    // ClientId = "quickapp_spa",
        //    //    // ValidationMode = ValidationMode.ValidationEndpoint,
        //    //});
        //    ////app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions
        //    //{
        //    //    Authority = "https://localhost:44350",
        //    //    RequiredScopes = new string[] { "api1", "quickapp_api" },
        //    //});
        //    // configure web api
        //    //  var config = new HttpConfiguration();
        //    //config.MapHttpAttributeRoutes();
        //    // require authentication for all controllers
        //    var config = WebApiConfig.Register1();
        //    //  config.Filters.Add(new AuthorizeAttribute());
        //    app.UseWebApi(config);
        //}
    }
}