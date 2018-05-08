using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;
using System.Configuration;
using Microsoft.AspNet.SignalR;

[assembly: OwinStartup(typeof(FSI.LAB.eTesting.Hub.Startup))]
namespace FSI.LAB.eTesting.Hub
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            //string sqlConnectionString = ConfigurationManager.ConnectionStrings["eLearningSignalRConnection"].ConnectionString; ;
            //GlobalHost.DependencyResolver.UseSqlServer(sqlConnectionString);

            app.MapSignalR();
            //app.UseCors("AllowAll");
        }

        //public void ConfigureServices(IServiceCollection services)
        //{
        //    services.AddCors();
        //}
    }
}
