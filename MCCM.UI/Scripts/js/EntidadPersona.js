$(document).on("click", "#entidadPersona", function () {

    CargarEntidadPersona();
    cargarTipoIdentificacion();
    cargarPersonaSexo();
    cargarPersonaGenero();
    cargarPersonaNacionalidad();
    iniciarCalendarioPersona(moment());
})


/*Fecha*/
function iniciarCalendarioPersona(fecha) {
    $('#TF_Fecha_Nacimiento_Persona').daterangepicker({
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
        form.append("TB_Verificado", $("#TB_Verificado_P").is(":checked"));
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


/*Eliminar Persona*/

function eliminarPersona(entidadPersonaID) {
    $.ajax({
        type: "POST",
        url: "/E_Persona/Eliminar_E_PersonaPorID",
        data: { "entidadPersonaID": entidadPersonaID }
    }).done(function (data) {

    });
}


/*Editar Persona*/

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
        $("#TB_Fotografia_Persona").val(entidadPersona.TB_Fotografia);
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
        $("#fechaModificación_Row_P").show();
        $("TF_Fecha_Modificacion_P").val(entidadPersona.TF_Fecha_Modificacion);
        $("#modificadoPor_Row_P").show();
        $("#TC_Modificado_Por_P").val(entidadPersona.TC_Modificado_Por);
        $('#TB_Verificado_P').attr('checked', entidadPersona.TB_Verificado);
        $("#btnInsertarEntidadPersona").hide();
        $("#btnModificarEntidadPersona").show();
        $("#entidadPersonaModal").modal("show");
    });
});

$('#entidadPersonaModal').on('hidden.bs.modal', function () {
    $("#FormEntidadPersona")[0].reset();
    $("#tituloEntidadPersona").html("Insertar Persona");
    $("#divPersonaID").hide();
    $("#fechaCreacion_Row_P").hide();
    $("#fechaModificación_Row_P").hide();
    $("#modificadoPor_Row_P").hide();
    $("#btnInsertarEntidadPersona").show();
    $("#btnModificarEntidadPersona").hide();
    $('#TN_ID_Tipo_Identificacion_Persona').selectpicker('refresh');
    $('#TN_ID_Sexo_Persona').selectpicker('refresh');
    $('#TN_ID_Genero_Persona').selectpicker('refresh');
    $('#TN_ID_Nacionalidad_Persona').selectpicker('refresh');
    $("label.error").hide();
})





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
                '<img src="' + entidadPersona[i].TC_Imagen + '" class="img-fluid">' +
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
                '<p>' + entidadPersona[i].TC_Nacionalidad + '</p>' +
                '</div>' +
                '</div>' +
                '<div class="row">' +
                '<div class="col-4">' +
                '<h6><span class="w-100 badge badge-primary">Genero:</span></h6>' +
                '</div>' +
                '<div class="col-md-8" id="divNovedad">' +
                '<p>' + entidadPersona[i].TC_Genero + '</p>' +
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

/*/Modificar Entidad persona*/
$(document).on("click", "#btnModificarEntidadPersona", function (e) {
    e.preventDefault();
    $("#TN_ID_Caso_P").val(sessionStorage.CasoID);
    var form = new FormData($("#FormEntidadPersona")[0]);
    form.append("TB_Verificado", $("#TB_Verificado_P").is(":checked"));
    alert(JSON.stringify(Object.fromEntries(form)));
    $.ajax({
        type: "POST",
        url: "/E_Persona/Modificar_E_Persona",
        data: form,
        contentType: false,
        cache: false,
        processData: false,
    }).done(function (data) {
        $("#entidadPersonaModal").modal("hide");
        CargarEntidadPersona();
    });
});


/*Cargar Tipo Identificación*/
function cargarTipoIdentificacion() {

    $.ajax({
        type: "GET",
        url: "/C_PersonaTipoIdentificacion/ListarPersonaTipoIdentificacion",
    }).done(function (data) {
        let tipo = JSON.parse(data);
        $("#TN_ID_Tipo_Identificacion_Persona").empty();
        var s;
        for (var i = 0; i < tipo.length; i++) {
            s += '<option value="' + tipo[i].TN_ID_Tipo_Identificacion + '">' + tipo[i].TC_Descripcion + '</option>';
        }
        $("#TN_ID_Tipo_Identificacion_Persona").html(s);
        $('#TN_ID_Tipo_Identificacion_Persona').selectpicker('refresh');

    });
}

/*Cargar Persona Sexo*/
function cargarPersonaSexo() {

    $.ajax({
        type: "GET",
        url: "/C_PersonaSexo/ListarPersonaSexo",
    }).done(function (data) {
        let sexo = JSON.parse(data);
        $("#TN_ID_Sexo_Persona").empty();
        var s;
        for (var i = 0; i < sexo.length; i++) {
            s += '<option value="' + sexo[i].TN_ID_Sexo + '">' + sexo[i].TC_Descripcion + '</option>';
        }
        $("#TN_ID_Sexo_Persona").html(s);
        $('#TN_ID_Sexo_Persona').selectpicker('refresh');
    });

}

/*Cargar Persona Genero*/
function cargarPersonaGenero() {

    $.ajax({
        type: "GET",
        url: "/C_PersonaGenero/ListarPersonaGenero",
    }).done(function (data) {
        let genero = JSON.parse(data);
        $("#TN_ID_Genero_Persona").empty();
        var s;
        for (var i = 0; i < genero.length; i++) {
            s += '<option value="' + genero[i].TN_ID_Genero + '">' + genero[i].TC_Descripcion + '</option>';
        }
        $("#TN_ID_Genero_Persona").html(s);
        $('#TN_ID_Genero_Persona').selectpicker('refresh');
    });
}

/*Cargar Persona Nacionalidad*/
function cargarPersonaNacionalidad() {
    $.ajax({
        type: "GET",
        url: "/C_PersonaNacionalidad/ListarPersonaNacionalidad",
    }).done(function (data) {
        let nacionalidad = JSON.parse(data);
        $("#TN_ID_Nacionalidad_Persona").empty();
        var s;
        for (var i = 0; i < nacionalidad.length; i++) {
            s += '<option value="' + nacionalidad[i].TN_ID_Nacionalidad + '">' + nacionalidad[i].TC_Descripcion + '</option>';
        }
        $("#TN_ID_Nacionalidad_Persona").html(s);
        $('#TN_ID_Nacionalidad_Persona').selectpicker('refresh');
    });
}


/*Insertar Tipo Identificacion*/
$(document).on("click", "#btnAgregar_C_PersonaTipoIdentificacion", function (e) {
    e.preventDefault();
    if ($("#Form_C_PersonaTipoIdentificacion").valid()) {
        var form = new FormData($("#Form_C_PersonaTipoIdentificacion")[0]);
        $.ajax({
            type: "POST",
            url: "/C_PersonaTipoIdentificacion/InsertarPersonaTipoIdentificacion",
            data: Object.fromEntries(form)
        }).done(function (data) {
            $("#modal_C_PersonaTipoIdentificacion").modal("hide");
            cargarTipoIdentificacion();
        });
    } else {
        alert("NO es valido");
    }
});

/*Insertar Genero*/
$(document).on("click", "#btnAgregar_C_PersonaGenero", function (e) {
    e.preventDefault();
    if ($("#Form_C_PersonaGenero").valid()) {
        var form = new FormData($("#Form_C_PersonaGenero")[0]);
        $.ajax({
            type: "POST",
            url: "/C_PersonaGenero/InsertarPersonaGenero",
            data: Object.fromEntries(form)
        }).done(function (data) {
            $("#modal_C_PersonaGenero").modal("hide");
            cargarPersonaGenero();
        });
    } else {
        alert("NO es valido");
    }
});

/*Insertar Nacionalidad*/
$(document).on("click", "#btnAgregar_C_PersonaNacionalidad", function (e) {
    e.preventDefault();
    if ($("#Form_C_PersonaNacionalidad").valid()) {
        var form = new FormData($("#Form_C_PersonaNacionalidad")[0]);
        $.ajax({
            type: "POST",
            url: "/C_PersonaNacionalidad/InsertarPersonaNacionalidad",
            data: Object.fromEntries(form)
        }).done(function (data) {
            $("#modal_C_PersonaNacionalidad").modal("hide");
            cargarPersonaNacionalidad();
        });
    } else {
        alert("NO es valido");
    }
});
/*Insertar Sexo*/
$(document).on("click", "#btnAgregar_C_PersonaSexo", function (e) {
    e.preventDefault();
    if ($("#Form_C_PersonaSexo").valid()) {
        var form = new FormData($("#Form_C_PersonaSexo")[0]);
        $.ajax({
            type: "POST",
            url: "/C_PersonaSexo/InsertarPersonaSexo",
            data: Object.fromEntries(form)
        }).done(function (data) {
            $("#modal_C_PersonaSexo").modal("hide");
            cargarPersonaSexo();
        });
    } else {
        alert("NO es valido");
    }
});