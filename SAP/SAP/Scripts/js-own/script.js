$(function (){

	$("#DELEY_DESCUENTO").change(function () {
		if (this.checked) {
			$("#create_porcentaje").show();
			$("#PORCENTAJE").val("").prop('required', true);
			$("#create_descuento").hide().prop('required', false);
			$("#create_fechainicio").hide().prop('required', false);
			$("#create_fechafin").hide().prop('required', false);
		} else {
			$("#create_porcentaje").hide();
			$("#PORCENTAJE").val("").prop('required', false);
			$("#DESCUENTO").val("").prop('required', true);
			$("#FECHA_INICIO").val("").prop('required', true);
			$("#FECHA_FIN").val("").prop('required', true);
			$("#create_descuento").show();
			$("#create_fechainicio").show();
			$("#create_fechafin").show();
		}
	});
	
});