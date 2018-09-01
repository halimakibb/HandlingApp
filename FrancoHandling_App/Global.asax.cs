using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using DevExpress.Web;
using DevExpress.Web.Bootstrap;

    namespace FrancoHandling_App {
        public class Global_asax : System.Web.HttpApplication {
            void Application_Start(object sender, EventArgs e) {
                System.Web.Routing.RouteTable.Routes.MapPageRoute("defaultRoute", "", "~/Pages/Home.aspx");
                DevExpress.Web.ASPxWebControl.CallbackError += new EventHandler(Application_Error);
            }

            void Application_End(object sender, EventArgs e) {
                // Code that runs on application shutdown
            }

            void Application_Error(object sender, EventArgs e) {
                //if (Session["ApplicationErrorLog"] == null)
                //{
                    //Exception ex = Server.GetLastError().GetBaseException();
                    //Server.ClearError();
                    //Response.Redirect("~/Pages/ErrorPage/ErrorPage.aspx?Error=" + ex.Message, true);
                //}
            }

            void Session_Start(object sender, EventArgs e) {
                // Code that runs when a new session is started
            }

            void Session_End(object sender, EventArgs e) {
                // Code that runs when a session ends. 
                // Note: The Session_End event is raised only when the sessionstate mode
                // is set to InProc in the Web.config file. If session mode is set to StateServer 
                // or SQLServer, the event is not raised.
            }
        }
    }