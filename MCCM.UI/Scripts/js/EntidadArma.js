$(document).on("click", "#entidadArma", function () {
    if (validarCasoSession()) {
        CargarEntidadArmas();
        cargarArmaMarca();
        cargarTipoArma();
    }
})

//*Agregar Arma
$(document).on("click", "#btnAgregarEntidadArma", function (e) {
    e.preventDefault();
    if ($("#FormEntidadArma").valid()) {
        var form = new FormData($("#FormEntidadArma")[0]);
        form.append("TB_Verificado", $("#TB_Verificado_Arma").is(":checked"));
        $.ajax({
            type: "POST",
            url: "/E_Arma/Insertar_E_Arma",
            data: { "entidadArma": Object.fromEntries(form), "caso": sessionStorage.CasoID },
            beforeSend: function () {
                $("#btnAgregarEntidadArma").prop("disabled", true);
                $("#btnAgregarEntidadArma").html(
                    '<span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span> Procesando...'
                );
            }
        }).done(function (data) {
            $("#btnAgregarEntidadArma").removeAttr("disabled");
            $("#btnAgregarEntidadArma").html('Insertar');
            $("#entidadArmaModal").modal("hide");
            CargarEntidadArmas();
        });
    }
});

/*Cargar Armas*/
function CargarEntidadArmas() {
    $.ajax({
        type: "GET",
        url: "/E_Arma/Listar_E_Arma",
        data: { "caso": sessionStorage.CasoID },
        beforeSend: function () {
            $("#entidades-body").empty();
            agregarSpinnerCargando($("#entidades-body"));
        }
    }).done(function (data) {
        let entidadArmas = new Array();
        entidadArmas = JSON.parse(data);

        $("#entidades-body").empty();

        for (let i = 0; i < entidadArmas.length; i++) {

            $("#entidades-body").append(
                '<div class="card" id="cartaEntidadArma"' + entidadArmas[i].TN_ID_Arma + '>' +

                '<div class="card-header gris_claro">' +
                '<div>Arma Código #' + entidadArmas[i].TN_ID_Arma + '</div>' +
                ' <div>' +
                ' <a href="#" class="editar editarEntidadArma" id="' + entidadArmas[i].TN_ID_Arma + '"><span><i class="fa fa-pencil icono" aria-hidden="true"></i></span></a>' +
                '<a href="#" class="borrar borrarEntidadArma" id="' + entidadArmas[i].TN_ID_Arma + '"><span><i class="fa fa-trash icono" data-toggle="modal" data-target="#ModalMensaje" aria-hidden="true"></i></span></a>' +
                '</div>' +

                '</div>' +
                '<div class="card-body" style="padding:0px!important">' +
                '<div class="container">' +

                '<div class="row">' +
                '<div class="col-4">' +
                '<h6><span class="w-100 badge badge-primary">Marca:</span></h6>' +
                '</div>' +
                '<div class="col-md-8">' +
                '<p>' + entidadArmas[i].TC_Marca + '<p />' +

                '</div>' +
                '</div>' +

                '<div class="row">' +
                '<div class="col-4">' +
                '<h6><span class="w-100 badge badge-primary">Tipo:</span></h6>' +
                '</div>' +
                '<div class="col-md-8">' +
                '<p>' + entidadArmas[i].TC_Tipo + '</p>' +
                '</div>' +
                '</div>' +

                '<div class="row">' +
                '<div class="col-4">' +
                '<h6><span class="w-100 badge badge-primary">Calibre:</span></h6>' +
                '</div>' +

                '<div class="col-md-8">' +
                '<p>' + entidadArmas[i].TC_Calibre + '</p>' +
                ' </div>' +
                '</div>' +

                '</div>' +
                ' </div>' +
                ' </div>'
            );
        }
        desactivarAcciones();
        if (entidadArmas.length == 0) {
            agregarMensajeVacio($("#entidades-body"));
        }
    });
}

/*Eliminar Arma*/

function eliminarArma(entidadArmaID) {
    $.ajax({
        type: "POST",
        url: "/E_Arma/Eliminar_E_ArmaPorID",
        data: { "entidadArmaID": entidadArmaID }
    }).done(function (data) {
        elemento.parent().parent().parent().remove();
    });
}
/*Editar*/

$(document).on("click", ".editarEntidadArma", function () {
    $.ajax({
        type: "GET",
        url: "/E_Arma/Obtener_E_ArmaPorID",
        data: { "ID": $(this).attr('ID') }
    }).done(function (data) {
        let entidadArma = new Array();
        entidadArma = JSON.parse(data);
        $("#tituloEntidadArma").html("Modificar Arma");
        $("#divArmaID").show();
        $("#TN_ID_Arma").val(entidadArma.TN_ID_Arma);
        $("#TC_Serie_Arma").val(entidadArma.TC_Serie);
        $('#TN_ID_Marca_Arma').selectpicker('val', entidadArma.TN_ID_Marca_Arma);
        $('#TN_ID_Marca_Arma').selectpicker('refresh');
        $('#TN_ID_Tipo_Arma').selectpicker('val', entidadArma.TN_ID_Tipo_Arma);
        $('#TN_ID_Tipo_Arma').selectpicker('refresh');
        $("#TC_Modelo_Arma").val(entidadArma.TC_Modelo_Arma);
        $("#TC_Calibre_Arma").val(entidadArma.TC_Calibre);
        $("#TC_Comentario_Arma").val(entidadArma.TC_Comentario);
        $("#divFCA").show();
        $("#TF_Fecha_Creacion_Arma").val(entidadArma.TF_Fecha_Creacion);
        $("#divFMA").show();
        $("#TF_Fecha_Modificacion_Arma").val(entidadArma.TF_Fecha_Modificacion);
        $("#TC_Creado_Por_Arma").val(entidadArma.TC_Creado_Por);
        $("#divMPA").show();
        $("#TC_Modificado_Por_Arma").val(entidadArma.TC_Modificado_Por);
        $('#TB_Verificado_Arma').attr('checked', entidadArma.TB_Verificado);
        $("#btnModificarEntidadArma").show();
        $("#btnAgregarEntidadArma").hide();
        $("#entidadArmaModal").modal("show");
    });
});

$('#entidadArmaModal').on('hidden.bs.modal', function () {
    $("#FormEntidadArma")[0].reset();
    $("#tituloEntidadArma").html("Insertar Arma");
    $("#divArmaMarcaID").hide();
    $("#divFCA").hide();
    $("#divFMA").hide();
    $("#divMPA").hide();
    $('#TN_ID_Marca_Arma').selectpicker('refresh');
    $('#TN_ID_Tipo_Arma').selectpicker('refresh');
    $('#TB_Verificado_Arma').attr('checked', false);
    $("#btnModificarEntidadArma").hide();
    $("#btnAgregarEntidadArma").show();
    $("label.error").hide();

})

//*Modificar Arma
$(document).on("click", "#btnModificarEntidadArma", function (e) {
    e.preventDefault();
    if ($("#FormEntidadArma").valid()) {
        var form = new FormData($("#FormEntidadArma")[0]);
        form.append("TB_Verificado", $("#TB_Verificado_Arma").is(":checked"));
        $.ajax({
            type: "POST",
            url: "/E_Arma/Modificar_E_Arma",
            data: Object.fromEntries(form),
            beforeSend: function () {
                $("#btnModificarEntidadArma").prop("disabled", true);
                $("#btnModificarEntidadArma").html(
                    '<span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span> Procesando...'
                );
            }
        }).done(function (data) {
            $("#btnModificarEntidadArma").removeAttr("disabled");
            $("#btnModificarEntidadArma").html('Modificar');
            $("#entidadArmaModal").modal("hide");
            CargarEntidadArmas();
        });
    }
});

///*-----------------------------------------------------

//*Cargar Arma Marca*
function cargarArmaMarca() {

    $.ajax({
        type: "GET",
        url: "/C_ArmaMarca/ListarArmaMarca",
    }).done(function (data) {
        let marcaArma = JSON.parse(data);
        $("#TN_ID_Marca_Arma").empty();
        var s;
        for (var i = 0; i < marcaArma.length; i++) {
            s += '<option value="' + marcaArma[i].TN_ID_Marca_Arma + '">' + marcaArma[i].TC_Descripcion + '</option>';

        }
        $("#TN_ID_Marca_Arma").html(s);
        $('#TN_ID_Marca_Arma').selectpicker('refresh');

    });
}

//*Cargar Tipo Arma
function cargarTipoArma() {

    $.ajax({
        type: "GET",
        url: "/C_TipoArma/ListarTipoArma",
    }).done(function (data) {
        let tipoArma = JSON.parse(data);
        $("#TN_ID_Tipo_Arma").empty();
        var s;
        for (var i = 0; i < tipoArma.length; i++) {
            s += '<option value="' + tipoArma[i].TN_ID_Tipo_Arma + '">' + tipoArma[i].TC_Descripcion + '</option>';

        }
        $("#TN_ID_Tipo_Arma").html(s);
        $('#TN_ID_Tipo_Arma').selectpicker('refresh');

    });

}
/*Insertar Arma Marca*/
$(document).on("click", "#btnAgregar_C_ArmaMarca", function (e) {
    e.preventDefault();
    if ($("#Form_C_MarcaArma").valid()) {
        var form = new FormData($("#Form_C_MarcaArma")[0]);
        $.ajax({
            type: "POST",
            url: "/C_ArmaMarca/InsertarArmaMarca",
            data: Object.fromEntries(form),
            beforeSend: function () {
                $("#btnAgregar_C_ArmaMarca").prop("disabled", true);
                $("#btnAgregar_C_ArmaMarca").html(
                    '<span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span> Procesando...'
                );
            }
        }).done(function (data) {
            $("#btnAgregar_C_ArmaMarca").removeAttr("disabled");
            $("#btnAgregar_C_ArmaMarca").html('Insertar');
            $("#modal_C_ArmaMarca").modal("hide");
            cargarArmaMarca();
            $("#Form_C_MarcaArma")[0].reset();
        });
    }
});

/*Insertar Arma Tipo*/
$(document).on("click", "#btnAgregar_C_ArmaTipo", function (e) {
    e.preventDefault();
    if ($("#Form_C_ArmaTipo").valid()) {
        var form = new FormData($("#Form_C_ArmaTipo")[0]);
        $.ajax({
            type: "POST",
            url: "/C_TipoArma/InsertarTipoArma",
            data: Object.fromEntries(form),
            beforeSend: function () {
                $("#btnAgregar_C_ArmaTipo").prop("disabled", true);
                $("#btnAgregar_C_ArmaTipo").html(
                    '<span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span> Procesando...'
                );
            }
        }).done(function (data) {
            $("#btnAgregar_C_ArmaTipo").removeAttr("disabled");
            $("#btnAgregar_C_ArmaTipo").html('Insertar');
            $("#modal_C_ArmaTipo").modal("hide");
            cargarTipoArma();
            $("#Form_C_ArmaTipo")[0].reset();
        });
    }
});