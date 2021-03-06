CREATE or alter FUNCTION getLimMin(@id_puesto integer) RETURNS DECIMAL
AS
BEGIN 
	RETURN (SELECT SALARIO_MINIMO FROM PUESTO where id_puesto = @id_puesto)
END
GO



CREATE or alter FUNCTION getLimMax(@id_puesto integer) RETURNS DECIMAL
AS
BEGIN 
	RETURN (SELECT SALARIO_MAXIMO FROM PUESTO where id_puesto = @id_puesto)
END
GO


alter table EMPLEADO
ADD CONSTRAINT check_salario_puesto_min
CHECK (SALARIO_BASE >= [dbo].getLimMin(id_puesto))
GO

alter table EMPLEADO
ADD CONSTRAINT check_salario_puesto_max
CHECK (SALARIO_BASE <= [dbo].getLimMax(id_puesto))
GO



SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE getSubRegiones
	-- Add the parameters for the stored procedure here
	@idRegion int
AS
BEGIN
	SET NOCOUNT ON;
	IF(@idRegion = NULL)
		BEGIN
			SELECT @idRegion = 0
		END
   SELECT ID_SUB_REGION, NOMBRE_SUB_REGION, CODIGO_SUB_REGION, ID_REGION FROM SUB_REGION WHERE ID_REGION = @idRegion;
END
GO

CREATE PROCEDURE getRegiones
	-- Add the parameters for the stored procedure here
	@idPais int
AS
BEGIN
	SET NOCOUNT ON;
	IF(@idPais = NULL)
		BEGIN
			SELECT @idPais = 0
		END
   SELECT ID_REGION, CODIGO_REGION, ID_PAIS, NOMBRE_REGION FROM REGION WHERE ID_PAIS = @idPais;
   RETURN
END
GO

CREATE PROCEDURE getJefes
	-- Add the parameters for the stored procedure here
	@idPuesto int
AS
BEGIN
	SET NOCOUNT ON;
	IF(@idPuesto = NULL)
		BEGIN
			SELECT @idPuesto = 0
		END
   select e.APELLIDO_MATERNO, e.APELLIDO_PATERNO, e.CODIGO_EMPLEADO, e.COMISION, e.CORREO_INSTITUCIONAL, e.CORREO_PERSONAL, e.DUI, e.EMP_ID_EMPLEADO, e.FECHA_NACIMIENTO, e.ID_DIRECCION, e.ID_EMPLEADO, e.ID_ESTADO_CIVIL, e.ID_GENERO, e.ID_PROFESION, e.ID_PUESTO, e.ISSS, e.NIT, e.NUP, e.PASAPORTE, e.PRIMER_NOMBRE, e.SALARIO_BASE, e.SEGUNDO_NOMBRE from DEPARTAMENTO d inner join PUESTO p ON d.ID_DEPARTAMENTO=p.ID_DEPARTAMENTO AND d.ID_DEPARTAMENTO = (select h.ID_DEPARTAMENTO from PUESTO h WHERE h.ID_PUESTO = @idPuesto ) INNER JOIN EMPLEADO e ON e.ID_PUESTO = p.ID_PUESTO;
END
GO