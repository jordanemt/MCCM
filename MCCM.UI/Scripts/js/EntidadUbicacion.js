$(document).on("click", "#entidadUbicacion", function () {
    CargarEntidadUbicaciones();
    cargarTipoUbicacion();
    cargarUbicacionProvincia();
})

/* Agregar Ubicacion*/
$(document).on("click", "#btnInsertarEntidadUbicacion", function (e) {
    e.preventDefault();
    if ($("#FormEntidadUbicacion").valid()) {
        var form = new FormData($("#FormEntidadUbicacion")[0]);
        form.append("TB_Verificado", $("#TB_Verificado_Ubicacion").is(":checked"));
        $.ajax({
            type: "POST",
            url: "/E_Ubicacion/Insertar_E_Ubicacion",
            data: { "entidadUbicacion": Object.fromEntries(form), "caso": sessionStorage.CasoID },
            beforeSend: function () {
                $("#btnInsertarEntidadUbicacion").prop("disabled", true);
                $("#btnInsertarEntidadUbicacion").html(
                    '<span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span> Procesando...'
                );
            }
        }).done(function (data) {
            $("#btnInsertarEntidadUbicacion").removeAttr("disabled");
            $("#btnInsertarEntidadUbicacion").html('Insertar');
            $("#entidadUbicacionModal").modal("hide");
            CargarEntidadUbicaciones();
        });
    }
});

/*Cargar Ubicacion*/
function CargarEntidadUbicaciones() {
    $.ajax({
        type: "GET",
        url: "/E_Ubicacion/Listar_E_Ubicacion",
        data: { "caso": sessionStorage.CasoID },
        beforeSend: function () {
            $("#entidades-body").empty();
            agregarSpinnerCargando($("#entidades-body"));
        }
    }).done(function (data) {
        let entidadUbicaciones = new Array();
        entidadUbicaciones = JSON.parse(data);

        $("#entidades-body").empty();
        for (let i = 0; i < entidadUbicaciones.length; i++) {
            $("#entidades-body").append(
                ' <div class="card" id="cartaEntidadUbicacion"' + entidadUbicaciones[i].TN_ID_Ubicacion + '>' +
                '<div class="card-header gris_claro">' +
                ' <div>Ubicación Código #' + entidadUbicaciones[i].TN_ID_Ubicacion + '</div>' +
                ' <div>' +
                '<a href="#" class="editarEntidadUbicacion" id="' + entidadUbicaciones[i].TN_ID_Ubicacion + '"><span><i class="fa fa-pencil icono" aria-hidden="true"></i></span></a>' +
                '<a href="#" class="borrar borrarUbicacion" id="' + entidadUbicaciones[i].TN_ID_Ubicacion + '"><span><i class="fa fa-trash icono" data-toggle="modal" data-target="#ModalMensaje" aria-hidden="true"></i></span></a>' +
                '</div>' +

                '</div>' +
                '<div class="card-body" style="padding:0px!important">' +
                '<div class="container">' +

                '<div class="row">' +
                ' <div class="col-4">' +
                '<h6><span class="w-100 badge badge-primary">Provincia:</span></h6>' +
                '</div>' +
                '<div class=""col-md-8">' +
                '<p>' + entidadUbicaciones[i].TC_Provincia + '<p />' +

                '</div>' +
                '</div>' +

                '<div class="row">' +
                '<div class="col-4">' +
                '<h6><span class="w-100 badge badge-primary">Cantón:</span></h6>' +
                '</div>' +
                '<div class=""col-md-8">' +
                ' <p>' + entidadUbicaciones[i].TC_Canton + '</p>' +
                '</div>' +
                '</div>' +

                '<div class="row">' +
                '<div class="col-4">' +
                '<h6><span class="w-100 badge badge-primary">Distrito:</span></h6>' +
                '</div>' +
                '<div class=""col-md-8">' +
                '<p>' + entidadUbicaciones[i].TC_Distrito + '</p>' +
                '</div>' +
                '</div>' +

                '<div class="row">' +
                '<div class="col-4">' +
                '<h6><span class="w-100 badge badge-primary">Señas:</span></h6>' +
                '</div>' +
                '<div class="col-sm-6">' +
                '<p>' + entidadUbicaciones[i].TC_Sennas + '</p>' +
                '</div>' +
                '</div>' +
                '</div>' +
                '</div>' +
                '</div>'

            );
        }
    });
}
//*Eliminar Ubicacion
function eliminarUbicacion(entidadUbicacionID) {
    $.ajax({
        type: "POST",
        url: "/E_Ubicacion/Eliminar_E_UbicacionPorID",
        data: { "entidadUbicacionID": entidadUbicacionID }
    }).done(function (data) {
        elemento.parent().parent().parent().remove();
    });
}

//*Editar Ubicacion
$(document).on("click", ".editarEntidadUbicacion", function () {
    $.ajax({
        type: "GET",
        url: "/E_Ubicacion/Obtener_E_UbicacionPorID",
        data: { "ID": $(this).attr('ID') }
    }).done(function (data) {
        let entidadUbicacion = new Array();
        entidadUbicacion = JSON.parse(data);
        $("#tituloEntidadUbicacion").html("Modificar Ubicacion");
        $("#divUbicacionID").show();
        $("#TN_ID_Ubicacion").val(entidadUbicacion.TN_ID_Ubicacion);
        $('#TN_ID_Tipo_Ubicacion').selectpicker('val', entidadUbicacion.TN_ID_Tipo_Ubicacion);
        $('#TN_ID_Tipo_Ubicacion').selectpicker('refresh');
        $('#TN_ID_Provincia').selectpicker('val', entidadUbicacion.TN_ID_Provincia);
        $('#TN_ID_Provincia').selectpicker('refresh');
        cargarUbicacionCanton(entidadUbicacion.TN_ID_Provincia, entidadUbicacion.TN_ID_Canton);
        cargarUbicacionDistrito(entidadUbicacion.TN_ID_Canton, entidadUbicacion.TN_ID_Distrito);
        $("#TC_Sennas_Ubicacion").val(entidadUbicacion.TC_Sennas);
        $("#TD_Latitud_Ubicacion").val(entidadUbicacion.TD_Latitud);
        $("#TD_Longitud_Ubicacion").val(entidadUbicacion.TD_Longitud);
        $("#TC_Creado_Por_Ubicacion").val(entidadUbicacion.TC_Creado_Por);
        $("#fechaCreacion_Row_U").show();
        $("#TF_Fecha_Creacion_Ubicacion").val(entidadUbicacion.TF_Fecha_Creacion);
        $("#fechaModificación_Row_U").show();
        $("#TF_Fecha_Modificacion_Ubicacion").val(entidadUbicacion.TF_Fecha_Modificacion);
        $("#modificadoPor_Row_U").show();
        $("#TF_Modificado_Por_Ubicacion").val(entidadUbicacion.TC_Modificado_Por);
        $("#TB_Verificado_Ubicacion").attr('checked', entidadUbicacion.TB_Verificado);
        $("#btnInsertarEntidadUbicacion").hide();
        $("#btnCancelarEntidadUbicacion").hide();
        $("#btnModificarEntidadUbicacion").show();
        $("#btnEliminarEntidadUbicacion").show();
        $("#entidadUbicacionModal").modal("show");
    });
});
//Selecciona Canton
function cargarUbicacionCanton(idProvincia, idCanton) {
    $.ajax({
        type: "GET",
        url: "/C_UbicacionCanton/ListarUbicacionCanton",
        data: { "idProvincia": idProvincia }
    }).done(function (data) {
        let canton = JSON.parse(data);
        $("#TN_ID_Canton").empty();
        var s;
        for (var i = 0; i < canton.length; i++) {
            s += '<option value="' + canton[i].TN_ID_Canton + '">' + canton[i].TC_Descripcion + '</option>';

            $("#TN_ID_Canton").html(s);
            $('#TN_ID_Canton').selectpicker('refresh');
        }
        $('#TN_ID_Canton').selectpicker('val', idCanton);
        $('#TN_ID_Canton').selectpicker('refresh');

    });
}


//Selecciona Distrito
function cargarUbicacionDistrito(idCanton, idDistrito) {
    $.ajax({
        type: "GET",
        url: "/C_UbicacionDistrito/ListarUbicacionDistrito",
        data: { "idCanton": idCanton },
    }).done(function (data) {
        let distrito = JSON.parse(data);
        $("#TN_ID_Distrito").empty();
        var s;
        for (var i = 0; i < distrito.length; i++) {
            s += '<option value="' + distrito[i].TN_ID_Distrito + '">' + distrito[i].TC_Descripcion + '</option>';

            $("#TN_ID_Distrito").html(s);
            $('#TN_ID_Distrito').selectpicker('refresh');
        }
        $('#TN_ID_Distrito').selectpicker('val', idDistrito);
        $('#TN_ID_Distrito').selectpicker('refresh');

    });
}

$('#entidadUbicacionModal').on('hidden.bs.modal', function () {
    $("#FormEntidadUbicacion")[0].reset();
    $("#tituloEntidadUbicacion").html("Insertar Ubicacion");
    $("#divUbicacionID").hide();
    $("#fechaCreacion_Row_U").hide();
    $("#fechaModificación_Row_U").hide();
    $("#modificadoPor_Row_U").hide();
    $("#btnInsertarEntidadUbicacion").show();
    $("#btnModificarEntidadUbicacion").hide();
    $('#TN_ID_Tipo_Ubicacion').selectpicker('refresh');
    $('#TN_ID_Provincia').selectpicker('refresh');
    $('#TN_ID_Canton').selectpicker('refresh');
    $('#TN_ID_Distrito').selectpicker('refresh');
    $('#TB_Verificado_Ubicacion').attr('checked', false);
    $("label.error").hide();
})

//*Modificar Ubicacion
$(document).on("click", "#btnModificarEntidadUbicacion", function (e) {
    e.preventDefault();
    if ($("#FormEntidadDroga").valid()) {
        var form = new FormData($("#FormEntidadUbicacion")[0]);
        form.append("TB_Verificado", $("#TB_Verificado_Ubicacion").is(":checked"));
        $.ajax({
            type: "POST",
            url: "/E_Ubicacion/Modificar_E_Ubicacion",
            data: Object.fromEntries(form),
            beforeSend: function () {
                $("#btnModificarEntidadUbicacion").prop("disabled", true);
                $("#btnModificarEntidadUbicacion").html(
                    '<span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span> Procesando...')
            }
        }).done(function (data) {
            $("#btnModificarEntidadUbicacion").removeAttr("disabled");
            $("#btnModificarEntidadUbicacion").html('Modificar');
            $("#entidadUbicacionModal").modal("hide");
            CargarEntidadUbicaciones();
        });
    }
});

/*Cargar Tipo Ubicacion*/
function cargarTipoUbicacion() {
    $.ajax({
        type: "GET",
        url: "/C_TipoUbicacion/ListarTipoUbicacion"
    }).done(function (data) {
        let tipoUbicacion = JSON.parse(data);
        $("#TN_ID_Tipo_Ubicacion").empty();
        var s;
        for (var i = 0; i < tipoUbicacion.length; i++) {
            s += '<option value="' + tipoUbicacion[i].TN_ID_Tipo_Ubicacion + '">' + tipoUbicacion[i].TC_Nombre + '</option>';
        }
        $("#TN_ID_Tipo_Ubicacion").html(s);
        $('#TN_ID_Tipo_Ubicacion').selectpicker('refresh');
    });

}

/*Cargar Provincia*/
function cargarUbicacionProvincia() {
    $.ajax({
        type: "GET",
        url: "/C_UbicacionProvincia/ListarUbicacionProvincia"
    }).done(function (data) {
        let provincia = JSON.parse(data);
        $("#TN_ID_Provincia").empty();
        var s;
        for (var i = 0; i < provincia.length; i++) {
            s += '<option value="' + provincia[i].TN_ID_Provincia + '">' + provincia[i].TC_Descripcion + '</option>';
        }
        $("#TN_ID_Provincia").html(s);
        $('#TN_ID_Provincia').selectpicker('refresh');


    });
}

$(document).on("change", "#TN_ID_Provincia", function () {
    var idProvincia = this.value;
    $.ajax({
        type: "GET",
        url: "/C_UbicacionCanton/ListarUbicacionCanton",
        data: { "idProvincia": idProvincia }
    }).done(function (data) {
        let canton = JSON.parse(data);
        $("#TN_ID_Canton").empty();
        $("#TN_ID_Distrito").empty();
        $('#TN_ID_Distrito').selectpicker('refresh');
        var s;
        for (var i = 0; i < canton.length; i++) {
            s += '<option value="' + canton[i].TN_ID_Canton + '">' + canton[i].TC_Descripcion + '</option>';

            $("#TN_ID_Canton").html(s);
            $('#TN_ID_Canton').selectpicker('refresh');
        }

    });
});

//*Carga Distrito
$('#TN_ID_Canton').on('change', function () {
    var idCanton = this.value;
    $.ajax({
        type: "GET",
        url: "/C_UbicacionDistrito/ListarUbicacionDistrito",
        data: { "idCanton": idCanton },
    }).done(function (data) {
        let distrito = JSON.parse(data);
        $("#TN_ID_Distrito").empty();
        var s;
        for (var i = 0; i < distrito.length; i++) {
            s += '<option value="' + distrito[i].TN_ID_Distrito + '">' + distrito[i].TC_Descripcion + '</option>';

            $("#TN_ID_Distrito").html(s);
            $('#TN_ID_Distrito').selectpicker('refresh');
        }

    });
});

/*Insertar Tipo Ubicacion*/
$(document).on("click", "#btnAgregar_C_TipoUbicacion", function (e) {
    e.preventDefault();
    if ($("#Form_C_TipoUbicacion").valid()) {
        var form = new FormData($("#Form_C_TipoUbicacion")[0]);
        $.ajax({
            type: "POST",
            url: "/C_TipoUbicacion/InsertarTipoUbicacion",
            data: Object.fromEntries(form),
            beforeSend: function () {
                $("#btnAgregar_C_TipoUbicacion").prop("disabled", true);
                $("#btnAgregar_C_TipoUbicacion").html(
                    '<span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span> Procesando...'
                );
            }
        }).done(function (data) {
            $("#btnAgregar_C_TipoUbicacion").removeAttr("disabled");
            $("#btnAgregar_C_TipoUbicacion").html('Insertar');
            $("#modal_C_TipoUbicacion").modal("hide");
            cargarTipoUbicacion();
            $("#Form_C_TipoUbicacion")[0].reset();
        });
    }
});
