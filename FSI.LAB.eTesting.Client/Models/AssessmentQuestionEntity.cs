using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSI.LAB.eTesting.Client.Models
{
     public class AssessmentQuestionEntity 
    {
        public System.Guid QuestionId { get; set; }
        public System.Guid AssessmentId { get; set; }
        public Nullable<int> Version { get; set; }
        public int QuestionNumber { get; set; }
        public string QuestionText { get; set; }
        public string Course { get; set; }
        //public string Exam { get; set; }
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
        public System.Guid CreatedById { get; set; }
        public Nullable<System.Guid> LastModifiedById { get; set; }
        public string CreatedByIp { get; set; }
        public string LastModifiedByIp { get; set; }
        public int RecordStatusId { get; set; }

        public string AssessmentTitle { get; set; }
        public System.Guid ProgramId { get; set; }
        public string ProgramTitle { get; set; }

        public string SectionId { get; set; }
        public string Sectiontitle { get; set; }
        public Nullable<System.Guid> SubjectId { get; set; }
        public string SubjectTitle { get; set; }
        public string SubjectSystem { get; set; }

        public string MediaTitle { get; set; }
        public byte[] MediaData { get; set; }
        public string MediaType { get; set; }
        public string description { get; set; }

        public AssessmentMediaEntity AssessmentMediaEntity { get; set; }
    }
}
