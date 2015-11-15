using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Metricaencuesta.Models.Mapping
{
    public class gpreguntaMap : EntityTypeConfiguration<gpregunta>
    {
        public gpreguntaMap()
        {
            // Primary Key
            this.HasKey(t => t.id_gpregunta);

            // Properties
            this.Property(t => t.descripcion)
                .IsRequired()
                .HasMaxLength(250);

            this.Property(t => t.estado)
                .IsFixedLength()
                .HasMaxLength(1);

            this.Property(t => t.usu_reg)
                .HasMaxLength(30);

            this.Property(t => t.usu_mod)
                .HasMaxLength(30);

            // Table & Column Mappings
            this.ToTable("gpreguntas");
            this.Property(t => t.id_gpregunta).HasColumnName("id_gpregunta");
            this.Property(t => t.descripcion).HasColumnName("descripcion");
            this.Property(t => t.estado).HasColumnName("estado");
            this.Property(t => t.fec_reg).HasColumnName("fec_reg");
            this.Property(t => t.fec_mod).HasColumnName("fec_mod");
            this.Property(t => t.usu_reg).HasColumnName("usu_reg");
            this.Property(t => t.usu_mod).HasColumnName("usu_mod");
        }
    }
}
