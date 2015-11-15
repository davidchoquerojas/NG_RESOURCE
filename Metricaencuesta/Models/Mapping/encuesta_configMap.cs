using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;


namespace Metricaencuesta.Models.Mapping
{
    public class encuesta_configMap : EntityTypeConfiguration<encuesta_config>
    {
        public encuesta_configMap()
        {
            // Primary Key
            this.HasKey(t => t.id_encuesta);

            // Properties
            this.Property(t => t.estado)
                .IsFixedLength()
                .HasMaxLength(1);

            this.Property(t => t.usu_mod)
                .IsRequired()
                .HasMaxLength(30);

            this.Property(t => t.usu_reg)
                .HasMaxLength(30);

            // Table & Column Mappings
            this.ToTable("encuesta_config");
            this.Property(t => t.id_encuesta).HasColumnName("id_encuesta");
            this.Property(t => t.fecha_ini).HasColumnName("fecha_ini");
            this.Property(t => t.fecha_fin).HasColumnName("fecha_fin");
            this.Property(t => t.estado).HasColumnName("estado");
            this.Property(t => t.fec_reg).HasColumnName("fec_reg");
            this.Property(t => t.fec_mod).HasColumnName("fec_mod");
            this.Property(t => t.usu_mod).HasColumnName("usu_mod");
            this.Property(t => t.usu_reg).HasColumnName("usu_reg");
        }
    }
}
