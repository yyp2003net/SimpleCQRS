﻿using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using SimpleCqrs;

namespace Web
{
    public class MvcApplication : HttpApplication
    {
        public IServiceLocator ServiceLocator { get; private set; }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new {controller = "Home", action = "Index", id = UrlParameter.Optional} // Parameter defaults
                );
        }

        protected void Application_Start()
        {
            var bootstrapper = new WebBootstrapper();
            ServiceLocator = bootstrapper.Run();

            AreaRegistration.RegisterAllAreas();

            RegisterRoutes(RouteTable.Routes);
        }
    }
}