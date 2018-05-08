using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSI.LAB.eTesting.Client.Models
{
    public class AssessmentMediaEntity
    {
        public System.Guid MediaId { get; set; }
        public string MediaTitle { get; set; }
        public string MediaData { get; set; }
        public string MediaType { get; set; }
        public string description { get; set; }
    }
}
