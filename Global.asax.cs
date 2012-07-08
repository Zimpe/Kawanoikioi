using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Routing;
using System.Data.Entity;
using Kawanoikioi.Models;
using System.Globalization;
using System.Threading;

namespace Kawanoikioi
{
    public class Global : System.Web.HttpApplication
    {

        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup

            RegisterRoutes(RouteTable.Routes);
            Database.SetInitializer<KawanoikioiDbContext>(new KawanoikioiDbInit());
        }

        //private void OverrideDateTimeFormat()
        //{
        //    CultureInfo culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
        //    culture.DateTimeFormat.FullDateTimePattern = "yyyy-MM-dd HH:mm";
        //    culture.DateTimeFormat.ShortDatePattern = "yyyy-MM-dd";
        //    culture.DateTimeFormat.LongTimePattern = "HH:mm";

        //    Thread.CurrentThread.CurrentCulture = culture;
        //}

        private void RegisterRoutes(RouteCollection routes)
        {
            routes.Ignore("{resource}.axd/{*pathinfo}");
            routes.Ignore("{service}.svc/{*pathinfo}");

            routes.Add("FileRoute", new Route("Files/{uploader}/{type}/{*fileName}", new Handlers.Routes()));

            routes.MapPageRoute("ProfileRoute", "Users/{id}", "~/Account/Profile.aspx");
            routes.MapPageRoute("ForumRoute", "Forum/{action}/{*id}", "~/Forum/{action}.aspx", true, new RouteValueDictionary
            {
                { "action", "Default" }
            });
            routes.MapPageRoute("MediaRoute", "{media}/{action}/{*id}", "~/Media/{media}/{action}.aspx", true, new RouteValueDictionary
            {
                { "action", "Default" }
            });
        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

        }

        void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started

        }

        void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.

        }

    }
}
