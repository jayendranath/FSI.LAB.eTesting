using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FSI.LAB.eTesting.Client.Models
{
    public class GlobalVariables
    {
        public string LoginID { get; set; }
        public int ExamineeType { get; set; }
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