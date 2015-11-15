using Metricaencuesta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metricaencuesta.Data
{
    public class PreguntaDB
    {
        public List<pregunta> listAll(int id_gpregunta)
        {
            var list = new List<pregunta>();
            try
            {
                using (var db = new PruebaContext())
                {
                    var query = db.preguntas.Join(db.gpreguntas
                        , p => p.id_gpregunta
                        , g => g.id_gpregunta
                        , (p, g) => new { p, g }).Where(p=>p.p.id_gpregunta == id_gpregunta || id_gpregunta == 0 && p.g.estado.Equals("A")).ToList();

                    foreach (var item in query)
                    {
                        var pregunta = new pregunta()
                        {
                            id_gpregunta = item.p.id_gpregunta,
                            id_pregunta = item.p.id_pregunta,
                            descripcion = item.p.descripcion,
                            estado = item.p.estado,
                            gpregunta = new gpregunta()
                            {
                                descripcion = item.g.descripcion
                            }
                        };

                        list.Add(pregunta);
                    }
                    return list;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<pregunta> save(pregunta o)
        {
            try
            {
                using (var db = new PruebaContext())
                {
                    db.preguntas.Add(o);
                    db.SaveChanges();

                    return listAll(o.id_gpregunta);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<pregunta> update(pregunta o, int id)
        {
            try
            {
                using (var db = new PruebaContext())
                {
                    var pregunta = db.preguntas.Find(id);
                    pregunta.descripcion = o.descripcion;
                    pregunta.estado = o.estado;
                    pregunta.id_gpregunta = o.id_gpregunta;
                    db.SaveChanges();
                    return listAll(o.id_gpregunta);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
    