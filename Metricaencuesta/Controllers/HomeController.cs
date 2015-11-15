using System.Web.Mvc;
using Metricaencuesta.Utils;

namespace Metricaencuesta.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [SessionValidator]
        public ActionResult cliente()
        {
            if(Session["tipo_usuario"].ToString().ToUpper().Equals("ADM"))
                return View();
            return RedirectToAction("asistencia", "home");
        }
        [SessionValidator]
        public ActionResult menu()
        {
            if (Session["tipo_usuario"].ToString().ToUpper().Equals("ADM"))
                return View();
            return RedirectToAction("asistencia", "home");
        }
        [SessionValidator]
        public ActionResult gpregunta()
        {
            if (Session["tipo_usuario"].ToString().ToUpper().Equals("ADM"))
                return View();
            return RedirectToAction("asistencia", "home");
        }
        [SessionValidator]
        public ActionResult pregunta()
        {
            if (Session["tipo_usuario"].ToString().ToUpper().Equals("ADM"))
                return View();
            return RedirectToAction("asistencia", "home");
        }
        [SessionValidator]
        public ActionResult resultado()
        {
            if (Session["tipo_usuario"].ToString().ToUpper().Equals("ADM"))
                return View();
            return RedirectToAction("asistencia", "home");
        }
        [SessionValidator]
        public ActionResult evaluador()
        {
            if (Session["tipo_usuario"].ToString().ToUpper().Equals("ADM"))
                return View();
            return RedirectToAction("asistencia", "home");
        }
        [SessionValidator]
        public ActionResult empleado()
        {
            if (Session["tipo_usuario"].ToString().ToUpper().Equals("ADM"))
                return View();
            return RedirectToAction("asistencia", "home");
        }
        [SessionValidator]
        public ActionResult reporte()
        {
            if (Session["tipo_usuario"].ToString().ToUpper().Equals("ADM"))
                return View();
            return RedirectToAction("asistencia", "home");
        }
        [SessionValidator]
        public ActionResult asistencia()
        {
            return View();
        }
        [SessionValidator]
        public ActionResult clienteempleado()
        {
            if (Session["tipo_usuario"].ToString().ToUpper().Equals("ADM"))
                return View();
            return RedirectToAction("asistencia", "home");
        }
        [SessionValidator]
        public ActionResult encuestaconfig()
        {
            if (Session["tipo_usuario"].ToString().ToUpper().Equals("ADM"))
                return View();
            return RedirectToAction("asistencia", "home");
        }
        [SessionValidator]
        public ActionResult reporteencuesta()
        {
            if (Session["tipo_usuario"].ToString().ToUpper().Equals("ADM"))
                return View();
            return RedirectToAction("asistencia", "home");
        }
        [SessionValidator]
        public ActionResult instruccion()
        {
            return View();
        }
        //publico
        public ActionResult login()
        {
            return View();
        }
    }
}