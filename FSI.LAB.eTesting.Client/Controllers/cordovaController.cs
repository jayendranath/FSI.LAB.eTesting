using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FSI.LAB.eTesting.Client.Controllers.Controllers
{
    public class CordovaController : Controller
    {
        const string platformCookieKey = "cdva_platfrm";
        public ActionResult Index()
        {
            var cookie = HttpContext.Request.Cookies[platformCookieKey];
            var platform = "ios";
            if (cookie != null)
            {
                platform = cookie.Value;
            }
            ViewBag.Platform = platform;
            return View();
        }
        public ActionResult setPlatformCookie(string platform)
        {
            if (!string.IsNullOrWhiteSpace(platform))
            {
                HttpContext.Response.SetCookie(new
                HttpCookie(platformCookieKey, platform));
            }
            return RedirectToAction("index");
        }
        public ActionResult testradio()
        {

            return View();
        }
    }
}