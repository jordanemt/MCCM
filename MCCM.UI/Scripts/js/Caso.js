$(document).ready(function () {
    CargarCasos();

});

$(document).on("click",".caso",function () {

    if ($(".card").hasClass('filaseleccionada')) {
        $(".card").removeClass('filaseleccionada');
        $(this).addClass('filaseleccionada');
        alert($(this).attr('id'));
    } else {
        $(this).addClass('filaseleccionada');
        alert($(this).attr('id'));
    }
});

$("#FormCaso").submit(function (e) {
    e.preventDefault();
    var form = $(this);
    alert(JSON.stringify(form.serializeArray()));
    $.ajax({
        type: "POST",
        url: "/Caso/InsertarCaso",
        data: form.serialize()

    }).done(function (data) {
        CargarCasos();
    });
});





function CargarCasos() {
    $.ajax({
        type: "GET",
        url: "/Caso/ListarCasos"
    }).done(function (data) {
        alert(data);
        let casos = new Array();
        casos = JSON.parse(data);
        for (let i = 0; i < casos.length; i++) {
            $("#casos-body").append(
                '<div class="card caso" id="' + casos[i].TN_ID_Caso +'" style="height:10em;">'+
                '<div class="card-header"><div>Caso #' + casos[i].TN_ID_Caso + '</div>'+
                '<a href="#" class="ojito" id="' + casos[i].TN_ID_Caso+'"><span><i class="fa fa-eye" aria-hidden="true"></i></span></a></div >'+
                        '<div class="card-body" style="padding:0px!important">'+
                            '<h5><small>Nombre:'+ casos[i].TC_Nombre_Caso +'</small></h5>'+
                            '<h5><small>Fecha: ' + casos[i].TF_Fecha +'</small></h5>'+
                            '<h5><small>Delito: ' + casos[i].TC_Delito +'</small></h5>'+
                        '</div>'+
                    '</div>'
            );
        }
    });
}