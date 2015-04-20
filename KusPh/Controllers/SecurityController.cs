using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WebSecurity.IntellISense;

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
            var result = (IEnumerable<string>)new CommandTermDispatcher<CommandTermMain>(term);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}