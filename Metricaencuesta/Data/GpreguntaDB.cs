using Metricaencuesta.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Metricaencuesta.Data
{
    public class GpreguntaDB
    {
        public List<gpregunta> listAll(String estado = null)
        {
            try
            {
                using (var db = new PruebaContext())
                {
                    if(estado == null)
                        return db.gpreguntas.ToList();
                    else
                        return db.gpreguntas.Where(g=>g.estado.Equals(estado)) .ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<gpregunta> save(gpregunta o)
        {
            try
            {
                using (var db = new PruebaContext())
                {
                    db.gpreguntas.Add(o);
                    db.SaveChanges();
                    return this.listAll();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<gpregunta> update(gpregunta o,int id)
        {
            try
            {
                using (var db = new PruebaContext())
                {
                    var gp = db.gpreguntas.Find(id);
                    gp.descripcion = o.descripcion;
                    gp.estado = o.estado;
                    db.SaveChanges();

                    return this.listAll();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
