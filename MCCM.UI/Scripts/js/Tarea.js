$(document).ready(function () {
    iniciarCalendarioTarea(moment());
    cargarCatalogoUsuario();
    validarFormularioTarea();
})

function validarFormularioTarea() {
    $("#FormTarea").validate({
        rules: {
            TC_Diligencia: { required: true },
            TC_Lugar_Tarea: { required: true },
            TN_ID_Usuario: { required: true },
            TF_Fecha_Tarea: { required: true },
            TN_Tipo: { required: true }
        },
        submitHandler: function (form) {
            return false;
        }
    });
}


function cargarCatalogoUsuario() {
    $.ajax({
        type: "GET",
        url: "/Tarea/ObtenerCatalogoUsuarios"
    }).done(function (data) {
        let usuarios = JSON.parse(data);
        $("#TN_ID_Usuario").empty();
        for (let i = 0; i < usuarios.length; i++) {
            $("#TN_ID_Usuario").append(
                "<option value='" + usuarios[i].TN_ID_Usuario + "'>"+ usuarios[i].TC_Identificacion + " " + usuarios[i].TC_Nombre_Completo + "</option >"
            );
        }
        $("#TN_ID_Usuario").selectpicker("refresh");
    });
}

$(document).on("click", "#btnRegistrarTarea", function (e) {
    
    e.preventDefault();
    if ($("#FormTarea").valid()) {
        var form = new FormData($("#FormTarea")[0]);
        $.ajax({
            type: "POST",
            url: "/Tarea/InsertarTarea",
            data: { "tarea": Object.fromEntries(form), "TF_Fecha": $("#TF_Fecha_Tarea").val(), "caso": sessionStorage.CasoID },
            beforeSend: function () {
                $("#btnRegistrarTarea").prop("disabled", true);
                $("#btnRegistrarTarea").html(
                    '<span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span> Procesando...'
                );
            }
        }).done(function (data) {
            $("#btnRegistrarTarea").removeAttr("disabled");
            $("#btnRegistrarTarea").html('Registrar');
            CargarTareas();
            $("#ModalFormTarea").modal("hide");
        });
    }
    
});

function iniciarCalendarioTarea(fecha) {
    $('#TF_Fecha_Tarea').daterangepicker({
        "singleDatePicker": true,
        "timePicker": true,
        "timePicker24Hour": true,
        "starDate": fecha,
        locale: {
            format: 'YYYY/M/DD HH:mm'
        }
    });
}

function CargarTareas() {
    $.ajax({
        type: "GET",
        url: "/Tarea/ListarTarea",
        data: { "caso": sessionStorage.CasoID }
    }).done(function (data) {

        let tareas = new Array();
        tareas = JSON.parse(data);

        $("#tareas-body").empty();
        for (let i = 0; i < tareas.length; i++) {
            let iconoTarea = -1;
            let color;
            if (tareas[i].TN_Tipo == 1) {
                iconoTarea = '<i class="fa fa-warning" aria-hidden="true"></i>';
                color = "rojo";
            } else if (tareas[i].TN_Tipo == 2) {
                iconoTarea = '<i class="fa fa-tasks" aria-hidden="true"></i>';
                color = "gris_claro";
            } else {
                iconoTarea = '<i class="fa fa-check" aria-hidden="true"></i>';
                color = "";
            }
            $("#tareas-body").append(
                '<div class="card tarea" id="' + tareas[i].TN_ID_Tarea + '">' +
                '<div class="card-header ' + color + '" >' +
                    '<div>'+iconoTarea+'</div>' + "Tarea Código #"+tareas[i].TN_ID_Tarea +
                        '<div>' +
                            '<a href="#" class="editarTarea" id="' + tareas[i].TN_ID_Tarea + '"><span><i class="fa fa-pencil icono_tarea" aria-hidden="true" ></i></span ></a > ' +
                '<a href="#" class="borrar borrarTarea" id="' + tareas[i].TN_ID_Tarea + '"><span><i class="fa fa-trash icono_tarea" data-toggle="modal" data-target="#ModalMensaje" aria-hidden="true"></i></span ></a > ' +
                        '</div>' +
                    '</div>' +
                '<div class="card-body" style="padding:0px!important">' +
                    '<div class="container">' +
                       '<div class="row">' +
                            '<div class="col-4">' +
                                '<h6><span class="w-100 badge badge-primary">Asignado:</span></h6>' +
                            '</div >'+
                            '<div class="col-md-8" >' +
                                '<p>'+ tareas[i].T_Usuario + '</p > ' +
                            '</div>'+
                        '</div>' +
                        '<div class="row">' +
                            '<div class="col-4">' +
                                '<h6><span class="w-100 badge badge-primary">Fecha/Hora:</span></h6>' +
                            '</div >' +
                            '<div class="col-md-8" >' +
                              '<p>' + tareas[i].TF_Fecha + '</p > ' +
                            '</div>' +
                        '</div>' +
                        '<div class="row">' +
                            '<div class="col-4">' +
                                '<h6><span class="w-100 badge badge-primary">Diligencia:</span></h6>' +
                            '</div >' +
                            '<div class="col-md-8" >' +
                                '<p>' + tareas[i].TC_Diligencia + '</p > ' +
                            '</div>' +
                        '</div>' +
                        '<div class="row">' +
                            '<div class="col-4">' +
                                '<h6><span class="w-100 badge badge-primary">Lugar:</span></h6>' +
                            '</div >' +
                          '<div class="col-md-8" >' +
                                '<p>' + tareas[i].TC_Lugar + '</p > ' +
                          '</div>' +
                        '</div>' +
                    '</div>' +
                '</div>'+
                '</div>'
            )
        }
    })
}


function eliminarTarea(tareaID, elemento) {

    $.ajax({
        type: "POST",
        url: "/Tarea/EliminarTareaPorID",
        data: { "tareaID": tareaID }
    }).done(function (data) {
        elemento.parent().parent().parent().remove();
    });
}


$(document).on("click", ".editarTarea", function () {
    $.ajax({
        type: "GET",
        url: "/Tarea/ObtenerTareaPorID",
        data: { "ID": $(this).attr('ID') }
    }).done(function (data) {
        let tarea = JSON.parse(data);
        $("#tituloFormTarea").html("Modificar Tarea");
        $("#TN_ID_Tarea").val(tarea[0].TN_ID_Tarea);
        $(".input_Tarea_Lugar").val(tarea[0].TC_Lugar);
        $("#TC_Diligencia").val(tarea[0].TC_Diligencia);
        $("#TN_ID_Usuario").val(tarea[0].TN_ID_Usuario);
        $("#TN_ID_Usuario").selectpicker("refresh");
        $("#TN_Tipo").val(tarea[0].TN_Tipo);
        $("#TN_Tipo").selectpicker("refresh");
        $("#divTareaID").show();
        $("#btnModificarTarea").show();
        $("#btnRegistrarTarea").hide();
        $('#TF_Fecha_Tarea').val(tarea[0].TF_Fecha);
        iniciarCalendarioTarea(tarea[0].TF_Fecha);
        $("#ModalFormTarea").modal("show");
        
    });
});

$(document).on("click", "#btnModificarTarea", function (e) {
    e.preventDefault();
    if ($("#FormTarea").valid()) {
        var form = new FormData($("#FormTarea")[0]);
        $.ajax({
            type: "POST",
            url: "/Tarea/ModificarTarea",
            data: { "tarea": Object.fromEntries(form), "fecha": $("#TF_Fecha_Tarea").val() },
            beforeSend: function () {
                $("#btnModificarTarea").prop("disabled", true);
                $("#btnModificarTarea").html(
                    '<span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span> Procesando...'
                );
            }
        }).done(function (data) {
            $("#btnModificarTarea").removeAttr("disabled");
            $("#btnModificarTarea").html('Modificar');
            CargarTareas();
            $("#ModalFormTarea").modal("hide");
        });
    }
});

$('#ModalFormTarea').on('hidden.bs.modal', function () {
    $("#FormTarea")[0].reset();
    iniciarCalendarioTarea(moment());
    $("#TN_ID_Usuario").selectpicker("refresh");
    $("#divTareaID").hide();
    $("#tituloFormTarea").html("Registrar Tarea");
    $("#btnModificarTarea").hide();
    $("#btnRegistrarTarea").show();
    $("label.error").hide();
})