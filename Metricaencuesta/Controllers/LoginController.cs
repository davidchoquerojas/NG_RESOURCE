using System.Web.Mvc;
using System.Web.Security;

namespace Metricaencuesta.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Auth()
        {
            return View();
        }

        public ActionResult close()
        {
            Session.RemoveAll();
            Session.Clear();
            Session.Abandon();
            FormsAuthentication.SignOut();
            return RedirectToAction("auth", "login");
        }
    }
}