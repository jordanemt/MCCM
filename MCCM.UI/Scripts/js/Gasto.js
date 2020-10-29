﻿function abrirInsertarGastoFormModal() {
    $('#gasto-form-modal').remove();

    var url = "/Gasto/InsertarFormModal/";

    $.ajax({
        url: url,
        cache: false,
        type: "GET",
        success: function (data) {
            $('.body-content').append(data);
            $('#gasto-form-modal').modal('show');
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
    var url = "/Gasto/Listar/";

    $.ajax({
        url: url,
        cache: false,
        type: "GET",
        success: function (data) {
            $('#gastos-contenedor').html(data);
            //$('#divPartial').fadeIn('fast');
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
                //$('#gastos-contenedor').fadeIn('fast');
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
            //$('#gastos-contenedor').fadeOut('fast');
        },
        error: function (reponse) {
            alert("error : " + reponse);
        }
    });
}

function aplicarValidGastoForm() {
    $("#gasto-form").validate({
        rules: {
            TF_Fecha: "required",
            TN_Num_Factura: "required",
            TN_ID_Tipo_Gasto: "required",
            TD_Monto: "required",
            TC_Compra: "required"
        },
        messages: {
            TF_Fecha: "Seleccione una fecha",
            TN_Num_Factura: "Ingrese la factura",
            TN_ID_Tipo_Gasto: "Seleccione una opción",
            TD_Monto: "Ingrese el monto",
            TC_Compra: "Ingrese el detalle"
        }
    });
}

function aplicarMaskGastoForm() {
    //$('#TN_Num_Factura').mask("0000000000", { placeholder: "_ _ _ _ _ _ _ _ _ _" });
    //$('#TD_Monto').mask("0000000000", { placeholder: "0000000000" });
}

function aplicarGastoDateRangePicker() {
    $('#TF_Fecha_Gasto').daterangepicker({
        singleDatePicker: true,
        showDropdowns: true,
        minYear: parseInt(moment().format('YYYY'), 10),
        maxYear: parseInt(moment().format('YYYY'), 10),
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
    listarGastos();
});