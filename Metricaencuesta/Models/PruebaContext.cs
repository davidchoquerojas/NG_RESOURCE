using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Metricaencuesta.Models.Mapping;

namespace Metricaencuesta.Models
{
    public partial class PruebaContext : DbContext
    {
        static PruebaContext()
        {
            Database.SetInitializer<PruebaContext>(null);
        }

        public PruebaContext()
            : base("Name=PruebaContext")
        {
        }

        public DbSet<asistencia> asistencias { get; set; }
        public DbSet<cliente_empleado> cliente_empleado { get; set; }
        public DbSet<cliente> clientes { get; set; }
        public DbSet<empleado> empleados { get; set; }
        public DbSet<evaluador> evaluadors { get; set; }
        public DbSet<gpregunta> gpreguntas { get; set; }
        public DbSet<pregunta> preguntas { get; set; }
        public DbSet<resultado> resultadoes { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<encuesta_config> encuesta_config { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new asistenciaMap());
            modelBuilder.Configurations.Add(new cliente_empleadoMap());
            modelBuilder.Configurations.Add(new clienteMap());
            modelBuilder.Configurations.Add(new empleadoMap());
            modelBuilder.Configurations.Add(new evaluadorMap());
            modelBuilder.Configurations.Add(new gpreguntaMap());
            modelBuilder.Configurations.Add(new preguntaMap());
            modelBuilder.Configurations.Add(new resultadoMap());
            modelBuilder.Configurations.Add(new encuesta_configMap());
            modelBuilder.Configurations.Add(new sysdiagramMap());
        }
    }
}
