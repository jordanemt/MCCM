$(document).ready(function () {
    iniciarCalendarioTarea(moment());
    cargarCatalogoUsuario();
    validarFormularioTarea();
})

function validarFormularioTarea() {
    $("#FormTarea").validate({
        rules: {
            TC_Diligencia: { required: true },
            TC_Lugar: { required: true },
            TN_ID_Usuario: { required: true },
            TF_Fecha_Tarea: { required: true }
        },
        messages: {
            TC_Diligencia: { required: "Debe indicar la Diligencia" },
            TC_Lugar: { required: "Debe indicar el Lugar" },
            TN_ID_Usuario: { required: "Debe indicar a quién se le asigna la tarea" },
            TF_Fecha_Tarea: { required: "Debe indicar la fecha limite" }

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
                "<option value='" + usuarios[i].TN_ID_Usuario + "'>Cod:" + usuarios[i].TC_Identificacion + " " + usuarios[i].TC_Nombre_Completo + "</option >"
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
            data: { "tarea": Object.fromEntries(form), "TF_Fecha": $("#TF_Fecha_Tarea").val(), "caso": sessionStorage.CasoID }
        }).done(function (data) {
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
            $("#tareas-body").append(
                '<div class="card tarea" id="' + tareas[i].TN_ID_Tarea + '">' +
                    '<div class="card-header">' +
                        ' Tarea Codigo #' + tareas[i].TN_ID_Tarea +
                        '<div>' +
                            '<a href="#" class="editarTarea" id="' + tareas[i].TN_ID_Tarea + '"><span><i class="fa fa-pencil" aria-hidden="true"></i></span ></a > ' +
                            '<a href="#" class="borrar borrarTarea" id="' + tareas[i].TN_ID_Tarea + '"><span><i class="fa fa-trash" data-toggle="modal" data-target="#ModalMensaje" aria-hidden="true"></i></span ></a > ' +
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
        let tarea = new Array();
        tarea = JSON.parse(data);
        $("#tituloFormTarea").html("Modificar Tarea");
        $("#TN_ID_Tarea").val(tarea.TN_ID_Tarea);
        $(".input_Tarea_Lugar").val(tarea.TC_Lugar);
        $("#TC_Diligencia").val(tarea.TC_Diligencia);
        $("#TN_ID_Usuario").val(tarea.TN_ID_Usuario);
        $("#TN_ID_Usuario").selectpicker("refresh");
        $("#divTareaID").show();
        $("#btnModificarTarea").show();
        $("#btnRegistrarTarea").hide();
        $('#TF_Fecha_Tarea').val(tarea.TF_Fecha);
        iniciarCalendarioTarea(tarea.TF_Fecha);
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
            data: { "tarea": Object.fromEntries(form), "fecha": $("#TF_Fecha_Tarea").val() }
        }).done(function (data) {
            CargarTareas();
            $("#ModalFormTarea").modal("hide");
        });
    }
});

$('#ModalFormTarea').on('hidden.bs.modal', function () {
    $("#FormTarea")[0].reset();
    iniciarCalendarioTarea(moment());
    $("#divTareaID").hide();
    $("#tituloFormTarea").html("Registrar Tarea");
    $("#btnModificarTarea").hide();
    $("#btnRegistrarTarea").show();
})