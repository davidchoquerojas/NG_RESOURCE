using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Metricaencuesta.Models.Mapping
{
    public class evaluadorMap : EntityTypeConfiguration<evaluador>
    {
        public evaluadorMap()
        {
            // Primary Key
            this.HasKey(t => t.id_evaluador);

            // Properties
            this.Property(t => t.nombres)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.apellidos)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.cargo)
                .HasMaxLength(30);

            this.Property(t => t.email)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.usuario)
                .HasMaxLength(30);

            this.Property(t => t.password)
                .HasMaxLength(100);

            this.Property(t => t.estado)
                .IsFixedLength()
                .HasMaxLength(1);

            this.Property(t => t.usu_reg)
                .HasMaxLength(30);

            this.Property(t => t.usu_mod)
                .HasMaxLength(30);

            // Table & Column Mappings
            this.ToTable("evaluadors");
            this.Property(t => t.id_evaluador).HasColumnName("id_evaluador");
            this.Property(t => t.nombres).HasColumnName("nombres");
            this.Property(t => t.apellidos).HasColumnName("apellidos");
            this.Property(t => t.cargo).HasColumnName("cargo");
            this.Property(t => t.email).HasColumnName("email");
            this.Property(t => t.usuario).HasColumnName("usuario");
            this.Property(t => t.password).HasColumnName("password");
            this.Property(t => t.estado).HasColumnName("estado");
            this.Property(t => t.fec_reg).HasColumnName("fec_reg");
            this.Property(t => t.fec_mod).HasColumnName("fec_mod");
            this.Property(t => t.usu_reg).HasColumnName("usu_reg");
            this.Property(t => t.usu_mod).HasColumnName("usu_mod");
        }
    }
}
