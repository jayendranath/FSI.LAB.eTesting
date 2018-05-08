using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using FSI.LAB.eTesting.Hub.App_Start;
using Microsoft.AspNet.SignalR;
using System;
using System.Configuration;

namespace FSI.LAB.eTesting.Hub
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {

            // Register global filter
            GlobalFilters.Filters.Add(new FSI.LAB.eTesting.Hub.Controllers.BaseController.CustomFilterAttribute()); // ADDED

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            GlobalHost.Configuration.TransportConnectTimeout = TimeSpan.FromSeconds(15);
        }


        /// <summary>
        /// Add web.config app settings into the ViewBag so pages can utilize it for JS etc.
        /// </summary>
        public class AppSettingsAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuted(ActionExecutedContext filterContext)
            {
                var viewResult = filterContext.Result as ViewResult;
                if (viewResult == null)
                    return;

                //viewResult.ViewBag.AppSettings = ConfigurationManager.AppSettings.AllKeys.ToDictionary(key => key, key => ConfigurationManager.AppSettings[key]); ;

                base.OnActionExecuted(filterContext);
            }
        }
    }
}
