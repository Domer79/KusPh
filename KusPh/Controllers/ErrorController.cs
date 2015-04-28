using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KusPh.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index()
        {
            var context = HttpContext;
            var error = (Exception)Session["errorObject"];
            return View(error);
        }
    }
}