$(document).ready(function () {
    cargarArmaMarca();
    cargarTipoArma();

});

//*Agregar Arma
$(document).on("click", "#btnAgregarEntidadArma", function (e) {
    e.preventDefault();
    if ($("#FormEntidadArma").valid()) {
        var form = new FormData($("#FormEntidadArma")[0]);
        form.append("TB_Verificado", $("#TB_Verificado_Arma").is(":checked"));
        $.ajax({
            type: "POST",
            url: "/E_Arma/Insertar_E_Arma",
            data: { "entidadArma": Object.fromEntries(form), "caso": sessionStorage.CasoID },
        }).done(function (data) {
            $("#entidadArmaModal").modal("hide");
            CargarEntidadArmas();
        });
    } else {
        alert("NO es valido");
    }
});

/*Cargar Armas*/
function CargarEntidadArmas() {
    $.ajax({
        type: "GET",
        url: "/E_Arma/Listar_E_Arma",
        data: { "caso": sessionStorage.CasoID }
    }).done(function (data) {
        let entidadArmas = new Array();
        entidadArmas = JSON.parse(data);
        alert(data);

        $("#entidades-body").empty();

        for (let i = 0; i < entidadArmas.length; i++) {

            $("#entidades-body").append(
                '<div class="card" id="cartaEntidadArma"' + entidadArmas[i].TN_ID_Arma + '>' +

                '<div class="card-header">' +
                '<div>Entidad Arma' + entidadArmas[i].TN_ID_Arma + '</div>' +
                ' <div>' +
                ' <a href="#" class="editarEntidadArma" id="' + entidadArmas[i].TN_ID_Arma + '"><span><i class="fa fa-pencil" aria-hidden="true"></i></span></a>' +
                '<a href="#" class="borrar borrarEntidadArma" id="' + entidadArmas[i].TN_ID_Arma + '"><span><i class="fa fa-trash" data-toggle="modal" data-target="#ModalMensaje" aria-hidden="true"></i></span></a>' +
                '</div>' +

                '</div>' +
                '<div class="card-body" style="padding:0px!important">' +
                '<div class="container">' +

                '<div class="row">' +
                '<div class="col-sm-6">' +
                '<h6><span class="w-100 badge badge-primary">Marca:</span></h6>' +
                '</div>' +
                '<div class="col-sm-6">' +
                '<p>' + entidadArmas[i].TC_Marca + '<p />' +

                '</div>' +
                '</div>' +

                '<div class="row">' +
                '<div class="col-sm-6">' +
                '<h6><span class="w-100 badge badge-primary">Tipo:</span></h6>' +
                '</div>' +
                '<div class="col-sm-6">' +
                '<p>' + entidadArmas[i].TC_Tipo + '</p>' +
                '</div>' +
                '</div>' +

                '<div class="row">' +
                '<div class="col-sm-6">' +
                '<h6><span class="w-100 badge badge-primary">Calibre:</span></h6>' +
                '</div>' +

                '<div class="col-sm-6">' +
                '<p>' + entidadArmas[i].TC_Calibre + '</p>' +
                ' </div>' +
                '</div>' +

                '</div>' +
                ' </div>' +
                ' </div>'
            );
        }
    });
}

/*Eliminar Arma*/

function eliminarArma(entidadArmaID) {
    $.ajax({
        type: "POST",
        url: "/E_Arma/Eliminar_E_ArmaPorID",
        data: { "entidadArmaID": entidadArmaID }
    }).done(function (data) {
        CargarEntidadArmas();
    });
}
/*Editar*/

$(document).on("click", ".editarEntidadArma", function () {
    $.ajax({
        type: "GET",
        url: "/E_Arma/Obtener_E_ArmaPorID",
        data: { "ID": $(this).attr('ID') }
    }).done(function (data) {
        let entidadArma = new Array();
        entidadArma = JSON.parse(data);
        alert(JSON.stringify(data));
        $("#tituloEntidadArma").html("Modificar Arma");
        $("#divArmaID").show();
        $("#TN_ID_Arma").val(entidadArma.TN_ID_Arma);
        $("#TC_Serie_Arma").val(entidadArma.TC_Serie);
        $('#TN_ID_Marca_Arma').selectpicker('val', entidadArma.TN_ID_Marca_Arma);
        $('#TN_ID_Marca_Arma').selectpicker('refresh');
        $('#TN_ID_Tipo_Arma').selectpicker('val', entidadArma.TN_ID_Tipo_Arma);
        $('#TN_ID_Tipo_Arma').selectpicker('refresh');
        $("#TC_Modelo_Arma").val(entidadArma.TC_Modelo_Arma);
        $("#TC_Calibre_Arma").val(entidadArma.TC_Calibre);
        $("#TC_Comentario_Arma").val(entidadArma.TC_Comentario);
        $("#divFCA").show();
        $("#TF_Fecha_Creacion_Arma").val(entidadArma.TF_Fecha_Creacion);
        $("#divFMA").show();
        $("#TF_Fecha_Modificacion_Arma").val(entidadArma.TF_Fecha_Modificacion);
        $("#TC_Creado_Por_Arma").val(entidadArma.TC_Creado_Por);
        $("#divMPA").show();
        $("#TC_Modificado_Por_Arma").val(entidadArma.TC_Modificado_Por);
        $('#TB_Verificado_Arma').attr('checked', entidadArma.TB_Verificado);
        $("#btnModificarEntidadArma").show();
        $("#btnAgregarEntidadArma").hide();
        $("#entidadArmaModal").modal("show");
    });
});

$('#entidadArmaModal').on('hidden.bs.modal', function () {
    $("#FormEntidadArma")[0].reset();
    $('#TN_ID_Tipo_Droga').selectpicker('refresh');
    $("#tituloEntidadArma").html("Insertar Arma");
    $("#divArmaMarcaID").hide();
    $("#divFCA").hide();
    $("#divFMA").hide();
    $("#divMPA").hide();
    $("#btnModificarEntidadArma").hide();
    $("#btnAgregarEntidadArma").show();
    $("label.error").hide();

})

//*Modificar Arma
$(document).on("click", "#btnModificarEntidadArma", function (e) {
    e.preventDefault();
    var form = new FormData($("#FormEntidadArma")[0]);
    form.append("TB_Verificado", $("#TB_Verificado_Arma").is(":checked"));
    $.ajax({
        type: "POST",
        url: "/E_Arma/Modificar_E_Arma",
        data: Object.fromEntries(form)
    }).done(function (data) {
        $("#entidadArmaModal").modal("hide");
        CargarEntidadArmas();
    });
});

///*-----------------------------------------------------

//*Cargar Arma Marca*
function cargarArmaMarca() {

        $.ajax({
            type: "GET",
            url: "/C_ArmaMarca/ListarArmaMarca",
        }).done(function (data) {
            let marcaArma = JSON.parse(data);
            $("#TN_ID_Marca_Arma").empty();
            var s;
            s = '<option value="" disabled selected>Seleccione una Marca </option>';
            for (var i = 0; i < marcaArma.length; i++) {
                s += '<option value="' + marcaArma[i].TN_ID_Marca_Arma + '">' + marcaArma[i].TC_Descripcion + '</option>';
  
            }
            $("#TN_ID_Marca_Arma").html(s);
                $('#TN_ID_Marca_Arma').selectpicker('refresh');

    });
}

//*Cargar Tipo Arma
function cargarTipoArma() {

        $.ajax({
            type: "GET",
            url: "/C_TipoArma/ListarTipoArma",
        }).done(function (data) {
            let tipoArma = JSON.parse(data);
            $("#TN_ID_Tipo_Arma").empty();
            var s;
            s = '<option value="" disabled selected>Seleccione un tipo </option>';
            for (var i = 0; i < tipoArma.length; i++) {
                s += '<option value="' + tipoArma[i].TN_ID_Tipo_Arma + '">' + tipoArma[i].TC_Descripcion + '</option>';
               
            }
            $("#TN_ID_Tipo_Arma").html(s);
            $('#TN_ID_Tipo_Arma').selectpicker('refresh');

        });
    
}
/*Insertar Arma Marca*/
$(document).on("click", "#btnAgregar_C_ArmaMarca", function (e) {
    e.preventDefault();
    if ($("#Form_C_ArmaMarca").valid()) {
        var form = new FormData($("#Form_C_ArmaMarca")[0]);
        $.ajax({
            type: "POST",
            url: "/C_ArmaMarca/InsertarArmaMarca",
            data: Object.fromEntries(form)
        }).done(function (data) {
            $("#modal_C_ArmaMarca").modal("hide");
            cargarArmaMarca();
        });
    } else {
        alert("NO es valido");
    }
});

/*Insertar Arma Tipo*/
$(document).on("click", "#btnAgregar_C_ArmaTipo", function (e) {
    e.preventDefault();
    if ($("#Form_C_ArmaTipo").valid()) {
        var form = new FormData($("#Form_C_ArmaTipo")[0]);
        $.ajax({
            type: "POST",
            url: "/C_TipoArma/ InsertarTipoArma",
            data: Object.fromEntries(form)
        }).done(function (data) {
            $("#modal_C_ArmaTipo").modal("hide");
            cargarTipoArma();
        });
    } else {
        alert("NO es valido");
    }
});