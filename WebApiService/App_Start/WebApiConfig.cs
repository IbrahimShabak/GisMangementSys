using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebApiService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
        public static int GetuserID(System.Security.Principal.IIdentity UserIdentity)
        {
            int UserID = -1;
            try
            {
                var identity = (System.Security.Claims.ClaimsIdentity)UserIdentity;
                string StrUserID = identity.Claims.First(c => c.Type == "UserID").Value;
                UserID = int.Parse(StrUserID);
            }
            catch
            {
                UserID = -1;
            }
            return UserID;
        }
    }
}
