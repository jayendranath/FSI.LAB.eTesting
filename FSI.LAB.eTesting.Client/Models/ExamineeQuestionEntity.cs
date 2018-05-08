using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSI.LAB.eTesting.Client.Models
{
    public class ExamineeQuestionEntity : ExamineeResponseEntity
    {
        public int ExamineeSessionId { get; set; }
        public System.Guid LABQuestionId { get; set; }
        public long LABQuestionNumber { get; set; }
        public string LABQuestionText { get; set; }
        public string AdjResponse1 { get; set; }
        public string AdjResponse2 { get; set; }
        public string AdjResponse3 { get; set; }
        public string AdjResponse4 { get; set; }
        public string AdjResponse5 { get; set; }
        public int CorrectResponse { get; set; }
        public Nullable<System.Guid> LABMediaId { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<System.DateTime> LastModifiedDate { get; set; }
        public System.Guid CreatedById { get; set; }
        public Nullable<System.Guid> LastModifiedById { get; set; }
        public string CreatedByIp { get; set; }
        public string LastModifiedByIp { get; set; }
        public int RecordStatusId { get; set; }

        public int ExamSessionId { get; set; }
        public int ExamScheduleId { get; set; }

        public string SectionId { get; set; }
        public string Sectiontitle { get; set; }
        public Nullable<System.Guid> SubjectId { get; set; }
        public string SubjectTitle { get; set; }
        public string SubjectSystem { get; set; }
        public string MediaTitle { get; set; }
        public byte[] MediaData { get; set; }
        public string MediaType { get; set; }
        public string description { get; set; }
        public string Duration { get; set; }
        public AssessmentMediaEntity AssessmentMediaEntity { get; set; }
    }
}
