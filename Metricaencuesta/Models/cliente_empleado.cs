using System;

namespace Metricaencuesta.Models
{
    public partial class cliente_empleado
    {
        public int id_cliemp { get; set; }
        public int id_cliente { get; set; }
        public int id_empleado { get; set; }
        public Nullable<int> id_evaluador { get; set; }

    }

    public class cliente_empleadoList
    {
        public int id_cliemp { get; set; }
        public int id_cliente { get; set; }
        public int id_empleado { get; set; }
        public Nullable<int> id_evaluador { get; set; }
        public string cliente { get; set; }
        public string empleado { get; set; }
        public string evaluador { get; set; }
    }

}
