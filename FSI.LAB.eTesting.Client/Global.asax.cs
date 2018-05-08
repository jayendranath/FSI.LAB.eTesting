using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using FSI.LAB.eTesting.Client.App_Start;
using System;
using Microsoft.AspNet.SignalR;

namespace FSI.LAB.eTesting.Client
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            GlobalHost.Configuration.TransportConnectTimeout = TimeSpan.FromSeconds(15);

        }
    }
}
