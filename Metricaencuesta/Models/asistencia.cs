using System;

namespace Metricaencuesta.Models
{
    public partial class asistencia
    {
        public int id_asistencia { get; set; }
        public int id_empleado { get; set; }
        public string tipo_asistencia { get; set; }
        public System.DateTime fecha_asistencia { get; set; }
        public string hora_asistencia { get; set; }
        public string ip_conexion { get; set; }
        public string latitud { get; set; }
        public string longitud { get; set; }
        public string estado { get; set; }
        public System.DateTime fec_reg { get; set; }
        public Nullable<System.DateTime> fec_mod { get; set; }
        public string usu_reg { get; set; }
        public string usu_mod { get; set; }
        public empleado empleado { get; set; }
    }
    public class asistenciaReport
    {
        public String razon_social { get; set; }
        public String usuario { get; set; }
        public DateTime fecha_asistencia { get; set; }
        public String hora_ingresoS { get; set; }
        public String hora_ingreso { get; set; }
        public String ip_ingreso { get; set; }
        public String diferenciaIngreso { get; set; }
        public String hora_SalidaS { get; set; }
        public String hora_salida { get; set; }
        public String ip_salida { get; set; }
        public String diferenciaSalida { get; set; }
    }
}
