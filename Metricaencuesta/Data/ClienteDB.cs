using Metricaencuesta.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Metricaencuesta.Data
{
    public class ClienteDB
    {
        public List<cliente> listAll()
        {
            try
            {
                using (var db = new PruebaContext())
                {
                    return db.clientes.ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<cliente> add(cliente o)
        {
            try
            {
                using (var db = new PruebaContext())
                {
                    db.clientes.Add(o);
                    if (db.SaveChanges() > 0)
                    {
                        return listAll();
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
        public List<cliente> update(cliente o, int id)
        {
            try
            {
                using (var db = new PruebaContext())
                {
                    var empresa = db.clientes.Find(id);
                    empresa.razon_social = o.razon_social;
                    empresa.ruc = o.ruc;
                    empresa.telefono = o.telefono;
                    empresa.latitud = o.latitud;
                    empresa.longitud = o.longitud;
                    empresa.estado = o.estado;
                    empresa.fec_mod = o.fec_mod;
                    empresa.usu_mod = o.usu_mod;

                    if (db.SaveChanges() > 0)
                    {
                        return new List<cliente>() { empresa };
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
    }
}