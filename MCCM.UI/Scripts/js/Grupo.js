function abrirInsertarGrupoFormModal() {
    $('#grupo-form-modal').remove();

    var url = "/Grupo/CargarModal/";

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

    var url = "/Grupo/CargarModalConId/";

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
                alert("error : " + reponse);
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

function aplicarValidGrupoForm() {
    $("#grupo-form").validate({
        rules: {
            TC_Zona: "required",
            TF_Fecha_Inicio: "required",
            TF_Fecha_Final: "required",
            TF_Hora: "required",
            Encargado: "required",
            Acompannantes: "required"
        },
        messages: {
            TC_Zona: "Ingrese la zona",
            TF_Fecha_Inicio: "Ingrese una fecha de inicio",
            TF_Fecha_Final: "Ingrese una fecha final",
            TF_Hora: "Ingrese la hora",
            Encargado: "Seleccione un encargado",
            Acompannantes: "Seleccione al menos un acompañante"
        }
    });
}

function aplicarMaskGrupoForm() {
    //$('#TN_Num_Factura').mask("0000000000", { placeholder: "_ _ _ _ _ _ _ _ _ _" });
    //$('#TD_Monto').mask("0000000000", { placeholder: "0000000000" });
}

function bloquearAcompannanteEncargado() {
    var encargadoId = $('#Encargado').val();
    $('#Acompannantes').find('option').prop('disabled', false);
    $('#Acompannantes').find('#acompannante-' + encargadoId).prop('selected', false);
    $('#Acompannantes').find('#acompannante-' + encargadoId).prop('disabled', true);
}

function aplicarDateRangeGrupo() {
    $('#TF_Fecha_Inicio').daterangepicker({
        timePicker: false,
        singleDatePicker: true,
        showDropdowns: true,
        dateFormat: 'dd-mm-yyyy'
    });
    $('#TF_Fecha_Final').daterangepicker({
        timePicker: false,
        singleDatePicker: true,
        showDropdowns: true,
        dateFormat: 'dd/mm/yyyy' 
    });
}

$(document).ready(function () {
    listarGrupo();
});