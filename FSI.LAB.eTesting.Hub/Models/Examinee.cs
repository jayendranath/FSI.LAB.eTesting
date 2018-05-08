using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FSI.LAB.eTesting.Hub.Models
{
    public class Examinee
    {
        public string ExamineeID { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int Id { get; set; }
        public int ScheduleId { get; set; }
        public string ExamineeId { get; set; }
        public string LoginID { get; set; }
        public string LastName { get; set; }
        public string ExamineePNumber { get; set; }
        public string ExamineeName { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<System.DateTime> LastModifiedDate { get; set; }
        public int CreatedById { get; set; }
        public Nullable<int> LastModifiedById { get; set; }
        public string CreatedByIp { get; set; }
        public string LastModifiedByIp { get; set; }
        public int RecordStatusId { get; set; }

        public string ExamineeUserName { get; set; }
        public string ExamineePassword { get; set; }
        public string ExamineeEmailId { get; set; }
    }
}