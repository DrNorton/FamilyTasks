using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using ServiceStack.WebHost.Endpoints;

namespace FamilyTasks.Api
{
    public class Global : System.Web.HttpApplication
    {

        public class AppHost : AppHostBase
        {
            public AppHost() : base("Hello API", typeof(HelloService).Assembly) { }


            public override void Configure(Funq.Container container)
            {
             
            }
        }

        protected void Application_Start(Object sender, EventArgs e)
        {
            new AppHost().Init();
        }
    }
}