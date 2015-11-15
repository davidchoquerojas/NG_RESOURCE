using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Metricaencuesta.Models.Mapping
{
    public class preguntaMap : EntityTypeConfiguration<pregunta>
    {
        public preguntaMap()
        {
            // Primary Key
            this.HasKey(t => t.id_pregunta);

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
            this.ToTable("preguntas");
            this.Property(t => t.id_pregunta).HasColumnName("id_pregunta");
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
