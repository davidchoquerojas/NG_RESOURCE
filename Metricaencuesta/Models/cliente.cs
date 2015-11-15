using System;
using System.Collections.Generic;

namespace Metricaencuesta.Models
{
    public partial class cliente
    {
        //public cliente()
        //{
        //    this.cliente_empleado = new List<cliente_empleado>();
        //}

        public int id_cliente { get; set; }
        public string razon_social { get; set; }
        public string ruc { get; set; }
        public string telefono { get; set; }
        public string latitud { get; set; }
        public string longitud { get; set; }
        public string estado { get; set; }
        public System.DateTime fec_reg { get; set; }
        public Nullable<System.DateTime> fec_mod { get; set; }
        public string usu_reg { get; set; }
        public string usu_mod { get; set; }

        //public virtual ICollection<cliente_empleado> cliente_empleado { get; set; }
    }
}
