using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System.Collections;
using System.Threading.Tasks;
using FSI.LAB.eTesting.Hub.Models;
using System.Collections.Concurrent;


namespace FSI.LAB.eTesting.Hub
{
    /// <summary>
    /// LabExamHub manages Exam groups for various exams that are started by a proctor.. 
    /// </summary>
    [HubName("labExamHub")]
    public class LabExamHub : Microsoft.AspNet.SignalR.Hub
    {
        #region Data Member
        public static List<ExamGroup> examGroups = new List<ExamGroup>();
        static readonly object _lock = new object();
        #endregion


        /// <summary>
        /// THis can only be called by a proctor.. 
        /// </summary>
        /// <param name="examName"></param>
        /// <param name="memberName"></param>
        public void CreateExamGroup(string examName, string memberName)
        {
            JoinExamGroup(examName, memberName, "proctor");
        }

        /// <summary>
        /// Called when examniees join an Exam group. Group only created only for the proctor ..
        /// Only after proctor creates an exam group, examinees can join the exam group
        /// </summary>
        /// <param name="grpname"></param>
        /// <param name="memberName"> User identity of the examinee. Basically the login id with which examinee logs into the system</param>
        /// <param name="message"> Not in use yet</param>
        public void JoinExamGroup(string grpname, string memberName, string joinAs)
        {
            // TODO (Sudhakar): make sure the proctor has permissions to proctor the exam.. 
            // list of exams a proctor can see in the proctoring dashboard will be based on permissions, but it may so happen
            //that permissions denied after the drop down list is loaded ??? 

            lock (_lock)
            {
                try
                {
                    ExamGroup htGroup = examGroups.Find(o => o.GroupName == grpname);

                    // The below is based on the below assumption:
                    // 1)Multiple proctors assigned for an exam, so when one proctor is conducting exam other accidentally tried to load it too??
                    // 2) When protors loads other assessment, the group will be ended
                    if (joinAs.Equals("Proctor") && (htGroup != null))
                    {
                        if (htGroup.proctorName != memberName)
                            throw new Exception(memberName);
                    }

                    // Group doesn't exist, since proctor joining creates the group object for tracking Exam group sessions
                    if (joinAs.Equals("Proctor") && (htGroup == null))
                    {
                        htGroup = new ExamGroup(grpname, memberName, 0);
                        examGroups.Add(htGroup);
                        Clients.All.CheckAndAddExaminee(grpname, memberName);
                        // Sudhakar: This is where the exam specific logging needs to be initiated; Basically the log file will be created and
                        // the log header will be written
                    }

                    // If we are here then Examinee must be the one joining group, go ahead and add the examiee to the group 
                    // and also track the examinee in the application?? 
                    //Assert(joinAs.Equals("Examinee"));


                    // add the examinee to the group only if Proctor already started the group. If proctor leaves the group, everyone else should.
                    if (htGroup != null)
                    {
                        Groups.Add(Context.ConnectionId, grpname);
                        htGroup.AddMember(memberName, Context.ConnectionId);
                    }
                   
                }
                catch (Exception ex)
                {
                    throw new HubException("proctor", ex);
                }
            }
        }

        /// <summary>
        /// Removes a memeber (proctor or an examinee) from a group
        /// </summary>
        /// <param name="grpname"></param>
        /// <param name="memberName"></param>
        /// <param name="removeAs"></param>
        public void RemoveFromExamGroup(string memberName, string grpname, string removeAs)
        {
            // If Proctor is the one removed from exam group for some reason, notify all the proctor that examinees in the group and cannot be 
            //removed (if examiness started the exam??).
            lock (_lock)
            {
                ExamGroup group = examGroups.Find(o => o.GroupName == grpname);

                if (group != null)
                {
                    if (removeAs.Equals("Proctor"))
                    {
                        //Notify all users that proctor is diconnected;
                        ProctorDisconnected(grpname);

                        // remove from the signalR group and also the connection cache.
                        Groups.Remove(Context.ConnectionId, grpname);
                        examGroups.Remove(group);
                    }
                    //else
                    //{
                    //    ExamineeDisconnected(memberName);
                    //    examGroups.ForEach(x => { x.RemoveMember(memberName);});
                    //}
                }
                else
                {
                    ExamineeDisconnected(memberName);
                    examGroups.ForEach(x => { x.RemoveMember(memberName); });
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conID"></param>
        /// <param name="Msg"></param>
        public void SendInvidualMsg(string grpname, string conID, string fromID, string Msg)
        {
            ExamGroup examGrp = examGroups.Find(o => o.GroupName == grpname);
            string procid = examGrp.GetExamineeConnection(conID);
            var connectionIds = GetAllConnectionIds(procid).ToList();
            //Clients.Client(procid).broadcastMessage(Msg,fromID);
            Clients.Clients(connectionIds).broadcastMessage(Msg, fromID);
        }

        public void SendGroupMsg(string grpName, string Msg)
        {
            Clients.Group(grpName).broadcastMessage(Msg);
        }
        public void StartIndExam(string conID)
        {
            Clients.Client(conID).StartExam();
        }
        public void StartGrpExam(string grpName, string ProctorId)
        {
            Clients.Group(grpName).StartExam(grpName, ProctorId);
        }

        public void EndGrpExam(string grpName, string ProctorId)
        {
            Clients.Group(grpName).ProctorEndExam(grpName, ProctorId);
        }

        public void ProctorRecievedMsg(string grpname, string fromid)
        {

            ExamGroup examGrp = examGroups.Find(o => o.GroupName == grpname);
            string procid = examGrp.GetExamineeConnection(fromid);
            var connectionIds = GetAllConnectionIds(procid).ToList();
            //Clients.Client(procid).broadcastMessage(Msg,fromID);
            Clients.Clients(connectionIds).ProctorAcknowledge();
        }
        /// <summary>
        /// Display Examinee status when examniee logged in after assessment started 
        /// </summary>
        /// <param name="grpname"></param>
        /// <param name="name"></param>
        public void AddUserAfterExamStarted(string grpname, string name, string ProctorID, string stIP, string stCompName)
        {
            ExamGroup examGrp = examGroups.Find(o => o.GroupName == grpname);
            string procid = examGrp.GetExamineeConnection(ProctorID);
            var connectionIds = GetAllConnectionIds(procid).ToList();
            //Clients.Client(procid).addUserName(Context.ConnectionId, name,stIP,stCompName);
            Clients.Clients(connectionIds).addUserName(Context.ConnectionId, name, stIP, stCompName);
        }

        /// <summary>
        /// Called by examinee sessions when an exam is started.
        /// </summary> Called by client for every exam the user is registered for . 
        /// Load test to see how this behaves when let us say 300 users try to connect.
        /// <param name="examName"> is the name of the exam.. exam name is the exam group name</param>
        public void StartedExam(string examName, string examineeName, string ProctorID)
        {
            lock (_lock)
            {
                ExamGroup examGrp = examGroups.Find(o => o.GroupName == examName);
                if (examGrp == null)
                {
                    // application in invalid state.. Server needs to be shut down if this happens.
                    throw new InvalidOperationException();
                }

                //string id = examGrp.GetExamineeConnection(examineeName);
                string procid = examGrp.GetExamineeConnection(ProctorID);


                /// Send a message to Proctor that the examinees on the connection has started the exam .. 
                var connectionIds = GetAllConnectionIds(procid).ToList();
                //Clients.Client(procid).StartedExamChStatus(id);
                Clients.Clients(connectionIds).StartedExamChStatus(examineeName);
            }
        }

        /// <summary>
        /// Called by examinee sessions when a question was answered.
        /// </summary> Called by client for every question answered. 
        /// <param name="examName"> is the name of the exam.. exam name is the exam group name</param>
        public void callAnsweredQuestionsStatus(string examName, string examineeName, string ProctorID, int AnsQnsCount,int TotalQnsCount)
        {
            lock (_lock)
            {
                ExamGroup examGrp = examGroups.Find(o => o.GroupName == examName);
                if (examGrp == null)
                {
                    // application in invalid state.. Server needs to be shut down if this happens.
                    throw new InvalidOperationException();
                }

                //string id = examGrp.GetExamineeConnection(examineeName);
                string procid = examGrp.GetExamineeConnection(ProctorID);


                /// Send a message to Proctor that the examinees on the connection has started the exam .. 
                var connectionIds = GetAllConnectionIds(procid).ToList();
                //Clients.Client(procid).StartedExamChStatus(id);
                Clients.Clients(connectionIds).updateAnsweredQuestionStatus(examineeName, AnsQnsCount,TotalQnsCount);
            }
        }

        public void PauseExam(string name, string examineeName, string ProctorID)
        {
            lock (_lock)
            {
                ExamGroup examGrp = examGroups.Find(o => o.GroupName == name);
                if (examGrp == null)
                {
                    // application in invalid state.. Server needs to be shut down if this happens.
                    throw new InvalidOperationException();
                }
                    
                string id = examGrp.GetExamineeConnection(examineeName);
                //string procid = examGrp.GetExamineeConnection(ProctorID);


                /// Send a message to Proctor that the examinees on the connection has started the exam .. 
                var connectionIds = GetAllConnectionIds(id).ToList();
                //Clients.Client(procid).PausedExamChStatus(id);
                Clients.Clients(connectionIds).ProctorPausedExam(ProctorID);
            }
        }

        public void IndMisconduct(string name, string examineeName, string ProctorID)
        {
            lock (_lock)
            {
                ExamGroup examGrp = examGroups.Find(o => o.GroupName == name);
                if (examGrp == null)
                {
                    // application in invalid state.. Server needs to be shut down if this happens.
                    throw new InvalidOperationException();
                }

                string id = examGrp.GetExamineeConnection(examineeName);
                //string procid = examGrp.GetExamineeConnection(ProctorID);


                /// Send a message to Proctor that the examinees on the connection has started the exam .. 
                var connectionIds = GetAllConnectionIds(id).ToList();
                //Clients.Client(procid).PausedExamChStatus(id);
                Clients.Clients(connectionIds).ClientMisconduct(ProctorID);
            }
        }

        public void ResumeExam(string ProctorID, string difftime, string examineeName, string name)
        {
            lock (_lock)
            {
                ExamGroup examGrp = examGroups.Find(o => o.GroupName == name);
                if (examGrp == null)
                {
                    // application in invalid state.. Server needs to be shut down if this happens.
                    throw new InvalidOperationException();
                }
                    
                string id = examGrp.GetExamineeConnection(examineeName);
                string procid = examGrp.GetExamineeConnection(ProctorID);


                /// Send a message to Proctor that the examinees on the connection has started the exam .. 
                var connectionIds = GetAllConnectionIds(procid).ToList();
                //Clients.Client(procid).PausedExamChStatus(id);
                Clients.Clients(connectionIds).ResumeExamAtProctor(examineeName,name, difftime);
            }
        }

        public void ProctorGrpReview(string name)
        {
            lock (_lock)
            {
                ExamGroup examGrp = examGroups.Find(o => o.GroupName == name);
                if (examGrp == null)
                {
                    // application in invalid state.. Server needs to be shut down if this happens.
                    throw new InvalidOperationException();
                }

                Clients.Group(name).EnableGrpReview();
            }
        }

        /// <summary>
        /// ////
        /// </summary>
        /// <param name="name"></param>
        /// <param name="examineeName"></param>
        public void EndedExam(string name, string examineeName, string proctorId)
        {
            lock (_lock)
            {
                ExamGroup examGrp = examGroups.Find(o => o.GroupName == name);
                if (examGrp == null)
                {
                    // application in invalid state.. Server needs to be shut down if this happens.
                    throw new InvalidOperationException();
                }

                string id = examGrp.GetExamineeConnection(examineeName);
                string procid = examGrp.GetExamineeConnection(proctorId);


                /// Send a message to Proctor that the examinees on the connection has started the exam .. 
                var connectionIds = GetAllConnectionIds(procid).ToList();
                //Clients.Client(procid).EndedExamChStatus(id);
                Clients.Clients(connectionIds).EndedExamChStatus(examineeName);
            }
        }

        /// <summary>
        /// Permission to proctor to extend exam time.
        /// </summary>
        public void ExtendExambyExaminee(string name, string examineeName, string proctorId)
        {
            lock (_lock)
            {
                ExamGroup examGrp = examGroups.Find(o => o.GroupName == name);
                if (examGrp == null)
                {
                    // application in invalid state.. Server needs to be shut down if this happens.
                    throw new InvalidOperationException();
                }

                string id = examGrp.GetExamineeConnection(examineeName);
                string procid = examGrp.GetExamineeConnection(proctorId);


                /// Send a message to Proctor that the examinees on the connection has started the exam .. 
                var connectionIds = GetAllConnectionIds(procid).ToList();
                //Clients.Client(procid).getConfirmExamExtend(id, Context.ConnectionId);
                Clients.Clients(connectionIds).getConfirmExamExtend(id, Context.ConnectionId);
            }
        }

        /// <summary>
        /// Proctor confirmed examinee request to exten exam
        /// </summary>
        /// <param name="examineeID"></param>
        public void ProctorConformedExtendExam(string name, string examineeID, int extndMinutes)
        {
            lock (_lock)
            {
                ExamGroup examGrp = examGroups.Find(o => o.GroupName == name);
                if (examGrp == null)
                {
                    // application in invalid state.. Server needs to be shut down if this happens.
                    throw new InvalidOperationException();
                }
                /// Send a message to examinee
                string id = examGrp.GetExamineeConnection(examineeID);
                var connectionIds = GetAllConnectionIds(id).ToList();
                //Clients.Client(examineeID).gotConfirmationExamExtend();
                Clients.Clients(connectionIds).gotConfirmationExamExtend(extndMinutes);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="grpname"></param>
        /// <param name="memberName"></param>
        /// <param name="joinAs"></param>
        public void ProctorTransferRequest(string grpname, string memberID, string joinAs)
        {
            // TODO (Sudhakar): make sure the proctor has permissions to proctor the exam.. 
            // list of exams a proctor can see in the proctoring dashboard will be based on permissions, but it may so happen
            //that permissions denied after the drop down list is loaded ??? 

            lock (_lock)
            {
                try
                {
                    ExamGroup htGroup = examGroups.Find(o => o.GroupName == grpname);

                    // The below is based on the below assumption:
                    // 1)Multiple proctors assigned for an exam, so when one proctor is conducting exam other accidentally tried to load it too??
                    // 2) When protors loads other assessment, the group will be ended
                    if (joinAs.Equals("Proctor") && (htGroup != null))
                    {
                        string procid = htGroup.GetExamineeConnection(memberID);
                        /// Send a message to Proctor that the examinees on the connection has started the exam .. 
                        var connectionIds = GetAllConnectionIds(procid).ToList();
                        //Clients.Client(procid).AskProctorTransferConfirm(memberID);
                        Clients.Clients(connectionIds).AskProctorTransferConfirm(memberID);
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public void ProctorTransferConfirmed(string grpname, string memberID, string newProcID, string joinAs)
        {
            // TODO (Sudhakar): make sure the proctor has permissions to proctor the exam.. 
            // list of exams a proctor can see in the proctoring dashboard will be based on permissions, but it may so happen
            //that permissions denied after the drop down list is loaded ??? 

            lock (_lock)
            {
                try
                {
                    ExamGroup htGroup = examGroups.Find(o => o.GroupName == grpname);

                    // The below is based on the below assumption:
                    // 1)Multiple proctors assigned for an exam, so when one proctor is conducting exam other accidentally tried to load it too??
                    // 2) When protors loads other assessment, the group will be ended
                    if (joinAs.Equals("Proctor") && (htGroup != null))
                    {
                        string procid = htGroup.GetExamineeConnection("Proctor");
                        /// Send a message to Proctor that the examinees on the connection has started the exam .. 
                        var connectionIds = GetAllConnectionIds(procid).ToList();
                        //Clients.Client(newProcID).ConfirmedProctorTransfer();
                        Clients.Clients(connectionIds).ConfirmedProctorTransfer();
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// Gets the examinee status ????
        /// </summary>
        /// <param name="grpName"></param>
        /// <param name="examineeName"></param>
        /// <returns></returns>
        internal static string GetExamineeStatus(string grpName, string examineeName)
        {
            string status = "";
            lock (_lock)
            {
                ExamGroup examGrp = examGroups.Find(o => o.GroupName == grpName);
                status = examGrp.GetExamineeStatus(examineeName);
            }
            return status;
        }

        /// <summary>
        /// //
        /// </summary>
        /// <returns></returns>
        private void ProctorDisconnected(string groupName)
        {
            // Jayendra: if proctor disconnected, inform all the connected examinees about it 

            var group = examGroups.Where(x => x.GroupName == groupName);

            foreach(var con in group)
            {
                //Clients.All.OnExamineeDisconnected(con.Key, con.Value);
                Clients.Group(con.GroupName).OnExamineeDisconnected(con.GroupName);
            }

            Groups.Remove(Context.ConnectionId, groupName);
        }

        /// <summary>
        /// Get UserID from all groups based on ConnectionID
        /// </summary>
        /// <param name="ConnID"></param>
        /// <returns>UserID</returns>
        private string GetIdFromConnectionId(string ConnID)
        {
            string UserID = "";
            if (examGroups.Count > 0)
            {
                //var group = examGroups.FirstOrDefault(x => x.htUsers_ConIds.ContainsValue(ConnID) != null).htUsers_ConIds;

                foreach(var group in examGroups)
                {
                    foreach (DictionaryEntry entry in group.htUsers_ConIds)
                    {
                        if (entry.Value.ToString() == ConnID)
                        {
                            UserID = entry.Key.ToString();
                            break;
                        }
                    }
                }
            }

            return UserID;
        }

        /// <summary>
        /// Returns group name for the user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private string IsProctorFor(string user)
        {
            //jayendra
            var group = examGroups.FirstOrDefault(x => x.proctorName.ToLower() == user.ToLower() && x.GroupName != "ProctorDashboard");
            //var group = examGroups.FirstOrDefault(x => x.htUsers_ConIds.ContainsValue(user) != null).htUsers_ConIds;
            //object key=null;
            //foreach (DictionaryEntry entry in group)
            //{
            //    if (entry.Value.ToString() == user)
            //    {
            //        key = entry.Key;
            //        break;
            //    }
            //}
            //if (key.ToString() == "Proctor")
            //    return key.ToString();
            //else
            //    return null;
            if (group == null)
                return null;
            else
                return group.GroupName;

        }

        public void ProctorClosedConsoleTab(string ProctorId)
        {
            string groupName = null;
            if ((groupName = IsProctorFor(ProctorId)) != null)
            {
                RemoveFromExamGroup(ProctorId, groupName, "Proctor");
            }
        }

        public void ExamScheduleStatusIdChanged(string grpName, string scheduleid, string statusid)
        {
            //string groupName = null;
            //examGroups.ForEach(x =>
            //{
            //string procid = x.GetExamineeConnection(ProctorId);
            Clients.Group(grpName).onExamStatusChanged(scheduleid, statusid);
            //});
        }
        
        private void ExamineeDisconnected(string examineeName)
        {
            // if Examinee disconnected, remove examinee from the group list.

            examGroups.ForEach(x =>
            {
                if (x.IsExamineeInGroup(examineeName))
                {
                    //var id = x.GetExamineeConnection(examineeName);

                    // Jayendra , OnexamineeDisconnected has to be implemented
                    //string id = examGroups.GetExamineeConnection(examineeName);
                    //string procid = examGroups.GetExamineeConnection("Proctor");
                    string groupName = "";
                    string proctorName = "";
                    string procid = "";
                    string id = x.GetExamineeConnection(examineeName);

                    foreach (var group in examGroups)
                    {
                        foreach (DictionaryEntry entry in group.htUsers_ConIds)
                        {
                            if (entry.Value.ToString() == id)
                            {
                                //UserID = entry.Key.ToString();
                                groupName = group.GroupName;
                                proctorName = group.proctorName;
                                procid = group.GetExamineeConnection(proctorName);
                                break;
                            }
                        }
                    }

                    //string procid = x.GetExamineeConnection("Proctor");
                    
                    var connectionIds = GetAllConnectionIds(procid).ToList();
                    Clients.Clients(connectionIds).OnExamineeDisconnected(examineeName);

                    /// Send a message to Proctor that the examinees on the connection has started the exam .. 

                    //Clients.All.OnExamineeDisconnected(id, examineeName); 

                }
            });
        }

        //public override Task OnConnected()
        //{
        //    return base.OnConnected();
        //}


        public void CloseProctorReview()
        {
            string groupName = null;
            string connectedUser = GetIdFromConnectionId(Context.ConnectionId);

            if ((groupName = IsProctorFor(connectedUser)) != null)
            {
                RemoveFromExamGroup(connectedUser, groupName, "Proctor");
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="stopCalled"></param>
        /// <returns></returns>
        public override Task OnDisconnected(bool stopCalled)
        {
            // jayendra: get user identity (when security is implemented, we will get the user.identity.name set with the name)
            //var  connectedUser1 = examGroups.FirstOrDefault(x => x.htUsers_ConIds.ContainsValue(Context.ConnectionId) != null).htUsers_ConIds;
            //var connectedUser = "Proctor";
            string groupName = null;
            string connectedUser = GetIdFromConnectionId(Context.ConnectionId);

            if ((groupName = IsProctorFor(connectedUser)) != null)
            {
                RemoveFromExamGroup(connectedUser, groupName, "Proctor");
            }
            else
            {
                RemoveFromExamGroup(connectedUser, groupName, "Examinee");
            }

            return base.OnDisconnected(stopCalled);
        }

        internal const string SessionId = "SessionId";

        public static readonly ConcurrentDictionary<string, HashSet<string>> sessions = new ConcurrentDictionary<string, HashSet<string>>();

        public static IEnumerable<string> GetAllConnectionIds(string connectionId)
        {
            foreach (var session in sessions)
            {
                if (session.Value.Contains(connectionId) == true)
                {
                    return session.Value;
                }
            }

            return Enumerable.Empty<string>();
        }

        public override Task OnReconnected()
        {
            this.EnsureGroups();

            return base.OnReconnected();
        }

        public override Task OnConnected()
        {
            this.EnsureGroups();

            return base.OnConnected();
        }

        private void EnsureGroups()
        {

            var connectionIds = null as HashSet<string>;
            var sessionId = this.Context.QueryString[SessionId];
            var connectionId = this.Context.ConnectionId;

            if (sessions.TryGetValue(sessionId, out connectionIds) == false)
            {
                connectionIds = sessions[sessionId] = new HashSet<string>();
            }

            connectionIds.Add(connectionId);
        }

        public static List<ExamGroup> lstGroups { get; set; }
    }
}