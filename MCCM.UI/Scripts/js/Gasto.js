function abrirInsertarGastoFormModal() {
    $('#gasto-form-modal').remove();

    var url = "/Gasto/InsertarFormModal/";

    $.ajax({
        url: url,
        cache: false,
        type: "GET",
        success: function (data) {
            $('.body-content').append(data);
            if (agregarCasoIDToInputElementVal($('#TN_ID_Caso_Gasto'))) {
                $('#gasto-form-modal').modal('show');
            }
        },
        error: function (error) {
            $("#mensaje-body").html(error.responseText);
            $("#modalMensajeError").modal("show");
        }
    });
}

function abrirActualizarGastoFormModal(id) {
    $('#gasto-form-modal').remove();

    var url = "/Gasto/ActualizarFormModal/";

    $.ajax({
        url: url,
        cache: false,
        type: "GET",
        data: { "id": id },
        success: function (data) {
            $('.body-content').append(data);
            $('#gasto-form-modal').modal('show');
        },
        error: function (error) {
            $("#mensaje-body").html(error.responseText);
            $("#modalMensajeError").modal("show");
        }
    });
}

function listarGastos() {
    var url = "/Gasto/ListarPorCasoId/";

    $.ajax({
        url: url,
        cache: false,
        type: "GET",
        data: {
            idCaso: sessionStorage.CasoID
        },
        beforeSend: function () {
            $("#gastos-contenedor").empty();
            agregarSpinnerCargando($("#gastos-contenedor"))
        },
        success: function (data) {
            $('#gastos-contenedor').html(data);
            desactivarAcciones();
        },
        error: function (error) {
            $("#mensaje-body").html(error.responseText);
            $("#modalMensajeError").modal("show");
        }
    });
}

function insertarGasto() {
    if ($("#gasto-form").valid()) {
        var url = "/Gasto/Insertar/";

        $.ajax({
            url: url,
            cache: false,
            type: "POST",
            data: $('#gasto-form').serialize(),
            beforeSend: function () {
                $("#gasto-form-modal-submit")
                    .prop("disabled", true);
                $("#gasto-form-modal-submit")
                    .html(
                        '<span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span> Procesando...'
                    );
            },
            success: function (data) {
                $('#gasto-form-modal').modal('hide');
                $('.mensajeVacio').remove();
                $('#gastos-contenedor').append(data);
                desactivarAcciones();
            },
            error: function (error) {
                $("#mensaje-body").html(error.responseText);
                $("#modalMensajeError").modal("show");
            },
            complete: function () {
                $("#gasto-form-modal-submit")
                    .prop("disabled", false);
                $("#gasto-form-modal-submit")
                    .html('Insertar');
            }
        });
    }
}

function actualizarGasto() {
    if ($("#gasto-form").valid()) {
        var url = "/Gasto/Actualizar/";

        $.ajax({
            url: url,
            cache: false,
            type: "POST",
            data: $('#gasto-form').serialize(),
            beforeSend: function () {
                $("#gasto-form-modal-submit")
                    .prop("disabled", true);
                $("#gasto-form-modal-submit")
                    .html(
                        '<span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span> Procesando...'
                    );
            },
            success: function (data) {
                $('#gasto-' + $('#TN_ID_Gasto').val()).remove();
                $('#gasto-form-modal').modal('hide');
                $('.mensajeVacio').remove();
                $('.mensajeVacio').remove();
                $('#gastos-contenedor').append(data);
                desactivarAcciones();
            },
            error: function (error) {
                $("#mensaje-body").html(error.responseText);
                $("#modalMensajeError").modal("show");
            },
            complete: function () {
                $("#gasto-form-modal-submit")
                    .prop("disabled", false);
                $("#gasto-form-modal-submit")
                    .html('Actualizar');
            }
        });
    }
}

function eliminarGastoPorId(id) {
    var url = "/Gasto/EliminarPorId/";

    $.ajax({
        url: url,
        cache: false,
        type: "POST",
        data: { "id": id },
        success: function (data) {
            $('#gasto-' + id).remove();
            $('#ModalMensaje').modal('hide');
        },
        error: function (error) {
            $("#mensaje-body").html(error.responseText);
            $("#modalMensajeError").modal("show");
        }
    });
}

function abrirInsertarTipo_GastoModal() {
    $('#tipo_gasto-form').trigger('reset');
    $('#TC_Nombre-error').hide();
    $('#TC_Descripcion-error').hide();
    $('#tipo_gasto-form-modal').modal('show');
}

function insertarTipo_Gasto() {
    if ($("#tipo_gasto-form").valid()) {
        var url = "/Gasto/InsertarTipo_Gasto/";

        $.ajax({
            url: url,
            cache: false,
            type: "POST",
            data: $('#tipo_gasto-form').serialize(),
            beforeSend: function () {
                $("#tipo_gasto-form-modal-submit")
                    .prop("disabled", true);
                $("#tipo_gasto-form-modal-submit")
                    .html(
                        '<span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span> Procesando...'
                    );
            },
            success: function (data) {
                $("#TN_ID_Tipo_Gasto").append(new Option(data.Nombre, data.ID, true, true));
                $('#TN_ID_Tipo_Gasto').selectpicker('refresh');
                $('#tipo_gasto-form-modal').modal('hide');
                $('#gasto-form-modal').modal('show');
            },
            error: function (error) {
                $("#mensaje-body").html(error.responseText);
                $("#modalMensajeError").modal("show");
            },
            complete: function () {
                $("#tipo_gasto-form-modal-submit")
                    .prop("disabled", false);
                $("#tipo_gasto-form-modal-submit")
                    .html('Insertar');
            }
        });
    }
}

function obtenerSumatoriaDeGastosPorTipoPorCaso() {
    if (sessionStorage.CasoID == null) {
        alert('Debe seleccionar un gasto');
        return 0;
    }
    var url = "/Gasto/ObtenerSumatoriaDeGastosPorTipoPorCaso/";

    $.ajax({
        url: url,
        cache: false,
        type: "GET",
        data: { "idCaso": sessionStorage.CasoID },
        success: function (data) {
            var msg = '';
            jQuery.each(data.tiposSumatoria, function (i, val) {
                msg += val.nombre + ': ' + val.totalTipo + '<br>';
            });
            msg += 'Total: ' + data.total;
            $("#mensaje-body").html(msg);
            $("#modalMensajeError").modal("show");
        },
        error: function (error) {
            $("#mensaje-body").html(error.responseText);
            $("#modalMensajeError").modal("show");
        }
    });
}

function aplicarGastoDateRangePicker() {
    $('#TF_Fecha_Gasto').daterangepicker({
        singleDatePicker: true,
        startDate: ($('#TF_Fecha_Gasto').val() !== '') ? moment($('#TF_Fecha_Gasto').val()) : moment(),
        locale: {
            format: 'DD/M/Y'
        }
    });
}

function aplicarGastoSelectPicker() {
    $('#TN_ID_Tipo_Gasto').selectpicker();
}