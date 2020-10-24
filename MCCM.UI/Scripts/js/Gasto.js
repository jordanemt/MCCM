function listGastos() {
    var url = "/Gasto/List/";

    $.ajax({
        url: url,
        cache: false,
        type: "GET",
        success: function (data) {
            $('#gastos-body').html(data);
            /* little fade in effect */
            //$('#divPartial').fadeIn('fast');
        },
        error: function (reponse) {
            alert("error : " + reponse);
        }
    });
}

function removeGasto(id) {
    var url = "/Gasto/Remove/";

    $.ajax({
        url: url,
        cache: false,
        type: "POST",
        data: { "id": id},
        success: function (data) {
            window.location = '/Dashboard/';
        },
        error: function (reponse) {
            alert("error : " + reponse);
        }
    });
}

function openInsertGastoModal() {
    $(".modal-title").text("Insertar Gasto");
    $('#gasto-form').attr('action', '/Insert/Gasto');
    $('#TN_ID_Gasto').val('0');
    $('.TN_ID_Caso').val('1');
    var d = new Date();
    $('#TF_Fecha').val(d.toLocaleDateString());
    $('#TN_Num_Factura').val('');
    //$('#TN_ID_Tipo_Gasto').val('');
    $('#TD_Monto').val('');
    $('#TC_Compra').val('');
    $('.submit-button').val('Insertar');
    $('#gasto-insert-modal').modal('show');
}

function openUpdateGastoModal(id) {
    //Funcionalidad no implementada
    //GetById
    $(".modal-title").text("Actualizar Gasto");
    $('#gasto-form').attr('action', '/Update/Gasto');
    $('#TN_ID_Gasto').val('1');
    $('.TN_ID_Caso').val('1');
    $('#TF_Fecha').val('12/12/2020');
    $('#TN_Num_Factura').val('1234567');
    //$('#TN_ID_Tipo_Gasto').val('');
    $('#TD_Monto').val('50.000');
    $('#TC_Compra').val('Detalle de compra');
    $('.submit-button').val('Actualizar');
    $('#gasto-insert-modal').modal('show');
}

$(document).ready(function () {
    //listGastos();
});