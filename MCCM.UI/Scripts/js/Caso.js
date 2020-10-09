$(document).ready(function () {
    //CargarCasos();
    iniciarCalendario("06/10/2020");
});

function iniciarCalendario(fecha) {
    //alert(fecha);
    $('#calendarioBitacora').daterangepicker({
        "singleDatePicker": true,
        "timePicker": true,
        "minDate":  fecha,
        locale: {
            format: 'M/DD hh:mm A'
        }
    }, function (start, end, label) {
        console.log('New date range selected: ' + start.format('YYYY-MM-DD') + ' to ' + end.format('YYYY-MM-DD') + ' (predefined range: ' + label + ')');
    });
}

$(document).on("click",".caso",function () {
    if ($(".card").hasClass('filaseleccionada')) {
        $(".card").removeClass('filaseleccionada');
        $(this).addClass('filaseleccionada');
    } else {
        $(this).addClass('filaseleccionada');
    }
    sessionStorage.CasoID= $(this).attr('id');
});


$(document).on("click", ".disquete", function () {
    let lugar = $("#Lugar").val();
    let novedad = $("#Novedad").val();
    let informa = $("#Informa").val();
    let calendario = $("#calendarioBitacora").val();
    $("#divLugar").html("<h6 id='Lugar'>" + lugar + "</h6>")
    $("#divNovedad").html("<h6 id='Novedad'>" + novedad + "</h6>")
    $("#divInforma").html("<h6 id='Informa'>" + informa + "</h6>")
    $("#divCalendario").html("<h6 id='Calendario'>" + calendario + "</h6>")
    $("#guardarEvento").hide();
    $("#eventoDiv").show();
});

$(document).on("click", ".editarEvento", function () {
    let lugar = $("#Lugar").html();
    let novedad = $("#Novedad").html();
    let informa = $("#Informa").html();
    let calendario = $("#Calendario").html();
    $("#divLugar").html('<input class="form-control" id="Informa" value=' + lugar + '  />')
    $("#divNovedad").html('<input class="form-control" id="Novedad" value=' + novedad + '  />')
    $("#divInforma").html('<input class="form-control" id="Informa" value=' + informa + '  />')
    $("#divCalendario").html('<input class="form-control" id="calendarioBitacora" value=' + calendario + '  />')
    iniciarCalendario(calendario);
    $("#guardarEvento").hide();
    $("#eventoDiv").show();
});




$(document).on("click", ".caso", function () {
    
});


$('#ModalFormCaso').on('hidden.bs.modal', function () {
    limpiarFormularioCaso();
})

$('#ModalFormCaso').on('show.bs.modal', function (e) {
    if (e.relatedTarget != null) {
        console.log(e.relatedTarget.nodeName);
        $("#btnRegistrar").show();
        $("#btnModificar").hide();
        $("#btnEliminar").hide(); 
        $("#tituloFormModal").html("Registrar Caso");
        $("#TN_ID_Caso").hide();
    } else {
        $("#TN_ID_Caso").show();
        $("#tituloFormModal").html("Modificar Caso");
        $("#btnRegistrar").hide();
        $("#btnModificar").show();
        $("#btnEliminar").show();    
    }
})


$(document).on("click", ".ojito", function () {
    $.ajax({
        type: "GET",
        url: "/Caso/ObtenerCasoPorID",
        data: { "ID": $(this).attr('id') }
    }).done(function (data) {
        let caso = new Array();
        caso = JSON.parse(data);
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