

$(document).ready(function () {
    CargarCasos();
});

$(document).on("click",".caso",function () {
    if ($(".card").hasClass('filaseleccionada')) {
        $(".card").removeClass('filaseleccionada');
        $(this).addClass('filaseleccionada');
    } else {
        $(this).addClass('filaseleccionada');
    }
    sessionStorage.CasoID= $(this).attr('id');
});


$('#ModalFormCaso').on('hidden.bs.modal', function () {
    limpiarFormularioCaso();
})

$('#ModalFormCaso').on('show.bs.modal', function (e) {
    var $activeElement = $(document.activeElement);
    /*alert($activeElement.serialize());*/
    $("#btnRegistrar").show();
    $("#btnModificar").hide();
    $("#btnEliminar").hide();    
})


$(document).on("click", ".ojito", function () {
    $.ajax({
        type: "GET",
        url: "/Caso/ObtenerCasoPorID",
        data: { "ID": $(this).attr('id') }
    }).done(function (data) {
        let caso = new Array();
        caso = JSON.parse(data);
        $("#btnRegistrar").hide();
        $("#EliminarCasoPorID").show();
        $("#btnModificar").show();
        $("#btnEliminar").show();
        $("#tituloFormModal").html("Modificar Caso");
        $("#TN_ID_Caso").val(caso.TN_ID_Caso);
        $("#TN_ECU").val(caso.TN_ECU);
        $("#TC_Nombre_Caso").val(caso.TC_Nombre_Caso);
        $("#TC_Enfoque_Trabajo").val(caso.TC_Enfoque_Trabajo);
        $("#TC_Area_Trabajo").val(caso.TC_Area_Trabajo);
        $("#TN_Nivel").val(caso.TN_Nivel);
        $("#TC_Descripcion").val(caso.TC_Descripcion);
        $("#TC_Fuente").val(caso.TC_Fuente);
        $("#TC_Delito").val(caso.TC_Delito);        
        $("#ModalFormCaso").modal("show");
    });
});

function limpiarFormularioCaso() {
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


$(document).on("click", "#btnModificar", function (e) {
    e.preventDefault();
    var form = $("#FormCaso");
    alert(form.serialize());
    let url;
    url = "/Caso/ActualizarCaso";
    AccionesCasoForm(form,url);
        
});

$(document).on("click", "#btnEliminar", function (e) {
    e.preventDefault();
    alert("Eliminar");

    $.ajax({
        type: "POST",
        url: "/Caso/EliminarCasoPorID",
        data: { "ID": $("#TN_ID_Caso").val() }
    }).done(function (data) {
        $("#ModalFormCaso").modal("hide");
        CargarCasos();
    });

});

$(document).on("click", "#btnRegistrar", function (e) {
    e.preventDefault();
    var form = $("#FormCaso");
    alert(form.serialize());
    let url;
    url = "/Caso/InsertarCaso";
    AccionesCasoForm(form,url);

});


function AccionesCasoForm(form,url) {
    $.ajax({
        type: "POST",
        url: url,
        data: form.serialize()

    }).done(function (data) {
        $("#ModalFormCaso").modal("hide");
        CargarCasos();
    });
}



function CargarCasos() {
    $.ajax({
        type: "GET",
        url: "/Caso/ListarCasos"
    }).done(function (data) {
        
        let casos = new Array();
        casos = JSON.parse(data);
        $("#casos-body").empty();
        for (let i = 0; i < casos.length; i++) {
            
            $("#casos-body").append(
                '<div class="card caso" id="' + casos[i].TN_ID_Caso +'" style="height:10em;">'+
                '<div class="card-header"><div>Caso #' + casos[i].TN_ID_Caso + '</div>'+
                '<a href="#" class="ojito" id="' + casos[i].TN_ID_Caso+'"><span><i class="fa fa-eye" aria-hidden="true"></i></span></a></div >'+
                        '<div class="card-body" style="padding:0px!important">'+
                            '<h6><small>Nombre:'+ casos[i].TC_Nombre_Caso +'</small></h5>'+
                            '<h6><small>Fecha: ' + casos[i].TF_Fecha +'</small></h5>'+
                            '<h6><small>Delito: ' + casos[i].TC_Delito +'</small></h5>'+
                        '</div>'+
                    '</div>'
            );
        }
    });
}