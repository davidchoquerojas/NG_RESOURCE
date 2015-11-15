using System.Data.Entity.ModelConfiguration;

namespace Metricaencuesta.Models.Mapping
{
    public class empleadoMap : EntityTypeConfiguration<empleado>
    {
        public empleadoMap()
        {
            // Primary Key
            this.HasKey(t => t.id_empleado);

            // Properties
            this.Property(t => t.dni)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(8);

            this.Property(t => t.nombres)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.apellidos)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.telefono)
                .HasMaxLength(15);

            this.Property(t => t.correo)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.usuario)
                .IsRequired()
                .HasMaxLength(30);

            this.Property(t => t.password)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.tipo_usuario)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(3);

            this.Property(t => t.estado)
                .IsFixedLength()
                .HasMaxLength(1);

            this.Property(t => t.usu_reg)
                .IsRequired()
                .HasMaxLength(30);

            this.Property(t => t.usu_mod)
                .HasMaxLength(30);

            // Table & Column Mappings
            this.ToTable("empleados");
            this.Property(t => t.id_empleado).HasColumnName("id_empleado");
            this.Property(t => t.dni).HasColumnName("dni");
            this.Property(t => t.nombres).HasColumnName("nombres");
            this.Property(t => t.apellidos).HasColumnName("apellidos");
            this.Property(t => t.telefono).HasColumnName("telefono");
            this.Property(t => t.correo).HasColumnName("correo");
            this.Property(t => t.usuario).HasColumnName("usuario");
            this.Property(t => t.password).HasColumnName("password");
            this.Property(t => t.tipo_usuario).HasColumnName("tipo_usuario");
            this.Property(t => t.foto).HasColumnName("foto");
            this.Property(t => t.curri_file).HasColumnName("curri_file");
            this.Property(t => t.hora_ingreso).HasColumnName("hora_ingreso");
            this.Property(t => t.estado).HasColumnName("estado");
            this.Property(t => t.fec_reg).HasColumnName("fec_reg");
            this.Property(t => t.fec_mod).HasColumnName("fec_mod");
            this.Property(t => t.usu_reg).HasColumnName("usu_reg");
            this.Property(t => t.usu_mod).HasColumnName("usu_mod");
            /*--DRIVERA Ini--*/
            this.Property(t => t.hora_salida).HasColumnName("hora_salida");
            /*--DRIVERA Fin--*/
        }
    }
}
