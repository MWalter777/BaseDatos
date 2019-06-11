namespace SAP.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=DefaultConnection")
        {
        }

        public virtual DbSet<ACCEDE> ACCEDE { get; set; }
        public virtual DbSet<DEPARTAMENTO> DEPARTAMENTO { get; set; }
        public virtual DbSet<DIRECCION> DIRECCION { get; set; }
        public virtual DbSet<EMPRESA> EMPRESA { get; set; }
        public virtual DbSet<ESTADO_CIVIL> ESTADO_CIVIL { get; set; }
        public virtual DbSet<GENERO> GENERO { get; set; }
        public virtual DbSet<MENU> MENU { get; set; }
        public virtual DbSet<PAIS> PAIS { get; set; }
        public virtual DbSet<PERMISO> PERMISO { get; set; }
        public virtual DbSet<PERMITE> PERMITE { get; set; }
        public virtual DbSet<PROFESION> PROFESION { get; set; }
        public virtual DbSet<PUESTO> PUESTO { get; set; }
        public virtual DbSet<REGION> REGION { get; set; }
        public virtual DbSet<ROL> ROL { get; set; }
        public virtual DbSet<SUB_REGION> SUB_REGION { get; set; }
        public virtual DbSet<USUARIO> USUARIO { get; set; }



        public virtual DbSet<CATALOGO_DESCUENTO> CATALOGO_DESCUENTO { get; set; }
        public virtual DbSet<CATALOGO_INGRESO> CATALOGO_INGRESO { get; set; }
        public virtual DbSet<CENTRO_COSTO> CENTRO_COSTO { get; set; }
        public virtual DbSet<DESCUENTO_EMPLEADO> DESCUENTO_EMPLEADO { get; set; }
        public virtual DbSet<DESCUENTO_RENTA> DESCUENTO_RENTA { get; set; }
        public virtual DbSet<DETALLEPLANILLA> DETALLEPLANILLA { get; set; }
        public virtual DbSet<EMPLEADO> EMPLEADO { get; set; }
        public virtual DbSet<INGRESO_EMPLEADO> INGRESO_EMPLEADO { get; set; }
        public virtual DbSet<PERIODICIDAD_ANUAL> PERIODICIDAD_ANUAL { get; set; }
        public virtual DbSet<PLANILLA> PLANILLA { get; set; }
        public virtual DbSet<RANGO_COMISION> RANGO_COMISION { get; set; }
        public virtual DbSet<SALARIO_MINIMO> SALARIO_MINIMO { get; set; }


        public virtual DbSet<DESCUENTO> DESCUENTO { get; set; }
        public virtual DbSet<HISTORIAL> HISTORIAL { get; set; }
        public virtual DbSet<INGRESO> INGRESO { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DEPARTAMENTO>()
                .Property(e => e.NOMBRE_DEPARTAMENTO)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTAMENTO>()
                .HasMany(e => e.DEPARTAMENTO1)
                .WithOptional(e => e.DEPARTAMENTO2)
                .HasForeignKey(e => e.DEP_ID_DEPARTAMENTO);

            modelBuilder.Entity<DEPARTAMENTO>()
                .HasMany(e => e.PUESTO)
                .WithRequired(e => e.DEPARTAMENTO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DIRECCION>()
                .Property(e => e.BARRIO)
                .IsUnicode(false);

            modelBuilder.Entity<DIRECCION>()
                .Property(e => e.COLONIA)
                .IsUnicode(false);

            modelBuilder.Entity<DIRECCION>()
                .Property(e => e.CANTON)
                .IsUnicode(false);

            modelBuilder.Entity<DIRECCION>()
                .Property(e => e.CASERIO)
                .IsUnicode(false);

            modelBuilder.Entity<DIRECCION>()
                .Property(e => e.CALLE)
                .IsUnicode(false);

            modelBuilder.Entity<DIRECCION>()
                .Property(e => e.AVENIDA)
                .IsUnicode(false);

            modelBuilder.Entity<DIRECCION>()
                .Property(e => e.PASAJE)
                .IsUnicode(false);

            modelBuilder.Entity<DIRECCION>()
                .Property(e => e.RESIDENCIAL)
                .IsUnicode(false);

            modelBuilder.Entity<DIRECCION>()
                .Property(e => e.NUMERO_CASA)
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
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<EMPRESA>()
                .Property(e => e.NIC)
                .IsUnicode(false);

            modelBuilder.Entity<EMPRESA>()
                .Property(e => e.TELEFONO_EMPRESA)
                .IsFixedLength()
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

            modelBuilder.Entity<EMPRESA>()
                .HasMany(e => e.DEPARTAMENTO)
                .WithRequired(e => e.EMPRESA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ESTADO_CIVIL>()
                .Property(e => e.NOMBRE_ESTADO_CIVIL)
                .IsUnicode(false);


            modelBuilder.Entity<GENERO>()
                .Property(e => e.NOMBRE_GENERO)
                .IsUnicode(false);


            modelBuilder.Entity<MENU>()
                .Property(e => e.NOMBRE_MENU)
                .IsUnicode(false);

            modelBuilder.Entity<MENU>()
                .Property(e => e.URL)
                .IsUnicode(false);

            modelBuilder.Entity<MENU>()
                .HasMany(e => e.MENU1)
                .WithOptional(e => e.MENU2)
                .HasForeignKey(e => e.MEN_ID_MENU);

            modelBuilder.Entity<PAIS>()
                .Property(e => e.CODIGO_PAIS)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PAIS>()
                .Property(e => e.NOMBRE_PAIS)
                .IsUnicode(false);

            modelBuilder.Entity<PAIS>()
                .HasMany(e => e.REGION)
                .WithRequired(e => e.PAIS)
                .WillCascadeOnDelete(false);

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

            modelBuilder.Entity<REGION>()
                .HasMany(e => e.SUB_REGION)
                .WithRequired(e => e.REGION)
                .WillCascadeOnDelete(false);

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

            modelBuilder.Entity<SUB_REGION>()
                .HasMany(e => e.DIRECCION)
                .WithRequired(e => e.SUB_REGION)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.EMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.USERNAME)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.PASSWORD)
                .IsUnicode(false);
            modelBuilder.Entity<CATALOGO_DESCUENTO>()
    .Property(e => e.NOMBRE_DESCUENTO)
    .IsUnicode(false);

            modelBuilder.Entity<CATALOGO_DESCUENTO>()
                .Property(e => e.PORCENTAJE)
                .HasPrecision(2, 2);

            modelBuilder.Entity<CATALOGO_DESCUENTO>()
                .Property(e => e.DESCUENTO)
                .HasPrecision(8, 2);

            modelBuilder.Entity<CATALOGO_INGRESO>()
                .Property(e => e.NOMBRE_INGRESO)
                .IsUnicode(false);

            modelBuilder.Entity<CATALOGO_INGRESO>()
                .Property(e => e.INGRESO)
                .HasPrecision(8, 2);

            modelBuilder.Entity<CENTRO_COSTO>()
                .Property(e => e.MONTO_ASIGNADO)
                .HasPrecision(8, 2);

            modelBuilder.Entity<CENTRO_COSTO>()
                .Property(e => e.SALDO)
                .HasPrecision(8, 2);

            modelBuilder.Entity<DESCUENTO_RENTA>()
                .Property(e => e.MIN_RENTA)
                .HasPrecision(8, 2);

            modelBuilder.Entity<DESCUENTO_RENTA>()
                .Property(e => e.MAX_RENTA)
                .HasPrecision(8, 2);

            modelBuilder.Entity<DESCUENTO_RENTA>()
                .Property(e => e.PORCENTAJE_RENTA)
                .HasPrecision(8, 2);

            modelBuilder.Entity<DETALLEPLANILLA>()
                .Property(e => e.SALARIO)
                .HasPrecision(8, 2);

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
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<EMPLEADO>()
                .Property(e => e.PASAPORTE)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLEADO>()
                .Property(e => e.NIT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<EMPLEADO>()
                .Property(e => e.ISSS)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<EMPLEADO>()
                .Property(e => e.NUP)
                .IsFixedLength()
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

            modelBuilder.Entity<PLANILLA>()
                .Property(e => e.CODIGO_PLANILLA)
                .IsUnicode(false);

            modelBuilder.Entity<PLANILLA>()
                .Property(e => e.TOTAL_INGRESOS)
                .HasPrecision(8, 2);

            modelBuilder.Entity<PLANILLA>()
                .Property(e => e.TOTAL_DESCUENTOS)
                .HasPrecision(8, 2);

            modelBuilder.Entity<PLANILLA>()
                .Property(e => e.TOTAL_PAGAR)
                .HasPrecision(10, 2);

            modelBuilder.Entity<RANGO_COMISION>()
                .Property(e => e.MIN_COMISION)
                .HasPrecision(8, 2);

            modelBuilder.Entity<RANGO_COMISION>()
                .Property(e => e.MAX_COMISION)
                .HasPrecision(8, 2);

            modelBuilder.Entity<RANGO_COMISION>()
                .Property(e => e.PORCENTAJE_POR_COMISION)
                .HasPrecision(8, 2);

            modelBuilder.Entity<SALARIO_MINIMO>()
                .Property(e => e.MONTO_SALARIO_MINIMO)
                .HasPrecision(8, 2);
            modelBuilder.Entity<DESCUENTO>()
    .Property(e => e.NOMBRE_DESCUENTO_HISTORIAL)
    .IsUnicode(false);

            modelBuilder.Entity<DESCUENTO>()
                .Property(e => e.DESCUENTO_HISTORIAL)
                .HasPrecision(8, 2);

            modelBuilder.Entity<HISTORIAL>()
                .Property(e => e.NOMBRE_EMPLEADO_HISTORIAL)
                .IsUnicode(false);

            modelBuilder.Entity<HISTORIAL>()
                .Property(e => e.TOTAL)
                .HasPrecision(8, 2);

            modelBuilder.Entity<HISTORIAL>()
                .Property(e => e.CODIGO_EMPLEADO)
                .IsUnicode(false);

            modelBuilder.Entity<INGRESO>()
                .Property(e => e.NOMBRE_INGRESO_HISTORIAL)
                .IsUnicode(false);

            modelBuilder.Entity<INGRESO>()
                .Property(e => e.INGRESO_HISTORIAL)
                .HasPrecision(8, 2);
        }
    }
}
