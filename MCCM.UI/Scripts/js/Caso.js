let insert = 0;

$(document).ready(function () {
    CargarCasos();
    validarFormularioCaso();
});


function validarFormularioCaso() {
    $("#FormCaso").validate({
        rules: {
            TC_Nombre_Caso: { required: true, },
            TN_ECU: { required: true, number: true },
            TN_Nivel: { required: true, number: true },
            TC_Descripcion: { required: true },
            TC_Fuente: { required: true },
            TC_Delito: { required: true }
        },
        submitHandler: function (form) {
            return false;
        }
    });
}


$(document).on("click", ".caso", function () {

    if ($(".card").hasClass('filaseleccionada')) {
        $(".card").removeClass('filaseleccionada');
        $(this).addClass('filaseleccionada');
    } else {
        $(this).addClass('filaseleccionada');
    }
    
    sessionStorage.CasoID = $(this).attr('id');
    CargarEventos();
    CargarTareas();
    listarGastos();
    listarGrupos();
    cargarGrupoMandoVigente();
    $("#casosTitulo").html($(this).children(".card-body").children().first().children().last().text());
    
});


$('#ModalFormCaso').on('hidden.bs.modal', function () {
    $("#FormCaso")[0].reset();
    $("label.error").hide();
})

$('#ModalFormCaso').on('show.bs.modal', function (e) {
    if (e.relatedTarget != null) {
        $("#btnRegistrarCaso").show();
        $("#btnModificarCaso").hide();
        $("#btnEliminarCaso").hide(); 
        $("#tituloFormModal").html("Registrar Caso");
        $("#btnCancelarCaso").show();
        $("#TN_ID_Caso").hide();
        $("#TN_ID_Input").hide();
    } else {
        $("#TN_ID_Caso").show();
        $("#tituloFormModal").html("Modificar Caso");
        $("#btnRegistrarCaso").hide();
        $("#btnModificarCaso").show();
        $("#btnEliminarCaso").show();
        $("#btnCancelarCaso").hide();
        $("#TN_ID_Input").show();
    }
})


$(document).on("click", ".ojito", function () {
    $.ajax({
        type: "GET",
        url: "/Caso/ObtenerCasoPorID",
        data: { "ID": $(this).attr('id') },
        error: function (data) {
            $("#mensaje-body").html(data);
            $("#modalMensajeError").modal("show");
        }
    }).done(function (data) {
        
        let caso = new Array();
        caso = JSON.parse(data);
        alert(caso.TC_Descripcion);
        $("#TN_ID_Caso").val(caso.TN_ID_Caso);
        $("#TN_ECU").val(caso.TN_ECU);
        $("#TC_Nombre_Caso").val(caso.TC_Nombre_Caso);
        $("#TC_Enfoque_Trabajo").val(caso.TC_Enfoque_Trabajo);
        $("#TC_Area_Trabajo").val(caso.TC_Area_Trabajo);
        $("#TN_Nivel").val(caso.TN_Nivel);
        $("#TC_Descripcion_Caso").text(caso.TC_Descripcion);
        $("#TC_Fuente").val(caso.TC_Fuente);
        $("#TC_Delito").val(caso.TC_Delito);
        $("#btnRegistrarCaso").hide();
        $("#btnEliminarCaso").show();
        $("#btnModificarCaso").show();
        $("#ModalFormCaso").modal("show");
    });
});



$(document).on("click", "#btnModificarCaso", function (e) {
    e.preventDefault();
    if ($("#FormCaso").valid()) {
        var form = $("#FormCaso");
        $.ajax({
            type: "POST",
            url: "/Caso/ActualizarCaso",
            data: form.serialize(),
            beforeSend: function () {
                $("#btnModificarCaso").prop("disabled", true);
                $("#btnModificarCaso").html(
                    '<span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span> Procesando...'
                );
            },
            error: function (data) {
                $("#mensaje-body").html(data);
                $("#modalMensajeError").modal("show");
            }

        }).done(function (data) {
            $("#btnModificarCaso").removeAttr("disabled");
            $("#btnModificarCaso").html('Modificar');
            $("#ModalFormCaso").modal("hide");
            CargarCasos();
        });
    }
});

$(document).on("click", "#btnEliminarCaso", function (e) {
    e.preventDefault();

    $.ajax({
        type: "POST",
        url: "/Caso/EliminarCasoPorID",
        data: { "ID": $("#TN_ID_Caso").val() },
        error: function (data) {
            $("#mensaje-body").html(data);
            $("#modalMensajeError").modal("show");
        }
    }).done(function (data) {
        $("#ModalFormCaso").modal("hide");
        CargarCasos();
    });

});

$(document).on("click", "#btnRegistrarCaso", function (e) {
    e.preventDefault();
    if ($("#FormCaso").valid()) {
        var form = new FormData($("#FormCaso")[0]);
        let url;
        url = "/Caso/InsertarCaso";
        $.ajax({
            type: "POST",
            url: url,
            data: Object.fromEntries(form),
            beforeSend: function () {
                $("#btnRegistrarCaso").prop("disabled", true);
                $("#btnRegistrarCaso").html(
                    '<span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span> Procesando...'
                );
            },
            error: function (data) {
                $("#mensaje-body").html(data);
                $("#modalMensajeError").modal("show");
            }

        }).done(function (data) {
            $("#btnRegistrarCaso").removeAttr("disabled");
            $("#btnRegistrarCaso").html('Insertar');
            insert = 1;
            CargarCasos();
            $("#ModalFormCaso").modal("hide");
        });
    }
});



function CargarCasos() {
    $.ajax({
        type: "GET",
        url: "/Caso/ListarCasos",
        beforeSend: function () {
            agregarSpinnerCargando($("#casos-body"));
        },
        error: function (data) {
            $("#mensaje-body").html(data);
            $("#modalMensajeError").modal("show");
        }
    }).done(function (data) {

        let casos = new Array();
        casos = JSON.parse(data);
        $("#casos-body").empty();
        for (let i = 0; i < casos.length; i++) {
            $("#casos-body").append(
                '<div class="card caso hoverOp" id="' + casos[i].TN_ID_Caso +'" >'+
                    '<div class="card-header gris_claro"><div>Caso Codigo #' + casos[i].TN_ID_Caso + '</div>'+
                    '<a href="#" class="ojito" id="' + casos[i].TN_ID_Caso+'"><span><i class="fa fa-eye" style="color:black" aria-hidden="true"></i></span></a></div >'+
                    '<div class="card-body" style="padding:0px!important">'+
                            '<h6><small><b>Nombre: </b></small><small class="nombre">'+casos[i].TC_Nombre_Caso +'</small></h5>'+
                            '<h6><small><b>Fecha: </b>' + casos[i].TF_Fecha.substr(0, 10) +" "+ casos[i].TF_Fecha.substr(11, 11) +'</small></h5>'+
                            '<h6><small><b>Delito: </b>' + casos[i].TC_Delito +'</small></h5>'+
                        '</div>'+
                    '</div>'
            );
        }
        if (insert == 1) {
            $("#casos-body").children().last().addClass('filaseleccionada');
            $("#casos-body").children().last()[0].scrollIntoView();
            $("#casosTitulo").html($("#casos-body").children().last().children(".card-body").children().first().children().last().text());
            //sessionStorage.CasoID = $("#casos-body").last().attr("id");
            insert = 0;
        }
    })
}