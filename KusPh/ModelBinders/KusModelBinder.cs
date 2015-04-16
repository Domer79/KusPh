using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
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
            try
            {
                var request = controllerContext.HttpContext.Request;
                return new Kus
                {
                    Id = int.Parse(request["Id"] ?? "0"),
                    ObjectName = request["ObjectName"],
                    Street = request["Street"],
                    House = request["House"],
                    Apartment = request["Apartment"],
                    TotalArea = TotalAreaParse(request["TotalArea"]),
                    Floors = int.Parse(request["Floors"] ?? "0"),
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private double TotalAreaParse(string totalAreaString)
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
                if (!rx.Match(totalAreaString).Success)
                    return 0;


            }
        }
    }
}