using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FSI.LAB.eTesting.Hub.Models
{
    public class Assessment
    {
        public string AssessmentID { get; set; }
        public string Title { get; set; }
        public string Course { get; set; }
        public int Duration { get; set; }
        public string Schedule { get; set; }
        public string CourseType { get; set; }
        public string Version { get; set; }
        public string GeneratedBy { get; set; }
        public int NoOfQuestion { get; set; }
        public string Instructions { get; set; }
        public string ScheduledDate { get; set; }
    }
}