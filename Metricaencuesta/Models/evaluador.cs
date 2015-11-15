using System;
using System.Collections.Generic;

namespace Metricaencuesta.Models
{
    public partial class evaluador
    {
        //public evaluador()
        //{
        //    this.cliente_empleado = new List<cliente_empleado>();
        //    this.resultadoes = new List<resultado>();
        //}

        public int id_evaluador { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string cargo { get; set; }
        public string email { get; set; }
        public string usuario { get; set; }
        public string password { get; set; }
        public string estado { get; set; }
        public Nullable<System.DateTime> fec_reg { get; set; }
        public Nullable<System.DateTime> fec_mod { get; set; }
        public string usu_reg { get; set; }
        public string usu_mod { get; set; }
        //public virtual ICollection<cliente_empleado> cliente_empleado { get; set; }
        //public virtual ICollection<resultado> resultadoes { get; set; }
    }
}
