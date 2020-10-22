$(document).ready(function () {
    iniciarCalendario(moment())
})

function iniciarCalendario(fecha) {

    $('#TF_Fecha').daterangepicker({
        "singleDatePicker": true,
        "timePicker": true,
        "timePicker24Hour": true,
        "starDate": fecha,
        locale: {
            format: 'YYYY/M/DD HH:mm'
        }
    });
}

$(document).on("click", "#btnModificarEvento", function (e) {
    e.preventDefault();
    var form = $("#FormEvento");
    let url;
    url = "/Caso/ActualizarCaso";

    alert("Modificar");
    $("#ModalFormEvento").modal("hide");


});


$('#ModalFormEvento').on('hidden.bs.modal', function () {
    $("#FormEvento")[0].reset();
    iniciarCalendario("10/09/2020 1:00AM");
    $("#divEventoID").hide();
})


$(document).on("click", ".editarEvento", function () {
    $("#tituloEventoModal").html("Modificar Evento");
    $("#eventoIDI").val("1");
    $("#LugarI").val("Turrialba");
    $("#NovedadI").val("Se procede a entablar dialogo con los ladrones");
    $("#InformaI").val("Juan Ramirez Suarez");
    $("#calendarioBitacora").val("10/10 12:00 PM");
    iniciarCalendario("10/10 12:00 PM");
    $("#divEventoID").show();
    $("#btnModificarEvento").show();
    $("#btnRegistrarEvento").hide();
    $("#btnEvento").hide();
    $("#ModalFormEvento").modal("show");

});

function eliminarEvento(evento) {
    alert(evento);
    $.ajax({
        type: "POST",
        url: "/Evento/EliminarEventoPorID",
        data: { "eventoID": evento }
    }).done(function (data) {
    });
}

$(document).on("click", "#btnRegistrarEvento", function (e) {
    e.preventDefault();
    var form = new FormData($("#FormEvento")[0]);
    alert(JSON.stringify(form));
    $.ajax({
        type: "POST",
        url: "/Evento/InsertarEvento",
        data: { "evento": Object.fromEntries(form), "caso": sessionStorage.CasoID }
    }).done(function (data) {
        $("#ModalFormEvento").modal("hide");
        CargarEventos();
        alert("Evento Insert");
    });
});



function CargarEventos() {
    $.ajax({
        type: "GET",
        url: "/Evento/ListarEventos",
        data: { "caso": sessionStorage.CasoID }
    }).done(function (data) {
        let eventos = new Array();
        eventos = JSON.parse(data);
        
        $("#bitacora-body").empty();
        for (let i = 0; i < eventos.length; i++) {

            $("#bitacora-body").append(
                '<div class="card evento" id="' + eventos[i].TN_ID_Evento + '" style="height:10em;">' +
                '<div class="card-header">'+
                  ' Evento #' + eventos[i].TN_ID_Evento +
                '<div>' +
                '<a href="#" class="editarEvento" id="' + eventos[i].TN_ID_Evento + '"><span><i class="fa fa-pencil" aria-hidden="true"></i></span></a>' +
                '<a href="#" class="borrar borrarEvento" id="' + eventos[i].TN_ID_Evento + '"><span><i class="fa fa-trash" data-toggle="modal" data-target="#ModalMensaje" aria-hidden="true"></i></span></a>' +
                '</div>' +

                '</div>' +
                
                '<div class="card-body" style="padding:0px!important">' +
                '<h6><small>Novedad:' + eventos[i].TC_Novedad + '</small></h6>' +
                '<h6><small>Lugar: ' + eventos[i].TC_Lugar + '</small></h6>' +
                '<h6><small>Fecha: ' + eventos[i].TF_Fecha + '</small></h6>' +
                '<h6><small>Informa: ' + eventos[i].TC_Informa + '</small></h6>' +
                '</div>' +
                '</div>'
            );
        }
    });
}


