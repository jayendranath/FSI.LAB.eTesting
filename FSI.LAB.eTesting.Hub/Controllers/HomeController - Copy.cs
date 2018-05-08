using FSI.LAB.eTesting.Hub;
using FSI.LAB.eTesting.Hub.Models;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;
using System.Web.Script.Serialization;
//using FSI.LAB.eTesting.Services;
//using FSI.LAB.eTesting.Entities;

namespace FSI.LAB.eTesting.Hub.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AnotherLink()
        {
            return View("Index");
        }

        public ActionResult ProctorConsole(string AssessmentID, string AssessmentName)
        {
            ViewData["Proctorid"] = FSI.LAB.eTesting.Hub.Models.GlobalVariables.LoginID;
            ViewData["AssessmentID"] = AssessmentID;
            ViewData["AssessmentName"] = AssessmentName;
            FSI.LAB.eTesting.Hub.Models.GlobalVariables.UserType = "Proctor";
            return View();
        }

        public ActionResult ExamSchedulers()
        {
            //IMessageService _Service = new MessageService();
            //_Service.AddMessageLog("1234", HttpContext.Session.SessionID.AsString(), "v001", "v002", "text", 1);
            FSI.LAB.eTesting.Hub.Models.GlobalVariables.UserType = "Admin";
            return View();
        }
        public ActionResult MessageBox()
        {
            return View();
        }
        public ActionResult PaperExam()
        {
            FSI.LAB.eTesting.Hub.Models.GlobalVariables.UserType = "Admin";
            return View();
        }
        public ActionResult PaperExamReview()
        {
            FSI.LAB.eTesting.Hub.Models.GlobalVariables.UserType = "Admin";
            return View();
        }
        public ActionResult ExamScheduler(string sid)
        {
            ViewData["sid"] = sid;
            FSI.LAB.eTesting.Hub.Models.GlobalVariables.UserType = "Admin";
            return View();
        }
        public ActionResult Screens()
        {
            FSI.LAB.eTesting.Hub.Models.GlobalVariables.UserType = "Admin";
            return View();
        }
        public ActionResult SupplimentalInfo()
        {
            FSI.LAB.eTesting.Hub.Models.GlobalVariables.UserType = "Admin";
            return View();
        }

        public ActionResult Roles()
        {
            FSI.LAB.eTesting.Hub.Models.GlobalVariables.UserType = "Admin";
            return View();
        }

        public ActionResult Users()
        {
            FSI.LAB.eTesting.Hub.Models.GlobalVariables.UserType = "Admin";
            return View();
        }

        public ActionResult ExamineeCredentials()
        {
            FSI.LAB.eTesting.Hub.Models.GlobalVariables.UserType = "Admin";
            return View();
        }

        public ActionResult ProctorDashboard()
        {
            FSI.LAB.eTesting.Hub.Models.GlobalVariables.UserType = "Proctor";
            return View();
        }
        public ActionResult test(int id)
        {
            ViewData["id"] = id;
            return PartialView();
        }
        public ActionResult ExamReview(string title, string exID, string exname)
        {
            FSI.LAB.eTesting.Hub.Models.GlobalVariables.UserType = "Admin";
            ViewData["extitle"] = title;
            ViewData["exID"] = exID;
            ViewData["exname"] = exname;
            return View();
        }
        public ActionResult ProctorConsolePartial(string AssessmentID, string AssessmentName, string id)
        {
            //return File(Server.MapPath("~/ProctorPOC/Proctor.html"), "text/html");
            FSI.LAB.eTesting.Hub.Models.GlobalVariables.UserType = "Proctor";

            ViewData["Proctorid"] = FSI.LAB.eTesting.Hub.Models.GlobalVariables.LoginID;
            ViewData["AssessmentID"] = AssessmentID;
            ViewData["AssessmentName"] = AssessmentName;
            ViewData["id"] = id;
            return PartialView();
        }

        public ActionResult ProctorReview(string AssessmentID, string AssessmentName)
        {
            //return File(Server.MapPath("~/ProctorPOC/Proctor.html"), "text/html");

            FSI.LAB.eTesting.Hub.Models.GlobalVariables.UserType = "Proctor";
            ViewData["Proctorid"] = FSI.LAB.eTesting.Hub.Models.GlobalVariables.LoginID;
            ViewData["AssessmentID"] = AssessmentID;
            ViewData["AssessmentName"] = AssessmentName;
            return View();
        }
        public ActionResult TestNG()
        {
            //return File(Server.MapPath("~/ProctorPOC/Proctor.html"), "text/html");
            return View();
        }
        public ActionResult Examinee()
        {
            //return File(Server.MapPath("~/ProctorPOC/Proctor.html"), "text/html");
            return View();
        }


        public void UpdateAssessmentStart(string AssessmentName)
        {
            //ChatHub ch;
            List<ExamGroup> htg = new List<ExamGroup>();
            htg = LabExamHub.examGroups;
            htg.Find(o => o.GroupName == AssessmentName).status = 1;
        }

        public int GetAssessmentStatus(string AssessmentName)
        {
            int status = 0;
            status = LabExamHub.examGroups.Find(o => o.GroupName == AssessmentName).status;
            return status;
        }

        public object getEventLogDetails(string scrName, string eventrefid)
        {
            object retVal = "";
            //if (scrName == "ExamSchedule")
            //{
            //    EventService _Service = new EventService();
            //    List<EventLogEntity> eventlist = _Service.GetEventLogs().Where(o => o.EventReferenceId == eventrefid && (o.EventTypeId == GlobalVariables.EventLogType.EXAM_SCHEDULE_ADD.GetHashCode() || o.EventTypeId == GlobalVariables.EventLogType.EXAM_SCHEDULE_UPDATE.GetHashCode())).ToList();
            //    retVal = Json(eventlist, JsonRequestBehavior.AllowGet);
            //}
            //else
            //{
            //    EventService _service = new EventService();
            //    List<Entities.EventLogEntity> evlog = _service.GetEventLogs();
            //    retVal= Json(evlog, JsonRequestBehavior.AllowGet);
            //}
            return retVal;
        }

        /// <summary>
        /// To get examniee status based on the group and examniee names
        /// </summary>
        /// <param name="grpName"></param>
        /// <param name="ExamineeName"></param>
        /// <returns></returns>
        public string GetExamineeStatusCtrl(string ExamineeName, string grpName)
        {
            return LabExamHub.GetExamineeStatus(grpName, ExamineeName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="grpName"></param>
        //public void ProctorDisconnected(string grpName)
        //{
        //    if (!String.IsNullOrEmpty(grpName))
        //    {
        //        var hubContext = GlobalHost.ConnectionManager.GetHubContext<LabExamHub>();
        //        hubContext.Clients.Group(grpName).proctorDisconnected(grpName);
        //    }
        //}
        [HttpGet]
        public ActionResult GetExamSchedules()
        {
            //IExamService examService = new ExamService();
            //var jsonData = examService.GetExamSchedules();
            //return Json(jsonData, JsonRequestBehavior.AllowGet);
            HttpClient client = new HttpClient();
            string responseStatus = "";

            client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["webAPIURL"]);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("api/examschedules").Result;

            if (!response.IsSuccessStatusCode)
            {
                responseStatus = "Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase;
            }
            else
            {
                var jsonData = response.Content.ReadAsStringAsync().Result;
                return Json(jsonData, JsonRequestBehavior.AllowGet);
            }
            return null;
        }

        [HttpGet]
        public JsonResult GetCenters()
        {
            //IExamService examService = new ExamService();
            //var jsonData = examService.GetCenters().Select(o => new { name = o.CenterName + '[' + o.CenterNumber + ']', Id = o.CenterID }).Distinct();
            //return Json(jsonData, JsonRequestBehavior.AllowGet);
            HttpClient client = new HttpClient();
            string responseStatus = "";

            client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["webAPIURL"]);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("api/centers").Result;

            if (!response.IsSuccessStatusCode)
            {
                responseStatus = "Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase;
            }
            else
            {
                var jsonData = response.Content.ReadAsStringAsync().Result;
                return Json(jsonData, JsonRequestBehavior.AllowGet);
            }

            return null;
        }

        [HttpGet]
        public JsonResult GetProgramTitleAutoComplete(string prefix)
        {
            //IAssessmentService assessmentService = new AssessmentService();
            //var jsonData = assessmentService.GetPrograms(prefix).Select(o => new { label = o.ProgramTitle, value = o.ProgramId });
            //return Json(jsonData, JsonRequestBehavior.AllowGet);
            HttpClient client = new HttpClient();
            string responseStatus = "";

            client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["webAPIURL"]);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("api/programs/" + prefix).Result;

            if (!response.IsSuccessStatusCode)
            {
                responseStatus = "Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase;
            }
            else
            {
                var jsonData = response.Content.ReadAsStringAsync().Result;
                return Json(jsonData, JsonRequestBehavior.AllowGet);
            }

            return null;
        }

        [HttpGet]
        public JsonResult GetAssessmentAutoComplete(string prefix, string programId)
        {
            //System.Guid? tempProgramId = programId.AsGuid();
            //IAssessmentService assessmentService = new AssessmentService();
            //var jsonData = assessmentService.GetAssessments(prefix, tempProgramId).Select(o => new { label = o.AssessmentTitle, value = o.AssessmentId });
            //return Json(jsonData, JsonRequestBehavior.AllowGet);
            HttpClient client = new HttpClient();
            string responseStatus = "";

            client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["webAPIURL"]);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("api/assessments/" + prefix + "/" + programId).Result;

            if (!response.IsSuccessStatusCode)
            {
                responseStatus = "Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase;
            }
            else
            {
                var jsonData = response.Content.ReadAsStringAsync().Result;
                return Json(jsonData, JsonRequestBehavior.AllowGet);
            }
            return null;
        }

        [HttpGet]
        public JsonResult GetProctorUserAutoComplete(string prefix)
        {
            //IUserService userService = new UserService();
            //var jsonData = userService.GetUsersByRole(GlobalVariables.Roles.Proctor.GetHashCode()).Where(o => (o.FirstName.StartsWith(prefix) || o.FirstName.StartsWith(prefix.ToUpper()) || o.FirstName.StartsWith(prefix.ToLower()) || o.LastName.StartsWith(prefix) || o.LastName.StartsWith(prefix.ToUpper()) || o.LastName.StartsWith(prefix.ToLower()) || o.PNumber.StartsWith(prefix) || o.PNumber.StartsWith(prefix.ToUpper()) || o.PNumber.StartsWith(prefix.ToLower()))).Select(o => new { label = o.FirstName + ' ' + o.LastName + '[' + o.PNumber + ']', value = o.UserId }).Distinct();
            //return Json(jsonData, JsonRequestBehavior.AllowGet);
            return null;
        }
        [HttpGet]
        public JsonResult GetCourseAutoComplete(string prefix)
        {
            //IExamService examService = new ExamService();
            //var jsonData = examService.GetExamSchedules().Where(o => (o.Course.StartsWith(prefix.ToUpper()) || o.Course.StartsWith(prefix.ToLower()))).Select(o => new { label = o.Course, value = o.ScheduleId + "~" + o.ProgramId + "~" + o.ProgramTitle });
            //return Json(jsonData, JsonRequestBehavior.AllowGet);
            return null;
        }

        // GET: Get Single Exam Schedule
        [HttpGet]
        public JsonResult GetExamScheduleByScheduleId(int id)
        {
            //IExamService examService = new ExamService();
            HttpClient client = new HttpClient();
            string responseStatus = "";
            ExamScheduleEntity AQE = null; ;

            client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["webAPIURL"]);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("api/examschedule/" + id).Result;

            if (!response.IsSuccessStatusCode)
            {
                responseStatus = "Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase;
            }
            else
            {
                var examSchedule = response.Content.ReadAsStringAsync().Result;
                JavaScriptSerializer js = new JavaScriptSerializer();

                AQE = js.Deserialize<ExamScheduleEntity>(examSchedule);
            }

            //examSchedule =GetExamScheduleByScheduleId(id);
            return Json(AQE, JsonRequestBehavior.AllowGet);
            //return null;
        }

        // POST: Save New Customer
        [HttpPost]
        public JsonResult InsertExamSchedule(string model)
        {
            //    IExamService examService = new ExamService();
            //    int result = 0; bool status = true;
            //    try
            //    {
            //        examService.InsertExamSchedule(model);
            //        if (result == 1)
            //        {
            //            status = true;
            //        }
            //        return Json(new { success = status });
            //    }
            //    catch { }
            //    return Json(new
            //    {
            //        success = false,
            //    });
            return null;
        }

        // POST: Save New Customer
        [HttpPost]
        public JsonResult UpdateExamSchedule(string model)
        {
            //IExamService examService = new ExamService();
            //int result = 0; bool status = true;
            //try
            //{
            //    examService.UpdateExamSchedule(model);
            //    if (result == 1)
            //    {
            //        status = true;
            //    }
            //    return Json(new { success = status });
            //}
            //catch { }
            //return Json(new
            //{
            //    success = false,
            //});
            return null;
        }

        // DELETE: Delete Customer
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            //IExamService examService = new ExamService();
            //int result = 0; bool status = true;
            //try
            //{
            //    examService.DeleteExamSchedule(id);
            //    if (result == 1)
            //    {
            //        status = true;
            //    }
            //}
            //catch { }
            //return Json(new
            //{
            //    success = status
            //});
            return null;
        }
    }
}