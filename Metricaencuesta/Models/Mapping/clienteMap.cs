using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Metricaencuesta.Models.Mapping
{
    public class clienteMap : EntityTypeConfiguration<cliente>
    {
        public clienteMap()
        {
            // Primary Key
            this.HasKey(t => t.id_cliente);

            // Properties
            this.Property(t => t.razon_social)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.ruc)
                .IsRequired()
                .HasMaxLength(11);

            this.Property(t => t.telefono)
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
            this.ToTable("clientes");
            this.Property(t => t.id_cliente).HasColumnName("id_cliente");
            this.Property(t => t.razon_social).HasColumnName("razon_social");
            this.Property(t => t.ruc).HasColumnName("ruc");
            this.Property(t => t.telefono).HasColumnName("telefono");
            this.Property(t => t.latitud).HasColumnName("latitud");
            this.Property(t => t.longitud).HasColumnName("longitud");
            this.Property(t => t.estado).HasColumnName("estado");
            this.Property(t => t.fec_reg).HasColumnName("fec_reg");
            this.Property(t => t.fec_mod).HasColumnName("fec_mod");
            this.Property(t => t.usu_reg).HasColumnName("usu_reg");
            this.Property(t => t.usu_mod).HasColumnName("usu_mod");
        }
    }
}
