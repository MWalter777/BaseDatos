
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

insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (47,'index_departamento','Index de los departamentos');
insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (48,'crear_departamento','crear departamento');
insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (49,'editar_departamento','Editar departamento');
insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (50,'eliminar_departamento','eliminar departamento');

insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (51,'index_puesto','Index de los puestos');
insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (52,'crear_puesto','crear puesto');
insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (53,'editar_puesto','Editar puesto');
insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (54,'eliminar_puesto','eliminar puesto');

insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (55,'ver_empresa','ver empresa');
insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (56,'editar_empresa','configurar empresa');

insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (57,'index_descuento','Index de los descuentos');
insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (58,'crear_descuento','crear descuento');
insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (59,'editar_descuento','Editar descuento');
insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (60,'eliminar_descuento','eliminar descuento');

insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (61,'index_renta','Index de la renta');
insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (62,'crear_renta','crear renta');
insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (63,'editar_renta','Editar renta');
insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (64,'eliminar_renta','eliminar renta');

insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (65,'index_direccion','Index de las direcciones');
insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (66,'crear_direccion','crear direccion');
insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (67,'editar_direccion','Editar direccion');
insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (68,'eliminar_direccion','eliminar direccion');

insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (69,'index_empleado','Index de los empleados');
insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (70,'crear_empleado','crear empleado');
insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (71,'editar_empleado','Editar empleado');
insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (72,'eliminar_empleado','eliminar empleado');

insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (73,'index_centro_costo','Index de los centros de costo');
insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (74,'crear_centro_costo','crear centro de costo');
insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (75,'editar_centro_costo','Editar centro de costo');
insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (76,'eliminar_centro_costo','eliminar centro de costo');

insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (77,'index_ingreso_empleado','Index de los ingresos');
insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (78,'crear_ingreso_empleado','crear ingreso');
insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (79,'editar_ingreso_empleado','Editar ingreso');
insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (80,'eliminar_ingreso_empleado','eliminar ingreso');

insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (81,'index_periodicidad_anual','Index de la periodicidad');
insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (82,'crear_periodicidad_anual','crear periodicidad');
insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (83,'editar_periodicidad_anual','Editar periodicidad');
insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (84,'eliminar_periodicidad_anual','eliminar periodicidad');

insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (85,'index_planilla','Index de planilla');
insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (86,'ver_boleta_pago','Ver Boleta de pago');
insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (87,'pagar_planilla','Pagar planilla');
insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (88,'guardar_planilla','Guardar planilla');
insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (89,'editar_planilla','Editar planilla');
insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (90,'eliminar_planilla','Editar planilla');

insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (91,'index_rango_comision','Index del rango de comisiones');
insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (92,'crear_rango_comision','crear rango de comision');
insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (93,'editar_rango_comision','Editar rango de comision');
insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (94,'eliminar_rango_comision','eliminar rango de comision');

insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (95,'index_salario_minimo','Index del rango de comisiones');
insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (96,'editar_salario_minimo','Editar rango de comision');


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

insert into permite (id_rol,id_permiso) values(1,47);
insert into permite (id_rol,id_permiso) values(1,48);
insert into permite (id_rol,id_permiso) values(1,49);
insert into permite (id_rol,id_permiso) values(1,50);

insert into permite (id_rol,id_permiso) values(1,51);
insert into permite (id_rol,id_permiso) values(1,52);
insert into permite (id_rol,id_permiso) values(1,53);
insert into permite (id_rol,id_permiso) values(1,54);


insert into permite (id_rol,id_permiso) values(1,55);
insert into permite (id_rol,id_permiso) values(1,56);

insert into permite (id_rol,id_permiso) values(1,57);
insert into permite (id_rol,id_permiso) values(1,58);
insert into permite (id_rol,id_permiso) values(1,59);
insert into permite (id_rol,id_permiso) values(1,60);

insert into permite (id_rol,id_permiso) values(1,61);
insert into permite (id_rol,id_permiso) values(1,62);
insert into permite (id_rol,id_permiso) values(1,63);
insert into permite (id_rol,id_permiso) values(1,64);

insert into permite (id_rol,id_permiso) values(1,65);
insert into permite (id_rol,id_permiso) values(1,66);
insert into permite (id_rol,id_permiso) values(1,67);
insert into permite (id_rol,id_permiso) values(1,68);

insert into permite (id_rol,id_permiso) values(1,69);
insert into permite (id_rol,id_permiso) values(1,70);
insert into permite (id_rol,id_permiso) values(1,71);
insert into permite (id_rol,id_permiso) values(1,72);

insert into permite (id_rol,id_permiso) values(1,73);
insert into permite (id_rol,id_permiso) values(1,74);
insert into permite (id_rol,id_permiso) values(1,75);
insert into permite (id_rol,id_permiso) values(1,76);

insert into permite (id_rol,id_permiso) values(1,77);
insert into permite (id_rol,id_permiso) values(1,78);
insert into permite (id_rol,id_permiso) values(1,79);
insert into permite (id_rol,id_permiso) values(1,80);

insert into permite (id_rol,id_permiso) values(1,81);
insert into permite (id_rol,id_permiso) values(1,82);
insert into permite (id_rol,id_permiso) values(1,83);
insert into permite (id_rol,id_permiso) values(1,84);

insert into permite (id_rol,id_permiso) values(1,85);
insert into permite (id_rol,id_permiso) values(1,86);
insert into permite (id_rol,id_permiso) values(1,87);
insert into permite (id_rol,id_permiso) values(1,88);
insert into permite (id_rol,id_permiso) values(1,89);
insert into permite (id_rol,id_permiso) values(1,90);

insert into permite (id_rol,id_permiso) values(1,91);
insert into permite (id_rol,id_permiso) values(1,92);
insert into permite (id_rol,id_permiso) values(1,93);
insert into permite (id_rol,id_permiso) values(1,94);

insert into permite (id_rol,id_permiso) values(1,95);
insert into permite (id_rol,id_permiso) values(1,96);
insert into permite (id_rol,id_permiso) values(1,95);
insert into permite (id_rol,id_permiso) values(1,96);

SET IDENTITY_INSERT usuario ON

insert into usuario (id_usuario,id_empleado,id_rol,USERNAME,email,password,habilitado) values(1,null,1,'BAD115','superusuariosap777@gmail.com','3GseFNXe8JBJ+WiHMprogrWwX4U=',1);

SET IDENTITY_INSERT usuario off


SET IDENTITY_INSERT MENU ON

insert into MENU (ID_MENU,MEN_ID_MENU,NOMBRE_MENU,URL) values (1,null,'Gestion de usuarios',null);
insert into MENU (ID_MENU,MEN_ID_MENU,NOMBRE_MENU,URL) values (2,null,'Catalogo',null);
insert into MENU (ID_MENU,MEN_ID_MENU,NOMBRE_MENU,URL) values (3,1,'Usuarios','/Usuario/Index');
insert into MENU (ID_MENU,MEN_ID_MENU,NOMBRE_MENU,URL) values (4,1,'Roles','/Rols/Index');
insert into MENU (ID_MENU,MEN_ID_MENU,NOMBRE_MENU,URL) values (5,1,'Permisos','/Permisoes/index');

insert into MENU (ID_MENU,MEN_ID_MENU,NOMBRE_MENU,URL) values (6,2,'Estados Civiles','/ESTADO_CIVIL/Index');
insert into MENU (ID_MENU,MEN_ID_MENU,NOMBRE_MENU,URL) values (7,1,'Profesiones','/profesion/Index');
insert into MENU (ID_MENU,MEN_ID_MENU,NOMBRE_MENU,URL) values (8,2,'Géneros','/generos/Index');
insert into MENU (ID_MENU,MEN_ID_MENU,NOMBRE_MENU,URL) values (9,2,'Regiones','/region/Index');
insert into MENU (ID_MENU,MEN_ID_MENU,NOMBRE_MENU,URL) values (10,2,'Subregiones','/sub_region/Index');

insert into MENU (ID_MENU,MEN_ID_MENU,NOMBRE_MENU,URL) values (11,null,'Gestion de menu',null);
insert into MENU (ID_MENU,MEN_ID_MENU,NOMBRE_MENU,URL) values (12,11,'Menus','/Menus/Index');
insert into MENU (ID_MENU,MEN_ID_MENU,NOMBRE_MENU,URL) values (13,11,'Asignar menu a roles','/MENUROL/Index');


insert into MENU (ID_MENU,MEN_ID_MENU,NOMBRE_MENU,URL) values (14,null,'Planillas',null);
insert into MENU (ID_MENU,MEN_ID_MENU,NOMBRE_MENU,URL) values (15,14,'Planilla','/Planillas');
insert into MENU (ID_MENU,MEN_ID_MENU,NOMBRE_MENU,URL) values (16,14,'Boleta de pago','/Planillas/PlanillaPorEmpleado');

insert into MENU (ID_MENU,MEN_ID_MENU,NOMBRE_MENU, URL) values (17,14,'Renta', '/Descuento_renta');
insert into MENU (ID_MENU,MEN_ID_MENU,NOMBRE_MENU, URL) values (18,14,'Descuentos', '/Catalogo_descuento/Index');

insert into MENU (ID_MENU,MEN_ID_MENU,NOMBRE_MENU, URL) values (19,2,'Paises', '/Pais');
insert into MENU (ID_MENU,MEN_ID_MENU,NOMBRE_MENU, URL) values (20,2,'Departamentos', '/Departamento');
insert into MENU (ID_MENU,MEN_ID_MENU,NOMBRE_MENU, URL) values (21,2,'Puestos', '/Puesto');
insert into MENU (ID_MENU,MEN_ID_MENU,NOMBRE_MENU, URL) values (22,2,'Direcciones', '/Direccion');
insert into MENU (ID_MENU,MEN_ID_MENU,NOMBRE_MENU, URL) values (23,2,'Empleados', '/Empleadoes');
insert into MENU (ID_MENU,MEN_ID_MENU,NOMBRE_MENU, URL) values (24,14,'Centro de costos', '/Centro_costo');
insert into MENU (ID_MENU,MEN_ID_MENU,NOMBRE_MENU, URL) values (25,14,'Empresa', '/Empresa');
insert into MENU (ID_MENU,MEN_ID_MENU,NOMBRE_MENU, URL) values (26,14,'Ingreso de empleados', '/ingreso_empleado');
insert into MENU (ID_MENU,MEN_ID_MENU,NOMBRE_MENU, URL) values (27,14,'Periodicidad Anual', '/periodicidad_anual');
insert into MENU (ID_MENU,MEN_ID_MENU,NOMBRE_MENU, URL) values (28,14,'Rango de comisiones', '/rango_comision');


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
insert into accede (ID_ROL,ID_MENU) values (1,17);
insert into accede (ID_ROL,ID_MENU) values (1,18);

insert into accede (ID_ROL,ID_MENU) values (1,19);
insert into accede (ID_ROL,ID_MENU) values (1,20);
insert into accede (ID_ROL,ID_MENU) values (1,21);
insert into accede (ID_ROL,ID_MENU) values (1,22);
insert into accede (ID_ROL,ID_MENU) values (1,23);
insert into accede (ID_ROL,ID_MENU) values (1,24);
insert into accede (ID_ROL,ID_MENU) values (1,25);
insert into accede (ID_ROL,ID_MENU) values (1,26);
insert into accede (ID_ROL,ID_MENU) values (1,27);
insert into accede (ID_ROL,ID_MENU) values (1,28);




