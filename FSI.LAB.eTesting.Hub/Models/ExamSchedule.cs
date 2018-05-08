using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FSI.LAB.eTesting.Hub.Models
{
    public class ExamScheduleEntity
    {
        public int ExamScheduleId { get; set; }
        public System.Guid AssessmentId { get; set; }
        public string Course { get; set; }
        public Nullable<System.DateTime> ScheduleDate { get; set; }
        public string Duration { get; set; }
        public string PassPercentage { get; set; }
        public int LearningCenterId { get; set; }
        public string RoomNumber { get; set; }
        public Nullable<int> StatusId { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<System.DateTime> LastModifiedDate { get; set; }
        public System.Guid CreatedById { get; set; }
        public Nullable<System.Guid> LastModifiedById { get; set; }
        public string CreatedByIp { get; set; }
        public string LastModifiedByIp { get; set; }
        public int RecordStatusId { get; set; }


        public string AssessmentTitle { get; set; }
        public System.Guid ProgramId { get; set; }
        public string ProgramTitle { get; set; }
        public string CenterName { get; set; }


        //Event log
        public string EventReferenceId { get; set; }
        public string SessionId { get; set; }
        public int EventTypeId { get; set; }
    }
}