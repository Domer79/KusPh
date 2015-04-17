using System;
using SystemTools;
using KusPh.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KusPh.Tests
{
    [TestClass]
    public class KusPhDataTesting
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="T:System.Object"/>.
        /// </summary>
        public KusPhDataTesting()
        {
            ApplicationSettings.ConnectionString = "data source=.;initial catalog=KusPh;User Id=developer;Password=sppdeveloper;MultipleActiveResultSets=True;App=EntityFramework";
        }

        [TestMethod]
        public void GetCurrentPeriodTest()
        {
            Assert.AreEqual(new DateTime(2014, 10, 01), Tools.GetCurrentPeriod());
        }
    }
}
