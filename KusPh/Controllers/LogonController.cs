using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace KusPh.Controllers
{
    public class LogonController : Controller
    {
        // GET: Logon
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string login, string password)
        {
            return new HttpStatusCodeResult(HttpStatusCode.NotImplemented);
        }
    }
}