create or alter trigger desactivar_descuento
on planilla
after update
as
begin
	set nocount on;
	
	declare cursor_descuentos cursor for
	select fecha_fin from CATALOGO_DESCUENTO;

	declare @fecha_fin datetime
	declare @fecha_actual datetime2
	declare @activo_planilla bit
	select @fecha_actual = SYSDATETIME();
	select @activo_planilla = activo from inserted

	open cursor_descuentos
	fetch next from cursor_descuentos into @fecha_fin

	if @activo_planilla = 0
	begin
		while @@FETCH_STATUS = 0
		begin
			if @fecha_actual >= @fecha_fin and @fecha_fin is not null
			begin
				update CATALOGO_DESCUENTO
				set ACTIVO = 0
				where current of cursor_descuentos;
			end
			fetch next from cursor_descuentos into @fecha_fin
		end
	end
	
	close cursor_descuentos;
	deallocate cursor_descuentos;
end