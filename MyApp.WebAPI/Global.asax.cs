using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
//using System.Data.Entity;
//using MyApp.DataAccess.EF;

namespace MyApp.WebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {

        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            //TODO: uncomment line 18 to use Entity Framework, 
            // add reference to the MyApp.DataAccess.EF project, add reference to Entity Framework
            // uncomment line 7 and 8
            //Database.SetInitializer<DatabaseContext>(new DropCreateDatabaseIfModelChanges<DatabaseContext>());
        }

    }
}
