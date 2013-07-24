using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebAPIAuthenitication.Security;

namespace WebAPIAuthenitication
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "Authentication",
                routeTemplate: "api/users/{id}",
                defaults: new { controller = "users" }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional },
                constraints: null,
                handler: new TokenInspector()
            );

            config.MessageHandlers.Add(new HTTPSGuard()); //Global handler - applicable to all the requests
        }
    }
}
