using Metricaencuesta.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Metricaencuesta.Data
{
    class ReporteEncuestaDB
    {
        public List<ReporteEncuesta> getData(int paso,DateTime fecha_ini,DateTime fecha_fin)
        {
            try
            {
                using (var db = new PruebaContext())
                {
                    var id_paso = new SqlParameter("@id_paso", paso);
                    var fecha_inicio = new SqlParameter("@fecha_inicio", fecha_ini);
                    var fecha_final = new SqlParameter("@fecha_fin", fecha_fin);
                    var param = new object[3] ;
                    param[0] = id_paso;
                    param[1] = fecha_inicio;
                    param[2] = fecha_final;
                    return db.Database.SqlQuery<ReporteEncuesta>("pr_reporte_encuesta @id_paso,@fecha_inicio,@fecha_fin", param).ToList();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public List<EmpleadoReport> consultReportEmpleado(DateTime fechaInicio, DateTime fechaFin,int steep)
        {
            try
            {
                using (var db = new PruebaContext())
                {
                    var num_steep = new SqlParameter("@num_steep", steep);
                    var fecha_ini = new SqlParameter("@fecha_ini", fechaInicio);
                    var fecha_fin = new SqlParameter("@fecha_fin", fechaFin);
                    var param = new object[3];
                    param[0] = num_steep;
                    param[1] = fecha_ini;
                    param[2] = fecha_fin;
                    return db.Database.SqlQuery<EmpleadoReport>("pr_reporte_final @num_steep,@fecha_ini,@fecha_fin", param).ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
