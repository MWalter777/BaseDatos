/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2008                    */
/* Created on:     4/6/2019 07:49:09                            */
/*==============================================================*/


if exists (select 1
            from  sysindexes
           where  id    = object_id('ACCEDE')
            and   name  = 'ACCEDE2_FK'
            and   indid > 0
            and   indid < 255)
   drop index ACCEDE.ACCEDE2_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ACCEDE')
            and   name  = 'ACCEDE_FK'
            and   indid > 0
            and   indid < 255)
   drop index ACCEDE.ACCEDE_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ACCEDE')
            and   type = 'U')
   drop table ACCEDE
go

if exists (select 1
            from  sysobjects
           where  id = object_id('CATALOGO_DESCUENTO')
            and   type = 'U')
   drop table CATALOGO_DESCUENTO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('CATALOGO_INGRESO')
            and   type = 'U')
   drop table CATALOGO_INGRESO
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('CENTRO_COSTO')
            and   name  = 'ASIGNADO_FK'
            and   indid > 0
            and   indid < 255)
   drop index CENTRO_COSTO.ASIGNADO_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('CENTRO_COSTO')
            and   type = 'U')
   drop table CENTRO_COSTO
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('DEPARTAMENTO')
            and   name  = 'CONSTITUIDA_FK'
            and   indid > 0
            and   indid < 255)
   drop index DEPARTAMENTO.CONSTITUIDA_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('DEPARTAMENTO')
            and   name  = 'COMPUESTO_POR_FK'
            and   indid > 0
            and   indid < 255)
   drop index DEPARTAMENTO.COMPUESTO_POR_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('DEPARTAMENTO')
            and   type = 'U')
   drop table DEPARTAMENTO
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('DESCUENTO_EMPLEADO')
            and   name  = 'SE_DESCU_FK'
            and   indid > 0
            and   indid < 255)
   drop index DESCUENTO_EMPLEADO.SE_DESCU_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('DESCUENTO_EMPLEADO')
            and   name  = 'DESCUENTA_FK'
            and   indid > 0
            and   indid < 255)
   drop index DESCUENTO_EMPLEADO.DESCUENTA_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('DESCUENTO_EMPLEADO')
            and   type = 'U')
   drop table DESCUENTO_EMPLEADO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('DESCUENTO_RENTA')
            and   type = 'U')
   drop table DESCUENTO_RENTA
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('DETALLEPLANILLA')
            and   name  = 'TIENE_MUCHOS_DETALLES_FK'
            and   indid > 0
            and   indid < 255)
   drop index DETALLEPLANILLA.TIENE_MUCHOS_DETALLES_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('DETALLEPLANILLA')
            and   name  = 'INGRESOS_TIENE_DETALLES_FK'
            and   indid > 0
            and   indid < 255)
   drop index DETALLEPLANILLA.INGRESOS_TIENE_DETALLES_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('DETALLEPLANILLA')
            and   name  = 'DESCUENTOS_TIENE_DETALLES_FK'
            and   indid > 0
            and   indid < 255)
   drop index DETALLEPLANILLA.DESCUENTOS_TIENE_DETALLES_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('DETALLEPLANILLA')
            and   type = 'U')
   drop table DETALLEPLANILLA
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('DIRECCION')
            and   name  = 'TIENE_UNA_FK'
            and   indid > 0
            and   indid < 255)
   drop index DIRECCION.TIENE_UNA_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('DIRECCION')
            and   type = 'U')
   drop table DIRECCION
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('EMPLEADO')
            and   name  = 'A_CARGO_DE_FK'
            and   indid > 0
            and   indid < 255)
   drop index EMPLEADO.A_CARGO_DE_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('EMPLEADO')
            and   name  = 'TRABAJA_EN_FK'
            and   indid > 0
            and   indid < 255)
   drop index EMPLEADO.TRABAJA_EN_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('EMPLEADO')
            and   name  = 'EJERCE_FK'
            and   indid > 0
            and   indid < 255)
   drop index EMPLEADO.EJERCE_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('EMPLEADO')
            and   name  = 'VIVE_EN_FK'
            and   indid > 0
            and   indid < 255)
   drop index EMPLEADO.VIVE_EN_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('EMPLEADO')
            and   name  = 'TIENE_UN_FK'
            and   indid > 0
            and   indid < 255)
   drop index EMPLEADO.TIENE_UN_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('EMPLEADO')
            and   name  = 'POSEE_FK'
            and   indid > 0
            and   indid < 255)
   drop index EMPLEADO.POSEE_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('EMPLEADO')
            and   type = 'U')
   drop table EMPLEADO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('EMPRESA')
            and   type = 'U')
   drop table EMPRESA
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ESTADO_CIVIL')
            and   type = 'U')
   drop table ESTADO_CIVIL
go

if exists (select 1
            from  sysobjects
           where  id = object_id('GENERO')
            and   type = 'U')
   drop table GENERO
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('INGRESO_EMPLEADO')
            and   name  = 'SE_AGREGA_FK'
            and   indid > 0
            and   indid < 255)
   drop index INGRESO_EMPLEADO.SE_AGREGA_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('INGRESO_EMPLEADO')
            and   name  = 'AGREGA_FK'
            and   indid > 0
            and   indid < 255)
   drop index INGRESO_EMPLEADO.AGREGA_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('INGRESO_EMPLEADO')
            and   type = 'U')
   drop table INGRESO_EMPLEADO
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('MENU')
            and   name  = 'CONTIENE_FK'
            and   indid > 0
            and   indid < 255)
   drop index MENU.CONTIENE_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('MENU')
            and   type = 'U')
   drop table MENU
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PAIS')
            and   type = 'U')
   drop table PAIS
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PERIODICIDAD_ANUAL')
            and   type = 'U')
   drop table PERIODICIDAD_ANUAL
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PERMISO')
            and   type = 'U')
   drop table PERMISO
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('PERMITE')
            and   name  = 'PERMITE2_FK'
            and   indid > 0
            and   indid < 255)
   drop index PERMITE.PERMITE2_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('PERMITE')
            and   name  = 'PERMITE_FK'
            and   indid > 0
            and   indid < 255)
   drop index PERMITE.PERMITE_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PERMITE')
            and   type = 'U')
   drop table PERMITE
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PLANILLA')
            and   type = 'U')
   drop table PLANILLA
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PROFESION')
            and   type = 'U')
   drop table PROFESION
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('PUESTO')
            and   name  = 'TIENE__FK'
            and   indid > 0
            and   indid < 255)
   drop index PUESTO.TIENE__FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PUESTO')
            and   type = 'U')
   drop table PUESTO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('RANGO_COMISION')
            and   type = 'U')
   drop table RANGO_COMISION
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('REGION')
            and   name  = 'TIENE_REGIONES_FK'
            and   indid > 0
            and   indid < 255)
   drop index REGION.TIENE_REGIONES_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('REGION')
            and   type = 'U')
   drop table REGION
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ROL')
            and   type = 'U')
   drop table ROL
go

if exists (select 1
            from  sysobjects
           where  id = object_id('SALARIO_MINIMO')
            and   type = 'U')
   drop table SALARIO_MINIMO
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('SUB_REGION')
            and   name  = 'TIENE_SUB_REGIONES_FK'
            and   indid > 0
            and   indid < 255)
   drop index SUB_REGION.TIENE_SUB_REGIONES_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('SUB_REGION')
            and   type = 'U')
   drop table SUB_REGION
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('USUARIO')
            and   name  = 'TIENE_FK'
            and   indid > 0
            and   indid < 255)
   drop index USUARIO.TIENE_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('USUARIO')
            and   name  = 'ES_FK'
            and   indid > 0
            and   indid < 255)
   drop index USUARIO.ES_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('USUARIO')
            and   type = 'U')
   drop table USUARIO
go

/*==============================================================*/
/* Table: ACCEDE                                                */
/*==============================================================*/
create table ACCEDE (
   ID_ROL               int                  not null,
   ID_MENU              int                  not null,
   constraint PK_ACCEDE primary key (ID_ROL, ID_MENU)
)
go

/*==============================================================*/
/* Index: ACCEDE_FK                                             */
/*==============================================================*/
create index ACCEDE_FK on ACCEDE (
ID_ROL ASC
)
go

/*==============================================================*/
/* Index: ACCEDE2_FK                                            */
/*==============================================================*/
create index ACCEDE2_FK on ACCEDE (
ID_MENU ASC
)
go

/*==============================================================*/
/* Table: CATALOGO_DESCUENTO                                    */
/*==============================================================*/
create table CATALOGO_DESCUENTO (
   ID_DESCUENTO         int                  not null identity(1,1),
   NOMBRE_DESCUENTO     varchar(75)          not null,
   DELEY_DESCUENTO      bit                  not null,
   constraint PK_CATALOGO_DESCUENTO primary key nonclustered (ID_DESCUENTO)
)
go

/*==============================================================*/
/* Table: CATALOGO_INGRESO                                      */
/*==============================================================*/
create table CATALOGO_INGRESO (
   ID_INGRESO           int                  not null identity(1,1),
   NOMBRE_INGRESO       varchar(75)          not null,
   DELEY_INGRESO        bit                  not null,
   constraint PK_CATALOGO_INGRESO primary key nonclustered (ID_INGRESO)
)
go

/*==============================================================*/
/* Table: CENTRO_COSTO                                          */
/*==============================================================*/
create table CENTRO_COSTO (
   ID_CENTRO_COSTO      int                  not null identity(1,1),
   ID_DEPARTAMENTO      int                  not null,
   ANIO                 int                  not null,
   MONTO_ASIGNADO       decimal(8,2)         not null,
   SALDO                decimal(8,2)         not null,
   constraint PK_CENTRO_COSTO primary key nonclustered (ID_CENTRO_COSTO)
)
go

/*==============================================================*/
/* Index: ASIGNADO_FK                                           */
/*==============================================================*/
create index ASIGNADO_FK on CENTRO_COSTO (
ID_DEPARTAMENTO ASC
)
go

/*==============================================================*/
/* Table: DEPARTAMENTO                                          */
/*==============================================================*/
create table DEPARTAMENTO (
   ID_DEPARTAMENTO      int                  not null identity(1,1),
   ID_EMPRESA           int                  not null,
   DEP_ID_DEPARTAMENTO  int                  null,
   NOMBRE_DEPARTAMENTO  varchar(60)          not null,
   constraint PK_DEPARTAMENTO primary key nonclustered (ID_DEPARTAMENTO)
)
go

/*==============================================================*/
/* Index: COMPUESTO_POR_FK                                      */
/*==============================================================*/
create index COMPUESTO_POR_FK on DEPARTAMENTO (
DEP_ID_DEPARTAMENTO ASC
)
go

/*==============================================================*/
/* Index: CONSTITUIDA_FK                                        */
/*==============================================================*/
create index CONSTITUIDA_FK on DEPARTAMENTO (
ID_EMPRESA ASC
)
go

/*==============================================================*/
/* Table: DESCUENTO_EMPLEADO                                    */
/*==============================================================*/
create table DESCUENTO_EMPLEADO (
   HABILITAR_DESCUENTO  bit                  not null,
   ID_DESCUENTO_EMPLEADO int                  not null identity(1,1),
   ID_EMPLEADO          int                  not null,
   ID_DESCUENTO         int                  not null,
   constraint PK_DESCUENTO_EMPLEADO primary key nonclustered (ID_DESCUENTO_EMPLEADO)
)
go

/*==============================================================*/
/* Index: DESCUENTA_FK                                          */
/*==============================================================*/
create index DESCUENTA_FK on DESCUENTO_EMPLEADO (
ID_DESCUENTO ASC
)
go

/*==============================================================*/
/* Index: SE_DESCU_FK                                           */
/*==============================================================*/
create index SE_DESCU_FK on DESCUENTO_EMPLEADO (
ID_EMPLEADO ASC
)
go

/*==============================================================*/
/* Table: DESCUENTO_RENTA                                       */
/*==============================================================*/
create table DESCUENTO_RENTA (
   ID_DESCUENTO_RENTA   int                  not null identity(1,1),
   MIN_RENTA            decimal(8,2)         not null,
   MAX_RENTA            decimal(8,2)         not null,
   PORCENTAJE_RENTA     decimal(8,2)         not null,
   constraint PK_DESCUENTO_RENTA primary key nonclustered (ID_DESCUENTO_RENTA)
)
go

/*==============================================================*/
/* Table: DETALLEPLANILLA                                       */
/*==============================================================*/
create table DETALLEPLANILLA (
   ID_DETALLE_PLANILLA  int                  not null identity(1,1),
   ID_INGRESO_EMPLEADO  int                  null,
   ID_PLANILLA          int                  not null,
   ID_DESCUENTO_EMPLEADO int                  null,
   constraint PK_DETALLEPLANILLA primary key nonclustered (ID_DETALLE_PLANILLA)
)
go

/*==============================================================*/
/* Index: DESCUENTOS_TIENE_DETALLES_FK                          */
/*==============================================================*/
create index DESCUENTOS_TIENE_DETALLES_FK on DETALLEPLANILLA (
ID_DESCUENTO_EMPLEADO ASC
)
go

/*==============================================================*/
/* Index: INGRESOS_TIENE_DETALLES_FK                            */
/*==============================================================*/
create index INGRESOS_TIENE_DETALLES_FK on DETALLEPLANILLA (
ID_INGRESO_EMPLEADO ASC
)
go

/*==============================================================*/
/* Index: TIENE_MUCHOS_DETALLES_FK                              */
/*==============================================================*/
create index TIENE_MUCHOS_DETALLES_FK on DETALLEPLANILLA (
ID_PLANILLA ASC
)
go

/*==============================================================*/
/* Table: DIRECCION                                             */
/*==============================================================*/
create table DIRECCION (
   ID_DIRECCION         int                  not null identity(1,1),
   ID_SUB_REGION        int                  not null,
   BARRIO               varchar(60)          null,
   COLONIA              varchar(60)          null,
   CANTON               varchar(60)          null,
   CASERIO              varchar(60)          null,
   CALLE                varchar(60)          null,
   AVENIDA              varchar(60)          null,
   PASAJE               varchar(60)          null,
   RESIDENCIAL          varchar(60)          null,
   NUMERO_CASA          varchar(60)          null,
   constraint PK_DIRECCION primary key nonclustered (ID_DIRECCION)
)
go

/*==============================================================*/
/* Index: TIENE_UNA_FK                                          */
/*==============================================================*/
create index TIENE_UNA_FK on DIRECCION (
ID_SUB_REGION ASC
)
go

/*==============================================================*/
/* Table: EMPLEADO                                              */
/*==============================================================*/
create table EMPLEADO (
   ID_EMPLEADO          int                  not null identity(1,1),
   ID_DIRECCION         int                  not null,
   EMP_ID_EMPLEADO      int                  null,
   ID_GENERO            int                  not null,
   ID_PROFESION         int                  null,
   ID_ESTADO_CIVIL      int                  not null,
   ID_PUESTO            int                  not null,
   CODIGO_EMPLEADO      varchar(25)          not null,
   APELLIDO_MATERNO     varchar(60)          null,
   APELLIDO_PATERNO     varchar(60)          not null,
   PRIMER_NOMBRE        varchar(60)          not null,
   SEGUNDO_NOMBRE       varchar(60)          null,
   FECHA_NACIMIENTO     datetime             not null,
   DUI                  char(10)             not null,
   PASAPORTE            varchar(20)          null,
   NIT                  char(17)             not null,
   ISSS                 char(9)              not null,
   NUP                  char(12)             not null,
   SALARIO_BASE         decimal(8,2)         not null,
   CORREO_PERSONAL      varchar(60)          not null,
   CORREO_INSTITUCIONAL varchar(60)          not null,
   constraint PK_EMPLEADO primary key nonclustered (ID_EMPLEADO)
)
go

/*==============================================================*/
/* Index: POSEE_FK                                              */
/*==============================================================*/
create index POSEE_FK on EMPLEADO (
ID_ESTADO_CIVIL ASC
)
go

/*==============================================================*/
/* Index: TIENE_UN_FK                                           */
/*==============================================================*/
create index TIENE_UN_FK on EMPLEADO (
ID_GENERO ASC
)
go

/*==============================================================*/
/* Index: VIVE_EN_FK                                            */
/*==============================================================*/
create index VIVE_EN_FK on EMPLEADO (
ID_DIRECCION ASC
)
go

/*==============================================================*/
/* Index: EJERCE_FK                                             */
/*==============================================================*/
create index EJERCE_FK on EMPLEADO (
ID_PROFESION ASC
)
go

/*==============================================================*/
/* Index: TRABAJA_EN_FK                                         */
/*==============================================================*/
create index TRABAJA_EN_FK on EMPLEADO (
ID_PUESTO ASC
)
go

/*==============================================================*/
/* Index: A_CARGO_DE_FK                                         */
/*==============================================================*/
create index A_CARGO_DE_FK on EMPLEADO (
EMP_ID_EMPLEADO ASC
)
go

/*==============================================================*/
/* Table: EMPRESA                                               */
/*==============================================================*/
create table EMPRESA (
   ID_EMPRESA           int                  not null identity(1,1),
   NOMBRE_EMPRESA       varchar(100)         not null,
   DIRECCION            varchar(250)         not null,
   REPRESENTANTE        varchar(60)          not null,
   NIT_EMPRESA          char(17)             not null,
   NIC                  varchar(15)          not null,
   TELEFONO_EMPRESA     char(9)              not null,
   PAGINA_WEB           varchar(100)         null,
   CORREO_EMPRESA       varchar(60)          not null,
   PAGE                 varchar(60)          null,
   constraint PK_EMPRESA primary key nonclustered (ID_EMPRESA)
)
go

/*==============================================================*/
/* Table: ESTADO_CIVIL                                          */
/*==============================================================*/
create table ESTADO_CIVIL (
   ID_ESTADO_CIVIL      int                  not null identity(1,1),
   NOMBRE_ESTADO_CIVIL  varchar(25)          not null,
   constraint PK_ESTADO_CIVIL primary key nonclustered (ID_ESTADO_CIVIL)
)
go

/*==============================================================*/
/* Table: GENERO                                                */
/*==============================================================*/
create table GENERO (
   ID_GENERO            int                  not null identity(1,1),
   NOMBRE_GENERO        varchar(50)          not null,
   constraint PK_GENERO primary key nonclustered (ID_GENERO)
)
go

/*==============================================================*/
/* Table: INGRESO_EMPLEADO                                      */
/*==============================================================*/
create table INGRESO_EMPLEADO (
   HABILITAR_INGRESO    bit                  not null,
   ID_INGRESO_EMPLEADO  int                  not null identity(1,1),
   ID_INGRESO           int                  not null,
   ID_EMPLEADO          int                  not null,
   constraint PK_INGRESO_EMPLEADO primary key nonclustered (ID_INGRESO_EMPLEADO)
)
go

/*==============================================================*/
/* Index: AGREGA_FK                                             */
/*==============================================================*/
create index AGREGA_FK on INGRESO_EMPLEADO (
ID_INGRESO ASC
)
go

/*==============================================================*/
/* Index: SE_AGREGA_FK                                          */
/*==============================================================*/
create index SE_AGREGA_FK on INGRESO_EMPLEADO (
ID_EMPLEADO ASC
)
go

/*==============================================================*/
/* Table: MENU                                                  */
/*==============================================================*/
create table MENU (
   ID_MENU              int                  not null identity(1,1),
   MEN_ID_MENU          int                  null,
   NOMBRE_MENU          varchar(50)          not null,
   URL                  varchar(70)          null,
   constraint PK_MENU primary key nonclustered (ID_MENU)
)
go

/*==============================================================*/
/* Index: CONTIENE_FK                                           */
/*==============================================================*/
create index CONTIENE_FK on MENU (
MEN_ID_MENU ASC
)
go

/*==============================================================*/
/* Table: PAIS                                                  */
/*==============================================================*/
create table PAIS (
   ID_PAIS              int                  not null identity(1,1),
   CODIGO_PAIS          char(2)              not null,
   NOMBRE_PAIS          varchar(60)          not null,
   constraint PK_PAIS primary key nonclustered (ID_PAIS)
)
go

/*==============================================================*/
/* Table: PERIODICIDAD_ANUAL                                    */
/*==============================================================*/
create table PERIODICIDAD_ANUAL (
   ID_PERIODICIDAD      int                  not null identity(1,1),
   ANIO_PERIODICIDAD    int                  not null,
   QUINCENAL            bit                  not null,
   MENSUAL              bit                  not null,
   constraint PK_PERIODICIDAD_ANUAL primary key nonclustered (ID_PERIODICIDAD)
)
go

/*==============================================================*/
/* Table: PERMISO                                               */
/*==============================================================*/
create table PERMISO (
   ID_PERMISO           int                  not null identity(1,1),
   NOMBRE_PERMISO       varchar(60)          not null,
   DESCRIPCION_PERMISO  varchar(150)         not null,
   constraint PK_PERMISO primary key nonclustered (ID_PERMISO)
)
go

/*==============================================================*/
/* Table: PERMITE                                               */
/*==============================================================*/
create table PERMITE (
   ID_ROL               int                  not null,
   ID_PERMISO           int                  not null,
   constraint PK_PERMITE primary key (ID_ROL, ID_PERMISO)
)
go

/*==============================================================*/
/* Index: PERMITE_FK                                            */
/*==============================================================*/
create index PERMITE_FK on PERMITE (
ID_ROL ASC
)
go

/*==============================================================*/
/* Index: PERMITE2_FK                                           */
/*==============================================================*/
create index PERMITE2_FK on PERMITE (
ID_PERMISO ASC
)
go

/*==============================================================*/
/* Table: PLANILLA                                              */
/*==============================================================*/
create table PLANILLA (
   ID_PLANILLA          int                  not null identity(1,1),
   FECHA                datetime             not null,
   CODIGO_PLANILLA      varchar(15)          not null,
   TOTAL_INGRESOS       numeric(8,2)         null,
   TOTAL_DESCUENTOS     numeric(8,2)         null,
   TOTAL_PAGAR          numeric(10,2)        null,
   constraint PK_PLANILLA primary key nonclustered (ID_PLANILLA)
)
go

/*==============================================================*/
/* Table: PROFESION                                             */
/*==============================================================*/
create table PROFESION (
   ID_PROFESION         int                  not null identity(1,1),
   NOMBRE_PROFESION     varchar(60)          not null,
   constraint PK_PROFESION primary key nonclustered (ID_PROFESION)
)
go

/*==============================================================*/
/* Table: PUESTO                                                */
/*==============================================================*/
create table PUESTO (
   ID_PUESTO            int                  not null identity(1,1),
   ID_DEPARTAMENTO      int                  not null,
   CODIGO_PUESTO        varchar(10)          not null,
   NOMBRE_PUESTO        varchar(60)          not null,
   SALARIO_MINIMO       decimal(8,2)         not null,
   SALARIO_MAXIMO       decimal(8,2)         not null,
   constraint PK_PUESTO primary key nonclustered (ID_PUESTO)
)
go

/*==============================================================*/
/* Index: TIENE__FK                                             */
/*==============================================================*/
create index TIENE__FK on PUESTO (
ID_DEPARTAMENTO ASC
)
go

/*==============================================================*/
/* Table: RANGO_COMISION                                        */
/*==============================================================*/
create table RANGO_COMISION (
   ID_RANGO             int                  not null identity(1,1),
   MIN_COMISION         decimal(8,2)         not null,
   MAX_COMISION         decimal(8,2)         not null,
   PORCENTAJE_POR_COMISION decimal(8,2)         not null,
   constraint PK_RANGO_COMISION primary key nonclustered (ID_RANGO)
)
go

/*==============================================================*/
/* Table: REGION                                                */
/*==============================================================*/
create table REGION (
   ID_REGION            int                  not null identity(1,1),
   ID_PAIS              int                  not null,
   CODIGO_REGION        varchar(60)          not null,
   NOMBRE_REGION        varchar(60)          not null,
   constraint PK_REGION primary key nonclustered (ID_REGION)
)
go

/*==============================================================*/
/* Index: TIENE_REGIONES_FK                                     */
/*==============================================================*/
create index TIENE_REGIONES_FK on REGION (
ID_PAIS ASC
)
go

/*==============================================================*/
/* Table: ROL                                                   */
/*==============================================================*/
create table ROL (
   ID_ROL               int                  not null identity(1,1),
   NOMBRE_ROL           varchar(60)          not null,
   DESCRIPCION_ROL      varchar(150)         not null,
   constraint PK_ROL primary key nonclustered (ID_ROL)
)
go

/*==============================================================*/
/* Table: SALARIO_MINIMO                                        */
/*==============================================================*/
create table SALARIO_MINIMO (
   ID_SALARIO_MINIMO    int                  not null identity(1,1),
   MONTO_SALARIO_MINIMO decimal(8,2)         not null,
   constraint PK_SALARIO_MINIMO primary key nonclustered (ID_SALARIO_MINIMO)
)
go

/*==============================================================*/
/* Table: SUB_REGION                                            */
/*==============================================================*/
create table SUB_REGION (
   ID_SUB_REGION        int                  not null identity(1,1),
   ID_REGION            int                  not null,
   CODIGO_SUB_REGION    varchar(60)          not null,
   NOMBRE_SUB_REGION    varchar(60)          not null,
   constraint PK_SUB_REGION primary key nonclustered (ID_SUB_REGION)
)
go

/*==============================================================*/
/* Index: TIENE_SUB_REGIONES_FK                                 */
/*==============================================================*/
create index TIENE_SUB_REGIONES_FK on SUB_REGION (
ID_REGION ASC
)
go

/*==============================================================*/
/* Table: USUARIO                                               */
/*==============================================================*/
create table USUARIO (
   ID_USUARIO           int                  not null identity(1,1),
   ID_EMPLEADO          int                  null,
   ID_ROL               int                  not null,
   EMAIL                varchar(60)          not null,
   USERNAME             varchar(60)          unique not null,
   PASSWORD             varchar(60)          not null,
   HABILITADO           bit                  not null,
   IMAGEN               varchar(60)          null,
   constraint PK_USUARIO primary key nonclustered (ID_USUARIO)
)
go

/*==============================================================*/
/* Index: ES_FK                                                 */
/*==============================================================*/
create index ES_FK on USUARIO (
ID_EMPLEADO ASC
)
go

/*==============================================================*/
/* Index: TIENE_FK                                              */
/*==============================================================*/
create index TIENE_FK on USUARIO (
ID_ROL ASC
)
go

