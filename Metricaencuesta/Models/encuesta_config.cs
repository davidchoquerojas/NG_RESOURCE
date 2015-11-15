using System;
using System.Collections.Generic;

namespace Metricaencuesta.Models
{
    public partial class encuesta_config
    {
        //public encuesta_config()
        //{
        //    this.resultadoes = new List<resultado>();
        //}

        public int id_encuesta { get; set; }
        public Nullable<System.DateTime> fecha_ini { get; set; }
        public Nullable<System.DateTime> fecha_fin { get; set; }
        public string estado { get; set; }
        public Nullable<System.DateTime> fec_reg { get; set; }
        public Nullable<System.DateTime> fec_mod { get; set; }
        public string usu_mod { get; set; }
        public string usu_reg { get; set; }
        //public virtual ICollection<resultado> resultadoes { get; set; }
    }
}
