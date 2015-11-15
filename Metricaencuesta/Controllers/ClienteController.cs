using Metricaencuesta.Data;
using Metricaencuesta.Models;
using Metricaencuesta.Utils;
using System;
using System.Configuration;
using System.Web.Mvc;

namespace Metricaencuesta.Controllers
{
    [SessionValidator]
    public class ClienteController : Controller
    {
        Int32 difftime = Convert.ToInt32(ConfigurationManager.AppSettings.Get("hDiff"));
        [HttpGet]
        public JsonResult listAll()
        {
            return new JsonResult { Data = new ClienteDB().listAll(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [HttpPost]
        public JsonResult add(cliente o)
        {

            o.usu_reg = Session["usuario"].ToString();
            o.fec_reg = System.DateTime.Now.AddHours(difftime);
            return new JsonResult { Data = new ClienteDB().add(o) };
        }

        //actualizar empresa
        [HttpPost]
        public JsonResult update(cliente o, int id)
        {
            o.fec_mod = System.DateTime.Now.AddHours(difftime);
            return new JsonResult { Data = new ClienteDB().update(o,id) };
        }
    }
}