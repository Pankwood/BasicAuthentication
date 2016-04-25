#region Licence
//===================================================================================
// Pankwood
//===================================================================================
// Copyright (c) 2016, Pankwood.  All Rights Reserved.
//===================================================================================
#endregion

#region References
using System.Web.Http;
#endregion

namespace WebAPIBasicAuth
{
    public class RouteConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{token}",
                defaults: new { token = RouteParameter.Optional }
            );

            //config.Formatters.Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);
        }
    }
}

