$(document).ready(function () {
    validarFormularioEntidadTelefono();
});

$(document).on("click", "#entidadTelefono", function () {
    CargarEntidadTelefono();
})


/*Descripción: Metodo que valida el formulario usando la libreria de js*/
function validarFormularioEntidadTelefono() {
    $("#FormEntidadTelefono").validate({
        rules: {
            TN_Numero_Telefono: {
                required: true,
                minlength: 8
            },
            TN_ID_Proveedor: { required: true },
            TC_Creado_Por_Telefono: {
                required: true
            }
        },
        messages: {
            TN_Numero_Telefono: {
                required: "El campo Numero Telefono no puede quedar en blanco",
                number: "Este campo debe ser un valor numerico",
                minlength: "El número de telefono debe ser de al menos 8 digitos"
            },
            TN_ID_Proveedor: {
                required: "Por favor, seleccione un proveedor"
            },
            TC_Creado_Por_Telefono: {
                required: "Debe especificar quien registró la entidad telefono."
            }

        },
        submitHandler: function (form) {
            return false;
        }
    });
}


/*Descripción: Metodo que registra una entidad telefono,
carga el formulario y lo envía los datos por el metodo POST*/
$(document).on("click", "#btnRegistrarEntidadTelefono", function (e) {
    e.preventDefault();
    if ($("#FormEntidadTelefono").valid()) {
        fechaActual = moment().format('YYYY-MM-DD HH:mm:00');
        var form = {
            "TN_Numero": $("#TN_Numero_Telefono").val(),
            "TN_ID_Proveedor": $("#TN_ID_Proveedor").val(),
            "TN_ID_Icono_Telefono": $("#TN_ID_Icono_Telefono").val(),
            "TC_Comentario": $("#TC_Comentario_Telefono").val(),
            "TF_Fecha_Modificacion": $("#TF_Fecha_Modificacion_Telefono").val(),
            "TF_Fecha_Creacion": fechaActual,
            "TC_Creado_Por": $("#TC_Creado_Por_Telefono").val(),
            "TF_Modificado_Por": $("#TF_Modificado_Por_Telefono").val(),
            "TB_Verificado": $("#TB_Verificado_Telefono").is(":checked")
        };
        $.ajax({
            type: "POST",
            url: "/E_Telefono/Insertar_E_Telefono",
            data: { "telefono": form, "caso": 15 },
        }).done(function (data) {
            CargarEntidadTelefono();
            $("#entidadTelefonoModal").modal("hide");
        });
    }
});

/*Descripción: Metodo que modifica una entidad telefono,
carga el formulario y lo envía los datos por el metodo POST*/
$(document).on("click", "#btnModificarEntidadTelefono", function (e) {
    e.preventDefault();
    if ($("#FormEntidadTelefono").valid()) {
        fechaActual = moment().format('YYYY-MM-DD HH:mm:00');
        var form = {
            "TN_ID_Telefono": $("#TN_ID_Telefono").val(),
            "TN_Numero": $("#TN_Numero_Telefono").val(),
            "TN_ID_Proveedor": $("#TN_ID_Proveedor").val(),
            "TN_ID_Icono_Telefono": $("#TN_ID_Icono_Telefono").val(),
            "TC_Comentario": $("#TC_Comentario_Telefono").val(),
            "TF_Fecha_Modificacion": fechaActual,
            "TF_Fecha_Creacion": $("#TF_Fecha_Creacion_Telefono").val(),
            "TC_Creado_Por": $("#TC_Creado_Por_Telefono").val(),
            "TC_Modificado_Por": $("#TC_Modificado_Por_Telefono").val(),
            "TB_Verificado": $("#TB_Verificado_Telefono").is(":checked")
        };
        $.ajax({
            type: "POST",
            url: "/E_Telefono/Modificar_E_Telefono",
            data: { "telefono": form },
        }).done(function (data) {
            CargarEntidadTelefono();
            $("#entidadTelefonoModal").modal("hide");
        });
    }
});


/*Descripción: Metodo que carga el formulario con los datos de la entidad solicitada,*/
$(document).on("click", ".editarEntidadTelefono", function () {
    $.ajax({
        type: "GET",
        url: "/E_Telefono/ObtenerEntidadTelefonoPorID",
        data: { "ID": $(this).attr('ID') }
    }).done(function (data) {
        let telefono = new Array();
        telefono = JSON.parse(data);
        $("#tituloEntidadTelefonoInsertar").html("Modificar Entidad Telefono");
        $("#TN_ID_Telefono").val(telefono.TN_ID_Telefono);
        $("#TN_Numero_Telefono").val(telefono.TN_Numero_Telefono);
        $("#TC_Comentario_Telefono").val(telefono.TC_Comentario_Telefono);
        $("#TF_Fecha_Creacion_Telefono").val(telefono.TF_Fecha_Creacion_Telefono);
        $("#TF_Fecha_Modificacion_Telefono").val(telefono.TF_Fecha_Modificacion_Telefono);
        $("#TC_Creado_Por_Telefono").val(telefono.TC_Creado_Por_Telefono);
        $("#TC_Modificado_Por_Telefono").val(telefono.TC_Modificado_Por_Telefono);
        $('#TB_Verificado_Telefono').attr('checked', telefono.TB_Verificado_Telefono);
        $("#TN_ID_Proveedor").val(telefono.TN_ID_Proveedor);
        $("#TN_ID_Proveedor").selectpicker("refresh");
        $("#btnModificarEntidadTelefono").show();
        $("#btnRegistrarEntidadTelefono").hide();
        $("#entidadTelefonoModal").modal("show");
        $("#divTelefonoID").show();
        $("#divFMT").show();
        $("#divMPT").show();
        $("#divFCT").show();
    });
});


/*Descripcion: Carga todas las cartas en el DOM con las entidades Telefono relacionadas al caso,
manda el id del caso y esto retorna un json con todas las entidades telefono, luego las carga en cartas*/
function CargarEntidadTelefono() {
    $.ajax({
        type: "GET",
        url: "/E_Telefono/ListarEntidadTelefono",
        data: { "caso": sessionStorage.CasoID }
    }).done(function (data) {
        let telefonos = new Array();
        telefonos = JSON.parse(data);
        $("#entidades-body").empty();
        for (let i = 0; i < telefonos.length; i++) {
            $("#entidades-body").append(
                '<div class="card" id="entidadTelefonoCard" >' +
                '<div class="card-header">' +
                '<div>Entidad Telefono #1</div>' +
                '<div>' +
                '<a href="#" class="editarEntidadTelefono" id="' + telefonos[i].TN_ID_Telefono + '"><span><i class="fa fa-pencil" aria-hidden="true"></i></span></a>' +
                '<a href="#" class="borrar borrarEntidadTelefono" id="' + telefonos[i].TN_ID_Telefono + '"><span><i class="fa fa-trash" data-toggle="modal" data-target="#ModalMensaje" aria-hidden="true"></i></span></a>' +
                '</div>' +
                '</div>' +
                '<div class="card-body" style="padding:0px!important">' +
                '<div class="container">' +
                '<div class="row">' +
                '<div class="col-4">' +
                '<h6><span class="w-100 badge badge-primary">Número:</span></h6>' +
                '</div>' +
                '<div class="col-md-8" id="divNumero">' +
                '<p>' + telefonos[i].TN_Numero + '<p />' +
                '</div>' +
                '</div>' +
                '<div class="row">' +
                '<div class="col-4">' +
                '<h6><span class="w-100 badge badge-primary">Empresa:</span></h6>' +
                '</div>' +
                '<div class="col-md-8" id="divProveedor">' +
                '<p>' + telefonos[i].TC_Descripcion + '</p>' +
                '</div>' +
                '</div>' +
                '<div class="row">' +
                '<div class="col-4">' +
                '<h6><span class="w-100 badge badge-primary">Comentario:</span></h6>' +
                '</div>' +
                '<div class="col-md-8" id="divComentario">' +
                '<p>' + telefonos[i].TC_Comentario + '</p>' +
                '</div>' +
                '</div>' +
                '</div>' +
                '</div>' +
                '</div>'
            );
        }
    });
}

/*Descripcion: metodo que elimina un Telefono, recibe el id del Telefono y el elemento del DOM a eliminar
El elemento del DOM es el botón de la carta del Telefono que se eliminó*/
function eliminarTelefono(telefonoID, elemento) {
    $.ajax({
        type: "POST",
        url: "/E_Telefono/EliminarTelefonoPorID",
        data: { "telefonoID": telefonoID }
    }).done(function (data) {
        elemento.parent().parent().parent().remove();
    });
}

/*Cuando el modal se cierra reinicia y limpia el formulario dentro de este*/
$('#entidadTelefonoModal').on('hidden.bs.modal', function () {
    $("#FormEntidadTelefono")[0].reset();
    $("#divTelefonoID").hide();
    $("#tituloEntidadTelefonoInsertar").html("Registrar Entidad Telefono");
    $("#TN_ID_Proveedor").selectpicker("refresh");
    $("#btnModificarEntidadTelefono").hide();
    $("#btnRegistrarEntidadTelefono").show();
})