$(document).ready(function () {
    cargarTipoIdentificacion();
    cargarPersonaSexo();
    cargarPersonaGenero();
    cargarPersonaNacionalidad();

});

/*Fecha*/
function iniciarCalendarioPersona(fecha) {
    $('#TF_Fecha_Nacimiento').daterangepicker({
        "singleDatePicker": true,
        "timePicker": true,
        "timePicker24Hour": true,
        "starDate": fecha,
        locale: {
            format: 'YYYY/M/DD HH:mm'
        }
    });
}

/* Agregar Persona*/
$(document).on("click", "#btnInsertarEntidadPersona", function (e) {
    e.preventDefault();
    if ($("#FormEntidadPersona").valid()) {
        $("#TN_ID_Caso_P").val(sessionStorage.CasoID);
        var form = new FormData($("#FormEntidadPersona")[0]);
        alert(JSON.stringify(Object.fromEntries(form)));
        alert(sessionStorage.CasoID);
        $.ajax({
            type: "POST",
            url: "/E_Persona/Insertar_E_Persona",
            data: form,
            contentType: false,
            cache: false,
            processData: false,
        }).done(function (data) {
            $("#entidadPersonaModal").modal("hide");
            CargarEntidadPersona();
        });
    } else {
        alert("NO es valido");
    }
});

/*Cargar Personas*/
function CargarEntidadPersona() {
    $.ajax({
        type: "GET",
        url: "/E_Persona/Listar_E_Persona",
        data: { "caso": sessionStorage.CasoID }
    }).done(function (data) {
        let entidadPersonaJuridicas = new Array();
        entidadPersona = JSON.parse(data);

        $("#entidades-body").empty();
        for (let i = 0; i < entidadPersona.length; i++) {

            $("#entidades-body").append(
                '<div class="card" id="cartaEntidadPersona">' +

                '<div class="card-header">' +
                '<div>Entidad Persona #' + entidadPersona[i].TN_ID_Persona + '</div>' +
                '<div>' +
                '<a href="#" class="editarEntidadPersona" id="' + entidadPersona[i].TN_ID_Persona + '"><span><i class="fa fa-pencil" aria-hidden="true"></i></span></a>' +
                '<a href="#" class="borrar borrarEntidadPersona" id="' + entidadPersona[i].TN_ID_Persona + '"><span><i class="fa fa-trash" data-toggle="modal" data-target="#ModalMensaje" aria-hidden="true"></i></span></a>' +
                '</div>' +

                '</div>' +
                '<div class="card-body" style="padding:0px!important">' +
                '<div class="container">' +
                '<div class="row">' +
                '<div class="col-md-4">' +
                '<img src="' + entidadPersona[i].imgString + '" class="img-fluid">' +
                '</div>' +

                '<div class="col-md-8">' +
                '<div class="row">' +
                '<div class="col-4">' +
                ' <h6><span class="w-100 badge badge-primary">Nombre</span></h6>' +
                '</div>' +
                '<div class="col-md-8" id="divInforma">' +
                '<small>' + entidadPersona[i].TC_Nombre + '</small>' +
                '</div>' +
                '</div>' +

                '<div class="row">' +
                ' <div class="col-4">' +
                ' <h6><span class="w-100 badge badge-primary">Identificación:</span></h6>' +
                '</div>' +
                '<div class="col-md-8" id="divInforma">' +
                ' <small>' + entidadPersona[i].TC_Cedula + '</small>' +
                '</div>' +
                '</div>' +

                '<div class="row">' +
                '<div class="col-4">' +
                '<h6><span class="w-100 badge badge-primary">Alias:</span></h6>' +
                '</div>' +

                '<div class="col-md-8" id="divLugar">' +
                '<small>' + entidadPersona[i].TC_Alias + '</small>' +
                '</div>' +
                '</div>' +

                '<div class="row">' +
                '<div class="col-4">' +
                '<h6><span class="w-100 badge badge-primary">Nacionalidad:</span></h6>' +
                '</div>' +
                ' <div class="col-md-8" id="divNovedad">' +
                '<p>' + entidadPersona[i].TN_ID_Nacionalidad + '</p>' +
                '</div>' +
                '</div>' +
                '<div class="row">' +
                '<div class="col-4">' +
                '<h6><span class="w-100 badge badge-primary">Genero:</span></h6>' +
                '</div>' +
                '<div class="col-md-8" id="divNovedad">' +
                '<p>' + entidadPersona[i].TN_ID_Genero + '</p>' +
                '</div>' +
                '</div>' +
                '</div>' +

                '<div>' +

                '</div>' +
                '</div>' +
                '</div>' +
                '</div>' +

                '</div>'

            );
        }
    });
}


/*Eliminar Persona

function eliminarPersona(entidadPersonaID) {
    $.ajax({
        type: "POST",
        url: "/E_Persona/Eliminar_E_PersonaPorID",
        data: { "entidadPersonaID": entidadPersonaID }
    }).done(function (data) {

    });
}
*/

/*Editar Persona

$(document).on("click", ".editarEntidadPersona", function () {
    $.ajax({
        type: "GET",
        url: "/E_Persona/Obtener_E_PersonaPorID",
        data: { "ID": $(this).attr('ID') }
    }).done(function (data) {
        let entidadPersona = new Array();
        entidadPersona = JSON.parse(data);
        alert(JSON.stringify(data));
        $("#tituloEntidadPersona").html("Modificar Persona");
        $("#divPersonaID").show();
        $("#TN_ID_Persona").val(entidadPersona.TN_ID_Persona);
        $("#TC_Nombre_Persona").val(entidadPersona.TC_Nombre);
        $("#TC_Primer_Apellido_Persona").val(entidadPersona.TC_Primer_Apellido);
        $("#TC_Segundo_Apellido_Persona").val(entidadPersona.TC_Segundo_Apellido);
        $("#TF_Fecha_Nacimiento_Persona").val(entidadPersona.TF_Fecha_Nacimiento);
        iniciarCalendarioPersona(entidadPersona.TF_Fecha_Nacimiento);
        $('#TN_ID_Tipo_Identificacion_Persona').selectpicker('val', entidadPersona.TN_ID_Tipo_Identificacion);
        $('#TN_ID_Tipo_Identificacion_Persona').selectpicker('refresh');
        $("#TC_Cedula_Persona").val(entidadPersona.TC_Cedula);
        $("#TN_Edad_Persona").val(entidadPersona.TN_Edad);
        $('#TN_ID_Sexo_Persona').selectpicker('val', entidadPersona.TN_ID_Sexo);
        $('#TN_ID_Sexo_Persona').selectpicker('refresh');
        $('#TN_ID_Genero_Persona').selectpicker('val', entidadPersona.TN_ID_Genero);
        $('#TN_ID_Genero_Persona').selectpicker('refresh');
        $('#TN_ID_Nacionalidad_Persona').selectpicker('val', entidadPersona.TN_ID_Nacionalidad);
        $('#TN_ID_Nacionalidad_Persona').selectpicker('refresh');
        $('#TB_Fallecido_Persona').attr('checked', entidadPersona.TB_Fallecido);
        $("#TN_Autopsia_Persona").val(entidadPersona.TN_Autopsia);
        $('#TB_Exp_Criminal_Persona').attr('checked', entidadPersona.TB_Exp_Criminal);
        $("#TC_Alias_Persona").val(entidadPersona.TC_Alias);
        $("#TC_Comentario_P").val(entidadPersona.TC_Comentario);
        $("#TC_Creado_Por_P").val(entidadPersona.TC_Creado_Por);
        $("#fechaCreacion_Row_P").show();
        $("#TF_Fecha_Creacion_P").val(entidadPersona.TF_Fecha_Creacion);
        iniciarCalendarioPersona(entidadPersona.TF_Fecha_Creacion);
        $("#fechaModificación_Row_P").show();
        $("TF_Fecha_Modificacion_P").val(entidadPersona.TF_Fecha_Modificacion);
        iniciarCalendarioPersona(entidadPersona.TF_Fecha_Modificacion);
        $("#modificadoPor_Row_P").show();
        $("#TF_Modificado_Por_P").val(entidadPersona.TF_Modificado_Por);
        $('#TB_Verificado_P').attr('checked', entidadPersona.TB_Verificado);
        $("#btnInsertarEntidadPersona").hide();
        $("#btnModificarEntidadPersona").show();
        $("#entidadPersonaModal").modal("show");
    });
});

$('#entidadPersonaModal').on('hidden.bs.modal', function () {
    $("#FormEntidadPersona")[0].reset();
    $("#tituloEntidadPersona").html("Insertar Persona");
    $("#fechaCreacion_Row_P").hide();
    $("#fechaModificación_Row_P").hide();
    $("#modificadoPor_Row_P").hide();
    $("#btnInsertarEntidadPersona").show();
    $("#btnModificarEntidadPersona").hide();
})
*/
$(document).on("click", "#btnModificarEntidadPersona", function (e) {
    e.preventDefault();
    $("#TN_ID_Caso").val(sessionStorage.CasoID);
    var form = new FormData($("#FormEntidadPersona")[0]);
    alert(JSON.stringify(Object.fromEntries(form)));
    $.ajax({
        type: "POST",
        url: "/E_Persona/Obtener_E_PersonaPorID",
        data: form,
        contentType: false,
        cache: false,
        processData: false,
    }).done(function (data) {
        $("#Modificar_E_Persona").modal("hide");
        CargarEntidadPersona();
    });
});















/*Cargar Tipo Identificación*/
function cargarTipoIdentificacion() {

    $(document).ready(function () {
        $.ajax({
            type: "GET",
            url: "/C_PersonaTipoIdentificacion/ListarPersonaTipoIdentificacion",
            data: "{}",
            success: function (data) {
                var s;
                for (var i = 0; i < data.length; i++) {
                    s += '<option value="' + data[i].TN_ID_Tipo_Identificacion + '">' + data[i].TC_Descripcion + '</option>';
                }
                $("#TN_ID_Tipo_Identificacion_Persona").html(s);
                $('#TN_ID_Tipo_Identificacion_Persona').selectpicker('refresh');
            }

        });
    });
}

/*Cargar Persona Sexo*/
function cargarPersonaSexo() {

    $(document).ready(function () {
        $.ajax({
            type: "GET",
            url: "/C_PersonaSexo/ListarPersonaSexo",
            data: "{}",
            success: function (data) {
                var s;
                for (var i = 0; i < data.length; i++) {
                    s += '<option value="' + data[i].TN_ID_Sexo + '">' + data[i].TC_Descripcion + '</option>';
                }
                $("#TN_ID_Sexo_Persona").html(s);
               // $('#TN_ID_Sexo_Persona').selectpicker('refresh');
            }

        });
    });
}

/*Cargar Persona Genero*/
function cargarPersonaGenero() {

    $(document).ready(function () {
        $.ajax({
            type: "GET",
            url: "/C_PersonaGenero/ListarPersonaGenero",
            data: "{}",
            success: function (data) {
                var s;
                for (var i = 0; i < data.length; i++) {
                    s += '<option value="' + data[i].TN_ID_Genero + '">' + data[i].TC_Descripcion + '</option>';
                }
                $("#TN_ID_Genero_Persona").html(s);
                //$('#TN_ID_Genero_Persona').selectpicker('refresh');
            }

        });
    });
}

/*Cargar Persona Nacionalidad*/
function cargarPersonaNacionalidad() {

    $(document).ready(function () {
        $.ajax({
            type: "GET",
            url: "/C_PersonaNacionalidad/ListarPersonaNacionalidad",
            data: "{}",
            success: function (data) {
                var s;
                for (var i = 0; i < data.length; i++) {
                    s += '<option value="' + data[i].TN_ID_Nacionalidad + '">' + data[i].TC_Descripcion + '</option>';
                }
                $("#TN_ID_Nacionalidad_Persona").html(s);
               // $('#TN_ID_Nacionalidad_Persona').selectpicker('refresh');
            }

        });
    });
}