using Metricaencuesta.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace APIASIS.Data
{
    public class AsistenciaDB
    {
        Int32 difftime = Convert.ToInt32(ConfigurationManager.AppSettings.Get("hDiff"));
        public List<asistencia> listAll(int id)
        {
            var dateIni = Convert.ToDateTime(System.DateTime.Now.AddHours(difftime).ToString("MMMM dd, yyyy") +" 00:00:00");
            var dateEnd = Convert.ToDateTime(System.DateTime.Now.AddHours(difftime).ToString("MMMM dd, yyyy") + " 23:59:59");
            var asist = new List<asistencia>();
            try
            {
                using (var db = new PruebaContext())
                {
                    var asis = db.asistencias.Join(db.empleados
                              , a => a.id_empleado
                              , u => u.id_empleado
                              , (a, u) => new { a, u }).Where(i => i.a.fec_reg > dateIni && i.a.fec_reg < dateEnd && i.u.id_empleado == id).ToList();
                            
                    foreach (var o in asis)
                    {
                        var asistencia = new asistencia()
                        {
                            id_empleado = o.a.id_empleado,
                            tipo_asistencia = o.a.tipo_asistencia,
                            fecha_asistencia = o.a.fecha_asistencia,
                            hora_asistencia = o.a.hora_asistencia,
                            ip_conexion = o.a.ip_conexion,
                            latitud = o.a.latitud,
                            longitud = o.a.longitud,
                            estado = o.a.estado,
                            fec_reg = o.a.fec_reg,
                            fec_mod = o.a.fec_mod,
                            usu_reg = o.a.usu_reg,
                            usu_mod = o.a.usu_mod,
                            empleado = new empleado()
                            {
                                nombres = o.u.nombres,
                                apellidos = o.u.apellidos,
                                usuario = o.u.usuario
                            }
                        };
                        asist.Add(asistencia);
                    }
                }
                return asist;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public List<asistencia> add(asistencia o)
        {
            try
            {
                using (var db = new PruebaContext())
                {
                    db.asistencias.Add(o);
                    if (db.SaveChanges() > 0)
                    {
                        return this.listAll(o.id_empleado);
                    }
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<asistencia> chekMark(asistencia o)
        {
            var dateIni = Convert.ToDateTime(System.DateTime.Now.AddHours(difftime).ToString("MMMM dd, yyyy") +" 00:00:00");
            var dateEnd = Convert.ToDateTime(System.DateTime.Now.AddHours(difftime).ToString("MMMM dd, yyyy") + " 23:59:59");
            try
            {
                using (var db = new PruebaContext())
                {
                    return db.asistencias.Where(a => a.fec_reg > dateIni && a.fec_reg < dateEnd && a.id_empleado == o.id_empleado && a.tipo_asistencia == o.tipo_asistencia).ToList();
                }
            }catch(Exception ex){
                return null;
            }
        }
        public List<asistenciaReport> consult(asistencia o)
        {
           // var asistencia = new List<asistencia>();
            try
            {
                using (var db = new PruebaContext())
                {
                    var fecha_ini = new SqlParameter("@fecha_ini", o.fec_reg);
                    var fecha_fin = new SqlParameter("@fecha_fin", o.fec_mod);
                    var id_empleado = new SqlParameter("@id_empleado", o.id_empleado);
                    var param = new object[3];
                    param[0] = fecha_ini;
                    param[1] = fecha_fin;
                    param[2] = id_empleado;
                    return db.Database.SqlQuery<asistenciaReport>("pr_sel_asistencia @fecha_ini,@fecha_fin,@id_empleado", param).ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}