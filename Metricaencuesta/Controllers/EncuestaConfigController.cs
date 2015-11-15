using System;
using Metricaencuesta.Data;
using System.Web.Mvc;
using Metricaencuesta.Models;
using Metricaencuesta.Utils;

namespace Metricaencuesta.Controllers
{
    [SessionValidator]
    public class EncuestaConfigController : Controller
    {
        [HttpGet]
        public JsonResult listAll()
        {
            return new JsonResult { Data = new Encuesta_configDB().listAll(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
         }

        [HttpPost]
        public JsonResult save(encuesta_config o)
        {
            o.fec_reg = DateTime.Now;
            o.usu_reg = Session["usuario"].ToString();
            o.usu_mod = Session["usuario"].ToString();
            return new JsonResult { Data = new Encuesta_configDB().save(o) };
        }

        [HttpPost]
        public JsonResult update(encuesta_config o,int id)
        {
            o.fec_mod = DateTime.Now;
            o.usu_mod = Session["usuario"].ToString();
            return new JsonResult { Data = new Encuesta_configDB().update(o, id) };
        }
    }
}