namespace SAP.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<DIRECCION> DIRECCION { get; set; }
        public virtual DbSet<EMPLEADO> EMPLEADO { get; set; }
        public virtual DbSet<EMPRESA> EMPRESA { get; set; }
        public virtual DbSet<ESTADO_CIVIL> ESTADO_CIVIL { get; set; }
        public virtual DbSet<GENERO> GENERO { get; set; }
        public virtual DbSet<IDENTIFICACION> IDENTIFICACION { get; set; }
        public virtual DbSet<PAIS> PAIS { get; set; }
        public virtual DbSet<PERMISO> PERMISO { get; set; }
        public virtual DbSet<PERMITE> PERMITE { get; set; }
        public virtual DbSet<PROFESION> PROFESION { get; set; }
        public virtual DbSet<PUESTO> PUESTO { get; set; }
        public virtual DbSet<REGION> REGION { get; set; }
        public virtual DbSet<ROL> ROL { get; set; }
        public virtual DbSet<SUB_REGION> SUB_REGION { get; set; }
        public virtual DbSet<USUARIO> USUARIO { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DIRECCION>()
                .Property(e => e.DETALLE_DIRECCION)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLEADO>()
                .Property(e => e.CODIGO_EMPLEADO)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLEADO>()
                .Property(e => e.APELLIDO_MATERNO)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLEADO>()
                .Property(e => e.APELLIDO_PATERNO)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLEADO>()
                .Property(e => e.PRIMER_NOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLEADO>()
                .Property(e => e.SEGUNDO_NOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLEADO>()
                .Property(e => e.DUI)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLEADO>()
                .Property(e => e.PASAPORTE)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLEADO>()
                .Property(e => e.NIT)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLEADO>()
                .Property(e => e.ISSS)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLEADO>()
                .Property(e => e.NUP)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLEADO>()
                .Property(e => e.SALARIO_BASE)
                .HasPrecision(8, 2);

            modelBuilder.Entity<EMPLEADO>()
                .Property(e => e.CORREO_PERSONAL)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLEADO>()
                .Property(e => e.CORREO_INSTITUCIONAL)
                .IsUnicode(false);

            modelBuilder.Entity<EMPRESA>()
                .Property(e => e.NOMBRE_EMPRESA)
                .IsUnicode(false);

            modelBuilder.Entity<EMPRESA>()
                .Property(e => e.DIRECCION)
                .IsUnicode(false);

            modelBuilder.Entity<EMPRESA>()
                .Property(e => e.REPRESENTANTE)
                .IsUnicode(false);

            modelBuilder.Entity<EMPRESA>()
                .Property(e => e.NIT_EMPRESA)
                .IsUnicode(false);

            modelBuilder.Entity<EMPRESA>()
                .Property(e => e.NIC)
                .IsUnicode(false);

            modelBuilder.Entity<EMPRESA>()
                .Property(e => e.TELEFONO_EMPRESA)
                .IsUnicode(false);

            modelBuilder.Entity<EMPRESA>()
                .Property(e => e.PAGINA_WEB)
                .IsUnicode(false);

            modelBuilder.Entity<EMPRESA>()
                .Property(e => e.CORREO_EMPRESA)
                .IsUnicode(false);

            modelBuilder.Entity<EMPRESA>()
                .Property(e => e.PAGE)
                .IsUnicode(false);

            modelBuilder.Entity<ESTADO_CIVIL>()
                .Property(e => e.NOMBRE_ESTADO_CIVIL)
                .IsUnicode(false);

            modelBuilder.Entity<GENERO>()
                .Property(e => e.NOMBRE_GENERO)
                .IsUnicode(false);

            modelBuilder.Entity<IDENTIFICACION>()
                .Property(e => e.NOMBRE_IDENTIFICACION)
                .IsUnicode(false);

            modelBuilder.Entity<PAIS>()
                .Property(e => e.CODIGO_PAIS)
                .IsUnicode(false);

            modelBuilder.Entity<PAIS>()
                .Property(e => e.NOMBRE_PAIS)
                .IsUnicode(false);

            modelBuilder.Entity<PERMISO>()
                .Property(e => e.NOMBRE_PERMISO)
                .IsUnicode(false);

            modelBuilder.Entity<PERMISO>()
                .Property(e => e.DESCRIPCION_PERMISO)
                .IsUnicode(false);

            modelBuilder.Entity<PROFESION>()
                .Property(e => e.NOMBRE_PROFESION)
                .IsUnicode(false);

            modelBuilder.Entity<PUESTO>()
                .Property(e => e.CODIGO_PUESTO)
                .IsUnicode(false);

            modelBuilder.Entity<PUESTO>()
                .Property(e => e.NOMBRE_PUESTO)
                .IsUnicode(false);

            modelBuilder.Entity<PUESTO>()
                .Property(e => e.SALARIO_MINIMO)
                .HasPrecision(8, 2);

            modelBuilder.Entity<PUESTO>()
                .Property(e => e.SALARIO_MAXIMO)
                .HasPrecision(8, 2);

            modelBuilder.Entity<REGION>()
                .Property(e => e.CODIGO_REGION)
                .IsUnicode(false);

            modelBuilder.Entity<REGION>()
                .Property(e => e.NOMBRE_REGION)
                .IsUnicode(false);

            modelBuilder.Entity<ROL>()
                .Property(e => e.NOMBRE_ROL)
                .IsUnicode(false);

            modelBuilder.Entity<ROL>()
                .Property(e => e.DESCRIPCION_ROL)
                .IsUnicode(false);

            modelBuilder.Entity<SUB_REGION>()
                .Property(e => e.CODIGO_SUB_REGION)
                .IsUnicode(false);

            modelBuilder.Entity<SUB_REGION>()
                .Property(e => e.NOMBRE_SUB_REGION)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.EMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.PASSWORD)
                .IsUnicode(false);
        }
    }
}
