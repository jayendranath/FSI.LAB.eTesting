using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSI.LAB.eTesting.Client.Models
{
    public class ExamineeResponseEntity
    {
        public int ExamineeQuestionId { get; set; }
        public int SelectedResponse { get; set; }
        public Nullable<bool> BookMark { get; set; }
        public int StatusId { get; set; }
        public Nullable<System.DateTime> StartTime { get; set; }
        public Nullable<System.DateTime> EndTime { get; set; }
        public string Remarks { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<System.DateTime> LastModifiedDate { get; set; }
        public System.Guid CreatedById { get; set; }
        public Nullable<System.Guid> LastModifiedById { get; set; }
        public string CreatedByIp { get; set; }
        public string LastModifiedByIp { get; set; }
        public int RecordStatusId { get; set; }
    }
}
