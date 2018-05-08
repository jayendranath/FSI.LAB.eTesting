using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSI.LAB.eTesting.Hub.Models
{
    public class ExamUserEntity
    {
        public System.Guid ExamUserId { get; set; }
        public Nullable<int> ExamScheduleId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string EmailId { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> LastModifiedDate { get; set; }
        public System.Guid CreatedById { get; set; }
        public Nullable<System.Guid> LastModifiedById { get; set; }
        public string CreatedByIp { get; set; }
        public string LastModifiedByIp { get; set; }
        public int RecordStatusId { get; set; }
    }
}
