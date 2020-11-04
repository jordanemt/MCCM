function abrirGrupo_VehiculoInsertarFormModal() {
    $('#grupo_vehiculo-form-modal').remove();

    var url = "/Vehiculo/Grupo_VehiculoInsertarFormModal/";

    $.ajax({
        url: url,
        cache: false,
        type: "GET",
        success: function (data) {
            $('.body-content').append(data);
            if (agregarGrupoIDToInputElementVal($('#TN_ID_Grupo_Vehiculo'))) {
                $('#grupo_vehiculo-form-modal').modal('show');
                //$('#TN_ID_Grupo_Vehiculo').val(sessionStorage.GrupoID)
            }
        },
        error: function (reponse) {
            alert("error : " + reponse);
        }
    });
}

function abrirGrupo_VehiculoActualizarFormModal(idGrupo, idVehiculo) {
    $('#grupo_vehiculo-form-modal').remove();

    var url = "/Vehiculo/Grupo_VehiculoActualizarFormModal/";

    $.ajax({
        url: url,
        cache: false,
        type: "GET",
        data: {
            idGrupo: idGrupo,
            idVehiculo: idVehiculo
        },
        success: function (data) {
            $('.body-content').append(data);
            $('#grupo_vehiculo-form-modal').modal('show');
        },
        error: function (reponse) {
            alert("error : " + reponse);
        }
    });
}

function listarGrupo_Vehiculo() {
    var url = "/Vehiculo/ListarGrupo_VehiculoPorGrupoId/";

    $.ajax({
        url: url,
        cache: false,
        type: "GET",
        data: {
            idGrupo: sessionStorage.GrupoID
        },
        success: function (data) {
            $('#grupo_vehiculo-contenedor').html(data);
        },
        error: function (reponse) {
            alert("error : " + reponse);
        }
    });
}

function insertarGrupo_Vehiculo() {
    if ($("#grupo_vehiculo-form").valid()) {
        var url = "/Vehiculo/InsertarGrupo_Vehiculo/";

        $.ajax({
            url: url,
            cache: false,
            type: "POST",
            data: $('#grupo_vehiculo-form').serialize(),
            success: function (data) {
                $('#grupo_vehiculo-form-modal').modal('hide');
                $('#grupo_vehiculo-contenedor').append(data);
            },
            error: function (reponse) {
                alert("error : " + reponse);
            }
        });
    }
}

function actualizarGrupo_Vehiculo() {
    if ($("#grupo_vehiculo-form").valid()) {
        var url = "/Vehiculo/ActualizarGrupo_Vehiculo/";

        $.ajax({
            url: url,
            cache: false,
            type: "POST",
            data: $('#grupo_vehiculo-form').serialize(),
            success: function (data) {
                $('#grupo_vehiculo-' + $('#TN_ID_Vehiculo').val()).remove();
                $('#grupo_vehiculo-form-modal').modal('hide');
                $('#grupo_vehiculo-contenedor').append(data);
            },
            error: function (reponse) {
                alert("error : " + reponse);
            }
        });
    }
}

function aplicarGrupo_VehiculoValidation() {
    $("#grupo_vehiculo-form").validate({
        rules: {
            TN_ID_Vehiculo: "required",
            TF_Fecha_Hora: "required"
        },
        messages: {
            TN_ID_Vehiculo: "Este campo es requerido",
            TF_Fecha_Hora: "Este campo es requerido"
        }
    });
}

function aplicarGrupo_VehiculoDateRangePicker() {
    $('#TF_Fecha_Hora-Vehiculo').daterangepicker({
        singleDatePicker: true,
        timePicker: true,
        showDropdowns: true,
        startDate: ($('#TF_Fecha_Hora-Vehiculo').val() !== '') ? moment($('#TF_Fecha_Hora-Vehiculo').val()) : moment(),
        locale: {
            format: 'DD/M/Y HH:mm'
        }
    });
}

function aplicarGrupo_VehiculoSelectPicker() {
    $('#TN_ID_Vehiculo').selectpicker();
}

$(document).ready(function () {
    //listarGrupo_Vehiculo();
});