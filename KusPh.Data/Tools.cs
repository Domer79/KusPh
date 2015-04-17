using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KusPh.Data.Infrastructure;

namespace KusPh.Data
{
    public class Tools
    {
        public static DateTime GetCurrentPeriod()
        {
            return ScalarFunctions.GetCurrentPeriod();
        }
    }
}
