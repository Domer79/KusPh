using System;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Http;
using SystemTools;
using SystemTools.ConfigSections;
using SystemTools.WebTools.Infrastructure;
using DataRepository.Infrastructure;
using KusPh.Controllers;
using KusPh.Data;
using KusPh.Data.Models;
using KusPh.Data.Repositories;
using KusPh.ModelBinders;
using KusPh.Models;
using WebSecurity;
using WebSecurity.Infrastructure;

namespace KusPh
{
    public class Global : HttpApplication
    {
        private void Application_Start(object sender, EventArgs e)
        {
            // Код, выполняемый при запуске приложения
//            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ControllerCollection.Assemblies.Add(typeof(PhController).Assembly);
            ApplicationCustomizer.RegisterErrorLog(ErrorLog.SaveError);
            ApplicationCustomizer.ApplicationType = ApplicationType.Web;
            System.Web.Mvc.ModelBinders.Binders.Add(typeof(Kus), new KusModelBinder());
            ContextInfo.ContextInfoCollection.Add(typeof(KusPhContext));

            #region Security

            ApplicationCustomizer.Security = Security.Instance;
            ControllerBuilder.Current.SetControllerFactory(new SecurityControllerFactory());
            Security.Instance.SetAccessTypes<SecurityAccessType, PhAccess>();
            ApplicationCustomizer.EnableSecurity = true;
            ApplicationCustomizer.SecurityConnectionString = AdditionalConfiguration.Instance.SecurityConnectionString;
            ApplicationCustomizer.EnableSecurityAdminPanel = true;

            #endregion
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            Security.RenewContext();
        }

        protected void Application_EndRequest(object sender, EventArgs e)
        {
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