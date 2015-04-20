using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
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
using WebSecurity;
using WebSecurity.Infrastructure;
using WebSecurity.IntellISense;

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
            ApplicationSettings.SecurityConnectionString = "data source=.;initial catalog=KusPhSecurity;User Id=developer;Password=sppdeveloper;MultipleActiveResultSets=True;App=EntityFramework";
            ApplicationCustomizer.Security = Security.Instance;
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

        [TestMethod]
        public void EndSpaceTest()
        {
            const string pattern = @"[^\w]$";
//            var input = "add" + new string(new []{'\t'});
            var input = "add" + new string(new []{'\r', '\n'});

            Assert.IsTrue(Regex.IsMatch(input, pattern));
        }

        [TestMethod]
        public void GetCommandStringsTest()
        {
            var command = "add user Domer ";
//            var rx = new Regex(@"[^\W]+");
            var rx = new Regex(@"[^\W]+");
            var commandStrings = rx.Matches(command);

            var matchStrings = commandStrings.OfType<Match>().Select(m => m.Value).Union(Regex.IsMatch(command, @"[^\w]$") ? new []{""}:new string[]{}).ToArray();
            CollectionAssert.AreEqual("add,user,Domer,".Split(new []{','}), matchStrings);
        }

        [TestMethod]
        public void StartWithTest()
        {
            var commands = new[] { "add", "set", "grant", "delete" };
            const string term = "a";

            var results = commands.Where(c => c.StartsWith(term ?? string.Empty)).ToArray();

            foreach (var result in results)
            {
                Debug.WriteLine(result);
            }
        }

        [TestMethod]
        public void CommandTermDispatcherTest()
        {
            var commandTermDispatcher = new CommandTermDispatcher<CommandTermMain>("grant select to role2 on [dbo].[Kus]");

            foreach (var term in commandTermDispatcher)
            {
                Debug.WriteLine(term);
            }
        }

        [TestMethod]
        public void StringContainTest()
        {
            Assert.IsTrue("[dbo].[Kus]".ToLower().Contains("[dbo].[Kus]".ToLower()));
        }

        [TestMethod]
        public void SplitBySpacesTest()
        {
            const string pattern = @"\s+";
            var input = "grant select to role1 on object ";

            foreach (var s in Regex.Split(input, pattern))
            {
                Debug.WriteLine(string.Format("Word: \"{0}\"", s));
            }
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
