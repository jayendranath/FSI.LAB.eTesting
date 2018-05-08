using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Configuration;
using Microsoft.AspNet.SignalR;


[assembly: OwinStartup(typeof(FSI.LAB.eTesting.Client.Startup))]

namespace FSI.LAB.eTesting.Client
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //var policy = new CorsPolicy()

            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            //string sqlConnectionString = ConfigurationManager.ConnectionStrings["eLearningSignalRConnection"].ConnectionString; ;
            //GlobalHost.DependencyResolver.UseSqlServer(sqlConnectionString);
            app.MapSignalR();
        }
    }
}
