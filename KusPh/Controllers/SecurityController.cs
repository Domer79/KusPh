using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebSecurity.Infrastructure;

namespace KusPh.Controllers
{
    public class SecurityController : Controller
    {
        // GET: Security
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Users()
        {
            return View();
        }

        public ActionResult Controllers()
        {
            return View();
        }

        public ActionResult CmdRun(string command)
        {
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        public ActionResult Intellisense(string term)
        {
             var commands = new[] {"add", "set", "grant", "delete"};

            var result = commands.Where(c => c.StartsWith(term ?? string.Empty)).ToArray();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}