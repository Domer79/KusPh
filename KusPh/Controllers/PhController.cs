using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SystemTools.Extensions;
using SystemTools.WebTools.Helpers;
using SystemTools.WebTools.Infrastructure;
using DataRepository;
using KusPh.Data;
using KusPh.Data.Infrastructure;
using KusPh.Data.Models;
using KusPh.Data.Repositories;
using Microsoft.Ajax.Utilities;

namespace KusPh.Controllers
{
    public class PhController : Controller
    {
        readonly KusRepository _repo = new KusRepository();
        // GET: Ph
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetKus(GridSettings grid)
        {
            var period = Tools.GetCurrentPeriod();
            var result = ControllerHelper.GetData(grid, _repo.OrderBy(k => k.Street).ThenBy(k => k.House).ThenBy(k => k.Apartment).Where(k => k.Period == period));
            return Json(result);
        }

        public ActionResult EditKus(Kus kus)
        {
            try
            {
                _repo.InsertOrUpdate(kus);
                _repo.SaveChanges();
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                e.SaveError();
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, e.GetErrorMessage());
            }
        }
    }
}