SET IDENTITY_INSERT MENU ON
insert into MENU (ID_MENU,MEN_ID_MENU,NOMBRE_MENU,URL) values (1,null,'Gestion de usuarios',null);
insert into MENU (ID_MENU,MEN_ID_MENU,NOMBRE_MENU,URL) values (2,null,'Catalogo',null);
insert into MENU (ID_MENU,MEN_ID_MENU,NOMBRE_MENU,URL) values (3,1,'Usuarios','/Usuario/Index');
insert into MENU (ID_MENU,MEN_ID_MENU,NOMBRE_MENU,URL) values (4,1,'Roles','/');
insert into MENU (ID_MENU,MEN_ID_MENU,NOMBRE_MENU,URL) values (5,1,'Permisos','/');
insert into MENU (ID_MENU,MEN_ID_MENU,NOMBRE_MENU,URL) values (6,1,'Empleados','/');

insert into MENU (ID_MENU,MEN_ID_MENU,NOMBRE_MENU,URL) values (7,2,'Estado Civil','/ESTADO_CIVIL/Index');
insert into MENU (ID_MENU,MEN_ID_MENU,NOMBRE_MENU,URL) values (8,2,'Profesion','/');
insert into MENU (ID_MENU,MEN_ID_MENU,NOMBRE_MENU,URL) values (9,2,'Genero','/');
insert into MENU (ID_MENU,MEN_ID_MENU,NOMBRE_MENU,URL) values (10,2,'Estructura organizativa','/');
insert into MENU (ID_MENU,MEN_ID_MENU,NOMBRE_MENU,URL) values (11,2,'Estructura territorial','/');
insert into MENU (ID_MENU,MEN_ID_MENU,NOMBRE_MENU,URL) values (12,2,'Puesto','/');

insert into MENU (ID_MENU,MEN_ID_MENU,NOMBRE_MENU,URL) values (13,null,'Gestion de menu',null);
insert into MENU (ID_MENU,MEN_ID_MENU,NOMBRE_MENU,URL) values (14,13,'Menus','/Menus/Index');
insert into MENU (ID_MENU,MEN_ID_MENU,NOMBRE_MENU,URL) values (15,13,'Asignar menu a roles','/MENUROL/Index');
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
