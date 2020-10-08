$(document).on("click", "#btnModificar", function (e) {
    e.preventDefault();
    var form = $("#FormCaso");
    alert(form.serialize());
    let url;
    url = "/Caso/ActualizarCaso";
    AccionesCasoForm(form, url);

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

$(document).on("click", "#btnRegistrarEvento", function (e) {
    e.preventDefault();
    var form = $("#FormEvento");
    
    let url;
    url = "/Caso/InsertarCaso";
    //AccionesCasoForm(form, url);

});


function AccionesCasoForm(form, url) {
    $.ajax({
        type: "POST",
        url: url,
        data: form.serialize()

    }).done(function (data) {
        $("#ModalFormCaso").modal("hide");
        CargarCasos();
    });
}