using System;
using System.Collections.Generic;

namespace Metricaencuesta.Models
{
    public partial class empleado
    {
        public int id_empleado { get; set; }
        public string dni { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string telefono { get; set; }
        public string correo { get; set; }
        public string usuario { get; set; }
        public string password { get; set; }
        public string tipo_usuario { get; set; }
        public string foto { get; set; }
        public string curri_file { get; set; }

        public string hora_ingreso { get; set; }
        public string estado { get; set; }
        public System.DateTime fec_reg { get; set; }
        public Nullable<System.DateTime> fec_mod { get; set; }
        public string usu_reg { get; set; }
        public string usu_mod { get; set; }

        /*--DRIVERA Ini--*/
        public string hora_salida { get; set; }
    }
}
