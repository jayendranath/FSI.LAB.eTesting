using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace FSI.LAB.eTesting.Hub.Models
{
    public static class GlobalVariables
    {
        //public static string LoginID { get; set; }
        public static string UserType { get; set; }

        public static string APPLICATION_TITLE = ConfigurationManager.AppSettings.Get("ApplicationTitle");
        public static string APPLICATION_VERSION = ConfigurationManager.AppSettings.Get("ApplicationVersion");
        public static string APPLICATION_URL = ConfigurationManager.AppSettings.Get("ApplicationUrl");
        public static string SITE_ROOT = ConfigurationManager.AppSettings.Get("SiteRoot");
        public static string ERROR_LOG_FILENAME = ConfigurationManager.AppSettings.Get("ErrorLogFileName");
        public static string SMS_DATA_FILENAME = ConfigurationManager.AppSettings.Get("SMSDataFileName");
        public static string COPY_RIGHT = ConfigurationManager.AppSettings.Get("CopyRight");


        //Database
        public static string CONNECTION_NAME = "name=eTestingConnection";
        public static string CONNECTION_STRING = ConfigurationManager.ConnectionStrings["eTestingConnection"].ConnectionString;
        public static string SIGNALR_CONNECTION_STRING = ConfigurationManager.ConnectionStrings["eLearningSignalRConnection"].ConnectionString;
        public static string FSILAB_CONNECTION_STRING = ConfigurationManager.ConnectionStrings["FSILABConnection"].ConnectionString;

        public static string LoginID;
        public static string ProctorID;

        //Global Level
        public const string NO_DATA_FOUND = "No Data Found";

        #region enum


        public enum RecordStatus
        {
            Active = 1,
            Inactive = 2,
            Delete = 0,
            Hide = 5
        }

        public enum Roles
        {
            Administrator = 1,
            Proctor = 2,
            Instructor = 3,
            Examinee = 4
        }

        #endregion

        #region Event Log Type

        public enum EventLogType


        {
            LOGGED_IN = 10,
            LOGGED_OUT = 15,
            USER_ADD = 100,
            USER_UPDATE = 105,
            USER_DELETE = 110,
            ROLE_ADD = 130,
            ROLE_UPDATE = 135,
            ROLE_DELETE = 140,
            EXAM_SCHEDULE_ADD = 145,
            EXAM_SCHEDULE_UPDATE = 150,
            EXAM_SCHEDULE_DELETE = 155
        }
        //DoEvent.add
        #endregion

        #region Status
        public enum StatusFor
        {
            EXAMSCHEDULE,
            EXAMSESSION,
            EXAMINEESESSION,
            EXAMPROCTORSESSION
        }

        public enum ExamScheduleType
        {
            NotStarted = 0,
            InProgress = 1,
            InReview = 2,
            Completed = 3,
            Cancelled = 4,
            Terminated = 5
        }

        public enum ExamineeSessionType
        {
            InProgress = 1,
            Paused = 2,
            Completed = 3,
            Cancelled = 4,
            Terminated = 5,
            Deleted = 6
        }

        public enum ExamSessionType
        {
            InProgress = 1,
            Paused = 2,
            Completed = 3,
            Cancelled = 4,
            Terminated = 5
        }
        public enum SesssionType
        {
            ExamSession = 1,
            ReviewSession = 2
        }


        #endregion
    }
}