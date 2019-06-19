create procedure Centro_Costo_SP @id_planilla int
as
begin
	declare @id_centro_costo int
	
	declare cursor_centro_costo cursor for select id_centro_costo from CENTRO_COSTO
	--declare @total2 numeric(8,2)=0
	OPEN cursor_centro_costo
	FETCH FROM cursor_centro_costo into @id_centro_costo
 
	WHILE @@FETCH_STATUS=0
		BEGIN
			declare @id_empleado int, @salario_base numeric(8,2), @total numeric(8,2)=0, @comision bit
			declare @id_departamento int, @total2 numeric(8,2)=0
			declare cursor_ cursor for select e.id_empleado, SALARIO_BASE, d.ID_DEPARTAMENTO, COMISION from CENTRO_COSTO cc 
			join DEPARTAMENTO d on cc.ID_DEPARTAMENTO=d.ID_DEPARTAMENTO
			join PUESTO pu on d.ID_DEPARTAMENTO=pu.ID_DEPARTAMENTO
			join EMPLEADO e on pu.ID_PUESTO=e.ID_PUESTO
			join DESCUENTO_EMPLEADO demp on e.ID_EMPLEADO=demp.ID_EMPLEADO
			join CATALOGO_DESCUENTO cd on demp.ID_DESCUENTO=cd.ID_DESCUENTO
			join DETALLEPLANILLA dp on demp.ID_DESCUENTO_EMPLEADO=dp.ID_DESCUENTO_EMPLEADO
			join PLANILLA pl on dp.ID_PLANILLA=pl.ID_PLANILLA
			where cc.ID_CENTRO_COSTO=@id_centro_costo and pl.ID_PLANILLA=@id_planilla
			group by e.ID_EMPLEADO, SALARIO_BASE, d.ID_DEPARTAMENTO, COMISION
	
			OPEN cursor_
			FETCH FROM cursor_ into @id_empleado, @salario_base, @id_departamento, @comision
 
			-- check for a new row
			WHILE @@FETCH_STATUS=0
				BEGIN
					
					select @total=@salario_base

					declare @renta numeric(8,2)=0
					select @renta=@salario_base

					declare @comisionvalor numeric(8,2)=0
					declare @porcentaje_renta numeric(8,2)=null
					select top 1 @porcentaje_renta= porcentaje_renta from DESCUENTO_RENTA where @renta > MIN_RENTA and @renta <= MAX_RENTA
					if(@porcentaje_renta is not null)
						begin
								
							select @renta=@renta*@porcentaje_renta
						end
					else
						begin
							select @renta=0
						end
					select @total=@total-@renta

					declare @deley_descuento bit, @descuento numeric(8,2), @porcentaje numeric(8,2)
					declare cursor_descuento cursor for select cd.DELEY_DESCUENTO, cd.DESCUENTO, cd.PORCENTAJE from DESCUENTO_EMPLEADO demp 
					join CATALOGO_DESCUENTO cd on demp.ID_DESCUENTO=cd.ID_DESCUENTO where ID_EMPLEADO=@id_empleado and HABILITAR_DESCUENTO=1 and ACTIVO=1
					
					OPEN cursor_descuento
					FETCH FROM cursor_descuento into @deley_descuento, @descuento, @porcentaje
 
					-- check for a new row
					WHILE @@FETCH_STATUS=0
						BEGIN
							if(@deley_descuento=1)
								begin
									select @total=@total-(@salario_base*@porcentaje)
								end
							else
								begin
									select @total=@total-@descuento
								end
							FETCH NEXT FROM cursor_descuento into @deley_descuento, @descuento, @porcentaje
						END
						close cursor_descuento;
						deallocate cursor_descuento;

					declare @deley_ingreso bit, @ingreso numeric(8,2)
					declare cursor_ingreso cursor for select ci.DELEY_INGRESO, ci.INGRESO from INGRESO_EMPLEADO din
					join CATALOGO_INGRESO ci on din.ID_INGRESO=ci.ID_INGRESO where ID_EMPLEADO=@id_empleado and HABILITAR_INGRESO=1 and ACTIVO=1

					OPEN cursor_ingreso
					FETCH FROM cursor_ingreso into @deley_ingreso, @ingreso
 
					-- check for a new row
					WHILE @@FETCH_STATUS=0
						BEGIN
							if(@deley_ingreso!=1)
								begin
									select @total=@total+@ingreso
								end
							else
								begin
									if(@comision is not null and @comision=1)
										begin
											declare @porcentaje_por_comision numeric(8,2)=null
											select top 1 @porcentaje_por_comision= porcentaje_por_comision from RANGO_COMISION where @ingreso > MIN_COMISION and @ingreso <= MAX_COMISION
											if(@porcentaje_por_comision is not null)
												begin
													select @comisionvalor=@comisionvalor+(@ingreso*@porcentaje_por_comision)
													select @total=@total+@comisionvalor
												end
										end
								end

						
							FETCH NEXT FROM cursor_ingreso into @deley_ingreso, @ingreso
						END
						close cursor_ingreso;
						deallocate cursor_ingreso;
					select @total2=@total2+@total
				FETCH NEXT FROM cursor_ into @id_empleado, @salario_base, @id_departamento, @comision
				END
				close cursor_;
				deallocate cursor_;
			declare @anio int
			select @anio=year(fecha) from PLANILLA where ID_PLANILLA=@id_planilla
			declare @saldo numeric(8,2)
			select @saldo=saldo from CENTRO_COSTO where ID_CENTRO_COSTO=@id_centro_costo
			--select @total2=@total2+@total
			update CENTRO_COSTO set SALDO=@saldo-@total2 WHERE ID_CENTRO_COSTO=@id_centro_costo and ANIO=@anio
			FETCH NEXT FROM cursor_centro_costo into @id_centro_costo
		END
		close cursor_centro_costo;
		deallocate cursor_centro_costo;

end
go
/*TRIGGER*/
create or alter trigger descuento_trigger
on planilla
after update 
as 
begin
	set nocount on;
	declare @activo bit
	declare @id_planilla int
	select @id_planilla = [ID_PLANILLA] from inserted;
	select @activo = [ACTIVO] from inserted;
	if @activo = 0
		begin
			exec Centro_Costo_SP @id_planilla
		end
	
end
go