using Metricaencuesta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metricaencuesta.Data
{
    class ClienteEmpleadoDB
    {
        public List<cliente_empleadoList> listAll()
        {
            try
            {
                using (var db = new PruebaContext())
                {
                    return db.Database.SqlQuery<cliente_empleadoList>("pr_sel_cli_emp").ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<cliente_empleadoList> save(cliente_empleado o)
        {
            try
            {
                using (var db = new PruebaContext())
                {
                    db.cliente_empleado.Add(o);

                    var validationErrors = db.GetValidationErrors();

                    db.SaveChanges();
                    return listAll();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public List<cliente_empleadoList> update(cliente_empleado o,int id)
        {
            try
            {
                using (var db = new PruebaContext())
                {
                    var entity = db.cliente_empleado.Find(id);
                    entity.id_evaluador = o.id_evaluador;
                    entity.id_cliente = o.id_cliente;
                    entity.id_empleado = o.id_empleado;
                    db.SaveChanges();
                    return listAll();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
