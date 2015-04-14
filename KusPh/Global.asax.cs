using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Http;
using SystemTools;
using SystemTools.ConfigSections;
using SystemTools.WebTools.Infrastructure;
using WebSecurity;

namespace KusPh
{
    public class Global : HttpApplication
    {
        private void Application_Start(object sender, EventArgs e)
        {
            // Код, выполняемый при запуске приложения
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            #region Security

            ApplicationCustomizer.Security = Security.Instance;
            ControllerBuilder.Current.SetControllerFactory(new SecurityControllerFactory());
            Security.Instance.SetAccessTypes<SecurityAccessType>();
            ApplicationCustomizer.EnableSecurity = true;
            ApplicationCustomizer.SecurityConnectionString = AdditionalConfiguration.Instance.SecurityConnectionString;
            ApplicationCustomizer.EnableSecurityAdminPanel = false;

            #endregion
        }

        protected void Application_Error()
        {
            var exception = Server.GetLastError();
            Server.ClearError();
            Session["errorObject"] = exception;
            ApplicationCustomizer.IsError = true;
            Response.RedirectToRoute(new {AdditionalConfiguration.Instance.ErrorPage.Controller, AdditionalConfiguration.Instance.ErrorPage.Action});
        }
    }
}