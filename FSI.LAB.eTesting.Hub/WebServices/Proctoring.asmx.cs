//using FSI.LAB.eTesting.Hub.Models;
//using FSI.LAB.eTesting.Services;
using FSI.LAB.eTesting.Hub.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;


namespace FSI.LAB.eTesting.Hub.WebServices
{
    /// <summary>
    /// Summary description for Proctoring
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Proctoring : System.Web.Services.WebService
    {

        [WebMethod]
        public void GetAssessments()
        {
            //List<Assessment> listAssessment = new List<Assessment>();
            ////string cs = ConfigurationManager.ConnectionStrings["testing"].ConnectionString;
            //using (SqlConnection con = new SqlConnection(GlobalVariables.CONNECTION_STRING))
            //{
            //    SqlCommand cmd = new SqlCommand("select * from Assessment_vw", con);
            //    con.Open();
            //    SqlDataReader rdr = cmd.ExecuteReader();
            //    while (rdr.Read())
            //    {
            //        Assessment assessment = new Assessment();
            //        assessment.AssessmentID = rdr["AssessmentID"].ToString();
            //        assessment.Title = rdr["AssessmentTitle"].ToString();
            //        listAssessment.Add(assessment);
            //    }
            //}
            //JavaScriptSerializer js = new JavaScriptSerializer();
            //Context.Response.Write(js.Serialize(listAssessment));
        }

        [WebMethod]
        public void GetExamineesForSelectedAssessment(string assessmentid)
        {
            //List<Examinee> listexaminee = new List<Examinee>();
            ////string cs = ConfigurationManager.ConnectionStrings["testing"].ConnectionString;
            //using (SqlConnection con = new SqlConnection(GlobalVariables.CONNECTION_STRING))
            //{
            //    SqlCommand cmd = new SqlCommand("SELECT  distinct EX.ExamineeId ,USREX.PNumber AS ExamineePNumber,USREX.FirstName + ' '+USREX.LastName  AS ExamineeUserName " +
            //                            "FROM Examinee EX LEFT OUTER JOIN  " +
            //                            "ExamSchedule ES ON  ES.ScheduleId=EX.ScheduleId LEFT OUTER JOIN " +
            //                            "[User] USREX ON EX.ExamineeId=USREX.UserId  INNER JOIN  " +
            //                            "Assessment_vw AM ON ES.AssessmentId= AM.AssessmentId INNER JOIN " +
            //                            "Centers C ON ES.LearningCenterId=C.CenterID INNER JOIN  " +
            //                            "[User] USR ON ES.ProctorUserId=USR.UserId WHERE ES.RecordStatusId=1 and AM.AssessmentId = '" + assessmentid + "'", con);
            //    con.Open();
            //    SqlDataReader rdr = cmd.ExecuteReader();
                
            //    while (rdr.Read())
            //    {
            //        Examinee examinee = new Examinee();
            //        examinee.ExamineeID = rdr["ExamineeID"].ToString();
            //        examinee.Name = rdr["ExamineeUserName"].ToString();
            //        //examinee.Password = rdr["Password"].ToString();
            //        //examinee.LastName = rdr["LastName"].ToString();
            //        examinee.LoginID = rdr["ExamineePNumber"].ToString();
            //        listexaminee.Add(examinee);
                    
            //    }
            //}

            //JavaScriptSerializer js = new JavaScriptSerializer();
            //Context.Response.Write(js.Serialize(listexaminee));
        }

        [WebMethod]
        public void ValidateExamniee(string examinee)
        {
            //object count = 0;
            //List<Assessment> listAssessment = new List<Assessment>();
            ////string cs = ConfigurationManager.ConnectionStrings["testing"].ConnectionString;
            //using (SqlConnection con = new SqlConnection(GlobalVariables.CONNECTION_STRING))
            //{
            //    //SqlCommand cmd = new SqlCommand("select count(*) from tblExaminee where Name = '" + examinee + "'", con);
            //    //con.Open();
            //    //count = cmd.ExecuteScalar();

            //    //if (Convert.ToInt32(count) > 0)
            //    //{
            //    SqlCommand cmd = new SqlCommand("SELECT distinct EX.ExamineeId ,USREX.PNumber AS ExamineePNumber,USREX.FirstName + ' '+USREX.LastName +' ['+USREX.PNumber+']'  AS ExamineeUserName, " +
            //                    "ES.AssessmentId,ES.ScheduleDate,ES.Duration,AM.AssessmentTitle,USR.FirstName + ' '+USR.LastName +' ['+USR.PNumber+']'  AS ProctorUserName, ES.Course " +
            //                    "FROM Examinee EX LEFT OUTER JOIN  " +
            //                    "ExamSchedule ES ON  ES.ScheduleId=EX.ScheduleId LEFT OUTER JOIN " +
            //                    "[User] USREX ON EX.ExamineeId=USREX.UserId  INNER JOIN  " +
            //                    "Assessment_Vw AM ON ES.AssessmentId=AM.AssessmentId INNER JOIN " +
            //                    "Centers C ON ES.LearningCenterId=C.CenterID INNER JOIN  " +
            //                    "[User] USR ON ES.ProctorUserId=USR.UserId WHERE ES.RecordStatusId=1 and USREX.PNumber='" + examinee + "' order by ES.ScheduleDate asc", con);
            //    con.Open();
            //    SqlDataReader rdr = cmd.ExecuteReader();
            //    while (rdr.Read())
            //    {
            //        Assessment assessment = new Assessment();
            //        assessment.AssessmentID = rdr["AssessmentID"].ToString();
            //        assessment.Title = rdr["AssessmentTitle"].ToString();
            //        assessment.Duration = Convert.ToInt32(rdr["Duration"]);
            //        assessment.Course = rdr["Course"].ToString();
            //        if (assessment.Title.IndexOf("MX-")>=0)
            //            assessment.CourseType = "Maintenance";
            //        else
            //            assessment.CourseType = "Pilot";

            //        assessment.ScheduledDate = rdr["ScheduleDate"].AsString()  + " CST" ;
            //        assessment.Version = "2";
            //        assessment.GeneratedBy = rdr["ProctorUserName"].AsString();
            //        assessment.NoOfQuestion = 50;
            //        assessment.Instructions = "";
            //        listAssessment.Add(assessment);
            //    }
            //    //}
            //}
            //JavaScriptSerializer js = new JavaScriptSerializer();
            ////if (Convert.ToInt32(count) > 0)
            //Context.Response.Write(js.Serialize(listAssessment));
            //else
            //Context.Response.Write(Convert.ToInt32(count));
        }


        //validateUser
        [WebMethod]
        public void validateUser(string stid)
        {
            //object count = 0;
            ////List<User> lstUser = new List<User>();
            //User usr = new User();

            ////string cs = ConfigurationManager.ConnectionStrings["testing"].ConnectionString;
            //using (SqlConnection con = new SqlConnection(GlobalVariables.CONNECTION_STRING))
            //{
            //    SqlCommand cmd = new SqlCommand("SELECT USR.UserId,USR.PNumber,USR.FirstName,USR.LastName," +
            //                                        "USR.EmailId,USR.Phone,USR.Mobile,UROLE.RoleId" +
            //                                        " FROM [User] USR INNER JOIN" +
            //                                        " UserRole UROLE  ON USR.UserId=UROLE.UserId INNER JOIN" +
            //                                        " [Role] RL ON UROLE.RoleId=RL.RoleId WHERE USR.PNumber='" + stid + "'", con);
            //    con.Open();

            //    SqlDataReader rdr = cmd.ExecuteReader();
            //    if (rdr.Read())
            //    {
            //        usr.UserId = rdr["UserId"].AsGuid();
            //        usr.PNumber = rdr["PNumber"].AsString();
            //        usr.FirstName = rdr["FirstName"].AsString(); ;
            //        usr.LastName = rdr["LastName"].AsString();
            //        usr.EmailId = rdr["EmailId"].AsString();
            //        usr.Phone = rdr["Phone"].AsString();
            //        usr.Mobile = rdr["Mobile"].AsString();
            //        usr.RoleId = rdr["RoleId"].AsInt();
            //        //usr.Role = rdr["Role"].ToString();
            //        //lstUser.Add(usr);

            //        if (GlobalVariables.LoginID == null || GlobalVariables.LoginID == "")
            //        {

            //            EventService _service = new EventService();
            //            _service.AddEventLog(usr.PNumber, System.Web.HttpContext.Current.Session.SessionID.AsString(), usr.UserId, GlobalVariables.EventLogType.LOGGED_IN.GetHashCode(), string.Empty);
            //        }
            //        GlobalVariables.LoginID = usr.PNumber;
            //        if (usr.RoleId == Convert.ToInt16(GlobalVariables.Roles.Proctor))
            //            GlobalVariables.ProctorID = usr.PNumber;
            //    }
            //}
            //JavaScriptSerializer js = new JavaScriptSerializer();
            //if (Convert.ToInt32(count) > 0)
            //Context.Response.Write(js.Serialize(usr));
            //else
            //Context.Response.Write(Convert.ToInt32(count));
        }
        [WebMethod]
        public void validateProctorLogin(string stid)
        {
            //object count = 0;
            ////List<User> lstUser = new List<User>();
            //User usr = new User();

            ////string cs = ConfigurationManager.ConnectionStrings["testing"].ConnectionString;
            //using (SqlConnection con = new SqlConnection(GlobalVariables.CONNECTION_STRING))
            //{
            //    SqlCommand cmd = new SqlCommand("SELECT USR.UserId,USR.PNumber,USR.FirstName,USR.LastName," +
            //                                        "USR.EmailId,USR.Phone,USR.Mobile,UROLE.RoleId" +
            //                                        " FROM [User] USR INNER JOIN" +
            //                                        " UserRole UROLE  ON USR.UserId=UROLE.UserId INNER JOIN" +
            //                                        " [Role] RL ON UROLE.RoleId=RL.RoleId WHERE USR.PNumber='" + stid + "'", con);
            //    con.Open();

            //    SqlDataReader rdr = cmd.ExecuteReader();
            //    if (rdr.Read())
            //    {
            //        usr.UserId = rdr["UserId"].AsGuid();
            //        usr.PNumber = rdr["PNumber"].AsString();
            //        usr.FirstName = rdr["FirstName"].AsString(); ;
            //        usr.LastName = rdr["LastName"].AsString();
            //        usr.EmailId = rdr["EmailId"].AsString();
            //        usr.Phone = rdr["Phone"].AsString();
            //        usr.Mobile = rdr["Mobile"].AsString();
            //        usr.RoleId = rdr["RoleId"].AsInt();
            //        //usr.Role = rdr["Role"].ToString();
            //        //lstUser.Add(usr);


            //        GlobalVariables.LoginID = usr.PNumber;
            //        if (usr.RoleId == Convert.ToInt16(GlobalVariables.Roles.Proctor))
            //            GlobalVariables.ProctorID = usr.PNumber;
            //    }
            //}
            //JavaScriptSerializer js = new JavaScriptSerializer();
            ////if (Convert.ToInt32(count) > 0)
            //Context.Response.Write(js.Serialize(usr));
            //else
            //Context.Response.Write(Convert.ToInt32(count));
        }
        
        //get all users
        [WebMethod]
        public void GetAllUsers()
        {
            //List<Examinee> listexaminee = new List<Examinee>();
            ////string cs = ConfigurationManager.ConnectionStrings["testing"].ConnectionString;
            //using (SqlConnection con = new SqlConnection(GlobalVariables.CONNECTION_STRING))
            //{
            //    SqlCommand cmd = new SqlCommand("SELECT  FirstName + ' '+ LastName  AS ExamineeUserName, pnumber, userid from [User]", con);
            //    con.Open();
            //    SqlDataReader rdr = cmd.ExecuteReader();

            //    while (rdr.Read())
            //    {
            //        Examinee examinee = new Examinee();
            //        examinee.ExamineeID = rdr["userid"].ToString();
            //        examinee.Name = rdr["ExamineeUserName"].ToString();
            //        //examinee.Password = rdr["Password"].ToString();
            //        //examinee.LastName = rdr["LastName"].ToString();
            //        examinee.LoginID = rdr["pnumber"].ToString();
            //        listexaminee.Add(examinee);

            //    }
            //}

            //JavaScriptSerializer js = new JavaScriptSerializer();
            //Context.Response.Write(js.Serialize(listexaminee));
        }

        //validateUser
        [WebMethod]
        public void validateExamineeLogin(string stid)
        {
            //object count = 0;
            ////List<User> lstUser = new List<User>();
            //User usr = new User();

            ////string cs = ConfigurationManager.ConnectionStrings["testing"].ConnectionString;
            //using (SqlConnection con = new SqlConnection(GlobalVariables.CONNECTION_STRING))
            //{
            //    SqlCommand cmd = new SqlCommand("SELECT USR.UserId,USR.PNumber,USR.FirstName,USR.LastName," +
            //                                        "USR.EmailId,USR.Phone,USR.Mobile,UROLE.RoleId" +
            //                                        " FROM [User] USR INNER JOIN" +
            //                                        " UserRole UROLE  ON USR.UserId=UROLE.UserId INNER JOIN" +
            //                                        " [Role] RL ON UROLE.RoleId=RL.RoleId WHERE USR.PNumber='" + stid + "'", con);
            //    con.Open();

            //    SqlDataReader rdr = cmd.ExecuteReader();
            //    if (rdr.Read())
            //    {
            //        usr.UserId = rdr["UserId"].AsGuid();
            //        usr.PNumber = rdr["PNumber"].AsString();
            //        usr.FirstName = rdr["FirstName"].AsString(); ;
            //        usr.LastName = rdr["LastName"].AsString();
            //        usr.EmailId = rdr["EmailId"].AsString();
            //        usr.Phone = rdr["Phone"].AsString();
            //        usr.Mobile = rdr["Mobile"].AsString();
            //        usr.RoleId = rdr["RoleId"].AsInt();
            //        //usr.Role = rdr["Role"].ToString();
            //        //lstUser.Add(usr);


            //        GlobalVariables.LoginID = usr.PNumber;
            //        if (usr.RoleId == Convert.ToInt16( GlobalVariables.Roles.Proctor))
            //            GlobalVariables.ProctorID = usr.PNumber;
            //    }
            //}
            //JavaScriptSerializer js = new JavaScriptSerializer();
            ////if (Convert.ToInt32(count) > 0)
            //Context.Response.Write(js.Serialize(usr));
            ////else
            ////Context.Response.Write(Convert.ToInt32(count));
        }

        [WebMethod]
        public int GetExamineeStatus(string ExamineeName)
        {
            int status = -1;
            object obj;
            try
            {
                obj = ((ExamGroup)((List<ExamGroup>)LabExamHub.examGroups).FirstOrDefault(o => o.GroupName == ExamineeName));
                
                if (obj != null)
                    status = ((ExamGroup)(obj)).status;
            }
            catch (Exception)
            {

                //throw;
            }
            finally
            {
                
            }
            //if ()
            //    status = 1;
            return status;
        }

        [WebMethod]
        public void GetExamSchedules()
        {
            //CommonService commonService = new CommonService();
            //List<ExamSchedule> listExamSchedules = new List<ExamSchedule>();
            //List<ExamScheduleBO> listExamScheduleBOs = new List<ExamScheduleBO>();
            //List<ExamineeBO> listExamineeBOs = new List<ExamineeBO>();

            //listExamScheduleBOs = commonService.GetExamSchedules();
            //foreach (ExamScheduleBO examScheduleBO in listExamScheduleBOs)
            //{
            //    ExamSchedule examSchedule = new ExamSchedule();
            //    examSchedule.ScheduleId = examScheduleBO.ScheduleId;
            //    //examSchedule.Class = examScheduleBO.Class;
            //    examSchedule.Title = examScheduleBO.Title;
            //    examSchedule.AssessmentId = examScheduleBO.AssessmentId;
            //    examSchedule.AssessmentTitle = examScheduleBO.AssessmentTitle;
            //    examSchedule.ScheduleDate = examScheduleBO.ScheduleDate;
            //    examSchedule.Duration = examScheduleBO.Duration;
            //    examSchedule.LearningCenterId = examScheduleBO.LearningCenterId;
            //    examSchedule.RoomNumber = examScheduleBO.RoomNumber;
            //    examSchedule.ProctorUserId = examScheduleBO.ProctorUserId;
            //    examSchedule.AssignmentAlgo = examScheduleBO.AssignmentAlgo;
            //    examSchedule.ProgramId = examScheduleBO.ProgramId;
            //    examSchedule.ProgramTitle = examScheduleBO.ProgramTitle;
            //    examSchedule.CenterName = examScheduleBO.CenterName;
            //    examSchedule.ProctorPNumber = examScheduleBO.ProctorPNumber;
            //    examSchedule.ProctorUserName = examScheduleBO.ProctorUserName;
            //    listExamSchedules.Add(examSchedule);
            //}
            //JavaScriptSerializer js = new JavaScriptSerializer();
            //Context.Response.Write(js.Serialize(listExamSchedules));
        }

        [WebMethod]
        public string GetImageData(string assessmentid, string mediaId)
        {

            string base64 = ""; int errNumber = 0;
            //IExamService examService = new ExamService();
            //System.Guid temassessmentid = assessmentid.AsGuid();
            //System.Guid tempmediaid = mediaId.AsGuid();
            //base64 = examService.GetAssessmentMediaImageData(temassessmentid, tempmediaid);
            //using (SqlConnection con = new SqlConnection(GlobalVariables.CONNECTION_STRING))
            //{
            //    try
            //    {
            //        SqlCommand sqlCmd = new SqlCommand("getAssessmentQuestionMedia", con);
            //        sqlCmd.CommandType = CommandType.StoredProcedure;

            //        sqlCmd.Parameters.Add("@assessmentId", SqlDbType.VarChar).Value = assessmentid;
            //        sqlCmd.Parameters.Add("@mediaId", SqlDbType.VarChar).Value = mediaId;
            //        sqlCmd.Parameters.Add("@errNumber", SqlDbType.Int).Value = errNumber;

            //        con.Open();
            //        SqlDataReader sqlReader = sqlCmd.ExecuteReader();
            //        if (sqlReader.Read())
            //        {
            //            long iSize = sqlReader.GetBytes(2, 0, null, 0, 0);
            //            byte[] byaMedia = new byte[iSize];
            //            if (sqlReader.GetBytes(2, 0, byaMedia, 0, (int)iSize) != iSize) throw new Exception("cMedia.Get(): SQL data reader returned fewer bytes than expected");
            //            if (mediaType=="PNG")
            //                base64 = Convert.ToBase64String(byaMedia);
            //            else
            //            {
            //                UTF8Encoding utf8 = new UTF8Encoding();
            //                base64 = utf8.GetString(byaMedia);
            //            }
            //        }
            //    }
            //    catch (Exception)
            //    {

            //        throw;
            //    }
            //}
            return base64;
        }

        //[WebMethod]
        //public string GetImageData(string assessmentid, string mediaId)
        //{
        //    System.Guid tempassessmentid = assessmentid.AsGuid();
        //    System.Guid tempmediaId = mediaId.AsGuid();
        //    string base64 = ""; int errNumber = 0;
        //    using (SqlConnection con = new SqlConnection(GlobalVariables.CONNECTION_STRING))
        //    {
        //        try
        //        {
        //            SqlParameter[] arrParams = new SqlParameter[3];
        //            arrParams[0] = new SqlParameter("@assessmentId", tempassessmentid);
        //            arrParams[1] = new SqlParameter("@mediaId", tempmediaId);
        //            arrParams[2] = new SqlParameter("@errNumber", errNumber);
        //            arrParams[2].Direction = System.Data.ParameterDirection.InputOutput;
        //            SqlCommand sqlCmd = new SqlCommand();
        //            sqlCmd.Connection = con;
        //            sqlCmd.CommandTimeout = 1600;
        //            sqlCmd.CommandText = "getAssessmentQuestionMedia";
        //            sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
        //            sqlCmd.Parameters.AddRange(arrParams);

        //            con.Open();
        //            SqlDataReader sqlReader = sqlCmd.ExecuteReader();
        //            if (sqlReader.Read())
        //            {
        //                long iSize = sqlReader.GetBytes(2, 0, null, 0, 0);
        //                byte[] byaMedia = new byte[iSize];
        //                if (sqlReader.GetBytes(2, 0, byaMedia, 0, (int)iSize) != iSize) throw new Exception("cMedia.Get(): SQL data reader returned fewer bytes than expected");
        //                base64 = Convert.ToBase64String(byaMedia);
        //            }
        //        }
        //        catch (Exception)
        //        {

        //            throw;
        //        }
        //    }
        //    return base64;
        //}

        [WebMethod]
        public void GetExamScheduleDetailsById(int scheduleId)
        {
            //CommonService commonService = new CommonService();
            //ExamScheduleBO examScheduleBO = new ExamScheduleBO();
            //ExamSchedule examSchedule = new ExamSchedule();

            //examScheduleBO = commonService.GetExamSchedules().SingleOrDefault(o => o.ScheduleId == scheduleId);
            //if (examScheduleBO != null)
            //{
            //    examSchedule.ScheduleId = examScheduleBO.ScheduleId;
            //    //examSchedule.Class = examScheduleBO.Class;
            //    examSchedule.Title = examScheduleBO.Title;
            //    examSchedule.AssessmentId = examScheduleBO.AssessmentId;
            //    examSchedule.AssessmentTitle = examScheduleBO.AssessmentTitle;
            //    examSchedule.ScheduleDate = examScheduleBO.ScheduleDate;
            //    examSchedule.Duration = examScheduleBO.Duration;
            //    examSchedule.LearningCenterId = examScheduleBO.LearningCenterId;
            //    examSchedule.RoomNumber = examScheduleBO.RoomNumber;
            //    examSchedule.ProctorUserId = examScheduleBO.ProctorUserId;
            //    examSchedule.AssignmentAlgo = examScheduleBO.AssignmentAlgo;
            //    examSchedule.ProgramId = examScheduleBO.ProgramId;
            //    examSchedule.ProgramTitle = examScheduleBO.ProgramTitle;
            //    examSchedule.CenterName = examScheduleBO.CenterName;
            //    examSchedule.ProctorPNumber = examScheduleBO.ProctorPNumber;
            //    examSchedule.ProctorUserName = examScheduleBO.ProctorUserName;
            //}
            //JavaScriptSerializer js = new JavaScriptSerializer();
            //Context.Response.Write(js.Serialize(examSchedule));
        }

        [WebMethod]
        public void GetAssessmentQuestions(string assessmentId)
        {
            //CommonService commonService = new CommonService();
            //List<AssessmentQuestion> listAssessmentQuestions = new List<AssessmentQuestion>();
            //List<AssessmentQuestionBO> listAssessmentQuestionBOs = new List<AssessmentQuestionBO>();

            //listAssessmentQuestionBOs = commonService.GetAssessmentQuestions(assessmentId);
            //foreach (AssessmentQuestionBO assessmentQuestionBO in listAssessmentQuestionBOs)
            //{
            //    AssessmentQuestion assessmentQuestion = new AssessmentQuestion();
            //    assessmentQuestion.Id = assessmentQuestion.Id;
            //    assessmentQuestion.QuestionId = assessmentQuestionBO.QuestionId;
            //    assessmentQuestion.AssessmentId = assessmentQuestionBO.AssessmentId;
            //    assessmentQuestion.AssessmentTitle = assessmentQuestionBO.AssessmentTitle;
            //    assessmentQuestion.ProgramId = assessmentQuestionBO.ProgramId;
            //    assessmentQuestion.ProgramTitle = assessmentQuestionBO.ProgramTitle;
            //    assessmentQuestion.QuestionNumber = assessmentQuestionBO.QuestionNumber;
            //    assessmentQuestion.QuestionText = assessmentQuestionBO.QuestionText;
            //    assessmentQuestion.Response1 = assessmentQuestionBO.Response1;
            //    assessmentQuestion.Response2 = assessmentQuestionBO.Response2;
            //    assessmentQuestion.Response3 = assessmentQuestionBO.Response3;
            //    assessmentQuestion.Response4 = assessmentQuestionBO.Response4;
            //    assessmentQuestion.Response5 = assessmentQuestionBO.Response5;
            //    assessmentQuestion.CorrectResponse = assessmentQuestionBO.CorrectResponse;
            //    assessmentQuestion.Randomize = assessmentQuestionBO.Randomize;
            //    assessmentQuestion.Remarks = assessmentQuestionBO.Remarks;
            //    assessmentQuestion.MediaId = assessmentQuestionBO.MediaId;
            //    listAssessmentQuestions.Add(assessmentQuestion);
            //}
            //JavaScriptSerializer js = new JavaScriptSerializer();
            //Context.Response.Write(js.Serialize(listAssessmentQuestions));
        }
    }
}
