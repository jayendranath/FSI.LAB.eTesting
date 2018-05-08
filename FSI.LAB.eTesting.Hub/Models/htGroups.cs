using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FSI.LAB.eTesting.Hub.Models
{
    public class ExamGroup
    {
        #region data members
        public string GroupName { get; set; }
        public int status { get; set; }
        public Hashtable htUsers_ConIds = new Hashtable(50);
        public string proctorName { get; set; }
        #endregion data members


        public ExamGroup(string name, string proctorName, int status)
        {
            GroupName = name;
            this.proctorName = proctorName;
            this.status = status;
        }

        public void AddMember(string name, string connectionID)
        {
            htUsers_ConIds[name.ToLower()] = connectionID;
        }

        public bool IsExamineeInGroup(string examinee)
        {
            if (htUsers_ConIds[examinee] != null) return true;
            return false;
        }

        public string GetExamineeConnection(string examineeName)
        {
                return htUsers_ConIds[examineeName.ToLower()].ToString();
        }

        internal string GetExamineeStatus(string examineeName)
        {
            if (htUsers_ConIds[examineeName] != null)
                return 1 + "|" + htUsers_ConIds[examineeName];
            return 0 + "|" + 0;
        }

        public void RemoveMember(string examineeName)
        {
            var conId = (string) null;
            if ( (conId = (string) htUsers_ConIds[examineeName] ) != null)
            {
                htUsers_ConIds.Remove(conId);
            }
        }
    }
}