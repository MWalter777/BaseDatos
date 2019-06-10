
SET IDENTITY_INSERT rol ON

insert into rol (ID_ROL,NOMBRE_ROL,DESCRIPCION_ROL) values (1,'root','Rol de superusuario');
insert into rol (ID_ROL,NOMBRE_ROL,DESCRIPCION_ROL) values (2,'Admin','Rol de Administrador');
insert into rol (ID_ROL,NOMBRE_ROL,DESCRIPCION_ROL) values (3,'usuario','Rol de usuario');

SET IDENTITY_INSERT rol off


SET IDENTITY_INSERT permiso ON

insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (1,'lista_usuario','Index de los usuarios');
insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (2,'crear_usuario','crear usuario');
insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (3,'editar_usuario','Editar usuario');
insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (4,'eliminar_usuario','eliminar usuario');

insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (5,'index_estado','Index de los estados');
insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (6,'crear_estado','crear estado');
insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (7,'editar_estado','Editar estado');
insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (8,'eliminar_estado','eliminar estado');

insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (9,'index_permiso','Ver lista de permisos');
insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (10,'crear_permiso','Crear nuevos permisos');
insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (11,'editar_permiso','Editar los permisos');
insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (12,'eliminar_permiso','Eliminar los permisos');


insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (13,'index_genero','Index de los generos');
insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (14,'crear_genero','crear genero');
insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (15,'editar_genero','Editar genero');
insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (16,'eliminar_genero','eliminar genero');

insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (17,'index_menurol','Index de los menurols');
insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (18,'crear_menurol','crear menurol');
insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (19,'editar_menurol','Editar menurol');
insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (20,'eliminar_menurol','eliminar menurol');

insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (21,'index_menu','Index de los menus');
insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (22,'crear_menu','crear menu');
insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (23,'editar_menu','Editar menu');
insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (24,'eliminar_menu','eliminar menu');

insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (25,'index_pais','Index de los paises');
insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (26,'crear_pais','crear pais');
insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (27,'editar_pais','Editar pais');
insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (28,'eliminar_pais','eliminar pais');

insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (29,'index_profesion','Index de los profesiones');
insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (30,'crear_profesion','crear profesion');
insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (31,'editar_profesion','Editar profesion');
insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (32,'eliminar_profesion','eliminar profesion');


insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (33,'index_region','Index de los regiones');
insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (34,'crear_region','crear region');
insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (35,'editar_region','Editar region');
insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (36,'eliminar_region','eliminar region');

insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (37,'index_rol','Index de los rols');
insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (38,'crear_rol','crear rol');
insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (39,'editar_rol','Editar rol');
insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (40,'eliminar_rol','eliminar rol');

insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (41,'index_sub_region','Index de los sub_regions');
insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (42,'crear_sub_region','crear sub_region');
insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (43,'editar_sub_region','Editar sub_region');
insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (44,'eliminar_sub_region','eliminar sub_region');

insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (45,'ver_planilla','ver_planilla');
insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (46,'crear_planilla','crear_planilla');



SET IDENTITY_INSERT permiso off

insert into permite (id_rol,id_permiso) values(1,1);
insert into permite (id_rol,id_permiso) values(1,2);
insert into permite (id_rol,id_permiso) values(1,3);
insert into permite (id_rol,id_permiso) values(1,4);

insert into permite (id_rol,id_permiso) values(1,5);
insert into permite (id_rol,id_permiso) values(1,6);
insert into permite (id_rol,id_permiso) values(1,7);
insert into permite (id_rol,id_permiso) values(1,8);

insert into permite (id_rol,id_permiso) values(1,9);
insert into permite (id_rol,id_permiso) values(1,10);
insert into permite (id_rol,id_permiso) values(1,11);
insert into permite (id_rol,id_permiso) values(1,12);

insert into permite (id_rol,id_permiso) values(1,13);
insert into permite (id_rol,id_permiso) values(1,14);
insert into permite (id_rol,id_permiso) values(1,15);
insert into permite (id_rol,id_permiso) values(1,16);


insert into permite (id_rol,id_permiso) values(1,17);
insert into permite (id_rol,id_permiso) values(1,18);
insert into permite (id_rol,id_permiso) values(1,19);
insert into permite (id_rol,id_permiso) values(1,20);

insert into permite (id_rol,id_permiso) values(1,21);
insert into permite (id_rol,id_permiso) values(1,22);
insert into permite (id_rol,id_permiso) values(1,23);
insert into permite (id_rol,id_permiso) values(1,24);



insert into permite (id_rol,id_permiso) values(1,25);
insert into permite (id_rol,id_permiso) values(1,26);
insert into permite (id_rol,id_permiso) values(1,27);
insert into permite (id_rol,id_permiso) values(1,28);

insert into permite (id_rol,id_permiso) values(1,29);
insert into permite (id_rol,id_permiso) values(1,30);
insert into permite (id_rol,id_permiso) values(1,31);
insert into permite (id_rol,id_permiso) values(1,32);

insert into permite (id_rol,id_permiso) values(1,33);
insert into permite (id_rol,id_permiso) values(1,34);
insert into permite (id_rol,id_permiso) values(1,35);
insert into permite (id_rol,id_permiso) values(1,36);

insert into permite (id_rol,id_permiso) values(1,37);
insert into permite (id_rol,id_permiso) values(1,38);
insert into permite (id_rol,id_permiso) values(1,39);
insert into permite (id_rol,id_permiso) values(1,40);

insert into permite (id_rol,id_permiso) values(1,41);
insert into permite (id_rol,id_permiso) values(1,42);
insert into permite (id_rol,id_permiso) values(1,43);
insert into permite (id_rol,id_permiso) values(1,44);


insert into permite (id_rol,id_permiso) values(1,45);
insert into permite (id_rol,id_permiso) values(1,46);



SET IDENTITY_INSERT usuario ON

insert into usuario (id_usuario,id_empleado,id_rol,USERNAME,email,password,habilitado) values(1,null,1,'BAD115','superusuariosap777@gmail.com','3GseFNXe8JBJ+WiHMprogrWwX4U=',1);

SET IDENTITY_INSERT usuario off


SET IDENTITY_INSERT MENU ON

insert into MENU (ID_MENU,MEN_ID_MENU,NOMBRE_MENU,URL) values (1,null,'Gestion de usuarios',null);
insert into MENU (ID_MENU,MEN_ID_MENU,NOMBRE_MENU,URL) values (2,null,'Catalogo',null);
insert into MENU (ID_MENU,MEN_ID_MENU,NOMBRE_MENU,URL) values (3,1,'Usuarios','/Usuario/Index');
insert into MENU (ID_MENU,MEN_ID_MENU,NOMBRE_MENU,URL) values (4,1,'Roles','/Rols/Index');
insert into MENU (ID_MENU,MEN_ID_MENU,NOMBRE_MENU,URL) values (5,1,'Permisos','/Permisoes/index');

insert into MENU (ID_MENU,MEN_ID_MENU,NOMBRE_MENU,URL) values (6,2,'Estado Civil','/ESTADO_CIVIL/Index');
insert into MENU (ID_MENU,MEN_ID_MENU,NOMBRE_MENU,URL) values (7,1,'Profesion','/profesion/Index');
insert into MENU (ID_MENU,MEN_ID_MENU,NOMBRE_MENU,URL) values (8,2,'Genero','/generos/Index');
insert into MENU (ID_MENU,MEN_ID_MENU,NOMBRE_MENU,URL) values (9,2,'Region ','/region/Index');
insert into MENU (ID_MENU,MEN_ID_MENU,NOMBRE_MENU,URL) values (10,2,'Sub Region ','/sub_region/Index');

insert into MENU (ID_MENU,MEN_ID_MENU,NOMBRE_MENU,URL) values (11,null,'Gestion de menu',null);
insert into MENU (ID_MENU,MEN_ID_MENU,NOMBRE_MENU,URL) values (12,11,'Menus','/Menus/Index');
insert into MENU (ID_MENU,MEN_ID_MENU,NOMBRE_MENU,URL) values (13,11,'Asignar menu a roles','/MENUROL/Index');


insert into MENU (ID_MENU,MEN_ID_MENU,NOMBRE_MENU,URL) values (14,null,'Planillas',null);
insert into MENU (ID_MENU,MEN_ID_MENU,NOMBRE_MENU,URL) values (15,14,'Planilla','/Planillas');
insert into MENU (ID_MENU,MEN_ID_MENU,NOMBRE_MENU,URL) values (16,14,'Boleta de pago','/Planillas/PlanillaPorEmpleado');


SET IDENTITY_INSERT MENU off

insert into accede (ID_ROL,ID_MENU) values (1,1);
insert into accede (ID_ROL,ID_MENU) values (1,2);
insert into accede (ID_ROL,ID_MENU) values (1,3);
insert into accede (ID_ROL,ID_MENU) values (1,4);
insert into accede (ID_ROL,ID_MENU) values (1,5);
insert into accede (ID_ROL,ID_MENU) values (1,6);
insert into accede (ID_ROL,ID_MENU) values (1,7);
insert into accede (ID_ROL,ID_MENU) values (1,8);
insert into accede (ID_ROL,ID_MENU) values (1,9);
insert into accede (ID_ROL,ID_MENU) values (1,10);
insert into accede (ID_ROL,ID_MENU) values (1,11);
insert into accede (ID_ROL,ID_MENU) values (1,12);
insert into accede (ID_ROL,ID_MENU) values (1,13);
insert into accede (ID_ROL,ID_MENU) values (1,14);
insert into accede (ID_ROL,ID_MENU) values (1,15);
insert into accede (ID_ROL,ID_MENU) values (1,16);






