function abrirInsertarGrupoFormModal() {
    $('#grupo-form-modal').remove();

    var url = "/Grupo/InsertarFormModal/";

    $.ajax({
        url: url,
        cache: false,
        type: "GET",
        success: function (data) {
            $('.body-content').append(data);
            if (agregarCasoIDToInputElementVal($('#TN_ID_Caso_Grupo'))) {
                $('#grupo-form-modal').modal('show');
            }
        },
        error: function (error) {
            alert(error.responseText);
        }
    });
}

function abrirActualizarGrupoFormModal(id) {
    $('#grupo-form-modal').remove();

    var url = "/Grupo/ActualizarFormModal/";

    $.ajax({
        url: url,
        cache: false,
        type: "GET",
        data: { "id": id },
        success: function (data) {
            $('.body-content').append(data);
            $('#grupo-form-modal').modal('show');
        },
        error: function (error) {
            alert(error.responseText);
        }
    });
}

function listarGrupos() {
    var url = "/Grupo/ListarPorCasoId/";

    $.ajax({
        url: url,
        cache: false,
        type: "GET",
        data: {
            idCaso: sessionStorage.CasoID
        },
        beforeSend: function () {
            $('#grupo-contenedor').empty();
            agregarSpinnerCargando($('#grupo-contenedor'));
        },
        success: function (data) {
            $('#grupo-contenedor').html(data);
        },
        error: function (error) {
            alert(error.responseText);
        }
    });
}

function insertarGrupo() {
    if ($("#grupo-form").valid()) {
        var url = "/Grupo/Insertar/";

        $.ajax({
            url: url,
            cache: false,
            type: "POST",
            data: $('#grupo-form').serialize(),
            beforeSend: function () {
                $("#grupo-form-modal-submit")
                    .prop("disabled", true);
                $("#grupo-form-modal-submit")
                    .html(
                        '<span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span> Procesando...'
                    );
            },
            success: function (data) {
                $('#grupo-form-modal').modal('hide');
                $('#grupo-contenedor').append(data);
            },
            error: function (error) {
                alert(error.responseText);
            },
            complete: function () {
                $("#grupo-form-modal-submit")
                    .prop("disabled", false);
                $("#grupo-form-modal-submit")
                    .html('Insertar');
            }
        });
    }
}

function actualizarGrupo() {
    if ($("#grupo-form").valid()) {
        var url = "/Grupo/Actualizar/";

        $.ajax({
            url: url,
            cache: false,
            type: "POST",
            data: $('#grupo-form').serialize(),
            beforeSend: function () {
                $("#grupo-form-modal-submit")
                    .prop("disabled", true);
                $("#grupo-form-modal-submit")
                    .html(
                        '<span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span> Procesando...'
                    );
            },
            success: function (data) {
                $('#grupo-' + $('#TN_ID_Grupo').val()).remove();
                $('#grupo-form-modal').modal('hide');
                $('#grupo-contenedor').append(data);
            },
            error: function (error) {
                alert(error.responseText);
            },
            complete: function () {
                $("#grupo-form-modal-submit")
                    .prop("disabled", false);
                $("#grupo-form-modal-submit")
                    .html('Actualizar');
            }
        });
    }
}

function eliminarGrupoPorId(id) {
    var url = "/Grupo/EliminarPorId/";

    $.ajax({
        url: url,
        cache: false,
        type: "POST",
        data: { "id": id },
        success: function (data) {
            alert("Se elimino el grupo #" + id);
            $('#grupo-' + id).remove();
        },
        error: function (error) {
            alert(error.responseText);
        }
    });
}

function cargarGrupoMandoVigente() {
    if (sessionStorage.CasoID != null) {
        var url = "/Grupo/ObtenerGrupoDeMandoActivoPorIdCaso/";

        $.ajax({
            url: url,
            cache: false,
            type: "GET",
            data: { "idCaso": sessionStorage.CasoID },
            success: function (data) {
                $('#mando-body').html(data);
            },
            error: function (error) {
                alert(error.responseText);
            }
        });
    } else {
        alert('Debe seleccionar un caso');
    }
}

function aplicarGrupoDateRangePicker() {
    var fechaInicioElement = $('#TF_Fecha_Inicio');
    var fechaInicio = $('#TF_Fecha_Inicio').val();
    fechaInicioElement.daterangepicker({
        singleDatePicker: true,
        startDate: (fechaInicioElement.val() !== '') ? moment($('#TF_Fecha_Inicio').val()) : moment(),
        locale: {
            format: 'DD/M/Y'
        }
    });

    var fechaFinalElement = $('#TF_Fecha_Final');
    fechaInicioElement.on('apply.daterangepicker', function (ev, picker) {
        fechaFinalElement.val('');
        fechaFinalElement.daterangepicker({
            autoUpdateInput: false,
            singleDatePicker: true,
            minDate: picker.startDate,
        });
    });
    fechaFinalElement.daterangepicker({
        autoUpdateInput: false,
        singleDatePicker: true,
        minDate: (fechaInicio !== '') ? moment(fechaInicio) : moment(),
    });
    if (fechaFinalElement.val() !== '') {
        fechaFinalElement.val(moment(fechaFinalElement.val()).format('DD/M/Y'));
    }
    fechaFinalElement.on('apply.daterangepicker', function (ev, picker) {
        $(this).val(picker.startDate.format('DD/M/Y'));
    });
}

function aplicarGrupoSelectPicker() {
    $('#Encargado').selectpicker();
    $('#Acompannantes').selectpicker();
    $('#TB_Mando').selectpicker();
}

function bloquearAcompannanteEncargado() {
    var encargadoId = $('#Encargado').val();
    $('#Acompannantes').find('option').prop('disabled', false);
    $('#Acompannantes').find('[value=' + encargadoId + ']').prop('selected', false);
    $('#Acompannantes').find('[value=' + encargadoId + ']').prop('disabled', true);
    $('#Acompannantes').selectpicker('refresh');
}

function seleccionarGrupo(idGrupo) {
    $(".grupoCard").removeClass('filaseleccionada');
    $('#grupo-' + idGrupo).addClass('filaseleccionada');

    sessionStorage.GrupoID = idGrupo;
    $("#vehiculos-titulo").text('Vechículos/Grupo #' + idGrupo);
    listarGrupo_Vehiculo();//Definido en Vehiculo.js
}