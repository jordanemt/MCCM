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
            $('#gastos-contenedor').html(data);
        },
        error: function (reponse) {
            alert("error : " + reponse);
        }
    });
}

function insertarGrupo() {
    //if ($("#grupo-form").valid()) {
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
    //}
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
                $('#grupo-' + $('#TN_ID_Gasto').val()).remove();
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
    //$("#gasto-form").validate({
    //    rules: {
    //        TN_Num_Factura: "required",
    //        TN_ID_Tipo_Gasto: "required",
    //        TD_Monto: "required",
    //        TC_Compra: "required"
    //    },
    //    messages: {
    //        TN_Num_Factura: "Ingrese la factura",
    //        TN_ID_Tipo_Gasto: "Seleccione una opción",
    //        TD_Monto: "Ingrese el monto",
    //        TC_Compra: "Ingrese el detalle"
    //    }
    //});
}

function aplicarMaskGrupoForm() {
    //$('#TN_Num_Factura').mask("0000000000", { placeholder: "_ _ _ _ _ _ _ _ _ _" });
    //$('#TD_Monto').mask("0000000000", { placeholder: "0000000000" });
}

$(document).ready(function () {
    //listarGrupo();
    abrirActualizarGrupoFormModal(9);
});