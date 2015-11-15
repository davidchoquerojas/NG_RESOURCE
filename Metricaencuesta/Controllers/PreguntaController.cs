using Metricaencuesta.Data;
using Metricaencuesta.Models;
using Metricaencuesta.Utils;
using System.Web.Mvc;

namespace Metricaencuesta.Controllers
{
    [SessionValidator]
    public class PreguntaController : Controller
    {
        [HttpGet]
        public ActionResult listAll(int? id)
        {
            return new JsonResult { Data = new PreguntaDB().listAll((int)id), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        [HttpPost]
        public ActionResult save(pregunta o)
        {
            o.usu_reg = Session["usuario"].ToString();
            o.fec_reg = System.DateTime.Now;

            return new JsonResult { Data = new PreguntaDB().save(o) };
        }
        [HttpPost]
        public ActionResult update(pregunta o,int? id)
        {
            o.usu_reg = Session["usuario"].ToString();
            o.fec_reg = System.DateTime.Now;
            return new JsonResult { Data = new PreguntaDB().update(o,(int)id) };
        }
    }
}