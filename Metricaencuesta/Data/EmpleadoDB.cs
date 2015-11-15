using Metricaencuesta.Models;
using Metricaencuesta.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Metricaencuesta.Data
{
    class EmpleadoDB
    {
        static Int32 difftime = Convert.ToInt32(ConfigurationManager.AppSettings.Get("hDiff"));
        public List<empleado> listAll(int id_empleado = 0,String estado = null)
        {
            var ListEmpleado = new List<empleado>();
            try
            {
                using (var db = new PruebaContext())
                {
                    List<empleado> list;
                    if(estado == null)
                        list = db.empleados.Where(e=>e.id_empleado == id_empleado || id_empleado == 0).ToList();
                    else
                        list = db.empleados.Where(e => e.id_empleado == id_empleado || id_empleado == 0 && e.estado.Equals("A")).ToList();
                    EncriptarDesencriptar obj = new EncriptarDesencriptar();
                    foreach (var empleados in list)
                    {
                        empleados.password = obj.Desencriptar(empleados.password.ToString().Trim());
                        ListEmpleado.Add(empleados);
                    }
                    return ListEmpleado;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<empleado> listByEvaluador(int id_evaluador)
        {
            var list = new List<empleado>();
            try
            {
                using (var db = new PruebaContext())
                {
                    var query = db.empleados.Join(db.cliente_empleado
                        , e => e.id_empleado
                        , c => c.id_empleado
                        , (e, c) => new { e, c }).Where(c => c.c.id_evaluador == id_evaluador).ToList();
                    foreach (var item in query)
                    {
                        var empleado = new empleado()
                        {
                            id_empleado = item.e.id_empleado,
                            nombres = item.e.nombres,
                            apellidos = item.e.apellidos
                        };
                        list.Add(empleado);
                    }
                }
                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<empleado> login(empleado o)
        {
            try
            {
                using (var db = new PruebaContext())
                {
                    return db.empleados.Where(c => c.usuario == o.usuario && c.password == o.password && c.estado.Equals("A")).ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<empleado> add(empleado o)
        {
            try
            {
                using (var db = new PruebaContext())
                {
                    db.empleados.Add(o);

                    //var validationErrors = db.GetValidationErrors();

                    if (db.SaveChanges() > 0)
                    {
                        return this.listAll();
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

        public List<empleado> update(empleado o, int id)
        {
            try
            {
                using (var db = new PruebaContext())
                {
                    var usuario = db.empleados.Find(id);
                    usuario.nombres = o.nombres;
                    usuario.apellidos = o.apellidos;
                    usuario.telefono = o.telefono;
                    usuario.correo = o.correo;
                    usuario.usuario = o.usuario;
                    usuario.password = o.password;
                    usuario.tipo_usuario = o.tipo_usuario;
                    usuario.hora_ingreso = o.hora_ingreso;
                    usuario.estado = o.estado;
                    usuario.fec_mod = o.fec_mod;
                    usuario.usu_mod = o.usu_mod;
                    usuario.curri_file = o.curri_file;
                    usuario.hora_salida = o.hora_salida;

                    //var validationErrors = db.GetValidationErrors();


                    if (db.SaveChanges() > 0)
                    {
                        return new List<empleado>() { usuario };
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
        public List<empleado> updateFoto(empleado o, int id)
        {
            try
            {
                using (var db = new PruebaContext())
                {
                    var usuario = db.empleados.Find(id);
                    usuario.foto = o.foto;

                    //var validationErrors = db.GetValidationErrors();


                    if (db.SaveChanges() > 0)
                    {
                        return new List<empleado>() { usuario };
                    }
                    else
                        return null;

                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
