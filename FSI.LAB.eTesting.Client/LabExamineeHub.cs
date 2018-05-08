using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FSI.LAB.eTesting.Client
{
    [HubName("labExamineeHub")]
    public class LabExamineeHub : Microsoft.AspNet.SignalR.Hub
    {
        private HubConnection hubConnection;
        private IHubProxy examHubProxy;
        public LabExamineeHub()
        {
            hubConnection = new HubConnection(System.Configuration.ConfigurationManager.AppSettings["websiteURL"].ToString());
            hubConnection.TraceLevel = TraceLevels.All;
            hubConnection.TraceWriter = Console.Out;

            examHubProxy = hubConnection.CreateHubProxy("labExamHub");

            hubConnection.Start();
            //string err = hubConnection.Error;
        }

        public void startExam()
        {
            Console.WriteLine("started exam called by client: " + Context.ConnectionId);
            examHubProxy.Invoke("StartedExam", null, null, null);
        }

        public void endExam()
        {
            Console.WriteLine("End exam called by client: " + Context.ConnectionId);
        }

        public void JoinExamGroup()
        {
            Console.WriteLine("Joined exam group by client:" + Context.ConnectionId);
            examHubProxy.Invoke("JoinExamGroup", "", "", "");
        }
    }
}