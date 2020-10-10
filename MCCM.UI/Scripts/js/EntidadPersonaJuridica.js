$("#FormEntidadPersonaJuridica").submit(function (e) {
    e.preventDefault();
    var form = new FormData($("#FormEntidadPersonaJuridica")[0]);
    let url;

    AccionesEntidadPersonaJuridicaForm(form, url);

});

function AccionesEntidadPersonaJuridicaForm(form, url) {
    //alert(JSON.stringify(Object.fromEntries(form)));
    $.ajax({
        type: "POST",
        url: "/E_PersonaJuridica/Insertar_E_PersonaJuridica",
        data: form,
        contentType: false,
        cache: false,
        processData: false,
    }).done(function (data) {
        alert(data);
        $("#entidadPersonaJuridicaModal").modal("hide");

    });
}

/*function limpiarFormularioCaso() {
    $("#TN_ID_Caso").val("");
    $("#TN_ECU").val("");
    $("#TC_Nombre_Caso").val("");
    $("#TC_Enfoque_Trabajo").val("");
    $("#TC_Area_Trabajo").val("");
    $("#TN_Nivel").val("");
    $("#TC_Descripcion").val("");
    $("#TC_Fuente").val("");
    $("#TC_Delito").val("");
}
*/


$(document).ready(function () {

    $('#TF_Fecha_Nacimiento').daterangepicker({
        "singleDatePicker": true,
        "startDate": "09/29/2020",
        "endDate": "10/05/2020"
    }, function (start, end, label) {
        console.log('New date range selected: ' + start.format('YYYY-MM-DD') + ' to ' + end.format('YYYY-MM-DD') + ' (predefined range: ' + label + ')');
    });

})

$(document).on("click", ".editarEntidadPersonaJuridica", function () {
    $("#tituloEntidadPersonaJuridica").hide();
    $("#modificarEntidadPersonaJuridica").show();
    $("#TN_ID_Cedula_Juridica").val("0-0000-0000");
    $("#TC_Nombre_Organización").val("egit Habntem mundum");
    $("#TC_Nombre_Comercial").val("Mata Y Flores");
    $("#TN_ID_Tipo_Organización").val("Sociedad Anónima");
    $("#TC_Sitio_Web").val("www.matayflores.com");
    $("#TC_Comentario_PJ").val("Es ficticia");
    $("#fechaCreacion_Row_PJ").show();
    $("#TC_Creado_Por_PJ").val("Valeria");
    $("#TF_Fecha_Creacion_PJ").val("10/09/2020 5:00PM");
    $("#fechaModificación_Row_PJ").show();
    $("#modificadoPor_Row_PJ").show();
    $("#verificado_PJ").show();
    $("#btnInsertarEntidadPersonaJuridica").hide();
    $("#btnCancelarEntidadPersonaJuridica").hide();
    $("#btnModificarEntidadPersonaJuridica").show();
    $("#btnEliminarPersonaJuridica").show();
    $("#entidadPersonaJuridicaModal").modal("show");
});


$('#entidadPersonaJuridicaModal').on('hidden.bs.modal', function () {
    $("#FormEntidadPersonaJuridica")[0].reset();
    $("#fechaCreacion_Row_PJ").hide();
    $("#fechaModificación_Row_PJ").hide();
    $("#modificadoPor_Row_PJ").hide();
})