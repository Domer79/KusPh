using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KusPh.Data.Infrastructure;
using KusPh.Data.Repositories;

namespace KusPh.Data
{
    public class Tools
    {
        public static DateTime GetCurrentPeriod()
        {
            return ScalarFunctions.GetCurrentPeriod();
        }

        public static string GetLastError()
        {
            return ErrorRepository.Errors.GetLastError();
        }
    }
}
