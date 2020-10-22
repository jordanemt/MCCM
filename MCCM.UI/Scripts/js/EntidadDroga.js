$(document).ready(function () {
    cargarTipoDroga();
    iniciarCalendarioDroga(moment());
});

/*Fecha*/
function iniciarCalendarioDroga(fecha) {
    $('#TF_Fecha_Decomiso').daterangepicker({
        "singleDatePicker": true,
        "timePicker": true,
        "timePicker24Hour": true,
        "starDate": fecha,
        locale: {
            format: 'YYYY/M/DD HH:mm'
        }
    });
}

$(document).on("click", ".editarEntidadDroga", function () {
    $("#tituloEntidadDrogaInsertar").hide();
    $("#tituloEntidadDroga").show();
    $("#eventoIDI").val("1");
    $("#TC_Nombre_Droga").val("Marihuana");
    $("#TC_Detalle").val("Decomiso de gran cantidad de marihuana en Turrialba");
    $("#TN_Cantidad").val("500000");
    $("#TF_Fecha_Decomiso").val("10/09/2020 5:00PM");
    iniciarCalendarioDroga("10/09/2020 5:00PM");
    $("#divDrogaFC").show();
    $("#TF_Fecha_Creacion_Droga").val("10/09/2020 5:00PM");
    $("#TC_Creado_Por_Droga").val("Maikel Matamoros Zúñiga"); 
    $("#divDrogaMP").show();
    $("#TF_Modificado_Por_Droga").val("");
    $('#TB_Verificado_Droga').attr('checked', false);
    $("#btnModificarEntidadDroga").show();
    $("#btnEliminarEntidadDroga").show();
    $("#btnCancelarEntidadDroga").hide(); 
    $("#btnAgregarEntidadDroga").hide(); 
    $("#entidadDrogaModal").modal("show");

});
$('#entidadDrogaModal').on('hidden.bs.modal', function () {
    $("#FormEntidadDroga")[0].reset();
    $("#tituloEntidadDrogaInsertar").show();
    $("#tituloEntidadDroga").hide();
    $("#divDrogaFC").hide();
    $("#divDrogaMP").hide();
    $("#btnModificarEntidadDroga").hide();
    $("#btnEliminarEntidadDroga").hide();
    $("#btnCancelarEntidadDroga").show();
    $("#btnAgregarEntidadDroga").show(); 

})

/* Agregar Droga*/
$(document).on("click", "#btnAgregarEntidadDroga", function (e) {
    e.preventDefault();
    var form = new FormData($("#FormEntidadDroga")[0]);
    alert(JSON.stringify(Object.fromEntries(form)));
    $.ajax({
        type: "POST",
        url: "/E_Droga/Insertar_E_Droga",
        data: { "entidadDroga": Object.fromEntries(form), "caso": sessionStorage.CasoID },
    }).done(function (data) {
        $("#entidadDrogaModal").modal("hide");
        CargarEntidadDrogas();
        alert("Droga Insertada");
    });
});

/*Cargar Drogas*/
function CargarEntidadDrogas() {
    $.ajax({
        type: "GET",
        url: "/E_Droga/Listar_E_Droga",
        data: { "caso": sessionStorage.CasoID }
    }).done(function (data) {
        let entidadDrogas = new Array();
        entidadDrogas = JSON.parse(data);

        $("#entidades-body").empty();
        for (let i = 0; i < entidadDrogas.length; i++) {

            $("#entidades-body").append(
                '<div class="card" id="cartaEntidadDroga"' + entidadDrogas[i].TN_ID_Droga + '" style="height:10em;">' +
                '<div class="card-header">' +
                ' Droga #' + entidadDrogas[i].TN_ID_Droga +
                '<div>' +
                '<a href="#" class="editarEntidadDroga" id="' + entidadDrogas[i].TN_ID_Droga + '"><span><i class="fa fa-pencil" aria-hidden="true"></i></span></a>' +
                '<a href="#" class="borrar borrarEntidadEvento" id="' + entidadDrogas[i].TN_ID_Droga + '"><span><i class="fa fa-trash" data-toggle="modal" data-target="#ModalMensaje" aria-hidden="true"></i></span></a>' +
                '</div>' +

                '</div>' +

                '<div class="card-body" style="padding:0px!important">' +
                '<div class="container">'+

                    '<div class="row">'+
                        '<div class="col-4">'+
                           '<h6><span class="w-100 badge badge-primary">Nombre:</span></h6>'+
                        '</div>'+
                        '<div class="col-8">'+
                        '<span>'+ entidadDrogas[i].TC_Nombre + '</span>'+
                        '</div>'+
                    '</div>'+
                    '<div class="row">'+
                        '<div class="col-4">'+
                           ' <h6><span class="w-100 badge badge-primary">Cantidad:</span></h6>'+
                        '</div>'+
                        '<div class="col-md-8" id="divInforma">'+
                         '<p>' + entidadDrogas[i].TN_Cantidad +'</p>'+
                        '</div>'+
                   ' </div>'+
                '</div>'+
                '</div>' +
                '</div>'
            );
        }
    });
}

/*Eliminar Droga*/

function eliminarDroga(entidadDrogaID) {
    $.ajax({
        type: "DELETE",
        url: "/E_Droga/Eliminar_E_DrogaPorID",
        data: { "entidadDrogaID": entidadDrogaID }
    }).done(function (data) {
        CargarEntidadDrogas();

    });
}

/*Carga de Catalogos*/ 
function cargarTipoDroga() {

    $(document).ready(function () {
        $.ajax({
            type: "GET",
            url: "/C_TipoDroga/ListarTipoDroga",
            data: "{}",
            success: function (data) {
                var s;
                for (var i = 0; i < data.length; i++) {
                    s += '<option value="' + data[i].TN_ID_Tipo_Droga + '">' + data[i].TC_Nombre + '</option>';
            }
                $("#TN_ID_Tipo_Droga").html(s);
                $('#TN_ID_Tipo_Droga').selectpicker('refresh');
            }
          
        });
    });
}
