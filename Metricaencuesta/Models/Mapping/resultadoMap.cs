using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Metricaencuesta.Models.Mapping
{
    public class resultadoMap : EntityTypeConfiguration<resultado>
    {
        public resultadoMap()
        {
            // Primary Key
            this.HasKey(t => t.id_resultado);

            // Properties
            this.Property(t => t.comentario)
                .HasMaxLength(500);

            this.Property(t => t.usu_reg)
                .HasMaxLength(30);

            this.Property(t => t.usu_mod)
                .HasMaxLength(30);

            // Table & Column Mappings
            this.ToTable("resultado");
            this.Property(t => t.id_resultado).HasColumnName("id_resultado");
            this.Property(t => t.id_encuesta).HasColumnName("id_encuesta");
            this.Property(t => t.id_evaluador).HasColumnName("id_evaluador");
            this.Property(t => t.id_empleado).HasColumnName("id_empleado");
            this.Property(t => t.id_pregunta).HasColumnName("id_pregunta");
            this.Property(t => t.anio_evaluacion).HasColumnName("anio_evaluacion");
            this.Property(t => t.mes_evaluacion).HasColumnName("mes_evaluacion");
            this.Property(t => t.fecha_evaluacion).HasColumnName("fecha_evaluacion");
            this.Property(t => t.puntaje).HasColumnName("puntaje");
            this.Property(t => t.comentario).HasColumnName("comentario");
            this.Property(t => t.fec_reg).HasColumnName("fec_reg");
            this.Property(t => t.fec_mod).HasColumnName("fec_mod");
            this.Property(t => t.usu_reg).HasColumnName("usu_reg");
            this.Property(t => t.usu_mod).HasColumnName("usu_mod");

            // Relationships
            //this.HasRequired(t => t.empleado)
            //    .WithMany(t => t.resultadoes)
            //    .HasForeignKey(d => d.id_empleado);
            //this.HasRequired(t => t.evaluador)
            //    .WithMany(t => t.resultadoes)
            //    .HasForeignKey(d => d.id_evaluador);
            //this.HasRequired(t => t.pregunta)
            //    .WithMany(t => t.resultadoes)
            //    .HasForeignKey(d => d.id_pregunta);

        }
    }
}
