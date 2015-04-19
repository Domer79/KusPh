using System;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
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
            var addCommands = new[] {"user", "group", "role", "secobject"};

            object result = null;
            if (!commands.All(term.Contains))
                result = commands.Where(c => c.StartsWith(term ?? string.Empty)).ToArray();

//            if (Regex.IsMatch(term, "add"))

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}