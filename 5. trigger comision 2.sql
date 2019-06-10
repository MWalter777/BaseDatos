CREATE or alter TRIGGER insert_catalogo
ON INGRESO_EMPLEADO
AFTER INSERT
AS
--SET NOCOUNT ON agregado para evitar conjuntos de resultados adicionales
-- interferir con las instrucciones SELECT.
	SET NOCOUNT ON;
	declare @ID_EMPLEADO int
	BEGIN
	select @ID_EMPLEADO = [ID_EMPLEADO] from INSERTED;
	if (select COUNT(DELEY_INGRESO) as conteo from CATALOGO_INGRESO as ca join INGRESO_EMPLEADO as i on i.ID_INGRESO = ca.ID_INGRESO and ID_EMPLEADO = 1 AND DELEY_INGRESO = 1) > 1
		begin
			rollback transaction;
			raiserror('YA TIENES ASIGNADO UN INGRESO DE LEY',15,1);
		end
END