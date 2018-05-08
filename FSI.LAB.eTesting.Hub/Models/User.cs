using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FSI.LAB.eTesting.Hub.Models
{
    public class User
    {
        public System.Guid UserId { get; set; }
        public string PNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public int RoleId { get; set; }
        public string Role { get; set; }
    }
}