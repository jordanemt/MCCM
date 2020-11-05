$(document).ready(function () {
    cargarTipoOrganizacion();
    validarFormularioEntidadPersonaJuridica();
});


/*Descripción: Metodo que valida el formulario usando la libreria de js*/
function validarFormularioEntidadPersonaJuridica() {
    $("#FormEntidadPersonaJuridica").validate({
        rules: {
            TC_ID_Cedula_Juridica_PJ: {required: true},
            TC_Nombre_OrganizaciónPJuridca_PJ: { required: true },
            TC_Nombre_Comercial_PJ: { required: true },
            TN_ID_Tipo_Organizacion: { required: true },
            TC_Sitio_Web_PJ: { required: true },
            TC_Comentario_PJ: { required: true },
        },
        submitHandler: function (form) {
            return false;
        }
    });

    $("#FormTipoOrganizacion").validate({
        rules: {
            TC_Descripcion: { required: true }
        },
        submitHandler: function (form) {
            return false;
        }
    });


}


$(document).on("click", "#btnRegistrarTipoOrganizacion", function (e) {
    e.preventDefault();
    if ($("#FormTipoOrganizacion").valid()) {
        let form = new FormData($("#FormTipoOrganizacion")[0]);
        $.ajax({
            type: "POST",
            url: "/C_PersonaJuridicaTipoOrganizacion/InsertarPersonaJuridicaTipoOrganizacion",
            data: Object.fromEntries(form),
        }).done(function (data) {
            cargarTipoOrganizacion();
            $("#tipoOrganizacionModal").modal("hide");
        });
    }
});


/* Agregar Persona Juridica*/

$(document).on("click", "#btnInsertarEntidadPersonaJuridica", function (e) {
    e.preventDefault();
    if ($("#FormEntidadPersonaJuridica").valid()) {
        $("#TN_ID_Caso_PJ").val(sessionStorage.CasoID);
        let form = new FormData($("#FormEntidadPersonaJuridica")[0]);
        form.append("TB_Verificado", $("#TB_Verificado_PJ").is(":checked"));
        form.append("TF_Fecha_Creacion", moment().format('YYYY-MM-DD HH:mm:00'));
        form.append("TN_ID_Caso", sessionStorage.CasoID);

        $.ajax({
            type: "POST",
            url: "/E_PersonaJuridica/Insertar_E_PersonaJuridica",
            data: Object.fromEntries(form),
            beforeSend: function () {
                $("#btnInsertarEntidadPersonaJuridica").prop("disabled", true);
                $("#btnInsertarEntidadPersonaJuridica").html(
                    '<span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span> Procesando...'
                );
            }
        }).done(function (data) {
            $("#btnInsertarEntidadPersonaJuridica").removeAttr("disabled");
            $("#btnInsertarEntidadPersonaJuridica").html('Insertar');
            CargarEntidadPersonaJuridica();
            $("#entidadPersonaJuridicaModal").modal("hide");
            
        });
    } 
});


// Modificar Entidad Persona Juridica
$(document).on("click", "#btnModificarEntidadPersonaJuridica", function (e) {
    e.preventDefault();
    if ($("#FormEntidadPersonaJuridica").valid()) {
        let form = new FormData($("#FormEntidadPersonaJuridica")[0]);
        form.append("TB_Verificado", $("#TB_Verificado_PJ").is(":checked"));
        form.append("TF_Fecha_Creacion", $("#TF_Fecha_Creacion_PJ").val());
        form.append("TF_Fecha_Modificacion", moment().format('YYYY-MM-DD HH:mm:00'));

        $.ajax({
            type: "POST",
            url: "/E_PersonaJuridica/Modificar_E_PersonaJuridica",
            data: Object.fromEntries(form),
            beforeSend: function () {
                $("#btnModificarEntidadPersonaJuridica").prop("disabled", true);
                $("#btnModificarEntidadPersonaJuridica").html(
                    '<span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span> Procesando...'
                );
            }
        }).done(function (data) {
            $("#btnModificarEntidadPersonaJuridica").removeAttr("disabled");
            $("#btnModificarEntidadPersonaJuridica").html('Modificar');
            $("#entidadPersonaJuridicaModal").modal("hide");
            CargarEntidadPersonaJuridica();
        });
    }
});

/*Cargar Vehiculos*/
function CargarEntidadPersonaJuridica() {
    $.ajax({
        type: "GET",
        url: "/E_PersonaJuridica/Listar_E_PersonaJuridica",
        data: { "caso": sessionStorage.CasoID }
    }).done(function (data) {
        let entidadPersonaJuridica = JSON.parse(data);
        $("#entidades-body").empty();
        for (let i = 0; i < entidadPersonaJuridica.length; i++) {

            $("#entidades-body").append(
                ' <div class="card">' +

                '<div class="card-header gris_claro">' +
                'Persona Jurídica Código #' + entidadPersonaJuridica[i].TN_ID_Persona_Juridica +
                '<div>' +
                '<a href="#" class="editarEntidadPersonaJuridica" id="' + entidadPersonaJuridica[i].TN_ID_Persona_Juridica + '"><span><i class="fa fa-pencil icono font_amarilloHover" aria-hidden="true"></i></span ></a > ' +
                '<a href="#" class="borrar borrarPersonaJuridica" id="' + entidadPersonaJuridica[i].TN_ID_Persona_Juridica + '"><span><i class="fa fa-trash icono font_amarilloHover" data-toggle="modal" data-target="#ModalMensaje" aria-hidden="true"></i></span ></a > ' +
                '</div>' +
                '</div>' +
                    '<div class="card-body" style="padding:0px!important">' +
                        '<div class="container">' +
                            '<div class="row">' +
                                ' <div class="col-5">' +
                                    '<h6><span class="w-100 badge badge-primary">Cedula Juridica:</span></h6>' +
                                '</div>' +
                                '<div class="col-md-7" >' +
                                    '<p>' + entidadPersonaJuridica[i].TC_ID_Cedula_Juridica + '<p />' +
                                '</div>' +
                            '</div>' +
                            '<div class="row">' +
                                '<div class="col-5">' +
                                    '<h6><span class="w-100 badge badge-primary">Nombre Organización:</span></h6>' +
                                ' </div>' +
                                '<div class="col-md-7" >' +
                                    '<p>' + entidadPersonaJuridica[i].TC_Nombre_Organización + '</p>' +
                                '</div>' +
                            '</div>' +
                            '<div class="row">' +
                                '<div class="col-5">' +
                                    '<h6><span class="w-100 badge badge-primary">Tipo Organización:</span></h6>' +
                                ' </div>' +
                                '<div class="col-md-7">' +
                                    ' <p>' + entidadPersonaJuridica[i].TC_Tipo_Organizacion + '</p>' +
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

function eliminarPersonaJuridica(entidadPersonaJuridicaID, elemento) {
    $.ajax({
        type: "POST",
        url: "/E_PersonaJuridica/Eliminar_E_PersonaJuridicaPorID",
        data: { "entidadPersonaJuridicaID": entidadPersonaJuridicaID }
    }).done(function (data) {
        elemento.parent().parent().parent().remove();
    });
}

/*Editar*/

$(document).on("click", ".editarEntidadPersonaJuridica", function () {
    $.ajax({
        type: "GET",
        url: "/E_PersonaJuridica/Obtener_E_PersonaJuridicaPorID",
        data: { "ID": $(this).attr('ID') }
    }).done(function (data) {
        let entidadPersonaJuridica = JSON.parse(data);
        $("#tituloEntidadPersonaJuridica").html("Modificar Persona Juridica");
        $("#divPersonaJuridicaID").show();
        $("#TN_ID_Persona_Juridica").val(entidadPersonaJuridica.TN_ID_Persona_Juridica);
        $("#TC_ID_Cedula_Juridica_PJ").val(entidadPersonaJuridica.TC_ID_Cedula_Juridica);
        $("#TC_Nombre_OrganizaciónPJuridca_PJ").val(entidadPersonaJuridica.TC_Nombre_Organización);
        $("#TC_Nombre_Comercial_PJ").val(entidadPersonaJuridica.TC_Nombre_Comercial);
        $("#TN_ID_Tipo_Organizacion").val(entidadPersonaJuridica.TN_ID_Tipo_Organizacion).selectpicker("refresh");
        $("#TC_Sitio_Web_PJ").val(entidadPersonaJuridica.TC_Sitio_Web);
        $("#TC_Comentario_PJ").val(entidadPersonaJuridica.TC_Comentario);
        $("#TC_Creado_Por_PJ").val(entidadPersonaJuridica.TC_Creado_Por);
        $("#TC_Modificado_Por_PJ").val(entidadPersonaJuridica.TC_Modificado_Por);
        $("#fechaCreacion_Row_PJ").show();
        $("#TF_Fecha_Creacion_PJ").val(entidadPersonaJuridica.TF_Fecha_Creacion);
        $("#fechaModificación_Row_PJ").show();
        $("#modificadoPor_Row_PJ").show();
        $("#TF_Fecha_Modificacion_PJ").val(entidadPersonaJuridica.TF_Fecha_Modificacion);
        $('#TB_Verificado_PJ').attr('checked', entidadPersonaJuridica.TB_Verificado);
        $("#btnInsertarEntidadPersonaJuridica").hide();
        $("#btnModificarEntidadPersonaJuridica").show();
        $("#entidadPersonaJuridicaModal").modal().show();
    });
});

$('#entidadPersonaJuridicaModal').on('hidden.bs.modal', function () {
    $("#FormEntidadPersonaJuridica")[0].reset();
    $("#tituloEntidadPersonaJuridica").html("Insertar Persona Juriridica");
    $("#fechaCreacion_Row_PJ").hide();
    $("#fechaModificación_Row_PJ").hide();
    $("#modificadoPor_Row_PJ").hide();
    $('#TB_Verificado_PJ').attr('checked', false);
    $("#TN_ID_Tipo_Organizacion").selectpicker("refresh");
    $("#btnInsertarEntidadPersonaJuridica").show();
    $("#btnModificarEntidadPersonaJuridica").hide();
    $("#divPersonaJuridicaID").hide();
    $("label.error").hide();
})








/*Cargar Persona Juridica Tipo Organizacion*/
function cargarTipoOrganizacion() {

    $(document).ready(function () {
        $.ajax({
            type: "GET",
            url: "/C_PersonaJuridicaTipoOrganizacion/ListarPersonaJuridicaTipoOrganizacion",
            data: "{}",
            success: function (data) {
                let tipos = JSON.parse(data);
                var s;
                for (var i = 0; i < tipos.length; i++) {
                    s += '<option value="' + tipos[i].TN_ID_Tipo_Organizacion + '">' + tipos[i].TC_Descripcion + '</option>';
                }
                $("#TN_ID_Tipo_Organizacion").html(s);
                $('#TN_ID_Tipo_Organizacion').selectpicker('refresh');
            }

        });
    });
}