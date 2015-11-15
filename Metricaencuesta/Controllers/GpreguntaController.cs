using Metricaencuesta.Data;
using Metricaencuesta.Models;
using Metricaencuesta.Utils;
using System.Web.Mvc;

namespace Metricaencuesta.Controllers
{
    [SessionValidator]
    public class GpreguntaController : Controller
    {
        [HttpGet]
        public JsonResult listAll(string estado = null)
        {
            return new JsonResult { Data = new GpreguntaDB().listAll(estado), JsonRequestBehavior = JsonRequestBehavior.AllowGet};
        }

        [HttpPost]
        public JsonResult save(gpregunta o)
        {
            o.fec_reg = System.DateTime.Now;
            o.usu_reg = Session["usuario"].ToString();
            return new JsonResult { Data = new GpreguntaDB().save(o) };
        }

        [HttpPost]
        public JsonResult update(gpregunta o,int? id)
        {
            o.fec_mod = System.DateTime.Now;
            o.usu_mod = Session["usuario"].ToString();
            return new JsonResult { Data = new GpreguntaDB().update(o,(int)id) };
        }
    }
}