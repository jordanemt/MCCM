﻿$(document).on("click", "#btnModificar", function (e) {
    e.preventDefault();
    var form = $("#FormCaso");
    alert(form.serialize());
    let url;
    url = "/Caso/ActualizarCaso";
    AccionesCasoForm(form, url);

});

$(document).on("click", "#btnEliminar", function (e) {
    e.preventDefault();
    alert("Eliminar");

    $.ajax({
        type: "POST",
        url: "/Caso/EliminarCasoPorID",
        data: { "ID": $("#TN_ID_Caso").val() }
    }).done(function (data) {
        $("#ModalFormCaso").modal("hide");
        CargarCasos();
    });

});

$(document).on("click", "#btnRegistrarEvento", function (e) {
    e.preventDefault();
    var form = $("#FormEvento");
    let eventos = JSON.parse(JSON.stringify(form.serializeArray()));
    let url;
    url = "/Caso/InsertarCaso";
    $("#bitacora-body").empty();
    for (let i = 0; i < casos.length; i++) {

        $("#bitacora-body").append(
            '<div class="card evento" id="' + eventos.TN_ID_Caso + '" style="height:10em;">' +
            '<div class="card-header"><div>Caso #' + eventos.TN_ID_Caso + '</div>' +
            '<a href="#" class="ojito" id="' + eventos.TN_ID_Caso + '"><span><i class="fa fa-eye" aria-hidden="true"></i></span></a></div >' +
            '<div class="card-body" style="padding:0px!important">' +
            '<h6><small>Nombre:' + casos[i].TC_Nombre_Caso + '</small></h5>' +
            '<h6><small>Fecha: ' + casos[i].TF_Fecha + '</small></h5>' +
            '<h6><small>Delito: ' + casos[i].TC_Delito + '</small></h5>' +
            '</div>' +
            '</div>'
        );
    }
    //AccionesCasoForm(form, url);

});


function AccionesCasoForm(form, url) {
    $.ajax({
        type: "POST",
        url: url,
        data: form.serialize()

    }).done(function (data) {
        $("#ModalFormCaso").modal("hide");
        CargarCasos();
    });
}

function CargarCasos() {
    $.ajax({
        type: "GET",
        url: "/Caso/ListarCasos"
    }).done(function (data) {
        let casos = new Array();
        casos = JSON.parse(data);
        $("#casos-body").empty();
        for (let i = 0; i < casos.length; i++) {

            $("#casos-body").append(
                '<div class="card caso" id="' + casos[i].TN_ID_Caso + '" style="height:10em;">' +
                '<div class="card-header"><div>Caso #' + casos[i].TN_ID_Caso + '</div>' +
                '<a href="#" class="ojito" id="' + casos[i].TN_ID_Caso + '"><span><i class="fa fa-eye" aria-hidden="true"></i></span></a></div >' +
                '<div class="card-body" style="padding:0px!important">' +
                '<h6><small>Nombre:' + casos[i].TC_Nombre_Caso + '</small></h5>' +
                '<h6><small>Fecha: ' + casos[i].TF_Fecha + '</small></h5>' +
                '<h6><small>Delito: ' + casos[i].TC_Delito + '</small></h5>' +
                '</div>' +
                '</div>'
            );
        }
    });
}


