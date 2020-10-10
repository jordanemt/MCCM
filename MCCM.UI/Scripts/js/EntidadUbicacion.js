
$("#FormEntidadUbicacion").submit(function (e) {
    e.preventDefault();
    var form = new FormData($("#FormEntidadUbicacion")[0]);
    let url;

    AccionesEntidadUbicacionForm(form, url);

});

function AccionesEntidadUbicacionForm(form, url) {
    //alert(JSON.stringify(Object.fromEntries(form)));
    $.ajax({
        type: "POST",
        url: "/E_Ubicacion/Insertar_E_Ubicacion",
        data: form,
        contentType: false,
        cache: false,
        processData: false,
    }).done(function (data) {
        alert(data);
        $("#entidadUbicacionModal").modal("hide");

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
$(document).on("click", ".editarEntidadUbicacion", function () {
    $("#tituloEntidadUbicacion").hide();
    $("#modificarEntidadUbicacion").show();
    $("#TN_Id_Ubicacion").val("Edificio");
    $("#TN_ID_Provincia").val("Cartago");
    $("#TN_ID_Canton").val("No indica");
    $("#TN_ID_Distrito").val("No indica");
    $("#TC_Sennas").val("Por la ucr");
    $("#TD_Latitud").val("40.7143528");
    $("#TD_Longitud").val("-74.0059731");
    $("#fechaCreacion_Row_U").show();
    $("#TC_Creado_Por_U").val("Valeria");
    $("#TF_Fecha_Creacion_U").val("10/09/2020 5:00PM");
    $("#fechaModificación_Row_U").show();
    $("#modificadoPor_Row_U").show();
    $("#verificado_U").show();
    $("#btnInsertarEntidadUbicacion").hide();
    $("#btnCancelarEntidadUbicacion").hide();
    $("#btnModificarEntidadUbicacion").show();
    $("#btnEliminarEntidadUbicacion").show();
    $("#entidadUbicacionModal").modal("show");
});


$('#entidadUbicacionModal').on('hidden.bs.modal', function () {
    $("#FormEntidadUbicacion")[0].reset();
    $("#fechaCreacion_Row_U").hide();
    $("#fechaModificación_Row_U").hide();
    $("#modificadoPor_Row_U").hide();
    $("#btnInsertarEntidadUbicacion").show();
    $("#btnCancelarEntidadUbicacion").show();
    $("#btnModificarEntidadUbicacion").hide();
    $("#btnEliminarEntidadUbicacion").hide();
})