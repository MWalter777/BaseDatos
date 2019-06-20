SET IDENTITY_INSERT permiso ON

insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (57,'index_empleado','Index de los empleados');
insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (58,'crear_empleado','Crear un nuevo empleado');
insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (59,'editar_empleado','Editar un empleado');
insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (60,'eliminar_empleado','Eliminar un empleado');
SET IDENTITY_INSERT permiso off

insert into permite (id_rol,id_permiso) values(1,57);
insert into permite (id_rol,id_permiso) values(1,58);
insert into permite (id_rol,id_permiso) values(1,59);
insert into permite (id_rol,id_permiso) values(1,60);

SET IDENTITY_INSERT MENU ON

insert into MENU (ID_MENU,MEN_ID_MENU,NOMBRE_MENU,URL) values (17,null,'Empleados', null);
insert into MENU (ID_MENU,MEN_ID_MENU,NOMBRE_MENU,URL) values (18,17,'Empleados','/Empleadoes/Index');
SET IDENTITY_INSERT MENU off

insert into accede (ID_ROL,ID_MENU) values (1,17);
insert into accede (ID_ROL,ID_MENU) values (1,18);

--Agregado correspondiente al puesto

--SET IDENTITY_INSERT MENU ON

--insert into MENU (ID_MENU,MEN_ID_MENU,NOMBRE_MENU,URL) values (19,2,'Puestos','/Puesto/Index');
--SET IDENTITY_INSERT MENU off

--insert into accede (ID_ROL,ID_MENU) values (1,19);

go