/*CREACION DE SP*/
create or alter procedure agregar_deley @id_descuento int
as
begin
	/* Variables */
	declare @id_empleado int
	declare @deley bit
	declare cursor_empleados cursor for
	select id_empleado from EMPLEADO;

	select @deley = [DELEY_DESCUENTO] from CATALOGO_DESCUENTO 
					 where ID_DESCUENTO = @id_descuento
	
	open cursor_empleados
	fetch next from cursor_empleados into @id_empleado
	
	if @deley = 1
	begin
		while @@FETCH_STATUS = 0
			begin
				insert into DESCUENTO_EMPLEADO(
				HABILITAR_DESCUENTO, ID_EMPLEADO, ID_DESCUENTO)
				values (1, @id_empleado, @id_descuento)

				fetch next from cursor_empleados into @id_empleado
			end
	end

	close cursor_empleados;
	deallocate cursor_empleados;
end
go
/*CREACION DE TRIGGER*/
create or alter trigger agregar_de_ley
on catalogo_descuento
after insert
as 
begin
	set nocount on;
	declare @id_descuento int
	select @id_descuento = [id_descuento] from inserted;

	exec agregar_deley @id_descuento
end
go
