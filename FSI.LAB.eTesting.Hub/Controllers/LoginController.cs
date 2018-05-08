using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FSI.LAB.eTesting.Hub.Models;

namespace FSI.LAB.eTesting.Hub.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        //public ActionResult Index()
        //{
        //    return View();
        //}
        public ActionResult LoginProctor()
        {
            return View();
        }

        public void setUserID(string adPNumber, string adName, string adGuid, string adId, string adRole)
        {
            System.Web.HttpContext.Current.Session["AdLoginPNo"] = adPNumber;
            GlobalVariables.LoginID = adPNumber;
            System.Web.HttpContext.Current.Session["AdLoginName"] = adName;
            System.Web.HttpContext.Current.Session["AdLoginGuid"] = adGuid;
            System.Web.HttpContext.Current.Session["AdLoginId"] = adId;
            System.Web.HttpContext.Current.Session["AdLoginRole"] = adRole;
            if (adRole == "Proctor")
            {
                GlobalVariables.ProctorID = adPNumber;
                System.Web.HttpContext.Current.Session["AdProctorId"] = adRole;

            }
        }
    }
}