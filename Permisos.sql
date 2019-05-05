SET IDENTITY_INSERT permiso ON

insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (4,'index_estado','Permiso para ver todas las listas de usuarios');
insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (5,'crear_estado','Editar los usuarios');
insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (6,'editar_estado','Permiso para eliminar los usuarios');
insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (7,'eliminar_estado','Permiso para eliminar los usuarios');
insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (8,'index_permiso','Ver lista de permisos');
insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (9,'crear_permiso','Crear nuevos permisos');
insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (10,'editar_permiso','Editar los permisos');
insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (11,'eliminar_permiso','Eliminar los permisos');

SET IDENTITY_INSERT permiso off

insert into permite (id_rol,id_permiso) values(1,4);
insert into permite (id_rol,id_permiso) values(1,5);
insert into permite (id_rol,id_permiso) values(1,6);
insert into permite (id_rol,id_permiso) values(1,7);

insert into permite (id_rol,id_permiso) values(1,8);
insert into permite (id_rol,id_permiso) values(1,9);
insert into permite (id_rol,id_permiso) values(1,10);
insert into permite (id_rol,id_permiso) values(1,11);
