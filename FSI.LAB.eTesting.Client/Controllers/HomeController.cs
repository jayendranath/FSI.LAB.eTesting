//using FSI.LAB.eTesting.Client.Models;
//using FSI.LAB.eTesting.Entities;
//using FSI.LAB.eTesting.Services;
//using FSI.LAB.eTesting.Entities;
//using FSI.LAB.eTesting.Services;
using FSI.LAB.eTesting.Client.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Xml;
using System.Web.UI;

namespace FSI.LAB.eTesting.Client.Controllers
{
    public class HomeController : Controller
    {
        GlobalVariables gv = new GlobalVariables();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AnotherLink()
        {
            return View("Index");
        }
        public ActionResult Examinee(string eid)
        {
            //return File(Server.MapPath("~/ProctorPOC/Proctor.html"), "text/html");
            ViewBag.LoginID = System.Web.HttpContext.Current.Session["LoginId"].ToString();
            string IP = Request.UserHostName;
            string compName = DetermineCompName(IP);
            ViewData["IP"] = IP;
            ViewData["compName"] = compName;
            ViewData["eid"] = eid;
            return View();
        }

        public ActionResult MessageList()
        {
            return View();
        }
        public static string DetermineCompName(string IP)
        {

            try
            {
                IPAddress myIP = IPAddress.Parse(IP);
                IPHostEntry GetIPHost = Dns.GetHostEntry(myIP);
                string[] compName = GetIPHost.HostName.ToString().Split('.');
                return compName[0];
            }
            catch (Exception)
            {

                return "jay";
            }
        }

        public ActionResult ExamReview(string exID)
        {
            return View();
        }
        

        public object GetAssessmentQuestion(int QNo, string ExamScheduleID)
        {
            string responseStatus = "";
            List<ExamineeQuestionEntity> AQE = null; ;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["webAPIURL"]);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("api/examinee/" + System.Web.HttpContext.Current.Session["LoginGuid"] + "/" + ExamScheduleID + "/examResults").Result;

            if (!response.IsSuccessStatusCode)
            {
                responseStatus = "Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase;
            }
            else
            {
                var users = response.Content.ReadAsStringAsync().Result;
                JavaScriptSerializer js = new JavaScriptSerializer();

                AQE = js.Deserialize<List<ExamineeQuestionEntity>>(users);
            }
            //ExamService ES = new ExamService();
            //List<Entities.AssessmentQuestionEntity> AQE = ES.GetAssessmentQuestions(AssessmentName.AsGuid());
            if (AQE.Count > 0)
                return Json(AQE[QNo], JsonRequestBehavior.AllowGet);
            else
                return null;
                //return null;
        }



        public ActionResult ExamScreen(string ExamScheduleID, string ProctorID, string ExamScheduletitle, string eid, string clientId, string proctorGuid)
        {
            List<QChoice> choiceList = new List<QChoice>();
            try
            {
                string responseStatus = "";
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["webAPIURL"]);
                //client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["clientURL"].ToString());

                // Add an Accept header for JSON format.
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync("api/examinee/" + System.Web.HttpContext.Current.Session["LoginGuid"] + "/" + ExamScheduleID + "/examResults").Result;

                if (!response.IsSuccessStatusCode)
                {
                    responseStatus = "Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase;
                }
                else
                {
                    var users = response.Content.ReadAsStringAsync().Result;
                    JavaScriptSerializer js = new JavaScriptSerializer();

                    List<ExamineeQuestionEntity> AQE = js.Deserialize<List<ExamineeQuestionEntity>>(users);

                    int[] lstQN = new int[AQE.Count];
                    string ansQuestions = "";
                    string BMQuestions = "";
                    for (int i = 0; i < AQE.Count; i++)
                    {
                        //lstQN[i] = (AQE[i].QuestionNumber);
                        choiceList.Add(new QChoice() { SNo = i, Text = AQE[i].LABQuestionNumber.ToString(), QAns = false });
                        if (AQE[i].SelectedResponse > 0)
                            ansQuestions += AQE[i].ExamineeQuestionId + ":" + AQE[i].SelectedResponse + "|";
                        if (AQE[i].BookMark == true)
                            BMQuestions += AQE[i].ExamineeQuestionId + "|";
                    }

                    if (AQE.Count > 0)
                    {
                        ViewBag.ExamScheduletitle = ExamScheduletitle;
                        ViewData["AssessmentDataCount"] = AQE.Count;
                        ViewBag.Duration = AQE[0].Duration;
                        ViewBag.ExamineeSessionId = AQE[0].ExamineeSessionId;
                    }
                    else
                    {
                        ViewBag.ExamScheduletitle = "";
                        ViewData["AssessmentDataCount"] = 0;
                        ViewBag.Duration = 0;
                    }
                    ViewData["AssessmentData"] = AQE;
                    ViewBag.LoginID = System.Web.HttpContext.Current.Session["LoginId"].ToString();
                    ViewBag.ProctorID = ProctorID;
                    ViewBag.ClientID = clientId;
                    ViewBag.ProctorGuid = proctorGuid;
                    ViewBag.eid = eid;
                    ViewBag.sessionid = ExamScheduleID;
                    ViewBag.AnsweredQuestions = AQE.FindAll(f => f.SelectedResponse > 0);
                    ViewBag.ansQtns = ansQuestions;
                    ViewBag.BMQtns = BMQuestions;
                    //ViewBag.ExamineeType = ExamineeType;
                }
            }
            catch (Exception e)
            {
            }


            return View(choiceList);
            //return View();
        }
        public ActionResult LoginExaminee()
        {
            return View();
        }

        public void setUserID(string stuid, string stuname, string stuguid)
        {
            System.Web.HttpContext.Current.Session["LoginId"] = stuid;
            System.Web.HttpContext.Current.Session["LoginName"] = stuname;
            System.Web.HttpContext.Current.Session["LoginGuid"] = stuguid;
        }


    }
}