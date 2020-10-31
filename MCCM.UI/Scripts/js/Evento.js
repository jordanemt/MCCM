$(document).ready(function () {
    iniciarCalendarioEvento(moment())
})

function iniciarCalendarioEvento(fecha) {
    
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
    var form = new FormData($("#FormEvento")[0]);
    $.ajax({
        type: "POST",
        url: "/Evento/ModificarEvento",
        data: Object.fromEntries(form)
    }).done(function (data) {
        CargarEventos();
        $("#ModalFormEvento").modal("hide");
    });
});


$('#ModalFormEvento').on('hidden.bs.modal', function () {
    $("#FormEvento")[0].reset();
    iniciarCalendarioEvento(moment());
    $("#divEventoID").hide();
    $("#tituloEventoModal").html("Registrar Evento");
    $("#btnModificarEvento").hide();
    $("#btnRegistrarEvento").show();
})


$(document).on("click", ".editarEvento", function () {
    $.ajax({
        type: "GET",
        url: "/Evento/ObtenerEventoPorID",
        data: { "ID": $(this).attr('ID') }
    }).done(function (data) {
        let evento = new Array();
        evento = JSON.parse(data);
        $("#tituloEventoModal").html("Modificar Evento");
        $("#TN_ID_Evento").val(evento.TN_ID_Evento);
        $("#TC_Lugar").val(evento.TC_Lugar);
        $("#TC_Novedad").val(evento.TC_Novedad);
        $("#TC_Informa").val(evento.TC_Informa);
        $("#TF_Fecha").val(evento.TF_Fecha);
        iniciarCalendarioEvento(evento.TF_Fecha);
        $("#divEventoID").show();
        $("#btnModificarEvento").show();
        $("#btnRegistrarEvento").hide();
        $("#ModalFormEvento").modal("show");
    });
});

function eliminarEvento(eventoID) {
 
    $.ajax({
        type: "POST",
        url: "/Evento/EliminarEventoPorID",
        data: { "eventoID": eventoID }
    }).done(function (data) {

    });
}

$(document).on("click", "#btnRegistrarEvento", function (e) {
    e.preventDefault();
    var form = new FormData($("#FormEvento")[0]);
    
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
                '<div class="card evento" id="' + eventos[i].TN_ID_Evento + '" >' +
                '<div class="card-header">' +
                ' Evento Codigo #' + eventos[i].TN_ID_Evento +
                '<div>' +
                '<a href="#" class="editarTarea" id="' +  eventos[i].TN_ID_Evento + '"><span><i class="fa fa-pencil" aria-hidden="true"></i></span ></a > ' +
                '<a href="#" class="borrar borrarTarea" id="' + eventos[i].TN_ID_Evento + '"><span><i class="fa fa-trash" data-toggle="modal" data-target="#ModalMensaje" aria-hidden="true"></i></span ></a > ' +
                '</div>' +
                '</div>' +
                '<div class="card-body" style="padding:0px!important">' +
                    '<div class="container">'+
                        '<div class="row">' +
                            '<div class="col-4">' +
                                 '<h6><span class="w-100 badge badge-primary">Novedad:</span></h6>' +
                            '</div >' +
                            '<div class="col-md-8" >' +
                                '<p>' + eventos[i].TC_Novedad + '</p > ' +
                            '</div>' +
                        '</div>' +
                        '<div class="row">' +
                            '<div class="col-4">' +
                                '<h6><span class="w-100 badge badge-primary">Lugar:</span></h6>' +
                            '</div >' +
                            '<div class="col-md-8" >' +
                                '<p>' + eventos[i].TC_Lugar + '</p > ' +
                            '</div>' +
                        '</div>' +
                        '<div class="row">' +
                            '<div class="col-4">' +
                                '<h6><span class="w-100 badge badge-primary">Fecha/Hora:</span></h6>' +
                            '</div >' +
                            '<div class="col-md-8" >' +
                                '<p>' + eventos[i].TF_Fecha + '</p > ' +
                            '</div>' +
                        '</div>' +
                        '<div class="row">' +
                            '<div class="col-4">' +
                                '<h6><span class="w-100 badge badge-primary">Informa:</span></h6>' +
                            '</div >' +
                            '<div class="col-md-8" >' +
                                '<p>' + eventos[i].TC_Informa + '</p > ' +
                            '</div>' +
                        '</div>' +
                    '</div>'+ 
                '</div>'+
                '</div>'
            );
        }
    });
}


