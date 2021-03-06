CREATE OR ALTER TRIGGER desactivar_ingreso
ON planilla
AFTER UPDATE
AS
	BEGIN
		DECLARE @OldValue int, @NewValue int
		DECLARE @IDPlanilla int

		IF UPDATE(ACTIVO)
			SELECT @NewValue = ACTIVO FROM INSERTED
			SELECT @IDPlanilla = ID_PLANILLA FROM INSERTED
			UPDATE CATALOGO_INGRESO SET ACTIVO=@NewValue
			UPDATE INGRESO_EMPLEADO SET HABILITAR_INGRESO=@NewValue
	END
