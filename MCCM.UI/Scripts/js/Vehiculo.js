function abrirGrupo_VehiculoInsertarFormModal() {
    $('#grupo_vehiculo-form-modal').remove();

    var url = "/Vehiculo/Grupo_VehiculoInsertarFormModal/";

    $.ajax({
        url: url,
        cache: false,
        type: "GET",
        success: function (data) {
            $('.body-content').append(data);
            if (agregarGrupoIDToInputElementVal($('#TN_ID_Grupo_Vehiculo'))) {
                $('#grupo_vehiculo-form-modal').modal('show');
            }
        },
        error: function (error) {
            $("#mensaje-body").html(error.responseText);
            $("#modalMensajeError").modal("show");
        },
    });
}

function abrirGrupo_VehiculoActualizarFormModal(id) {
    $('#grupo_vehiculo-form-modal').remove();

    var url = "/Vehiculo/Grupo_VehiculoActualizarFormModal/";

    $.ajax({
        url: url,
        cache: false,
        type: "GET",
        data: { id: id },
        success: function (data) {
            $('.body-content').append(data);
            $('#grupo_vehiculo-form-modal').modal('show');
        },
        error: function (error) {
            $("#mensaje-body").html(error.responseText);
            $("#modalMensajeError").modal("show");
        }
    });
}

function listarGrupo_Vehiculo() {
    var url = "/Vehiculo/ListarGrupo_VehiculoPorGrupoId/";

    $.ajax({
        url: url,
        cache: false,
        type: "GET",
        data: {
            idGrupo: sessionStorage.GrupoID
        },
        beforeSend: function () {
            $("#grupo_vehiculo-contenedor").empty();
            agregarSpinnerCargando($("#grupo_vehiculo-contenedor"));
        },
        success: function (data) {
            $('#grupo_vehiculo-contenedor').html(data);
        },
        error: function (error) {
            $("#mensaje-body").html(error.responseText);
            $("#modalMensajeError").modal("show");
        }
    });
}

function insertarGrupo_Vehiculo() {
    if ($("#grupo_vehiculo-form").valid()) {
        var url = "/Vehiculo/InsertarGrupo_Vehiculo/";

        $.ajax({
            url: url,
            cache: false,
            type: "POST",
            data: $('#grupo_vehiculo-form').serialize(),
            beforeSend: function () {
                $("#grupo_vehiculo-form-modal-submit")
                    .prop("disabled", true);
                $("#grupo_vehiculo-form-modal-submit")
                    .html(
                        '<span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span> Procesando...'
                    );
            },
            success: function (data) {
                $('#grupo_vehiculo-form-modal').modal('hide');
                $('#grupo_vehiculo-contenedor').append(data);
            },
            error: function (error) {
                $("#mensaje-body").html(error.responseText);
                $("#modalMensajeError").modal("show");
            },
            complete: function () {
                $("#grupo_vehiculo-form-modal-submit")
                    .prop("disabled", false);
                $("#grupo_vehiculo-form-modal-submit")
                    .html('Insertar');
            }
        });
    }
}

function actualizarGrupo_Vehiculo() {
    if ($("#grupo_vehiculo-form").valid()) {
        var url = "/Vehiculo/ActualizarGrupo_Vehiculo/";

        $.ajax({
            url: url,
            cache: false,
            type: "POST",
            data: $('#grupo_vehiculo-form').serialize(),
            beforeSend: function () {
                $("#grupo_vehiculo-form-modal-submit")
                    .prop("disabled", true);
                $("#grupo_vehiculo-form-modal-submit")
                    .html(
                        '<span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span> Procesando...'
                    );
            },
            success: function (data) {
                $('#grupo_vehiculo-' + $('#TN_ID_Grupo_Vehiculo').val()).remove();
                $('#grupo_vehiculo-form-modal').modal('hide');
                $('#grupo_vehiculo-contenedor').append(data);
            },
            error: function (error) {
                $("#mensaje-body").html(error.responseText);
                $("#modalMensajeError").modal("show");
            },
            complete: function () {
                $("#grupo_vehiculo-form-modal-submit")
                    .prop("disabled", false);
                $("#grupo_vehiculo-form-modal-submit")
                    .html('Actualizar');
            }
        });
    }
}

function eliminarGrupo_VehiculoPorId(id) {
    var url = "/Vehiculo/EliminarGrupo_Vehiculo/";

    $.ajax({
        url: url,
        cache: false,
        type: "POST",
        data: { "id": id },
        success: function (data) {
            $("#mensaje-body").html('Se ha borrado el vehículo del grupo');
            $("#modalMensajeError").modal("show");
        },
        error: function (error) {
            $("#mensaje-body").html(error.responseText);
            $("#modalMensajeError").modal("show");
        }
    });
}

function abrirInsertarVehiculoModal() {
    $('#vehiculo-form').trigger('reset');
    $('#TC_Placa-error').hide();
    $('#TC_Kilometraje-error').hide();
    $('#TC_Descripcion-error').hide();
    $('#vehiculo-form-modal').modal('show');
}

function insertarVehiculo() {
    if ($("#vehiculo-form").valid()) {
        var url = "/Vehiculo/InsertarVehiculo/";

        $.ajax({
            url: url,
            cache: false,
            type: "POST",
            data: $('#vehiculo-form').serialize(),
            beforeSend: function () {
                $("#vehiculo-form-modal-submit")
                    .prop("disabled", true);
                $("#vehiculo-form-modal-submit")
                    .html(
                        '<span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span> Procesando...'
                    );
            },
            success: function (data) {
                $("#TN_ID_Vehiculo-Grupo_Vehiculo").append(new Option(data.Placa, data.ID, true, true));
                $('#TN_ID_Vehiculo-Grupo_Vehiculo').selectpicker('refresh');
                $('#vehiculo-form-modal').modal('hide');
                $('#grupo_vehiculo-form-modal').modal('show');
            },
            error: function (error) {
                $("#mensaje-body").html(error.responseText);
                $("#modalMensajeError").modal("show");
            },
            complete: function () {
                $("#vehiculo-form-modal-submit")
                    .prop("disabled", false);
                $("#vehiculo-form-modal-submit")
                    .html('Actualizar');
            }
        });
    }
}

function aplicarGrupo_VehiculoDateRangePicker() {
    $('#TF_Fecha_Hora-Vehiculo').daterangepicker({
        singleDatePicker: true,
        timePicker: true,
        showDropdowns: true,
        startDate: ($('#TF_Fecha_Hora-Vehiculo').val() !== '') ? moment($('#TF_Fecha_Hora-Vehiculo').val()) : moment(),
        locale: {
            format: 'DD/M/Y HH:mm'
        }
    });
}

function aplicarGrupo_VehiculoSelectPicker() {
    $('#TN_ID_Vehiculo').selectpicker();
}