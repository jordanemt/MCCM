﻿$(document).ready(function () {

    iniciarCalendarioDroga(moment());
});

function iniciarCalendarioDroga(fecha) {
    $('#TF_Fecha_Decomiso').daterangepicker({
        "singleDatePicker": true,
        "timePicker": true,
        "timePicker24Hour": true,
        "starDate": fecha,
        locale: {
            format: 'M/DD hh:mm A'
        }
    }, function (start, end, label) {
        console.log('New date range selected: ' + start.format('YYYY-MM-DD') + ' to ' + end.format('YYYY-MM-DD') + ' (predefined range: ' + label + ')');
    });
}

$(document).on("click", ".editarEntidadDroga", function () {

    $("#eventoIDI").val("1");
    $("#TC_Nombre_Droga").val("Marihuana");
    $("#TC_Detalle").val("Decomiso de gran cantidad de marihuana en Turrialba");
    $("#TN_Cantidad").val("500000");
    $("#TF_Fecha_Decomiso").val("10/09/2020 5:00PM");
    iniciarCalendarioDroga("10/09/2020 5:00PM");
    $("#divDrogaFC").show();
    $("#TF_Fecha_Creacion_Droga").val("10/09/2020 5:00PM");
    $("#TC_Creado_Por_Droga").val("Maikel Matamoros Zúñiga"); 
    $("#divDrogaMP").show();
    $("#TF_Modificado_Por_Droga").val("");
    $('#TB_Verificado_Droga').attr('checked', false);
    $("#btnModificarDroga").show();
    $("#btnAgregarEntidadDroga").hide();
  
    $("#entidadDrogaModal").modal("show");

});


$("#FormEntidadDroga").submit(function (e) {
    e.preventDefault();
    var form = new FormData($("#FormEntidadDroga")[0]);
    let url;

    AccionesEntidadDrogaForm(form, url);

});

function AccionesEntidadrogaForm(form, url) {
    //alert(JSON.stringify(Object.fromEntries(form)));
    $.ajax({
        type: "POST",
        url: "/E_Droga/Insertar_E_Droga",
        data: form,
        contentType: false,
        cache: false,
        processData: false,
    }).done(function (data) {
        alert(data);
        $("#entidadDrogaModal").modal("hide");

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