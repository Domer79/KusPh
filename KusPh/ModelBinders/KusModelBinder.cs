using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using KusPh.Data;
using KusPh.Data.Models;

namespace KusPh.ModelBinders
{
    public class KusModelBinder : IModelBinder
    {
        /// <summary>
        /// Привязывает модель к значению, используя указанный контекст контроллера и контекст привязки.
        /// </summary>
        /// <returns>
        /// Значение привязки.
        /// </returns>
        /// <param name="controllerContext">Контекст контроллера.</param><param name="bindingContext">Контекст привязки.</param>
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var request = controllerContext.HttpContext.Request;
            var kus = new Kus();
            kus.IdKus = int.Parse(string.IsNullOrEmpty(request["IdKus"]) ? "0" : request["IdKus"]);
            kus.ObjectName = request["ObjectName"];
            kus.Street = request["Street"];
            kus.House = request["House"];
            kus.Apartment = request["Apartment"];
            kus.TotalArea = TotalAreaParse(request["TotalArea"]);
            kus.Floors = int.Parse(request["Floors"] ?? "0");
            kus.RegOperator = request["RegOperator"] == string.Empty ? null : request["RegOperator"];
            kus.SpecAccount = request["SpecAccount"] == string.Empty ? null : request["SpecAccount"];
            kus.RegOperatorFund = request["RegOperatorFund"] == string.Empty ? null : request["RegOperatorFund"];
            kus.Period = Tools.GetCurrentPeriod();
            kus.IdOwner = string.IsNullOrEmpty(request["IdOwner"]) ? (int?) null : int.Parse(request["IdOwner"]);

            return kus;
        }

        private static double TotalAreaParse(string totalAreaString)
        {
            if (string.IsNullOrEmpty(totalAreaString))
                return 0;

            try
            {
                return Convert.ToDouble(totalAreaString);
            }
            catch
            {
                var rx = new Regex(@"(?<int>[\d]+)[,.]*(?<float>[\d]*)");
                var match = rx.Match(totalAreaString);
                if (!match.Success)
                    return 0;

                return Convert.ToDouble(string.Format("{0},{1}", match.Groups["int"], string.IsNullOrEmpty(match.Groups["float"].Value) ? "0" : match.Groups["float"].Value));
            }
        }
    }
}