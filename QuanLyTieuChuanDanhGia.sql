/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2008                    */
/* Created on:     15/04/2020 3:15:54 CH                        */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('MINHCHUNG') and o.name = 'FK_MINHCHUN_MINHCHUNG_LOAITAIL')
alter table MINHCHUNG
   drop constraint FK_MINHCHUN_MINHCHUNG_LOAITAIL
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('NGUONMINHCHUNG') and o.name = 'FK_NGUONMIN_NGUONMINH_LOAITAIL')
alter table NGUONMINHCHUNG
   drop constraint FK_NGUONMIN_NGUONMINH_LOAITAIL
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('NGUONMINHCHUNG_MINHCHUNG') and o.name = 'FK_NGUONMIN_NGUONMINH_MINHCHUN')
alter table NGUONMINHCHUNG_MINHCHUNG
   drop constraint FK_NGUONMIN_NGUONMINH_MINHCHUN
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('NGUONMINHCHUNG_MINHCHUNG') and o.name = 'FK_NGUONMIN_NGUONMINH_NGUONMIN')
alter table NGUONMINHCHUNG_MINHCHUNG
   drop constraint FK_NGUONMIN_NGUONMINH_NGUONMIN
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TIEUCHI') and o.name = 'FK_TIEUCHI_TIEUCHUAN_TIEUCHUA')
alter table TIEUCHI
   drop constraint FK_TIEUCHI_TIEUCHUAN_TIEUCHUA
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TIEUCHI_NGUONMINHCHUNG') and o.name = 'FK_TIEUCHI__TIEUCHI_N_TIEUCHI')
alter table TIEUCHI_NGUONMINHCHUNG
   drop constraint FK_TIEUCHI__TIEUCHI_N_TIEUCHI
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TIEUCHI_NGUONMINHCHUNG') and o.name = 'FK_TIEUCHI__TIEUCHI_N_NGUONMIN')
alter table TIEUCHI_NGUONMINHCHUNG
   drop constraint FK_TIEUCHI__TIEUCHI_N_NGUONMIN
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TIEUCHI_YEUCAU') and o.name = 'FK_TIEUCHI__TIEUCHI_Y_TIEUCHI')
alter table TIEUCHI_YEUCAU
   drop constraint FK_TIEUCHI__TIEUCHI_Y_TIEUCHI
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TIEUCHI_YEUCAU') and o.name = 'FK_TIEUCHI__TIEUCHI_Y_YEUCAU')
alter table TIEUCHI_YEUCAU
   drop constraint FK_TIEUCHI__TIEUCHI_Y_YEUCAU
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('YEUCAU_MOCTHAMCHIEU') and o.name = 'FK_YEUCAU_M_YEUCAU_MO_YEUCAU')
alter table YEUCAU_MOCTHAMCHIEU
   drop constraint FK_YEUCAU_M_YEUCAU_MO_YEUCAU
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('YEUCAU_MOCTHAMCHIEU') and o.name = 'FK_YEUCAU_M_YEUCAU_MO_MOCTHAMC')
alter table YEUCAU_MOCTHAMCHIEU
   drop constraint FK_YEUCAU_M_YEUCAU_MO_MOCTHAMC
go

if exists (select 1
            from  sysobjects
           where  id = object_id('LOAITAILIEU')
            and   type = 'U')
   drop table LOAITAILIEU
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('MINHCHUNG')
            and   name  = 'MINHCHUNG_LOAITAILIEU_FK'
            and   indid > 0
            and   indid < 255)
   drop index MINHCHUNG.MINHCHUNG_LOAITAILIEU_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('MINHCHUNG')
            and   type = 'U')
   drop table MINHCHUNG
go

if exists (select 1
            from  sysobjects
           where  id = object_id('MOCTHAMCHIEU')
            and   type = 'U')
   drop table MOCTHAMCHIEU
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('NGUONMINHCHUNG')
            and   name  = 'NGUONMINHCHUNG_LOAITAILIEU_FK'
            and   indid > 0
            and   indid < 255)
   drop index NGUONMINHCHUNG.NGUONMINHCHUNG_LOAITAILIEU_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('NGUONMINHCHUNG')
            and   type = 'U')
   drop table NGUONMINHCHUNG
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('NGUONMINHCHUNG_MINHCHUNG')
            and   name  = 'NGUONMINHCHUNG_MINHCHUNG2_FK'
            and   indid > 0
            and   indid < 255)
   drop index NGUONMINHCHUNG_MINHCHUNG.NGUONMINHCHUNG_MINHCHUNG2_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('NGUONMINHCHUNG_MINHCHUNG')
            and   name  = 'NGUONMINHCHUNG_MINHCHUNG_FK'
            and   indid > 0
            and   indid < 255)
   drop index NGUONMINHCHUNG_MINHCHUNG.NGUONMINHCHUNG_MINHCHUNG_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('NGUONMINHCHUNG_MINHCHUNG')
            and   type = 'U')
   drop table NGUONMINHCHUNG_MINHCHUNG
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('TIEUCHI')
            and   name  = 'TIEUCHUAN_TIEUCHI_FK'
            and   indid > 0
            and   indid < 255)
   drop index TIEUCHI.TIEUCHUAN_TIEUCHI_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TIEUCHI')
            and   type = 'U')
   drop table TIEUCHI
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('TIEUCHI_NGUONMINHCHUNG')
            and   name  = 'TIEUCHI_NGUONMINHCHUNG2_FK'
            and   indid > 0
            and   indid < 255)
   drop index TIEUCHI_NGUONMINHCHUNG.TIEUCHI_NGUONMINHCHUNG2_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('TIEUCHI_NGUONMINHCHUNG')
            and   name  = 'TIEUCHI_NGUONMINHCHUNG_FK'
            and   indid > 0
            and   indid < 255)
   drop index TIEUCHI_NGUONMINHCHUNG.TIEUCHI_NGUONMINHCHUNG_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TIEUCHI_NGUONMINHCHUNG')
            and   type = 'U')
   drop table TIEUCHI_NGUONMINHCHUNG
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('TIEUCHI_YEUCAU')
            and   name  = 'TIEUCHI_YEUCAU2_FK'
            and   indid > 0
            and   indid < 255)
   drop index TIEUCHI_YEUCAU.TIEUCHI_YEUCAU2_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('TIEUCHI_YEUCAU')
            and   name  = 'TIEUCHI_YEUCAU_FK'
            and   indid > 0
            and   indid < 255)
   drop index TIEUCHI_YEUCAU.TIEUCHI_YEUCAU_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TIEUCHI_YEUCAU')
            and   type = 'U')
   drop table TIEUCHI_YEUCAU
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TIEUCHUAN')
            and   type = 'U')
   drop table TIEUCHUAN
go

if exists (select 1
            from  sysobjects
           where  id = object_id('YEUCAU')
            and   type = 'U')
   drop table YEUCAU
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('YEUCAU_MOCTHAMCHIEU')
            and   name  = 'YEUCAU_MOCTHAMCHIEU2_FK'
            and   indid > 0
            and   indid < 255)
   drop index YEUCAU_MOCTHAMCHIEU.YEUCAU_MOCTHAMCHIEU2_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('YEUCAU_MOCTHAMCHIEU')
            and   name  = 'YEUCAU_MOCTHAMCHIEU_FK'
            and   indid > 0
            and   indid < 255)
   drop index YEUCAU_MOCTHAMCHIEU.YEUCAU_MOCTHAMCHIEU_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('YEUCAU_MOCTHAMCHIEU')
            and   type = 'U')
   drop table YEUCAU_MOCTHAMCHIEU
go

/*==============================================================*/
/* Table: LOAITAILIEU                                           */
/*==============================================================*/
create table LOAITAILIEU (
   MALOAITAILIEU        tinyint              not null,
   TENLOAITAILIEU       nvarchar(100)        null,
   GHICHU               nvarchar(100)        null,
   constraint PK_LOAITAILIEU primary key nonclustered (MALOAITAILIEU)
)
go

/*==============================================================*/
/* Table: MINHCHUNG                                             */
/*==============================================================*/
create table MINHCHUNG (
   MATAILIEU            tinyint              not null,
   MALOAITAILIEU        tinyint              not null,
   TENTAILIEU           nvarchar(100)        null,
   NGAYKY               nvarchar(100)        null,
   NGUOIKY              nvarchar(100)        null,
   SOBANHANH            nvarchar(100)        null,
   TOMTATNOIDUNG        nvarchar(100)        null,
   DUONGLINK            nvarchar(100)        null,
   GHICHU               nvarchar(100)        null,   
   constraint PK_MINHCHUNG primary key nonclustered (MATAILIEU)
)
go

/*==============================================================*/
/* Index: MINHCHUNG_LOAITAILIEU_FK                              */
/*==============================================================*/
create index MINHCHUNG_LOAITAILIEU_FK on MINHCHUNG (
MALOAITAILIEU ASC
)
go

/*==============================================================*/
/* Table: MOCTHAMCHIEU                                          */
/*==============================================================*/
create table MOCTHAMCHIEU (
   MAMOCTHAMCHIEU       tinyint              not null,
   TENMOCTHAMCHIEU      nvarchar(100)        null,
   NOIDUNGMOCTHAMCHIEU  nvarchar(100)        null,
   GHICHU               nvarchar(100)        null,
   constraint PK_MOCTHAMCHIEU primary key nonclustered (MAMOCTHAMCHIEU)
)
go

/*==============================================================*/
/* Table: NGUONMINHCHUNG                                        */
/*==============================================================*/
create table NGUONMINHCHUNG (
   MANGUONMINHCHUNG     tinyint              not null,
   MALOAITAILIEU        tinyint              not null,
   TENNGUONMINHCHUNG    nvarchar(100)        null,
   NOIDUNGNGUONMINHCHUNG nvarchar(100)        null,
   GHICHU               nvarchar(100)        null,   
   constraint PK_NGUONMINHCHUNG primary key nonclustered (MANGUONMINHCHUNG)
)
go

/*==============================================================*/
/* Index: NGUONMINHCHUNG_LOAITAILIEU_FK                         */
/*==============================================================*/
create index NGUONMINHCHUNG_LOAITAILIEU_FK on NGUONMINHCHUNG (
MALOAITAILIEU ASC
)
go

/*==============================================================*/
/* Table: NGUONMINHCHUNG_MINHCHUNG                              */
/*==============================================================*/
create table NGUONMINHCHUNG_MINHCHUNG (
   MATAILIEU            tinyint              not null,
   MANGUONMINHCHUNG     tinyint              not null,
   GHICHU               nvarchar(100)        null,
   constraint PK_NGUONMINHCHUNG_MINHCHUNG primary key (MATAILIEU, MANGUONMINHCHUNG)
)
go

/*==============================================================*/
/* Index: NGUONMINHCHUNG_MINHCHUNG_FK                           */
/*==============================================================*/
create index NGUONMINHCHUNG_MINHCHUNG_FK on NGUONMINHCHUNG_MINHCHUNG (
MATAILIEU ASC
)
go

/*==============================================================*/
/* Index: NGUONMINHCHUNG_MINHCHUNG2_FK                          */
/*==============================================================*/
create index NGUONMINHCHUNG_MINHCHUNG2_FK on NGUONMINHCHUNG_MINHCHUNG (
MANGUONMINHCHUNG ASC
)
go

/*==============================================================*/
/* Table: TIEUCHI                                               */
/*==============================================================*/
create table TIEUCHI (
   MATIEUCHI            tinyint              not null,
   MATIEUCHUAN          tinyint              not null,
   TENTIEUCHI           nvarchar(100)        null,
   NOIDUNGTIEUCHI       nvarchar(100)        null,
   GHICHU               nvarchar(100)        null,   
   constraint PK_TIEUCHI primary key nonclustered (MATIEUCHI)
)
go

/*==============================================================*/
/* Index: TIEUCHUAN_TIEUCHI_FK                                  */
/*==============================================================*/
create index TIEUCHUAN_TIEUCHI_FK on TIEUCHI (
MATIEUCHUAN ASC
)
go

/*==============================================================*/
/* Table: TIEUCHI_NGUONMINHCHUNG                                */
/*==============================================================*/
create table TIEUCHI_NGUONMINHCHUNG (
   MATIEUCHI            tinyint              not null,
   MANGUONMINHCHUNG     tinyint              not null,
   GHICHU               nvarchar(100)        null,
   constraint PK_TIEUCHI_NGUONMINHCHUNG primary key (MATIEUCHI, MANGUONMINHCHUNG)
)
go

/*==============================================================*/
/* Index: TIEUCHI_NGUONMINHCHUNG_FK                             */
/*==============================================================*/
create index TIEUCHI_NGUONMINHCHUNG_FK on TIEUCHI_NGUONMINHCHUNG (
MATIEUCHI ASC
)
go

/*==============================================================*/
/* Index: TIEUCHI_NGUONMINHCHUNG2_FK                            */
/*==============================================================*/
create index TIEUCHI_NGUONMINHCHUNG2_FK on TIEUCHI_NGUONMINHCHUNG (
MANGUONMINHCHUNG ASC
)
go

/*==============================================================*/
/* Table: TIEUCHI_YEUCAU                                        */
/*==============================================================*/
create table TIEUCHI_YEUCAU (
   MATIEUCHI            tinyint              not null,
   MAYEUCAU             tinyint              not null,
   GHICHU               nvarchar(100)        null,
   constraint PK_TIEUCHI_YEUCAU primary key (MATIEUCHI, MAYEUCAU)
)
go

/*==============================================================*/
/* Index: TIEUCHI_YEUCAU_FK                                     */
/*==============================================================*/
create index TIEUCHI_YEUCAU_FK on TIEUCHI_YEUCAU (
MATIEUCHI ASC
)
go

/*==============================================================*/
/* Index: TIEUCHI_YEUCAU2_FK                                    */
/*==============================================================*/
create index TIEUCHI_YEUCAU2_FK on TIEUCHI_YEUCAU (
MAYEUCAU ASC
)
go

/*==============================================================*/
/* Table: TIEUCHUAN                                             */
/*==============================================================*/
create table TIEUCHUAN (
   MATIEUCHUAN          tinyint              not null,
   TENTIEUCHUAN         nvarchar(100)        null,
   NOIDUNGTIEUCHUAN     nvarchar(100)        null,
   GHICHU               nvarchar(100)        null,
   constraint PK_TIEUCHUAN primary key nonclustered (MATIEUCHUAN)
)
go

/*==============================================================*/
/* Table: YEUCAU                                                */
/*==============================================================*/
create table YEUCAU (
   MAYEUCAU             tinyint              not null,
   TENYEUCAU            nvarchar(100)        null,
   NOIDUNGYEUCAU        nvarchar(100)        null,
   GHICHU               nvarchar(100)        null,
   constraint PK_YEUCAU primary key nonclustered (MAYEUCAU)
)
go

/*==============================================================*/
/* Table: YEUCAU_MOCTHAMCHIEU                                   */
/*==============================================================*/
create table YEUCAU_MOCTHAMCHIEU (
   MAYEUCAU             tinyint              not null,
   MAMOCTHAMCHIEU       tinyint              not null,
   GHICHU               nvarchar(100)        null,
   constraint PK_YEUCAU_MOCTHAMCHIEU primary key (MAYEUCAU, MAMOCTHAMCHIEU)
)
go

/*==============================================================*/
/* Index: YEUCAU_MOCTHAMCHIEU_FK                                */
/*==============================================================*/
create index YEUCAU_MOCTHAMCHIEU_FK on YEUCAU_MOCTHAMCHIEU (
MAYEUCAU ASC
)
go

/*==============================================================*/
/* Index: YEUCAU_MOCTHAMCHIEU2_FK                               */
/*==============================================================*/
create index YEUCAU_MOCTHAMCHIEU2_FK on YEUCAU_MOCTHAMCHIEU (
MAMOCTHAMCHIEU ASC
)
go

alter table MINHCHUNG
   add constraint FK_MINHCHUN_MINHCHUNG_LOAITAIL foreign key (MALOAITAILIEU)
      references LOAITAILIEU (MALOAITAILIEU)
go

alter table NGUONMINHCHUNG
   add constraint FK_NGUONMIN_NGUONMINH_LOAITAIL foreign key (MALOAITAILIEU)
      references LOAITAILIEU (MALOAITAILIEU)
go

alter table NGUONMINHCHUNG_MINHCHUNG
   add constraint FK_NGUONMIN_NGUONMINH_MINHCHUN foreign key (MATAILIEU)
      references MINHCHUNG (MATAILIEU)
go

alter table NGUONMINHCHUNG_MINHCHUNG
   add constraint FK_NGUONMIN_NGUONMINH_NGUONMIN foreign key (MANGUONMINHCHUNG)
      references NGUONMINHCHUNG (MANGUONMINHCHUNG)
go

alter table TIEUCHI
   add constraint FK_TIEUCHI_TIEUCHUAN_TIEUCHUA foreign key (MATIEUCHUAN)
      references TIEUCHUAN (MATIEUCHUAN)
go

alter table TIEUCHI_NGUONMINHCHUNG
   add constraint FK_TIEUCHI__TIEUCHI_N_TIEUCHI foreign key (MATIEUCHI)
      references TIEUCHI (MATIEUCHI)
go

alter table TIEUCHI_NGUONMINHCHUNG
   add constraint FK_TIEUCHI__TIEUCHI_N_NGUONMIN foreign key (MANGUONMINHCHUNG)
      references NGUONMINHCHUNG (MANGUONMINHCHUNG)
go

alter table TIEUCHI_YEUCAU
   add constraint FK_TIEUCHI__TIEUCHI_Y_TIEUCHI foreign key (MATIEUCHI)
      references TIEUCHI (MATIEUCHI)
go

alter table TIEUCHI_YEUCAU
   add constraint FK_TIEUCHI__TIEUCHI_Y_YEUCAU foreign key (MAYEUCAU)
      references YEUCAU (MAYEUCAU)
go

alter table YEUCAU_MOCTHAMCHIEU
   add constraint FK_YEUCAU_M_YEUCAU_MO_YEUCAU foreign key (MAYEUCAU)
      references YEUCAU (MAYEUCAU)
go

alter table YEUCAU_MOCTHAMCHIEU
   add constraint FK_YEUCAU_M_YEUCAU_MO_MOCTHAMC foreign key (MAMOCTHAMCHIEU)
      references MOCTHAMCHIEU (MAMOCTHAMCHIEU)
go

