SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE OR ALTER TRIGGER insertar_comisiones_de_ley
   ON  EMPLEADO 
   AFTER INSERT
AS 
BEGIN
	SET NOCOUNT ON;
		declare @idDescuento AS int;
		declare @empleadoGuardado AS int;
		select @empleadoGuardado = ID_EMPLEADO from inserted;
		declare cursor_descuentos_ley cursor for select ID_DESCUENTO from CATALOGO_DESCUENTO WHERE DELEY_DESCUENTO=1;
		
		open cursor_descuentos_ley
		fetch next from cursor_descuentos_ley into @idDescuento
		while @@FETCH_STATUS = 0
			BEGIN
				insert into DESCUENTO_EMPLEADO(ID_EMPLEADO,ID_DESCUENTO,HABILITAR_DESCUENTO) VALUES (@empleadoGuardado,@idDescuento,1);
				fetch next from cursor_descuentos_ley into @idDescuento
			END
		close cursor_descuentos_ley
		deallocate cursor_descuentos_ley
END
GO
