using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DataRepository;
using DataRepository.Interfaces;
using KusPh.Data.Models;

namespace KusPh.Data.Infrastructure
{
    internal class ScalarFunctions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        internal static DateTime GetCurrentPeriod()
        {
            const string pattern = @"(?<year>[\d]{4}).*(?<month>[\d]{2}).*(?<day>[\d]{2})";
            const string parameterName = "currentPeriod";
            var defaultPeriod = new DateTime(2014, 10, 01);

            IRepository<Settings> repo = new Repository<Settings>(new KusPhContext());
            var period = repo.First(s => s.Name == parameterName).Value;
            var periodMatch = Regex.Match(period, pattern);

            return periodMatch.Success
                ? DateTime.Parse(string.Format("{0}-{1}-{2}", periodMatch.Groups["year"], periodMatch.Groups["month"], periodMatch.Groups["day"]))
                : defaultPeriod;
        }
    }
}
