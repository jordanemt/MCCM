function listGrupo() {
    //var url = "/Gasto/List/";

    //$.ajax({
    //    url: url,
    //    cache: false,
    //    type: "GET",
    //    success: function (data) {
    //        $('#gastos-body').html(data);
    //        /* little fade in effect */
    //        //$('#divPartial').fadeIn('fast');
    //    },
    //    error: function (reponse) {
    //        alert("error : " + reponse);
    //    }
    //});
}

function removeGrupo(id) {
    //var url = "/Gasto/Remove/";

    //$.ajax({
    //    url: url,
    //    cache: false,
    //    type: "POST",
    //    data: { "id": id },
    //    success: function (data) {
    //        window.location = '/Dashboard/';
    //    },
    //    error: function (reponse) {
    //        alert("error : " + reponse);
    //    }
    //});
}

function openInsertGrupoModal() {
    $(".modal-title").text("Insertar Grupo");
    $('#grupo-form').attr('action', '/Insert/Grupo');
    $('#TN_ID_Grupo').val('0');
    $('.TN_ID_Caso').val('1');
    $('#TC_Zona').val('');
    $('#TF_Fecha_Inicio').val('');
    $('#TF_Fecha_Final').val('');
    $('#TF_Hora').val('');
    //$('#TN_ID_Grupo').val('');
    //$('#TN_ID_Grupo').val('');
    $('.submit-button').val('Insertar');
    $('#grupo-form-modal').modal('show');
}

function openAddVehiculoModal() {
    $(".modal-title").text("Insertar Vehículo a Grupo");
    //$('#add-vehiculo-form').attr('action', '/AddVehiculo/Grupo');
    $('#TN_ID_Grupo-Vehiculo').val('1');
    $('#TF_Hora-Vehiculo').val('08:00');
    $('#add-vehiculo-form-modal').modal('show');
}

function openUpdateGrupoModal(id) {
    //Funcionalidad no implementada
    //GetById
    $(".modal-title").text("Actualizar Grupo");
    $('#grupo-form').attr('action', '/Update/Grupo');
    $('#TN_ID_Grupo').val('1');
    $('.TN_ID_Caso').val('1');
    $('#TC_Zona').val('Turrialba');
    $('#TF_Fecha_Inicio').val('12/12/2019');
    $('#TF_Fecha_Final').val('');
    $('#TF_Hora').val('08:00');
    //$('#TN_ID_Grupo').val('');
    //$('#TN_ID_Grupo').val('');
    $('.submit-button').val('Actualizar');
    $('#grupo-form-modal').modal('show');
}

$(document).ready(function () {
    //listGrupos();
});