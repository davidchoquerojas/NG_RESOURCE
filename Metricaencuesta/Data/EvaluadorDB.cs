using Metricaencuesta.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Metricaencuesta.Data
{
    public class EvaluadorDB
    {
        public List<evaluador> listAll(int id = 0)
        {
            var list = new List<evaluador>();
            try
            {
                using (var db = new PruebaContext())
                {
                    return db.evaluadors.Where(e=>e.id_evaluador.Equals(id) || id == 0).ToList();
                    //var query = db.evaluadors.Join(db.clientes
                    //    , e => e.id_cliente
                    //    , c => c.id_cliente
                    //    , (e, c) => new { e, c }).Where(e=>e.e.id_evaluador == id || id==0).ToList();
                    //foreach(var item in query)
                    //{
                    //    var evaluador = new evaluador()
                    //    {
                    //        id_cliente = item.e.id_cliente,
                    //        id_evaluador = item.e.id_evaluador,
                    //        nombres = item.e.nombres,
                    //        apellidos = item.e.apellidos,
                    //        cargo = item.e.cargo,
                    //        email = item.e.email,
                    //        usuario = item.e.usuario,
                    //        estado = item.e.estado,
                    //        cliente = new cliente()
                    //        {
                    //            razon_social = item.c.razon_social
                    //        }
                    //    };

                    //    list.Add(evaluador);
                    //}
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<evaluador> login(evaluador o)
        {
            try
            {
                using (var db = new PruebaContext())
                {
                   return db.evaluadors.Where(e => e.usuario == o.usuario && e.password == o.password && e.estado == o.estado).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<evaluador> save(evaluador o)
        {
            try
            {
                using (var db = new PruebaContext())
                {
                    db.evaluadors.Add(o);
                    db.SaveChanges();

                    return listAll();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<evaluador> update(evaluador o,int id)
        {
            try
            {
                using (var db = new PruebaContext())
                {
                    var evaluador = db.evaluadors.Find(id);
                    evaluador.apellidos = o.apellidos;
                    evaluador.nombres = o.nombres;
                    evaluador.estado = o.estado;
                    evaluador.cargo = o.cargo;
                    evaluador.email = o.email;
                    evaluador.password = o.password;
                    evaluador.usuario = o.usuario;
                    evaluador.fec_mod = o.fec_mod;
                    evaluador.usu_mod = o.usu_mod;
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
