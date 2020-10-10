$("#FormEntidadArma").submit(function (e) {
    e.preventDefault();
    var form = new FormData($("#FormEntidadArma")[0]);
    let url;

    AccionesEntidadArmaForm(form, url);

});

function AccionesEntidadArmaForm(form, url) {
    //alert(JSON.stringify(Object.fromEntries(form)));
    $.ajax({
        type: "POST",
        url: "/E_Arma/Insertar_E_Arma",
        data: form,
        contentType: false,
        cache: false,
        processData: false,
    }).done(function (data) {
        alert(data);
        $("#entidadArmaModal").modal("hide");

    });
}

$(document).on("click", ".editarEntidadArma", function () {

    $("#TD_ID_Arma").val("1");
    $("#TC_Serie").val("000203las003");
    $("#TC_Detalle").val("Decomiso de gran cantidad de marihuana en Turrialba");
    $("#TC_Modelo_Arma").val("Modelo 1");
    $("#TC_Calibre_Arma").val("22");
    $("#TC_Comentario_Arma").val("Arma pequeña decomisada por ahi");
    $("#divFMA").show();
    $("#divFCA").show();
    $("#TF_Fecha_Creacion_Arma").val("10/09/2020 5:00PM");
    $("#TC_Creado_Por_Arma").val("Maikel Matamoros Zúñiga");
    $("#TC_Modificado_Por_Arma").val("");
    $('#TB_Verificado_Droga').attr('checked', false);
    $("#btnModificarEntidadArma").show();
    $("#btnEliminarEntidadArma").show();
    $("#btnCancelarEntidadArma").hide();
    $("#btnAgregarEntidadArma").hide(); 
    $("#entidadArmaModal").modal("show");

});

$('#entidadTelefonoModal').on('hidden.bs.modal', function () {
    $("#FormEntidadArma")[0].reset();
    $("#tituloEntidadArmaInsertar").show();
    $("#tituloEntidadArma").hide();
    $("#divFMA").hide();
    $("#divFCA").hide();
    $("#btnModificarEntidadArma").hide();
    $("#btnEliminarEntidadArma").hide();
    $("#btnCancelarEntidadArma").show();
    $("#btnAgregarEntidadArma").show(); 

})


$(document).ready(function () {

    $('#TF_Fecha_Nacimiento').daterangepicker({
        "singleDatePicker": true,
        "startDate": "09/29/2020",
        "endDate": "10/05/2020"
    }, function (start, end, label) {
        console.log('New date range selected: ' + start.format('YYYY-MM-DD') + ' to ' + end.format('YYYY-MM-DD') + ' (predefined range: ' + label + ')');
    });

})