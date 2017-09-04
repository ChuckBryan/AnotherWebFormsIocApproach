using System;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;

namespace AnotherWebFormsIocApproach
{
    using Microsoft.Practices.ServiceLocation;
    using StructureMap;

    public class Global : HttpApplication
    {

        public static StructureMapDependencyResolver StructureMapResolver { get; set; }

        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // IoC
            var container = IoC.Initialize();

            StructureMapResolver = new StructureMapDependencyResolver(container);
            // DependencyResolver.SetResolver(StructureMapResolver);
            ServiceLocator.SetLocatorProvider(() => StructureMapResolver);
        }

        public void Application_BeginRequest()
        {
            // Make sure that each request has a nested container
            StructureMapResolver.CreateNestedContainer();
        }

        public void Application_EndRequest()
        {
            // Dispose nested container
            StructureMapResolver.DisposeNestedContainer();
        }
    }
}