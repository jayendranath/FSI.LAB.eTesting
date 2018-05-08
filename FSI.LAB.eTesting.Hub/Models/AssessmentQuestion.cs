using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FSI.LAB.eTesting.Hub.Models
{
    public class AssessmentQuestion
    {
        public int Id { get; set; }
        public System.Guid QuestionId { get; set; }
        public System.Guid AssessmentId { get; set; }
        public string AssessmentTitle { get; set; }
        public System.Guid ProgramId { get; set; }
        public string ProgramTitle { get; set; }
        public int QuestionNumber { get; set; }
        public string QuestionText { get; set; }
        public string Response1 { get; set; }
        public string Response2 { get; set; }
        public string Response3 { get; set; }
        public string Response4 { get; set; }
        public string Response5 { get; set; }
        public int CorrectResponse { get; set; }
        public bool Randomize { get; set; }
        public string Remarks { get; set; }
        public Nullable<System.Guid> MediaId { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<System.DateTime> LastModifiedDate { get; set; }
        public int CreatedById { get; set; }
        public Nullable<int> LastModifiedById { get; set; }
        public string CreatedByIp { get; set; }
        public string LastModifiedByIp { get; set; }
        public int RecordStatusId { get; set; }
    }
}