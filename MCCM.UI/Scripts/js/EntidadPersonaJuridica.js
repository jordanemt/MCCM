$(document).ready(function () {
    cargarTipoOrganizacion();

});
/* Agregar Persona Juridica*/

$(document).on("click", "#btnInsertarEntidadPersonaJuridica", function (e) {
    e.preventDefault();
    if ($("#FormEntidadPersonaJuridica").valid()) {
        $("#TN_ID_Caso_PJ").val(sessionStorage.CasoID);
        var form = new FormData($("#FormEntidadPersonaJuridica")[0]);
        alert(JSON.stringify(Object.fromEntries(form)));
        alert(sessionStorage.CasoID);
        $.ajax({
            type: "POST",
            url: "/E_PersonaJuridica/Insertar_E_PersonaJuridica",
            data: form,
            contentType: false,
            cache: false,
            processData: false,
        }).done(function (data) {
            $("#entidadPersonaJuridicaModal").modal("hide");
            CargarEntidadPersonaJuridica();
        });
    } else {
        alert("NO es valido");
    }
});

/*Cargar Vehiculos*/
function CargarEntidadPersonaJuridica() {
    $.ajax({
        type: "GET",
        url: "/E_PersonaJuridica/Listar_E_PersonaJuridica",
        data: { "caso": sessionStorage.CasoID }
    }).done(function (data) {
        let entidadPersonaJuridicas = new Array();
        entidadPersonaJuridica = JSON.parse(data);

        $("#entidades-body").empty();
        for (let i = 0; i < entidadPersonaJuridica.length; i++) {

            $("#entidades-body").append(
                ' <div class="card" id="cartaEntidadPersonaJuridica" ' + entidadPersonaJuridica[i].TN_ID_Persona_Juridica + '>' +

                '<div class="card-header">' +
                ' <div>Entidad Cedula Juridica #' + entidadPersonaJuridica[i].TN_ID_Persona_Juridica + '</div>' +
                '<div>' +
                ' <a href="#" class="editarEntidadPersonaJuridica" id="' + entidadPersonaJuridica[i].TN_ID_Persona_Juridica + '"><span><i class="fa fa-pencil" aria-hidden="true"></i></span></a>' +
                '<a href="#" class="borrar borrarPersonaJuridica" id="' + entidadPersonaJuridica[i].TN_ID_Persona_Juridica + '"><span><i class="fa fa-trash" data-toggle="modal" data-target="#ModalMensaje" aria-hidden="true"></i></span></a>' +
                '</div>' +

                '</div>' +
                '<div class="card-body" style="padding:0px!important">' +
                '<div class="container">' +

                '<div class="row">' +
                ' <div class="col-4">' +
                '<h6><span class="w-100 badge badge-primary">Cedula Juridica:</span></h6>' +
                '</div>' +
                '<div class="col-md-8" id="divInforma">' +
                '<p' + entidadPersonaJuridica[i].TC_ID_Cedula_Juridica + '<p />' +

                '</div>' +
                '</div>' +

                '<div class="row">' +
                '<div class="col-4">' +
                '<h6><span class="w-100 badge badge-primary">Nombre Organización:</span></h6>' +
                ' </div>' +
                '<div class="col-md-8" id="divInforma">' +
                '<p>' + entidadPersonaJuridica[i].TC_Nombre_Organización + '</p>' +
                '</div>' +
                '</div>' +

                '<div class="row">' +
                '<div class="col-4">' +
                '<h6><span class="w-100 badge badge-primary">Tipo Organización:</span></h6>' +
                ' </div>' +

                '<div class="col-md-8" id="divLugar">' +
                ' <p>' + entidadPersonaJuridica[i].TN_ID_Tipo_Organizacion + '</p>' +
                '</div>' +
                '</div>' +
                ' </div>' +
                ' </div>' +
                '</div>'

            );
        }
    });
}


/*Eliminar Persona Juridca*/

function eliminarPersonaJuridica(entidadPersonaJuridicaID) {
    $.ajax({
        type: "POST",
        url: "/E_PersonaJuridica/Eliminar_E_PersonaJuridicaPorID",
        data: { "entidadPersonaJuridicaID": entidadPersonaJuridicaID }
    }).done(function (data) {

    });
}

/*Editar*/

$(document).on("click", ".editarEntidadPersonaJuridica", function () {
    $.ajax({
        type: "GET",
        url: "/E_PersonaJuridica/Obtener_E_PersonaJuridicaPorID",
        data: { "ID": $(this).attr('ID') }
    }).done(function (data) {
        let entidadPersonaJuridica = new Array();
        entidadPersonaJuridica = JSON.parse(data);
        alert(JSON.stringify(data));
        $("#tituloEntidadPersonaJuridica").html("Modificar Persona Juridica");
        $("#divPersonaJuridicaID").show();
        $("#TN_ID_Persona_Juridica").val(entidadPersonaJuridica.TN_ID_Persona_Juridica);
        $("#TC_ID_Cedula_Juridica_PJ").val(entidadPersonaJuridica.TC_ID_Cedula_Juridica);
        $("#TC_Nombre_OrganizaciónPJuridca_P").val(entidadPersonaJuridica.TC_Nombre_Organización);
        $("#TC_Nombre_Comercial_PJ").val(entidadPersonaJuridica.TC_Nombre_Comercial);
        $("#TN_ID_Tipo_Organización").val(entidadPersonaJuridica.TN_ID_Tipo_Organizacion);
        $("#TC_Sitio_Web_PJ").val(entidadPersonaJuridica.TC_Sitio_Web);
        $("#TC_Comentario_PJ").val(entidadPersonaJuridica.TC_Comentario);
        $("#TC_Creado_Por_PJ").val(entidadPersonaJuridica.TC_Creado_Por);
        $("#fechaCreacion_Row_PJ").show();
        $("#TF_Fecha_Creacion_PJ").val(entidadPersonaJuridica.TF_Fecha_Creacion);
        iniciarCalendarioVehiculo(entidadPersonaJuridica.TF_Fecha_Creacion);
        $("#fechaModificación_Row_PJ").show();
        $("#modificadoPor_Row_PJ").show();
        $("TF_Fecha_Modificacion_Vehiculo").val(entidadPersonaJuridica.TF_Fecha_Modificacion);
        iniciarCalendarioVehiculo(entidadPersonaJuridica.TF_Fecha_Modificacion);
        $('#TB_Verificado_PJ').attr('checked', entidadPersonaJuridica.TB_Verificado);
        $("#btnInsertarEntidadPersonaJuridica").hide();
        $("#btnModificarEntidadPersonaJuridica").show();
        $("#entidadPersonaJuridicaModal").modal("show");
    });
});

$('#entidadPersonaJuridicaModal').on('hidden.bs.modal', function () {
    $("#FormEntidadPersonaJuridica")[0].reset();
    $("#tituloEntidadPersonaJuridica").html("Insertar Persona Juriridica");
    $("#fechaCreacion_Row_PJ").hide();
    $("#fechaModificación_Row_PJ").hide();
    $("#modificadoPor_Row_PJ").hide();
    $("#btnInsertarEntidadPersonaJuridica").show();
    $("#btnModificarEntidadPersonaJuridica").hide();
})








/*Cargar Persona Juridica Tipo Organizacion*/
function cargarTipoOrganizacion() {

    $(document).ready(function () {
        $.ajax({
            type: "GET",
            url: "/C_PersonaJuridicaTipoOrganizacion/ListarPersonaJuridicaTipoOrganizacion",
            data: "{}",
            success: function (data) {
                var s;
                for (var i = 0; i < data.length; i++) {
                    s += '<option value="' + TN_ID_Tipo_Organizacion + '">' + data[i].TC_Descripcion + '</option>';
                }
                $("#TN_ID_Tipo_Organizacion").html(s);
                $('#TN_ID_Tipo_Organizacion').selectpicker('refresh');
            }

        });
    });
}