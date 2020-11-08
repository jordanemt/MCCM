$(document).ready(function () {
    validarFormularioEntidadTelefono();
});

$(document).on("click", "#entidadTelefono", function () {
    if (validarCasoSession()) {
        CargarEntidadTelefono();
        cargarCatalogoProveedores();
    }
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
            data: { "telefono": form, "caso": sessionStorage.CasoID },
            beforeSend: function () {
                $("#btnRegistrarEntidadTelefono").prop("disabled", true);
                $("#btnRegistrarEntidadTelefono").html(
                    '<span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span> Procesando...'
                );
            },
            error: function (data) {
                $("#mensaje-body").html(data);
                $("#modalMensajeError").modal("show");
            }
        }).done(function (data) {
            $("#btnRegistrarEntidadTelefono").removeAttr("disabled");
            $("#btnRegistrarEntidadTelefono").html('Registrar');
            CargarEntidadTelefono();
            $("#entidadTelefonoModal").modal("hide");
        });
    }
});




$(document).on("click", "#btnRegistrarTelefonoProveedor", function (e) {
    e.preventDefault();
    if ($("#FormTelefonoProveedor").valid()) {
        $.ajax({
            type: "POST",
            url: "/E_Telefono/Insertar_Proveedor",
            data: { "TC_Descripcion": $("#TC_Descripcion").val() },
            beforeSend: function () {
                $("#btnRegistrarTelefonoProveedor").prop("disabled", true);
                $("#btnRegistrarTelefonoProveedor").html(
                    '<span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span> Procesando...'
                );
            },
            error: function (data) {
                $("#mensaje-body").html(data);
                $("#modalMensajeError").modal("show");
            }
        }).done(function (data) {
            $("#btnRegistrarTelefonoProveedor").removeAttr("disabled");
            $("#btnRegistrarTelefonoProveedor").html('Registrar');
            cargarCatalogoProveedores();
            $("#FormTelefonoProveedor")[0].reset();
            $("#telefonoProveedorModal").modal("hide");
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
            beforeSend: function () {
                $("#btnModificarEntidadTelefono").prop("disabled", true);
                $("#btnModificarEntidadTelefono").html(
                    '<span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span> Procesando...'
                );
            },
            error: function (data) {
                $("#mensaje-body").html(data);
                $("#modalMensajeError").modal("show");
            }
        }).done(function (data) {
            $("#btnModificarEntidadTelefono").removeAttr("disabled");
            $("#btnModificarEntidadTelefono").html('Modificar');
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
        data: { "ID": $(this).attr('ID') },
        error: function (data) {
            $("#mensaje-body").html(data);
            $("#modalMensajeError").modal("show");
        }
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
        data: { "caso": sessionStorage.CasoID },
        beforeSend: function () {
            $("#entidades-body").empty();
            agregarSpinnerCargando($("#entidades-body"));
        },
        error: function (data) {
            $("#mensaje-body").html(data);
            $("#modalMensajeError").modal("show");
        }
    }).done(function (data) {
        let telefonos = new Array();
        telefonos = JSON.parse(data);
        $("#entidades-body").empty();
        for (let i = 0; i < telefonos.length; i++) {
            $("#entidades-body").append(
                '<div class="card" >' +
                '<div class="card-header gris_claro">' +
                'Teléfono Código #' + telefonos[i].TN_ID_Telefono +
                '<div>' +
                '<a href="#" class="editar editarEntidadTelefono" id="' + telefonos[i].TN_ID_Telefono + '"><span><i class="fa fa-pencil icono font_amarilloHover" aria-hidden="true"></i></span ></a > ' +
                '<a href="#" class="borrar borrarEntidadTelefono" id="' + telefonos[i].TN_ID_Telefono + '"><span><i class="fa fa-trash icono font_amarilloHover" data-toggle="modal" data-target="#ModalMensaje" aria-hidden="true"></i></span ></a > ' +
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
        desactivarAcciones();
        if (telefonos.length == 0) {
            agregarMensajeVacio($("#entidades-body"));
        }
    });
}

/*Descripcion: metodo que elimina un Telefono, recibe el id del Telefono y el elemento del DOM a eliminar
El elemento del DOM es el botón de la carta del Telefono que se eliminó*/
function eliminarTelefono(telefonoID, elemento) {
    $.ajax({
        type: "POST",
        url: "/E_Telefono/EliminarTelefonoPorID",
        data: { "telefonoID": telefonoID },
        error: function (data) {
            $("#mensaje-body").html(data);
            $("#modalMensajeError").modal("show");
        }
    }).done(function (data) {
        elemento.parent().parent().parent().remove();
        $("#ModalMensaje").modal("hide");
    });
}

/*Cuando el modal se cierra reinicia y limpia el formulario dentro de este*/
$('#entidadTelefonoModal').on('hidden.bs.modal', function () {
    $("#FormEntidadTelefono")[0].reset();
    $("#divTelefonoID").hide();
    $("#divFMT").hide();
    $("#divMPT").hide();
    $("#divFCT").hide();
    $("#tituloEntidadTelefonoInsertar").html("Registrar Entidad Telefono");
    $("#TN_ID_Proveedor").selectpicker("refresh");
    $("#btnModificarEntidadTelefono").hide();
    $("#btnRegistrarEntidadTelefono").show();
    $("label.error").hide();
})



function cargarCatalogoProveedores() {
    $.ajax({
        type: "GET",
        url: "/E_Telefono/ObtenerCatalogoProveedores",
        error: function (data) {
            $("#mensaje-body").html(data);
            $("#modalMensajeError").modal("show");
        }
    }).done(function (data) {
        let proveedores = JSON.parse(data);
        $("#TN_ID_Proveedor").empty();
        for (let i = 0; i < proveedores.length; i++) {
            $("#TN_ID_Proveedor").append(
                "<option value='" + proveedores[i].TN_ID_Proveedor + "'>" + proveedores[i].TC_Descripcion +"</option >"
            );
        }
        $("#TN_ID_Proveedor").selectpicker("refresh");
    });
}