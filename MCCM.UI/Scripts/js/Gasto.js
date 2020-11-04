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
        error: function (reponse) {
            alert("error : " + reponse);
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
        error: function (reponse) {
            alert("error : " + reponse);
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
        success: function (data) {
            $('#gastos-contenedor').html(data);
        },
        error: function (reponse) {
            alert("error : " + reponse);
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
            success: function (data) {
                $('#gasto-form-modal').modal('hide');
                $('#gastos-contenedor').append(data);
            },
            error: function (reponse) {
                alert("error : " + reponse);
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
            success: function (data) {
                $('#gasto-' + $('#TN_ID_Gasto').val()).remove();
                $('#gasto-form-modal').modal('hide');
                $('#gastos-contenedor').append(data);
                //$('#gastos-contenedor').fadeIn('fast');
            },
            error: function (reponse) {
                alert("error : " + reponse);
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
            alert("Se elimino el gasto #" + id);
            $('#gasto-' + id).remove();
        },
        error: function (reponse) {
            alert("error : " + reponse);
        }
    });
}

function insertarTipo_Gasto() {
    if ($("#tipo_gasto-form").valid()) {
        var url = "/Gasto/InsertarTipo_Gasto/";

        $.ajax({
            url: url,
            cache: false,
            type: "POST",
            data: $('#tipo_gasto-form').serialize(),
            success: function (data) {
                $("#TN_ID_Tipo_Gasto").append(new Option(data.Nombre, data.ID, true, true));
                $('#TN_ID_Tipo_Gasto').selectpicker('refresh');
                $('#tipo_gasto-form-modal').modal('hide');
                $('#gasto-form-modal').modal('show');
            },
            error: function (reponse) {
                alert("error : " + reponse);
            }
        });
    }
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

$(document).ready(function () {
    //listarGastos();
});
