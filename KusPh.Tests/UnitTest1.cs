using System;
using System.Diagnostics;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.UI.WebControls;
using SystemTools;
using SystemTools.Extensions;
using DataRepository.Infrastructure;
using KusPh.Controllers;
using KusPh.Data;
using KusPh.Data.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebSecurity.Infrastructure;

namespace KusPh.Tests
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="T:System.Object"/>.
        /// </summary>
        public UnitTest1()
        {
            ApplicationSettings.ConnectionString = "data source=.;initial catalog=KusPh;User Id=developer;Password=sppdeveloper;MultipleActiveResultSets=True;App=EntityFramework";
        }

        [TestMethod]
        public void CheckInterfaceInTypeTest()
        {
            foreach (var @interface in typeof(SimpleClass).GetInterfaces())
            {
                Debug.WriteLine(@interface);
            }

            Assert.IsTrue(typeof(SimpleClass).GetInterface("IController") != null);
        }

        [TestMethod]
        public void ControllerCollectionTest()
        {
            ControllerCollection.Assemblies.Add(typeof(ErrorController).Assembly);
            var controllerCollection = new ControllerCollection();

            foreach (var ci in controllerCollection)
            {
                Debug.WriteLine(ci);
            }
        }

        [TestMethod]
        public void IsActionResultTypeTest()
        {
            Assert.IsTrue(typeof(ActionResult).Is<ActionResult>());
        }

        [TestMethod]
        public void GetTableNameTest()
        {
            var contextInfo = new ContextInfo(new KusPhContext());
            Assert.AreEqual("[dbo].[kus]", contextInfo.GetTableName(typeof (Kus)).ToLower());
        }

        [TestMethod]
        public void GetTableNamesTest()
        {
            var contextInfo = new ContextInfo(new KusPhContext());
            foreach (var tableName in contextInfo.GetTableNames())
            {
                Debug.WriteLine(tableName);
            }
        }

        [TestMethod]
        public void DoubleToStringTest()
        {
            double v1 = double.Parse("48,1");

            Assert.AreEqual(48,1, v1);
        }
    }

    public class SimpleClass : IController
    {
        /// <summary>
        /// Выполняет указанный контекст запроса.
        /// </summary>
        /// <param name="requestContext">Контекст запроса.</param>
        public void Execute(RequestContext requestContext)
        {
            throw new NotImplementedException();
        }
    }
}
