/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2008                    */
/* Created on:     03/05/2019 21:44:14                          */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ACCEDE') and o.name = 'FK_ACCEDE_ACCEDE_ROL')
alter table ACCEDE
   drop constraint FK_ACCEDE_ACCEDE_ROL
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ACCEDE') and o.name = 'FK_ACCEDE_ACCEDE2_MENU')
alter table ACCEDE
   drop constraint FK_ACCEDE_ACCEDE2_MENU
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('DEPARTAMENTO') and o.name = 'FK_DEPARTAM_COMPUESTO_DEPARTAM')
alter table DEPARTAMENTO
   drop constraint FK_DEPARTAM_COMPUESTO_DEPARTAM
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('DEPARTAMENTO') and o.name = 'FK_DEPARTAM_CONSTITUI_EMPRESA')
alter table DEPARTAMENTO
   drop constraint FK_DEPARTAM_CONSTITUI_EMPRESA
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('DIRECCION') and o.name = 'FK_DIRECCIO_TIENE_UNA_SUB_REGI')
alter table DIRECCION
   drop constraint FK_DIRECCIO_TIENE_UNA_SUB_REGI
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('EMPLEADO') and o.name = 'FK_EMPLEADO_A_CARGO_D_EMPLEADO')
alter table EMPLEADO
   drop constraint FK_EMPLEADO_A_CARGO_D_EMPLEADO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('EMPLEADO') and o.name = 'FK_EMPLEADO_EJERCE_PROFESIO')
alter table EMPLEADO
   drop constraint FK_EMPLEADO_EJERCE_PROFESIO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('EMPLEADO') and o.name = 'FK_EMPLEADO_POSEE_ESTADO_C')
alter table EMPLEADO
   drop constraint FK_EMPLEADO_POSEE_ESTADO_C
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('EMPLEADO') and o.name = 'FK_EMPLEADO_TIENE_UN_GENERO')
alter table EMPLEADO
   drop constraint FK_EMPLEADO_TIENE_UN_GENERO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('EMPLEADO') and o.name = 'FK_EMPLEADO_TRABAJA_E_PUESTO')
alter table EMPLEADO
   drop constraint FK_EMPLEADO_TRABAJA_E_PUESTO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('EMPLEADO') and o.name = 'FK_EMPLEADO_VIVE_EN_DIRECCIO')
alter table EMPLEADO
   drop constraint FK_EMPLEADO_VIVE_EN_DIRECCIO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('MENU') and o.name = 'FK_MENU_CONTIENE_MENU')
alter table MENU
   drop constraint FK_MENU_CONTIENE_MENU
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PERMITE') and o.name = 'FK_PERMITE_PERMITE_ROL')
alter table PERMITE
   drop constraint FK_PERMITE_PERMITE_ROL
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PERMITE') and o.name = 'FK_PERMITE_PERMITE2_PERMISO')
alter table PERMITE
   drop constraint FK_PERMITE_PERMITE2_PERMISO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PUESTO') and o.name = 'FK_PUESTO_TIENE__DEPARTAM')
alter table PUESTO
   drop constraint FK_PUESTO_TIENE__DEPARTAM
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('REGION') and o.name = 'FK_REGION_TIENE_REG_PAIS')
alter table REGION
   drop constraint FK_REGION_TIENE_REG_PAIS
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('SUB_REGION') and o.name = 'FK_SUB_REGI_TIENE_SUB_REGION')
alter table SUB_REGION
   drop constraint FK_SUB_REGI_TIENE_SUB_REGION
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('USUARIO') and o.name = 'FK_USUARIO_ES_EMPLEADO')
alter table USUARIO
   drop constraint FK_USUARIO_ES_EMPLEADO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('USUARIO') and o.name = 'FK_USUARIO_TIENE_ROL')
alter table USUARIO
   drop constraint FK_USUARIO_TIENE_ROL
go

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
            and   name  = 'EMPLEADO_EMAIL_INS_UQ'
            and   indid > 0
            and   indid < 255)
   drop index EMPLEADO.EMPLEADO_EMAIL_INS_UQ
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('EMPLEADO')
            and   name  = 'EMPLEADO_EMAIL_PER_UQ'
            and   indid > 0
            and   indid < 255)
   drop index EMPLEADO.EMPLEADO_EMAIL_PER_UQ
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('EMPLEADO')
            and   name  = 'EMPLEADO_NUP_UQ'
            and   indid > 0
            and   indid < 255)
   drop index EMPLEADO.EMPLEADO_NUP_UQ
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('EMPLEADO')
            and   name  = 'EMPLEADO_ISSS_UQ'
            and   indid > 0
            and   indid < 255)
   drop index EMPLEADO.EMPLEADO_ISSS_UQ
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('EMPLEADO')
            and   name  = 'EMPLEADO_NIT_UQ'
            and   indid > 0
            and   indid < 255)
   drop index EMPLEADO.EMPLEADO_NIT_UQ
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('EMPLEADO')
            and   name  = 'EMPLEADO_DUI_UQ'
            and   indid > 0
            and   indid < 255)
   drop index EMPLEADO.EMPLEADO_DUI_UQ
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('EMPLEADO')
            and   name  = 'EMPLEADO_COD_UQ'
            and   indid > 0
            and   indid < 255)
   drop index EMPLEADO.EMPLEADO_COD_UQ
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
            from  sysindexes
           where  id    = object_id('PAIS')
            and   name  = 'PAIS_CODE_UQ'
            and   indid > 0
            and   indid < 255)
   drop index PAIS.PAIS_CODE_UQ
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PAIS')
            and   type = 'U')
   drop table PAIS
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
           where  id = object_id('PROFESION')
            and   type = 'U')
   drop table PROFESION
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('PUESTO')
            and   name  = 'COD_PUESTO_UQ'
            and   indid > 0
            and   indid < 255)
   drop index PUESTO.COD_PUESTO_UQ
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
            from  sysindexes
           where  id    = object_id('REGION')
            and   name  = 'REGION_COD_UQ'
            and   indid > 0
            and   indid < 255)
   drop index REGION.REGION_COD_UQ
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
            from  sysindexes
           where  id    = object_id('SUB_REGION')
            and   name  = 'SUB_REGION_COD_UQ'
            and   indid > 0
            and   indid < 255)
   drop index SUB_REGION.SUB_REGION_COD_UQ
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
            and   name  = 'EMAIL_USER_UQ'
            and   indid > 0
            and   indid < 255)
   drop index USUARIO.EMAIL_USER_UQ
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
   ID_ROL               int              not null,
   ID_MENU              int              not null,
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
/* Table: DEPARTAMENTO                                          */
/*==============================================================*/
create table DEPARTAMENTO (
   ID_DEPARTAMENTO      int                  identity(1,1),
   ID_EMPRESA           int              not null,
   DEP_ID_DEPARTAMENTO  int              null,
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
/* Table: DIRECCION                                             */
/*==============================================================*/
create table DIRECCION (
   ID_DIRECCION         int                  identity(1,1),
   ID_SUB_REGION        int              not null,
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
   ID_EMPLEADO          int                  identity(1,1),
   ID_DIRECCION         int              not null,
   EMP_ID_EMPLEADO      int              null,
   ID_GENERO            int              not null,
   ID_PROFESION         int              null,
   ID_ESTADO_CIVIL      int              not null,
   ID_PUESTO            int              not null,
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
/* Index: EMPLEADO_COD_UQ                                       */
/*==============================================================*/
create unique index EMPLEADO_COD_UQ on EMPLEADO (
CODIGO_EMPLEADO ASC
)
go

/*==============================================================*/
/* Index: EMPLEADO_DUI_UQ                                       */
/*==============================================================*/
create unique index EMPLEADO_DUI_UQ on EMPLEADO (
DUI ASC
)
go

/*==============================================================*/
/* Index: EMPLEADO_NIT_UQ                                       */
/*==============================================================*/
create unique index EMPLEADO_NIT_UQ on EMPLEADO (
NIT ASC
)
go

/*==============================================================*/
/* Index: EMPLEADO_ISSS_UQ                                      */
/*==============================================================*/
create unique index EMPLEADO_ISSS_UQ on EMPLEADO (
ISSS ASC
)
go

/*==============================================================*/
/* Index: EMPLEADO_NUP_UQ                                       */
/*==============================================================*/
create unique index EMPLEADO_NUP_UQ on EMPLEADO (
NUP ASC
)
go

/*==============================================================*/
/* Index: EMPLEADO_EMAIL_PER_UQ                                 */
/*==============================================================*/
create unique index EMPLEADO_EMAIL_PER_UQ on EMPLEADO (
CORREO_PERSONAL ASC
)
go

/*==============================================================*/
/* Index: EMPLEADO_EMAIL_INS_UQ                                 */
/*==============================================================*/
create unique index EMPLEADO_EMAIL_INS_UQ on EMPLEADO (
CORREO_INSTITUCIONAL ASC
)
go

/*==============================================================*/
/* Table: EMPRESA                                               */
/*==============================================================*/
create table EMPRESA (
   ID_EMPRESA           int                  identity(1,1),
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
   ID_ESTADO_CIVIL      int                  identity(1,1),
   NOMBRE_ESTADO_CIVIL  varchar(25)          not null,
   constraint PK_ESTADO_CIVIL primary key nonclustered (ID_ESTADO_CIVIL)
)
go

/*==============================================================*/
/* Table: GENERO                                                */
/*==============================================================*/
create table GENERO (
   ID_GENERO            int                  identity(1,1),
   NOMBRE_GENERO        varchar(50)          not null,
   constraint PK_GENERO primary key nonclustered (ID_GENERO)
)
go

/*==============================================================*/
/* Table: MENU                                                  */
/*==============================================================*/
create table MENU (
   ID_MENU              int                  identity(1,1),
   MEN_ID_MENU          int              null,
   NOMBRE_MENU          varchar(50)          not null,
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
   ID_PAIS              int                  identity(1,1),
   CODIGO_PAIS          char(2)              not null,
   NOMBRE_PAIS          varchar(60)          not null,
   constraint PK_PAIS primary key nonclustered (ID_PAIS)
)
go

/*==============================================================*/
/* Index: PAIS_CODE_UQ                                          */
/*==============================================================*/
create unique index PAIS_CODE_UQ on PAIS (
CODIGO_PAIS ASC
)
go

/*==============================================================*/
/* Table: PERMISO                                               */
/*==============================================================*/
create table PERMISO (
   ID_PERMISO           int                  identity(1,1),
   NOMBRE_PERMISO       varchar(60)          not null,
   DESCRIPCION_PERMISO  varchar(150)         not null,
   constraint PK_PERMISO primary key nonclustered (ID_PERMISO)
)
go

/*==============================================================*/
/* Table: PERMITE                                               */
/*==============================================================*/
create table PERMITE (
   ID_ROL               int              not null,
   ID_PERMISO           int              not null,
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
/* Table: PROFESION                                             */
/*==============================================================*/
create table PROFESION (
   ID_PROFESION         int                  identity(1,1),
   NOMBRE_PROFESION     varchar(60)          not null,
   constraint PK_PROFESION primary key nonclustered (ID_PROFESION)
)
go

/*==============================================================*/
/* Table: PUESTO                                                */
/*==============================================================*/
create table PUESTO (
   ID_PUESTO            int                  identity(1,1),
   ID_DEPARTAMENTO      int              not null,
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
/* Index: COD_PUESTO_UQ                                         */
/*==============================================================*/
create unique index COD_PUESTO_UQ on PUESTO (
CODIGO_PUESTO ASC
)
go

/*==============================================================*/
/* Table: REGION                                                */
/*==============================================================*/
create table REGION (
   ID_REGION            int                  identity(1,1),
   ID_PAIS              int              not null,
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
/* Index: REGION_COD_UQ                                         */
/*==============================================================*/
create unique index REGION_COD_UQ on REGION (
CODIGO_REGION ASC
)
go

/*==============================================================*/
/* Table: ROL                                                   */
/*==============================================================*/
create table ROL (
   ID_ROL               int                  identity(1,1),
   NOMBRE_ROL           varchar(60)          not null,
   DESCRIPCION_ROL      varchar(150)         not null,
   constraint PK_ROL primary key nonclustered (ID_ROL)
)
go

/*==============================================================*/
/* Table: SUB_REGION                                            */
/*==============================================================*/
create table SUB_REGION (
   ID_SUB_REGION        int                  identity(1,1),
   ID_REGION            int              not null,
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
/* Index: SUB_REGION_COD_UQ                                     */
/*==============================================================*/
create unique index SUB_REGION_COD_UQ on SUB_REGION (
CODIGO_SUB_REGION ASC
)
go

/*==============================================================*/
/* Table: USUARIO                                               */
/*==============================================================*/
create table USUARIO (
   ID_USUARIO           int                  identity(1,1),
   ID_EMPLEADO          int                  null,
   ID_ROL               int					 null,
   USERNAME 			varchar(60)			 unique not null,
   imagen 			  	varchar(60)			 null,
   EMAIL                varchar(60)          not null,
   PASSWORD             varchar(60)          not null,
   HABILITADO           bit                  not null,
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

/*==============================================================*/
/* Index: EMAIL_USER_UQ                                         */
/*==============================================================*/
create unique index EMAIL_USER_UQ on USUARIO (
EMAIL ASC
)
go

alter table ACCEDE
   add constraint FK_ACCEDE_ACCEDE_ROL foreign key (ID_ROL)
      references ROL (ID_ROL)
go

alter table ACCEDE
   add constraint FK_ACCEDE_ACCEDE2_MENU foreign key (ID_MENU)
      references MENU (ID_MENU)
go

alter table DEPARTAMENTO
   add constraint FK_DEPARTAM_COMPUESTO_DEPARTAM foreign key (DEP_ID_DEPARTAMENTO)
      references DEPARTAMENTO (ID_DEPARTAMENTO)
go

alter table DEPARTAMENTO
   add constraint FK_DEPARTAM_CONSTITUI_EMPRESA foreign key (ID_EMPRESA)
      references EMPRESA (ID_EMPRESA)
go

alter table DIRECCION
   add constraint FK_DIRECCIO_TIENE_UNA_SUB_REGI foreign key (ID_SUB_REGION)
      references SUB_REGION (ID_SUB_REGION)
go

alter table EMPLEADO
   add constraint FK_EMPLEADO_A_CARGO_D_EMPLEADO foreign key (EMP_ID_EMPLEADO)
      references EMPLEADO (ID_EMPLEADO)
go

alter table EMPLEADO
   add constraint FK_EMPLEADO_EJERCE_PROFESIO foreign key (ID_PROFESION)
      references PROFESION (ID_PROFESION)
go

alter table EMPLEADO
   add constraint FK_EMPLEADO_POSEE_ESTADO_C foreign key (ID_ESTADO_CIVIL)
      references ESTADO_CIVIL (ID_ESTADO_CIVIL)
go

alter table EMPLEADO
   add constraint FK_EMPLEADO_TIENE_UN_GENERO foreign key (ID_GENERO)
      references GENERO (ID_GENERO)
go

alter table EMPLEADO
   add constraint FK_EMPLEADO_TRABAJA_E_PUESTO foreign key (ID_PUESTO)
      references PUESTO (ID_PUESTO)
go

alter table EMPLEADO
   add constraint FK_EMPLEADO_VIVE_EN_DIRECCIO foreign key (ID_DIRECCION)
      references DIRECCION (ID_DIRECCION)
go

alter table MENU
   add constraint FK_MENU_CONTIENE_MENU foreign key (MEN_ID_MENU)
      references MENU (ID_MENU)
go

alter table PERMITE
   add constraint FK_PERMITE_PERMITE_ROL foreign key (ID_ROL)
      references ROL (ID_ROL)
go

alter table PERMITE
   add constraint FK_PERMITE_PERMITE2_PERMISO foreign key (ID_PERMISO)
      references PERMISO (ID_PERMISO)
go

alter table PUESTO
   add constraint FK_PUESTO_TIENE__DEPARTAM foreign key (ID_DEPARTAMENTO)
      references DEPARTAMENTO (ID_DEPARTAMENTO)
go

alter table REGION
   add constraint FK_REGION_TIENE_REG_PAIS foreign key (ID_PAIS)
      references PAIS (ID_PAIS)
go

alter table SUB_REGION
   add constraint FK_SUB_REGI_TIENE_SUB_REGION foreign key (ID_REGION)
      references REGION (ID_REGION)
go

alter table USUARIO
   add constraint FK_USUARIO_ES_EMPLEADO foreign key (ID_EMPLEADO)
      references EMPLEADO (ID_EMPLEADO)
go

alter table USUARIO
   add constraint FK_USUARIO_TIENE_ROL foreign key (ID_ROL)
      references ROL (ID_ROL)
go

SET IDENTITY_INSERT permiso ON

insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (1,'lista_usuario','Permiso para ver todas las listas de usuarios');
insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (2,'editar_usuario','Editar los usuarios');
insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (3,'eliminar_usuario','Permiso para eliminar los usuarios');

SET IDENTITY_INSERT permiso off

SET IDENTITY_INSERT rol ON

insert into rol (ID_ROL,NOMBRE_ROL,DESCRIPCION_ROL) values (1,'root','Rol de superusuario');
insert into rol (ID_ROL,NOMBRE_ROL,DESCRIPCION_ROL) values (2,'Admin','Rol de Administrador');
insert into rol (ID_ROL,NOMBRE_ROL,DESCRIPCION_ROL) values (3,'usuario','Rol de usuario');

SET IDENTITY_INSERT rol off


insert into permite (id_rol,id_permiso) values(1,1);
insert into permite (id_rol,id_permiso) values(1,2);
insert into permite (id_rol,id_permiso) values(1,3);


SET IDENTITY_INSERT usuario ON

insert into usuario (id_usuario,id_rol,USERNAME,email,password,habilitado) values(1,1,'BAD115','superusuariosap777@gmail.com','3GseFNXe8JBJ+WiHMprogrWwX4U=',1);

SET IDENTITY_INSERT usuario off
