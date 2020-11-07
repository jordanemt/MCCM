$(document).on("click", "#entidadDroga", function () {

    CargarEntidadDrogas();
    cargarTipoDroga();
    iniciarCalendarioDroga(moment());
})

/*Fecha*/
function iniciarCalendarioDroga(fecha) {
    $('#TF_Fecha_Decomiso_Droga').daterangepicker({
        "singleDatePicker": true,
        "timePicker": true,
        "timePicker24Hour": true,
        "starDate": fecha,
        locale: {
            format: 'YYYY/M/DD HH:mm'
        }
    });
}
/* Agregar Droga*/
$(document).on("click", "#btnAgregarEntidadDroga", function (e) {
    e.preventDefault();
    if ($("#FormEntidadDroga").valid()) {

        var form = new FormData($("#FormEntidadDroga")[0]);
        form.append("TB_Verificado", $("#TB_Verificado_Droga").is(":checked"));
        $.ajax({
            type: "POST",
            url: "/E_Droga/Insertar_E_Droga",
            data: { "entidadDroga": Object.fromEntries(form), "caso": sessionStorage.CasoID },
            beforeSend: function () {
                $("#btnAgregarEntidadDroga").prop("disabled", true);
                $("#btnAgregarEntidadDroga").html(
                    '<span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span> Procesando...'
                );
            }
        }).done(function (data) {
            $("#btnAgregarEntidadDroga").removeAttr("disabled");
            $("#btnAgregarEntidadDroga").html('Insertar');
            $("#entidadDrogaModal").modal("hide");
            CargarEntidadDrogas();
        });
    }
});

/*Cargar Drogas*/
function CargarEntidadDrogas() {
    $.ajax({
        type: "GET",
        url: "/E_Droga/Listar_E_Droga",
        data: { "caso": sessionStorage.CasoID },
        beforeSend: function () {
            $("#entidades-body").empty();
            agregarSpinnerCargando($("#entidades-body"));
        }
    }).done(function (data) {
        let entidadDrogas = new Array();
        entidadDrogas = JSON.parse(data);

        $("#entidades-body").empty();
        for (let i = 0; i < entidadDrogas.length; i++) {


            $("#entidades-body").append(
                '<div class="card" id="cartaEntidadDroga"' + entidadDrogas[i].TN_ID_Droga + '>' +
                '<div class="card-header gris_claro">' +
                ' Droga Código #' + entidadDrogas[i].TN_ID_Droga +
                '<div>' +
                '<a href="#" class="editarEntidadDroga" id="' + entidadDrogas[i].TN_ID_Droga + '"><span><i class="fa fa-pencil icono" aria-hidden="true"></i></span></a>' +
                '<a href="#" class="borrar borrarEntidadDroga" id="' + entidadDrogas[i].TN_ID_Droga + '"><span><i class="fa fa-trash icono" data-toggle="modal" data-target="#ModalMensaje" aria-hidden="true"></i></span></a>' +
                '</div>' +
                '</div>' +
                '<div class="card-body" style="padding:0px!important">' +
                '<div class="container">' +
                '<div class="row">' +
                '<div class="col-4">' +
                '<span class="w-100 badge badge-primary">Nombre:</span>' +
                '</div>' +
                '<div class="col-md-8">' +
                '<p>' + entidadDrogas[i].TC_Nombre + '<p>' +
                '</div>' +
                '</div>' +
                '<div class="row">' +
                '<div class="col-4">' +
                '<span class="w-100 badge badge-primary">Cantidad:</span>' +
                '</div>' +
                '<div class="col-md-8">' +
                '<p>' + entidadDrogas[i].TN_Cantidad + '</p>' +
                '</div>' +
                ' </div>' +
                '</div>' +
                '</div>' +
                '</div>'
            );
        }
    });
}

/*Eliminar Droga*/

function eliminarDroga(entidadDrogaID) {
    $.ajax({
        type: "POST",
        url: "/E_Droga/Eliminar_E_DrogaPorID",
        data: { "entidadDrogaID": entidadDrogaID }
    }).done(function (data) {
        elemento.parent().parent().parent().remove();

    });
}


/*Editar*/

$(document).on("click", ".editarEntidadDroga", function () {
    $.ajax({
        type: "GET",
        url: "/E_Droga/Obtener_E_DrogaPorID",
        data: { "ID": $(this).attr('ID') }
    }).done(function (data) {
        let entidadDroga = new Array();
        entidadDroga = JSON.parse(data);
        $("#tituloEntidadDroga").html("Modificar Droga");
        $("#divDrogaID").show();
        $("#TN_ID_Droga").val(entidadDroga.TN_ID_Droga);
        $('#TN_ID_Tipo_Droga').selectpicker('val', entidadDroga.TN_ID_Tipo_Droga);
        $('#TN_ID_Tipo_Droga').selectpicker('refresh');
        $("#TC_Nombre_Droga").val(entidadDroga.TC_Nombre);
        $("#TC_Detalle_Droga").val(entidadDroga.TC_Detalle);
        $("#TN_Cantidad_Droga").val(entidadDroga.TN_Cantidad);
        $("#TF_Fecha_Decomiso_Droga").val(entidadDroga.TF_Fecha_Decomiso);
        iniciarCalendarioDroga(entidadDroga.TF_Fecha_Decomiso);
        $("#divDrogaFC").show();
        $("#TF_Fecha_Creacion_Droga").val(entidadDroga.TF_Fecha_Creacion);
        $("#divDrogaFM").show();
        $("#TF_Fecha_Modificacion_Droga").val(entidadDroga.TF_Fecha_Modificacion);
        $("#divDrogaMP").show();
        $("#TC_Modificado_Por_Droga").val(entidadDroga.TC_Modificado_Por);
        $("#TC_Creado_Por_Droga").val(entidadDroga.TC_Creado_Por);
        $('#TB_Verificado_Droga').attr('checked', entidadDroga.TB_Verificado);
        $("#btnModificarEntidadDroga").show();
        $("#btnAgregarEntidadDroga").hide();
        $("#entidadDrogaModal").modal("show");
    });
});

$('#entidadDrogaModal').on('hidden.bs.modal', function () {
    $("#FormEntidadDroga")[0].reset();
    $('#TN_ID_Tipo_Droga').selectpicker('refresh');
    $("#tituloEntidadDroga").html("Insertar Droga");
    $("#divDrogaFC").hide();
    $("#divDrogaFM").hide();
    $("#divDrogaMP").hide();
    $('#TB_Verificado_Droga').attr('checked', false);
    $("#btnModificarEntidadDroga").hide();
    $("#btnAgregarEntidadDroga").show();
    $("label.error").hide();

})

//*Modificar Droga
$(document).on("click", "#btnModificarEntidadDroga", function (e) {
    e.preventDefault();
    if ($("#FormEntidadDroga").valid()) {
        var form = new FormData($("#FormEntidadDroga")[0]);
        form.append("TB_Verificado", $("#TB_Verificado_Droga").is(":checked"));
        $.ajax({
            type: "POST",
            url: "/E_Droga/Modificar_E_Droga",
            data: Object.fromEntries(form),
            beforeSend: function () {
                $("#btnModificarEntidadDroga").prop("disabled", true);
                $("#btnModificarEntidadDroga").html(
                    '<span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span> Procesando...'
                );
            }
        }).done(function (data) {
            $("#btnModificarEntidadDroga").removeAttr("disabled");
            $("#btnModificarEntidadDroga").html('Modificar');
            $("#entidadDrogaModal").modal("hide");
            CargarEntidadDrogas();
        });
    }
});


/*Carga de catálogo tipo droga*/
function cargarTipoDroga() {

    $.ajax({
        type: "GET",
        url: "/C_TipoDroga/ListarTipoDroga"
    }).done(function (data) {
        let tipoDroga = JSON.parse(data);
        $("#TN_ID_Tipo_Droga").empty();
        var s;
        for (var i = 0; i < tipoDroga.length; i++) {
            s += '<option value="' + tipoDroga[i].TN_ID_Tipo_Droga + '">' + tipoDroga[i].TC_Nombre + '</option>';
        }

        $("#TN_ID_Tipo_Droga").html(s);
        $('#TN_ID_Tipo_Droga').selectpicker('refresh');


    });
}

/*Insertar Tipo Droga*/
$(document).on("click", "#btnAgregar_C_Droga", function (e) {
    e.preventDefault();
    if ($("#Form_C_Droga").valid()) {
        var form = new FormData($("#Form_C_Droga")[0]);
        $.ajax({
            type: "POST",
            url: "/C_TipoDroga/InsertarTipoDroga",
            data: Object.fromEntries(form),
            beforeSend: function () {
                $("#btnAgregar_C_Droga").prop("disabled", true);
                $("#btnAgregar_C_Droga").html(
                    '<span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span> Procesando...'
                );
            }
        }).done(function (data) {
            $("#btnAgregar_C_Droga").removeAttr("disabled");
            $("#btnAgregar_C_Droga").html('Insertar');
            $("#modal_C_Droga").modal("hide");
            cargarTipoDroga();
            $("#Form_C_Droga")[0].reset();
        });
    }
});

