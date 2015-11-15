using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metricaencuesta.Models;

namespace Metricaencuesta.Data
{
    public class Encuesta_configDB
    {
        public List<encuesta_config> config()
        {
            try
            {
                var dateRange = DateTime.Now;
                using (var db = new PruebaContext())
                {
                    return db.encuesta_config.Where(e=>e.fecha_ini >= dateRange && e.fecha_fin <= dateRange || e.estado == "C").ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<encuesta_config> listAll()
        {
            try
            {
                using (var db = new PruebaContext())
                {
                    return db.encuesta_config.ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<encuesta_config> save(encuesta_config o)
        {
            try
            {
                using (var db = new PruebaContext())
                {
                    db.encuesta_config.Add(o);
                    db.SaveChanges();
                    return listAll();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public List<encuesta_config> update(encuesta_config o,int id)
        {
            try
            {
                using (var db = new PruebaContext())
                {
                    var entity = db.encuesta_config.Find(id);
                    entity.fecha_ini = o.fecha_ini;
                    entity.fecha_fin = o.fecha_fin;
                    entity.estado = o.estado;
                    entity.usu_mod = o.usu_mod;
                    entity.fec_mod = o.fec_mod;
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
