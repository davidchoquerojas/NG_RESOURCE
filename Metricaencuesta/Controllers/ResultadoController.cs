using Metricaencuesta.Data;
using Metricaencuesta.Models;
using Metricaencuesta.Utils;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Metricaencuesta.Controllers
{
    [SessionValidator]
    public class ResultadoController : Controller
    {
        [HttpGet]
        public JsonResult listPregunta()
        {
            return new JsonResult { Data = new ResultadoDB().listPregunta(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [HttpPost]
        public JsonResult save(List<resultado> o,List<encuesta> e)
        {

            var fileName = "Evaluacion_de_colaboradores_" + DateTime.Now.ToString("yyyyMMddHHmmss")+ ".pdf";
            var pdf = new Utils.PdfGenerator().generatePdf(fileName, e,o[0]);

            new Utils.SendMail().mailTo(fileName, o[0]);
            if (pdf)
            {
                if (saveResultado(o))
                    return new JsonResult { Data = new string[1] { "OK" } };
                else
                    return new JsonResult { Data = new string[1] { "BAD" } };
            }
            else
            {
                return new JsonResult { Data = new string[1] { "NO PDF" } };
            }
        }

        private bool saveResultado(List<resultado> o)
        {
            try
            {
                var db = new ResultadoDB();
                for (var i = 0; i < o.Count; i++)
                {
                    o[i].anio_evaluacion = DateTime.Now.Year;
                    o[i].mes_evaluacion = DateTime.Now.Month;
                    o[i].fecha_evaluacion = DateTime.Now;
                    o[i].usu_reg = Session["usuario"].ToString();
                    o[i].fec_reg = DateTime.Now;
                    db.save(o[i]);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
           
        }

        [HttpPost]
        public JsonResult exportExcelEncuesta(resultado o,int type)
        {
            if (type == 1)
                return new JsonResult { Data = new String[1] { new Utils.ReporteEncuestaExcel().GenerateExcel(Convert.ToDateTime(o.fec_reg), Convert.ToDateTime(o.fec_mod)) } };
            else
                return new JsonResult { Data = new String[1] { new Utils.ReporteEmpleado().generateExcelEmpleado(Convert.ToDateTime(o.fec_reg), Convert.ToDateTime(o.fec_mod)) } };
        }
    }
}