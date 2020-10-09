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