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
        error: function (reponse) {
            alert("error : " + reponse);
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
        error: function (reponse) {
            alert("error : " + reponse);
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
        error: function (reponse) {
            alert("error : " + JSON.stringify(reponse));
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
            success: function (data) {
                $('#grupo-form-modal').modal('hide');
                $('#grupo-contenedor').append(data);
            },
            error: function (reponse) {
                alert("error : " + reponse);
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
            success: function (data) {
                $('#grupo-' + $('#TN_ID_Grupo').val()).remove();
                $('#grupo-form-modal').modal('hide');
                $('#grupo-contenedor').append(data);
            },
            error: function (reponse) {
                alert("error: " + reponse);
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
        error: function (reponse) {
            alert("error : " + reponse);
        }
    });
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

$(document).ready(function () {
    //listarGrupo();
});