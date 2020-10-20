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

function obtenerGastoPorId(id) {
    var url = "/Gasto/ObtenerPorId/";

    $.ajax({
        url: url,
        cache: false,
        type: "GET",
        data: { "id": id },
        success: function (data) {
            return data;
        },
        error: function (reponse) {
            alert("error : " + reponse);
            return 'error';
        }
    });
}

function insertarGasto() {
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

function actualizarGasto() {
    var url = "/Gasto/Actualizar/";

    $.ajax({
        url: url,
        cache: false,
        type: "POST",
        data: $('#gasto-form').serialize(),
        success: function (data) {
            $('#gasto-' + $('#TN_ID_Gasto').val).remove();
            $('#gasto-form-modal').modal('hide');
            $('#gastos-contenedor').append(data);
            //$('#gastos-contenedor').fadeIn('fast');
        },
        error: function (reponse) {
            alert("error : " + reponse);
        }
    });
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

function abrirInsertarGastoFormModal() {
    alert($('#gasto-form').serialize());
    $("#gasto-form-modal-title").text("Insertar Gasto");
    $('#gasto-form').attr('action', '/Gasto/Insertar');
    $('#TN_ID_Gasto').val('0');
    $('.TN_ID_Caso').val('15');
    var d = new Date();
    $('#TF_Fecha').val(d.toLocaleDateString());
    $('#TN_Num_Factura').val('');
    //$('#TN_ID_Tipo_Gasto').val('');
    $('#TD_Monto').val('');
    $('#TC_Compra').val('');
    $('#gasto-form-modal-submit').val('Insertar');
    $('#gasto-form-modal').modal('show');
}

function abrirActualizarGastoFormModal(id) {
    $('#gasto-form').trigger("reset");
    var data = obtenerGastoPorId(id);
    alert(data);
    //Funcionalidad no implementada
    ////GetById
    //$("#gasto-form-modal-title").text("Actualizar Gasto");
    //$('#gasto-form').attr('action', '/Update/Gasto');
    //$('#TN_ID_Gasto').val('1');
    //$('.TN_ID_Caso').val('1');
    //$('#TF_Fecha').val('12/12/2020');
    //$('#TN_Num_Factura').val('1234567');
    ////$('#TN_ID_Tipo_Gasto').val('');
    //$('#TD_Monto').val('50.000');
    //$('#TC_Compra').val('Detalle de compra');
    $('#gasto-form-modal-submit').val('Actualizar');
    $('#gasto-form-modal').modal('show');
}

$(document).ready(function () {
    //listarGastos();
});