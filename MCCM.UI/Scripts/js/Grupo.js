function abrirInsertarGrupoFormModal() {
    $('#grupo-form-modal').remove();

    var url = "/Grupo/InsertarFormModal/";

    $.ajax({
        url: url,
        cache: false,
        type: "GET",
        success: function (data) {
            $('.body-content').append(data);
            $('#grupo-form-modal').modal('show');
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

function listarGrupo() {
    var url = "/Grupo/Listar/";

    $.ajax({
        url: url,
        cache: false,
        type: "GET",
        success: function (data) {
            $('#grupo-contenedor').html(data);
        },
        error: function (reponse) {
            alert("error : " + reponse);
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

function aplicarGrupoValidation() {
    $("#grupo-form").validate({
        rules: {
            TC_Zona: "required",
            TF_Fecha_Inicio: "required",
            TF_Hora: "required",
            Encargado: "required",
            Acompannantes: "required",
            TB_Mando: "required"
        },
        messages: {
            TC_Zona: "Este campo es necesario",
            TF_Fecha_Inicio: "Este campo es necesario",
            TF_Hora: "Este campo es necesario",
            Encargado: "Este campo es necesario",
            Acompannantes: "Este campo es necesario",
            TB_Mando: "Este campo es necesario"
        }
    });
}

function aplicarGrupoDateRangePicker() {
    var fechaInicioElement = $('#TF_Fecha_Inicio');
    var fechaInicio = $('#TF_Fecha_Inicio').val();
    fechaInicioElement.daterangepicker({
        singleDatePicker: true,
        startDate: (fechaInicioElement.val() !== '') ? moment(fechaInicioElement.val()) : moment(),
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

$(document).ready(function () {
    listarGrupo();
});