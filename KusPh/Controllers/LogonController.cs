using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using SystemTools;

namespace KusPh.Controllers
{
    public class LogonController : Controller
    {
        // GET: Logon
        public ActionResult Index()
        {
            return View(new LoginView());
        }

        [HttpPost]
        public ActionResult Index(LoginView loginView)
        {
            if (ModelState.IsValid)
            {
                if (!ApplicationCustomizer.Security.Sign(loginView.Login, loginView.Password))
                {
                    ModelState["Login"].Errors.Add("Пользователь не прошел проверку подлинности");
                    return View(loginView);
                }
            }

            ApplicationCustomizer.Security.CreateCookie(loginView.Login);
            return RedirectToAction("Index", "Ph");
        }
    }

    public class LoginView
    {
        [Required(ErrorMessage = "Введите логин")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        public string Password { get; set; }

        public bool IsPersistent { get; set; }
    }

}