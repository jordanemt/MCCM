$(document).ready(function () {
    $('#calendarioTarea').daterangepicker({
        "singleDatePicker": true,
        "timePicker": true,
        "timePicker24Hour": true,
        "starDate": moment(),
        locale: {
            format: 'M/DD hh:mm A'
        }
    }, function (start, end, label) {
        console.log('New date range selected: ' + start.format('YYYY-MM-DD') + ' to ' + end.format('YYYY-MM-DD') + ' (predefined range: ' + label + ')');
    });
})


$(document).on("click", ".editarTarea", function () {
    $("#tituloFormTarea").html("Modificar Tarea");
    $("#eventoIDI").val("1");
    $("#TLugarI").val("Turrialba");
    $("#DiligenciaI").val("Comprar Pan");
    $("#InformaI").val("Maikel Matamoros Zúñiga");
    $("#calendarioTarea").val("10/09/2020 5:00PM");
    iniciarCalendario("10/09/2020 5:00PM");
    $("#btnModificarTarea").show();
    $("#btnRegistrarTarea").hide();
    $("#btnTarea").hide();
    $("#ModalFormTarea").modal("show");

});