using FSI.LAB.eTesting.Hub.Models;
using FSI.LAB.eTesting.Hub.WebServices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FSI.LAB.eTesting.Hub.Controllers
{
    public class BaseController : Controller, IActionFilter
    {
        // GET: Base
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public class CustomFilterAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                if (((filterContext.ActionDescriptor).ControllerDescriptor).ControllerName == "Home")
                {
                    //Trace.WriteLine("In custom filter");
                    //UserService usrService = new UserService();
                    //bool isvalid = usrService.IsAuthenticated(System.Security.Principal.WindowsIdentity.GetCurrent().Name);
                    string userName = Thread.CurrentPrincipal.Identity.Name;
                    userName = userName.Substring(userName.IndexOf("\\") + 1);
                    //Trace.WriteLine(userName);

                    Proctoring pc = new Proctoring();

                    pc.validateUser(userName);
                    if (System.Web.HttpContext.Current.Session["AdLoginPNo"] == null || System.Web.HttpContext.Current.Session["AdLoginPNo"].ToString() == "")
                    {
                        //Trace.WriteLine("Invalid user!");
                        //string exceptionMsg = string.Format("Access denied ! User {0} has no access. Contact Site Administrator!",
                        //    System.Security.Principal.WindowsIdentity.GetCurrent().Name);
                        //string exceptionMsg = string.Format("Access denied ! User {0} has no access. Contact Site Administrator!",                            userName);

                        //throw new AuthenticationException(exceptionMsg);
                        filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                        {
                            controller = "Login",
                            action = "LoginProctor",
                            //Message = exceptionMsg

                        }));
                    }
                    else
                    {
                        if (System.Web.HttpContext.Current.Session["AdProctorId"].ToString().Trim().ToLower() != userName.Trim().ToLower())
                        {
                            //Trace.WriteLine("Invalid user!");
                            //string exceptionMsg = string.Format("Access denied ! User {0} has no access. Contact Site Administrator!",
                            //    System.Security.Principal.WindowsIdentity.GetCurrent().Name);
                            //string exceptionMsg = string.Format("Access denied ! User {0} has no access. Contact Site Administrator!",                                userName);

                            //throw new AuthenticationException(exceptionMsg);
                            //filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                            //{
                            //    controller = "Login",
                            //    action = "LoginProctor",
                            //    //Message = exceptionMsg

                            //}));
                        }
                        else
                        {
                        }
                    }
                }
                //return View();

                base.OnActionExecuting(filterContext);
            }
        }


    }
}