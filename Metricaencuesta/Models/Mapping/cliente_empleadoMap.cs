using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Metricaencuesta.Models.Mapping
{
    public class cliente_empleadoMap : EntityTypeConfiguration<cliente_empleado>
    {
        public cliente_empleadoMap()
        {
            // Primary Key
            this.HasKey(t => t.id_cliemp);

            //this.HasKey(t => new { t.id_cliente, t.id_empleado });

            // Properties
            this.Property(t => t.id_cliente)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.id_empleado)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("cliente_empleado");
            this.Property(t => t.id_cliemp).HasColumnName("id_cliemp");
            this.Property(t => t.id_cliente).HasColumnName("id_cliente");
            this.Property(t => t.id_empleado).HasColumnName("id_empleado");
            this.Property(t => t.id_evaluador).HasColumnName("id_evaluador");

            // Relationships
            //this.HasRequired(t => t.cliente)
            //    .WithMany(t => t.cliente_empleado)
            //    .HasForeignKey(d => d.id_cliente);
            //this.HasRequired(t => t.empleado)
            //    .WithMany(t => t.cliente_empleado)
            //    .HasForeignKey(d => d.id_empleado);
            //this.HasOptional(t => t.evaluador)
            //    .WithMany(t => t.cliente_empleado)
            //    .HasForeignKey(d => d.id_evaluador);

        }
    }
}
