using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Metricaencuesta.Models.Mapping
{
    public class asistenciaMap : EntityTypeConfiguration<asistencia>
    {
        public asistenciaMap()
        {
            // Primary Key
            this.HasKey(t => t.id_asistencia);

            // Properties
            this.Property(t => t.tipo_asistencia)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(3);

            this.Property(t => t.ip_conexion)
                .HasMaxLength(15);

            this.Property(t => t.latitud)
                .HasMaxLength(30);

            this.Property(t => t.longitud)
                .HasMaxLength(30);

            this.Property(t => t.estado)
                .IsFixedLength()
                .HasMaxLength(1);

            this.Property(t => t.usu_reg)
                .IsRequired()
                .HasMaxLength(30);

            this.Property(t => t.usu_mod)
                .HasMaxLength(30);

            // Table & Column Mappings
            this.ToTable("asistencias");
            this.Property(t => t.id_asistencia).HasColumnName("id_asistencia");
            this.Property(t => t.id_empleado).HasColumnName("id_empleado");
            this.Property(t => t.tipo_asistencia).HasColumnName("tipo_asistencia");
            this.Property(t => t.fecha_asistencia).HasColumnName("fecha_asistencia");
            this.Property(t => t.hora_asistencia).HasColumnName("hora_asistencia");
            this.Property(t => t.ip_conexion).HasColumnName("ip_conexion");
            this.Property(t => t.latitud).HasColumnName("latitud");
            this.Property(t => t.longitud).HasColumnName("longitud");
            this.Property(t => t.estado).HasColumnName("estado");
            this.Property(t => t.fec_reg).HasColumnName("fec_reg");
            this.Property(t => t.fec_mod).HasColumnName("fec_mod");
            this.Property(t => t.usu_reg).HasColumnName("usu_reg");
            this.Property(t => t.usu_mod).HasColumnName("usu_mod");

            // Relationships
            //this.HasRequired(t => t.empleado)
            //    .WithMany(t => t.asistencias)
            //    .HasForeignKey(d => d.id_empleado);

        }
    }
}
