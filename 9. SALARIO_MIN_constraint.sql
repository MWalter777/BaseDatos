USE BAD115;
GO

CREATE FUNCTION getMinSal () RETURNS DECIMAL
AS
BEGIN
	RETURN (SELECT MONTO_SALARIO_MINIMO FROM SALARIO_MINIMO )
END
GO

alter table EMPLEADO
ADD CONSTRAINT check_salario_mayor_min
CHECK (SALARIO_BASE >= [dbo].getMinSal())
GO
/* 
SET IDENTITY_INSERT EMPLEADO ON

insert into EMPLEADO(ID_EMPLEADO,ID_DIRECCION,EMP_ID_EMPLEADO,ID_GENERO,ID_PROFESION,ID_ESTADO_CIVIL,ID_PUESTO,CODIGO_EMPLEADO,APELLIDO_MATERNO,APELLIDO_PATERNO,PRIMER_NOMBRE,SEGUNDO_NOMBRE,FECHA_NACIMIENTO,DUI,PASAPORTE,NIT,ISSS,NUP,SALARIO_BASE,CORREO_PERSONAL,CORREO_INSTITUCIONAL,COMISION)
VALUES(6, 1,1,1,1,1,1,'ASD','ASDASD','ASDASDASD', 'aa','bb','12-12-1999','123','123','1','123','ASDDDD', 300, 'correo','cporreoi',0);

select * from empleado;
*/