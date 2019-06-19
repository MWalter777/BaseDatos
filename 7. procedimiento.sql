create or alter procedure guardar_planilla
@id_empresa int, 
@id_planilla int
as 
begin try
begin transaction 
declare @ID_EMPLEADO int, @NOMBRE NCHAR(100), @SALARIO_BASE NUMERIC(8,2),@COMISION bit, @id_historia int, @rent numeric(2,2)
declare empleados cursor for SELECT e.ID_EMPLEADO, CONCAT(e.PRIMER_NOMBRE,' ', e.APELLIDO_PATERNO) as nombre, SALARIO_BASE, COMISION   FROM EMPLEADO e JOIN PUESTO p  on p.ID_PUESTO = e.ID_PUESTO JOIN DEPARTAMENTO d on d.ID_DEPARTAMENTO = p.ID_DEPARTAMENTO and ID_EMPRESA = @id_empresa

open empleados

fetch empleados into @ID_EMPLEADO, @NOMBRE, @SALARIO_BASE,@COMISION
while (@@FETCH_STATUS = 0)
begin
	insert into historial(ID_PLANILLA, NOMBRE_EMPLEADO_HISTORIAL,TOTAL, CODIGO_EMPLEADO) VALUES (@id_planilla,@NOMBRE, @SALARIO_BASE, convert(varchar,@ID_EMPLEADO))
	select @id_historia = ID_HISTORIAL from HISTORIAL where CODIGO_EMPLEADO = CONVERT(varchar,@ID_EMPLEADO) and ID_PLANILLA = @id_planilla

	select @rent = ISNULL(SUM(PORCENTAJE_RENTA),0) from DESCUENTO_RENTA where @SALARIO_BASE BETWEEN MIN_RENTA AND MAX_RENTA
	insert into DESCUENTO (ID_HISTORIAL,NOMBRE_DESCUENTO_HISTORIAL,DESCUENTO_HISTORIAL) values (@id_historia,'Renta',@rent*@SALARIO_BASE);

	if(@COMISION=1)
		begin
			insert into INGRESO (ID_HISTORIAL,NOMBRE_INGRESO_HISTORIAL,INGRESO_HISTORIAL) 
				select @id_historia as ID_HISTORIAL,ca.NOMBRE_INGRESO, case ca.DELEY_INGRESO when 1 then 
				ca.INGRESO*ca.COMISION
				else 
				ca.INGRESO
				end as ingreso_historial from CATALOGO_INGRESO as ca join INGRESO_EMPLEADO as i on ca.ID_INGRESO = i.ID_INGRESO where i.ID_EMPLEADO = @ID_EMPLEADO and ca.ACTIVO = 1 and i.HABILITAR_INGRESO = 1
		end
	else
		begin
			insert into INGRESO (ID_HISTORIAL,NOMBRE_INGRESO_HISTORIAL,INGRESO_HISTORIAL) 
				select @id_historia as ID_HISTORIAL,ca.NOMBRE_INGRESO, case ca.DELEY_INGRESO when 1 then 
				0.0
				else 
				ca.INGRESO
				end as ingreso_historial from CATALOGO_INGRESO as ca join INGRESO_EMPLEADO as i on ca.ID_INGRESO = i.ID_INGRESO where i.ID_EMPLEADO = @ID_EMPLEADO and ca.ACTIVO = 1 and i.HABILITAR_INGRESO = 1
		end
	

	insert into DESCUENTO  (ID_HISTORIAL,NOMBRE_DESCUENTO_HISTORIAL,DESCUENTO_HISTORIAL)
		select @id_historia as ID_HISTORIAL, ca_des.NOMBRE_DESCUENTO, case ca_des.DELEY_DESCUENTO
		WHEN 1 then
		@SALARIO_BASE*ca_des.PORCENTAJE
		else
		ca_des.DESCUENTO
		end
		as descu
		from CATALOGO_DESCUENTO as ca_des join DESCUENTO_EMPLEADO des_emp ON des_emp.ID_DESCUENTO = ca_des.ID_DESCUENTO and ca_des.ACTIVO = 1 and des_emp.ID_EMPLEADO = @ID_EMPLEADO




	fetch empleados into @ID_EMPLEADO, @NOMBRE, @SALARIO_BASE,@COMISION
end
close empleados
deallocate empleados

commit transaction
end try
begin catch
rollback transaction
end catch









