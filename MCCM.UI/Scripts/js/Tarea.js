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

    $("#eventoIDI").val("1");
    $("#LugarI").val("En Turri");
    $("#NovedadI").val("Valeria está vendiendo mota a todos los niños de la escuela T_T");
    $("#InformaI").val("Maikel Matamoros Zúñiga");
    $("#calendarioBitacora").val("10/09/2020 5:00PM");
    iniciarCalendario("10/09/2020 5:00PM");
    $("#divEventoID").show();
    $("#btnModificarEvento").show();
    $("#btnRegistrarEvento").hide();
    $("#btnEvento").hide();
    $("#ModalFormEvento").modal("show");

});