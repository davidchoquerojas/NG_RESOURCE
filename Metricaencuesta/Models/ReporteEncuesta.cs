namespace Metricaencuesta.Models
{
    public class ReporteEncuesta
    {
        public int id_gpregunta { get; set; }
        public int id_pregunta { get; set; }
        public int cont_idPregunta { get; set; }
        public string empresa { get; set; }
        public string evaluador { get; set; } 
        public string empleado { get; set; }
        public int id_empleado { get; set; }
        public string gdescripcion { get; set; }
        public string pdescripcion { get; set; }
        public int puntaje { get; set; }
    }
    public class EmpleadoReport
    {
        public int id_empleado { get; set; }
        public string nombres { get; set; }
        public int mes_evaluacion { get; set; }
        public int anio_evaluacion { get; set; }
        public string puntaje { get; set; }
    }
}
