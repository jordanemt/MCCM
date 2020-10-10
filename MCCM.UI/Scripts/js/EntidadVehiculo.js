$("#FormEntidadVehiculo").submit(function (e) {
    e.preventDefault();
    var form = new FormData($("#FormEntidadVehiculo")[0]);
    let url;

    AccionesEntidadVehiculoForm(form, url);

});

function AccionesEntidadVehiculoForm(form, url) {
    //alert(JSON.stringify(Object.fromEntries(form)));
    $.ajax({
        type: "POST",
        url: "/E_Vehiculo/Insertar_E_Vehiculo",
        data: form,
        contentType: false,
        cache: false,
        processData: false,
    }).done(function (data) {
        alert(data);
        $("#entidadVehículoModal").modal("hide");

    });
}

/*function limpiarFormularioCaso() {
    $("#TN_ID_Caso").val("");
    $("#TN_ECU").val("");
    $("#TC_Nombre_Caso").val("");
    $("#TC_Enfoque_Trabajo").val("");
    $("#TC_Area_Trabajo").val("");
    $("#TN_Nivel").val("");
    $("#TC_Descripcion").val("");
    $("#TC_Fuente").val("");
    $("#TC_Delito").val("");
}
*/


$(document).ready(function () {

    $('#TF_Fecha_Nacimiento').daterangepicker({
        "singleDatePicker": true,
        "startDate": "09/29/2020",
        "endDate": "10/05/2020"
    }, function (start, end, label) {
        console.log('New date range selected: ' + start.format('YYYY-MM-DD') + ' to ' + end.format('YYYY-MM-DD') + ' (predefined range: ' + label + ')');
    });

})
$(document).on("click", ".editarEntidadVehiculo", function () {
    $("#tituloEntidadVehiculo").hide();
    $("#modificarEntidadVehiculo").show();
    $("#TC_Placa").val("000000");
    $("#TN_ID_Marca_Vehiculo").val("Foredil");
    $("#TC_Clase").val("Motocicleta");
    $("#TN_ID_Color_Vehiculo").val("Celeste");
    $("#TC_Estilo").val("Fossae");
    $("#TN_Anno").val("2010");
    $("#fechaCreacion_Row_V").show();
    $("#TC_Creado_Por_V").val("Valeria");
    $("#TF_Fecha_Creacion_V").val("10/09/2020 5:00PM");
    $("#fechaModificación_Row_V").show();
    $("#modificadoPor_Row_V").show();
    $("#verificado_V").show();
    $("#btnInsertarEntidadVehiculo").hide();
    $("#btnCancelarEntidadVehiculo").hide();
    $("#btnModificarEntidadVehiculo").show();
    $("#btnEliminarEntidadVehiculo").show();
    $("#entidadVehículoModal").modal("show");
});


$('#entidadVehículoModal').on('hidden.bs.modal', function () {
    $("#FormEntidadVehiculo")[0].reset();
    $("#fechaCreacion_Row_V").hide();
    $("#fechaModificación_Row_V").hide();
    $("#modificadoPor_Row_V").hide();
})