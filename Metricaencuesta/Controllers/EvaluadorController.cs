using Metricaencuesta.Data;
using Metricaencuesta.Models;
using Metricaencuesta.Utils;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Metricaencuesta.Controllers
{
    public class EvaluadorController : Controller
    {
        [HttpPost]
        public JsonResult Login(evaluador oEvaluador)
        {
            oEvaluador.password = new EncriptarDesencriptar().Encriptar(oEvaluador.password.ToString().Trim());
            var entity = new EvaluadorDB().login(oEvaluador);
            if (entity.Count > 0)
            {
                var encuesta_config = new Encuesta_configDB().config();
                if (encuesta_config.Count > 0)
                {
                    Session.Add("id_evaluador", entity[0].id_evaluador);
                    Session.Add("id_encuesta", encuesta_config[0].id_encuesta);
                    Session.Add("usuario", entity[0].nombres);
                    var evaluador = new List<evaluador>()
                    {
                        new evaluador { id_evaluador = entity[0].id_evaluador}
                    };
                    return new JsonResult { Data = evaluador };
                }
                else
                    return new JsonResult { Data = new string[1] { "BAD"} };
            }
            else
                return new JsonResult { Data = null };
        }

        [SessionValidator]
        [HttpPost]
        public JsonResult save(evaluador oEvaluador)
        {
            oEvaluador.fec_reg = System.DateTime.Now;
            oEvaluador.usu_reg = Session["usuario"].ToString();
            var vPassword = (oEvaluador.nombres.Substring(0, oEvaluador.nombres.Length - (oEvaluador.nombres.Length - 1)) +
                            oEvaluador.apellidos.Substring(0, oEvaluador.apellidos.Length - (oEvaluador.apellidos.Length - 1)) +
                            DateTime.Now.ToString("ddMMyyyy").ToString().Trim()).ToString().Trim();
            oEvaluador.password = new EncriptarDesencriptar().Encriptar(vPassword);
            return new JsonResult { Data = new EvaluadorDB().save(oEvaluador) };
        }

        [SessionValidator]
        [HttpGet]
        public JsonResult listAll()
        {
            List<evaluador> ListEvaluador = new List<evaluador>();
            EncriptarDesencriptar obj = new EncriptarDesencriptar();
            foreach (var evaluador in new EvaluadorDB().listAll())
            {
                evaluador.password = obj.Desencriptar(evaluador.password.ToString().Trim());
                ListEvaluador.Add(evaluador);
            }
            return new JsonResult { Data = ListEvaluador, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [SessionValidator]
        [HttpPost]
        public JsonResult update(evaluador oEvaluador, int id)
        {
            oEvaluador.fec_mod = System.DateTime.Now;
            oEvaluador.usu_mod = Session["usuario"].ToString();
            oEvaluador.password = new EncriptarDesencriptar().Encriptar(oEvaluador.password.ToString().Trim());
            return new JsonResult { Data = new EvaluadorDB().update(oEvaluador, id) };
        }
    }
}