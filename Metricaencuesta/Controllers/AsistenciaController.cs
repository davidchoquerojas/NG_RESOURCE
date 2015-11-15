using APIASIS.Data;
using Metricaencuesta.Models;
using Metricaencuesta.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;

namespace Metricaencuesta.Controllers
{
    [SessionValidator]
    public class AsistenciaController : Controller
    {
        Int32 difftime = Convert.ToInt32(ConfigurationManager.AppSettings.Get("hDiff"));
        //consultar asistencia
        [HttpGet]
        public JsonResult listAll(int id)
        {
            return new JsonResult { Data = new AsistenciaDB().listAll(id), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        //agregar asistencia
        [HttpPost]
        public JsonResult add(asistencia o)
        {
            try
            {
                o.ip_conexion = System.Web.HttpContext.Current.Request.UserHostAddress;
                o.fecha_asistencia = System.DateTime.Now.AddHours(difftime);
                o.hora_asistencia = System.DateTime.Now.AddHours(difftime).ToString("HH:mm");
                o.usu_reg = Session["usuario"].ToString();
                o.fec_reg = System.DateTime.Now.AddHours(difftime);
                return new JsonResult { Data = new AsistenciaDB().add(o) };
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        [HttpPost]
        public JsonResult chekMark(asistencia o)
        {
            return new JsonResult { Data = new AsistenciaDB().chekMark(o) };
        }

        [HttpPost]
        public JsonResult consult(asistencia o)
        {
            var reportList = new List<asistenciaReport>();
            foreach (var item in new AsistenciaDB().consult(o))
            {
                var reporte = new asistenciaReport()
                {
                    razon_social = item.razon_social,
                    usuario = item.usuario,
                    fecha_asistencia = item.fecha_asistencia,
                    hora_ingresoS = item.hora_ingresoS,
                    hora_ingreso = item.hora_ingreso,
                    ip_ingreso = item.ip_ingreso,
                    diferenciaIngreso = new Utils.ReporteAsistencia().differenceTime(item.hora_ingresoS, item.hora_ingreso),
                    hora_SalidaS = item.hora_SalidaS,
                    hora_salida = item.hora_salida,
                    ip_salida = item.ip_salida,
                    diferenciaSalida = new Utils.ReporteAsistencia().differenceTime(item.hora_SalidaS, item.hora_salida),
                    
                };
                reportList.Add(reporte);
            }
            return new JsonResult { Data = reportList };
        }

        [HttpPost]
        public JsonResult exportFile(asistencia o)
        {
            return new JsonResult { Data = new string[1] { new Utils.ReporteAsistencia().exportExcel(new AsistenciaDB().consult(o)) } };
        }
    }
}