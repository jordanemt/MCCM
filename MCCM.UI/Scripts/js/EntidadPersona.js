
$("#FormEntidadPersona").submit(function (e) {
    e.preventDefault();
    var form = new FormData($("#FormEntidadPersona")[0]);
    let url;
    
    AccionesEntidadPersonaForm(form,url);

});

function AccionesEntidadPersonaForm(form, url) {
    //alert(JSON.stringify(Object.fromEntries(form)));
    $.ajax({
        type: "POST",
        url: "/E_Persona/Insertar_E_Persona",
        data: form,
        contentType: false,
        cache: false,
        processData: false,
    }).done(function (data) {
        alert(data);
        $("#entidadPersonaModal").modal("hide");

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

$(document).on("click",".editarEntidadPersona", function () {
    $("#tituloEntidadPersonaInsertar").hide();
    $("#tituloEntidadPersona").show();
    $("#TC_Nombre").val("Juanito");
    $("#TC_Primer_Apellido").val("Gonzales");
    $("#TC_Segundo_Apellido").val("Mata");
    $("#TF_Fecha_Nacimiento").val("10/09/1986 5:00PM");
    $("#TN_ID_Tipo_Identificacion").val("Desconocido");
    $("#TC_Cedula").val("1-2345-6789");
    $("#TN_Edad").val("34");
    $("#TN_ID_Icono_Persona").val("1");
    $("#TN_ID_Sexo").val("Desconocido");
    $("#TN_ID_Genero").val("Indefinido");
    $("#TN_ID_Nacionalidad").val("Costa Rica");
    $("#TB_Fallecido").val("On");
    $("#TN_Autopsia").val("En proceso");
    $("#TB_Exp_Criminal").val("Of");
    $("#TC_Alias").val("Forest");
    $("#fechaCreacion_Row_P").show();
    $("#TC_Creado_Por_P").val("Valeria");
    $("#TF_Fecha_Creacion_P").val("10/09/2020 5:00PM");
    $("#fechaModificación_Row_P").show();
    $("#modificadoPor_Row_P").show();
    $("#verificado").show();
    $("#btnInsertarEntidadPersona").hide();
    $("#btnCancelarEntidadPersona").hide();
    $("#btnModificarEntidadPersona").show();
    $("#btnEliminarEntidadPersona").show();
    $("#entidadPersonaModal").modal("show");
});


$('#entidadPersonaModal').on('hidden.bs.modal', function () {
    $("#FormEntidadPersona")[0].reset();
    $("#fechaCreacion_Row_P").hide();
    $("#fechaModificación_Row_P").hide();
    $("#modificadoPor_Row_P").hide();
    $("#btnInsertarEntidadPersona").show();
    $("#btnCancelarEntidadPersona").show();
    $("#btnModificarEntidadPersona").hide();
    $("#btnEliminarEntidadPersona").hide();
})