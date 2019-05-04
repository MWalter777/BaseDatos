SET IDENTITY_INSERT permiso ON

insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (4,'index_estado','Permiso para ver todas las listas de usuarios');
insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (5,'crear_estado','Editar los usuarios');
insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (6,'editar_estado','Permiso para eliminar los usuarios');
insert into permiso (ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO) values (7,'eliminar_estado','Permiso para eliminar los usuarios');

SET IDENTITY_INSERT permiso off

insert into permite (id_rol,id_permiso) values(1,4);
insert into permite (id_rol,id_permiso) values(1,5);
insert into permite (id_rol,id_permiso) values(1,6);
