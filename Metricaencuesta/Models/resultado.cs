using System;
using System.Collections.Generic;

namespace Metricaencuesta.Models
{
    public partial class resultado
    {
        public int id_resultado { get; set; }
        public int id_encuesta { get; set; }
        public int id_evaluador { get; set; }
        public int id_empleado { get; set; }
        public int id_pregunta { get; set; }
        public int anio_evaluacion { get; set; }
        public int mes_evaluacion { get; set; }
        public System.DateTime fecha_evaluacion { get; set; }
        public int puntaje { get; set; }
        public string comentario { get; set; }
        public Nullable<System.DateTime> fec_reg { get; set; }
        public Nullable<System.DateTime> fec_mod { get; set; }
        public string usu_reg { get; set; }
        public string usu_mod { get; set; }
        public empleado empleado { get; set; }
        public evaluador evaluador { get; set; }
        public pregunta pregunta { get; set; }
    }
    public class encuesta
    {
        public int id_gpregunta { get; set; }
        public int id_pregunta { get; set; }
        public string descripcion { get; set; }
        public List<encuesta> subencuesta { get; set; }
        public int puntaje { get; set; }
    }
}
