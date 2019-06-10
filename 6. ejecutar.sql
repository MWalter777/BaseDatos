SET IDENTITY_INSERT rango_comision ON
insert into rango_comision (id_rango,min_comision,max_comision,porcentaje_por_comision) values(1,100,300,0.10);
insert into rango_comision (id_rango,min_comision,max_comision,porcentaje_por_comision) values(2,301,500,0.20);
insert into rango_comision (id_rango,min_comision,max_comision,porcentaje_por_comision) values(3,501,700,0.30);
insert into rango_comision (id_rango,min_comision,max_comision,porcentaje_por_comision) values(4,701,900,0.40);
insert into rango_comision (id_rango,min_comision,max_comision,porcentaje_por_comision) values(5,901,2000,0.50);
insert into rango_comision (id_rango,min_comision,max_comision,porcentaje_por_comision) values(6,2001,800000,0.70);
SET IDENTITY_INSERT rango_comision off



SET IDENTITY_INSERT CATALOGO_DESCUENTO ON

insert into CATALOGO_DESCUENTO (ID_DESCUENTO,NOMBRE_DESCUENTO,DELEY_DESCUENTO,PORCENTAJE,DESCUENTO,FECHA_INICIO,FECHA_FIN,activo) VALUES (1,'AFP',1,0.03,null,null,null,0);
insert into CATALOGO_DESCUENTO (ID_DESCUENTO,NOMBRE_DESCUENTO,DELEY_DESCUENTO,PORCENTAJE,DESCUENTO,FECHA_INICIO,FECHA_FIN,activo) VALUES (2,'ISSS',1,0.06, null, null, null,1);
insert into CATALOGO_DESCUENTO (ID_DESCUENTO,NOMBRE_DESCUENTO,DELEY_DESCUENTO,PORCENTAJE,DESCUENTO,FECHA_INICIO,FECHA_FIN,activo) VALUES (3,'cuota mensual',0,null, 70.56, '2018-05-06', '2019-09-09',1);

SET IDENTITY_INSERT CATALOGO_DESCUENTO off

SET IDENTITY_INSERT catalogo_ingreso ON

insert into catalogo_ingreso(ID_INGRESO,NOMBRE_INGRESO,DELEY_INGRESO,INGRESO,activo,comision) VALUES(1,'Comision',1,356.56,1,null);
insert into catalogo_ingreso(ID_INGRESO,NOMBRE_INGRESO,DELEY_INGRESO,INGRESO,activo,comision) VALUES(2,'otro ingreso',0,506.89,1, null);
insert into catalogo_ingreso(ID_INGRESO,NOMBRE_INGRESO,DELEY_INGRESO,INGRESO,activo,comision) VALUES(3,'bonificacion',0,253.56,1,null);
insert into catalogo_ingreso(ID_INGRESO,NOMBRE_INGRESO,DELEY_INGRESO,INGRESO,activo,comision) VALUES(4,'cOMISIION',1,256.56,1,null);

SET IDENTITY_INSERT catalogo_ingreso off


SET IDENTITY_INSERT empresa ON
insert into empresa (id_empresa,nombre_empresa,direccion,representante,nit_empresa,nic,telefono_empresa,pagina_web,correo_empresa,PAGE) values(1,'Empresa SA','San salvador','29 AV norte','asdfasd','12344567','77885599','empresa.com','empresa@gmail.com','Empresa');
SET IDENTITY_INSERT empresa off



SET IDENTITY_INSERT departamento ON
insert into departamento(id_departamento,id_empresa,dep_id_departamento,nombre_departamento) values(1,1,null,'Departamento de ventas');
SET IDENTITY_INSERT departamento off

SET IDENTITY_INSERT centro_costo ON
insert into centro_costo(id_centro_costo,id_departamento,anio,monto_asignado,saldo) values(1,1,2019,985685.45,0.0);
SET IDENTITY_INSERT centro_costo off

SET IDENTITY_INSERT pais ON
insert into pais(id_pais,codigo_pais,nombre_pais) values(1,'ES','El Salvador');
SET IDENTITY_INSERT pais off


SET IDENTITY_INSERT region ON
insert into region(id_region,id_pais,codigo_region,nombre_region) values(1,1,'SS','San Salvador');
SET IDENTITY_INSERT region off

SET IDENTITY_INSERT sub_region ON
insert into sub_region(id_sub_region,id_region,codigo_sub_region,nombre_sub_region) values(1,1,'SS','San Salvador');
SET IDENTITY_INSERT sub_region off


SET IDENTITY_INSERT direccion ON
insert into direccion(id_direccion,id_sub_region,barrio,colonia,canton,caserio,calle,avenida,pasaje,residencial,numero_casa) values(1,1,'San jose','Mercedes','canton el jocote','Caserio san esteban :v','25','A.V norte','pasaje numero 4','residencial las flores','casa numero 7');
SET IDENTITY_INSERT direccion off


SET IDENTITY_INSERT estado_civil ON
insert into estado_civil(id_estado_civil,nombre_estado_civil) values(1,'casad@');
SET IDENTITY_INSERT estado_civil off


SET IDENTITY_INSERT genero ON
insert into genero(id_genero,nombre_genero) values(1,'Masculino');
insert into genero(id_genero,nombre_genero) values(2,'Femenino');
SET IDENTITY_INSERT genero off


SET IDENTITY_INSERT profesion ON
insert into profesion(id_profesion,nombre_profesion) values(1,'Vendedor');
SET IDENTITY_INSERT profesion off


SET IDENTITY_INSERT puesto ON
insert into puesto(id_puesto,id_departamento,codigo_puesto,nombre_puesto,salario_minimo,salario_maximo) values(1,1,'VN001','Vendedor',300.00,25605.56);
SET IDENTITY_INSERT puesto off


SET IDENTITY_INSERT empleado ON

insert into empleado (id_empleado,id_direccion,emp_id_empleado,id_genero,id_profesion,id_estado_civil,id_puesto,codigo_empleado,apellido_materno,apellido_paterno,primer_nombre,segundo_nombre,fecha_nacimiento,dui,pasaporte,nit,isss,nup,salario_base,correo_personal,correo_institucional,comision) 
values(1,1,null,1,1,1,1,'EMP001','Martinez','Hernandez','Gabriela','Lisset','1995-05-06','8756984-3',null,'78459632-5','784526-4','7856425-54',563,'correo@gmail.com','correo@empresa.com',0);

insert into empleado (id_empleado,id_direccion,emp_id_empleado,id_genero,id_profesion,id_estado_civil,id_puesto,codigo_empleado,apellido_materno,apellido_paterno,primer_nombre,segundo_nombre,fecha_nacimiento,dui,pasaporte,nit,isss,nup,salario_base,correo_personal,correo_institucional,comision) 
values(2,1,null,1,1,1,1,'EMP002','Sanchez','Barrios','Mercedes','Emelina','1995-05-06','8756984-3',null,'78459632-5','784526-4','7856425-54',450,'correo@gmail.com','correo@empresa.com',1);

insert into empleado (id_empleado,id_direccion,emp_id_empleado,id_genero,id_profesion,id_estado_civil,id_puesto,codigo_empleado,apellido_materno,apellido_paterno,primer_nombre,segundo_nombre,fecha_nacimiento,dui,pasaporte,nit,isss,nup,salario_base,correo_personal,correo_institucional,comision) 
values(3,1,null,1,1,1,1,'EMP003','Ascencio','Muños','Ana','Ruth','1995-05-06','8756984-3',null,'78459632-5','784526-4','7856425-54',350,'correo@gmail.com','correo@empresa.com',1);

insert into empleado (id_empleado,id_direccion,emp_id_empleado,id_genero,id_profesion,id_estado_civil,id_puesto,codigo_empleado,apellido_materno,apellido_paterno,primer_nombre,segundo_nombre,fecha_nacimiento,dui,pasaporte,nit,isss,nup,salario_base,correo_personal,correo_institucional,comision) 
values(4,1,null,1,1,1,1,'EMP004','Torres','Martinez','Claudia','Beatriz','1995-05-06','8756984-3',null,'78459632-5','784526-4','7856425-54',670,'correo@gmail.com','correo@empresa.com',1);

SET IDENTITY_INSERT empleado off


SET IDENTITY_INSERT descuento_empleado ON
insert into descuento_empleado (habilitar_descuento,id_descuento_empleado,id_empleado,id_descuento) values(1,1,1,1);
insert into descuento_empleado (habilitar_descuento,id_descuento_empleado,id_empleado,id_descuento) values(1,2,1,2);
insert into descuento_empleado (habilitar_descuento,id_descuento_empleado,id_empleado,id_descuento) values(1,3,1,3);

SET IDENTITY_INSERT descuento_empleado ON
insert into descuento_empleado (habilitar_descuento,id_descuento_empleado,id_empleado,id_descuento) values(1,5,2,1);
insert into descuento_empleado (habilitar_descuento,id_descuento_empleado,id_empleado,id_descuento) values(1,6,2,2);
insert into descuento_empleado (habilitar_descuento,id_descuento_empleado,id_empleado,id_descuento) values(1,7,2,3);

insert into descuento_empleado (habilitar_descuento,id_descuento_empleado,id_empleado,id_descuento) values(1,8,3,1);
insert into descuento_empleado (habilitar_descuento,id_descuento_empleado,id_empleado,id_descuento) values(1,9,3,2);
insert into descuento_empleado (habilitar_descuento,id_descuento_empleado,id_empleado,id_descuento) values(1,10,3,3);

insert into descuento_empleado (habilitar_descuento,id_descuento_empleado,id_empleado,id_descuento) values(1,11,4,1);
insert into descuento_empleado (habilitar_descuento,id_descuento_empleado,id_empleado,id_descuento) values(1,12,4,2);
insert into descuento_empleado (habilitar_descuento,id_descuento_empleado,id_empleado,id_descuento) values(1,13,4,3);

SET IDENTITY_INSERT descuento_empleado off

SET IDENTITY_INSERT descuento_empleado off


SET IDENTITY_INSERT ingreso_empleado ON
insert into ingreso_empleado (habilitar_ingreso,id_ingreso_empleado,id_empleado,id_ingreso) values(1,1,1,1);
insert into ingreso_empleado (habilitar_ingreso,id_ingreso_empleado,id_empleado,id_ingreso) values(1,2,3,1);
insert into ingreso_empleado (habilitar_ingreso,id_ingreso_empleado,id_empleado,id_ingreso) values(1,3,4,1);
SET IDENTITY_INSERT ingreso_empleado off


SET IDENTITY_INSERT periodicidad_anual ON
insert into periodicidad_anual (id_periodicidad,anio_periodicidad, quincenal,mensual) values (1,2019,0,1);
SET IDENTITY_INSERT periodicidad_anual off



SET IDENTITY_INSERT salario_minimo ON
insert into salario_minimo (id_salario_minimo,monto_salario_minimo) values(1,300);
SET IDENTITY_INSERT salario_minimo off



SET IDENTITY_INSERT descuento_renta ON
insert into descuento_renta (id_descuento_renta,min_renta,max_renta,porcentaje_renta) values(1,400,600,0.07);
SET IDENTITY_INSERT descuento_renta off



SET IDENTITY_INSERT PERIODICIDAD_ANUAL ON
insert into PERIODICIDAD_ANUAL (ID_PERIODICIDAD,ANIO_PERIODICIDAD,QUINCENAL,MENSUAL) values(1,2019,0,1);
SET IDENTITY_INSERT PERIODICIDAD_ANUAL off











