CREATE or alter TRIGGER TR_EMPLEADO_INSERT
ON catalogo_ingreso
AFTER INSERT, UPDATE
AS
--SET NOCOUNT ON agregado para evitar conjuntos de resultados adicionales
-- interferir con las instrucciones SELECT.
	SET NOCOUNT ON;
	declare @ID_INGRESO int, @INGRESO numeric(8,2) , @COMISION numeric(8,2)
	BEGIN
	select @INGRESO = [INGRESO] from INSERTED;
	select @ID_INGRESO = [ID_INGRESO] from INSERTED;
	select @COMISION = [PORCENTAJE_POR_COMISION] from RANGO_COMISION where @INGRESO BETWEEN MIN_COMISION and MAX_COMISION;
	update catalogo_ingreso set comision = @COMISION where ID_INGRESO = @ID_INGRESO; 
END