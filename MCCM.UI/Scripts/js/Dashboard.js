function changeVisiblePestannaBody(name) {
    $("#pestanna-1-body").hide();
    $("#pestanna-2-body").hide();
    $("#reporte-body").hide();

    $('#' + name).show();
}

$(document).ready(function () {
    changeVisiblePestannaBody('pestanna-2-body');
    $('#picker').daterangepicker({
        "showDropdowns": true,
        "showWeekNumbers": true,
        "showISOWeekNumbers": true,
        "linkedCalendars": false,
        "showCustomRangeLabel": false,
        "startDate": "06/19/2020",
        // "endDate": "05/23/2020", 
        "opens": "center"
    }, function (start, end, label) {
        fecha1 = start.format('YYYY-MM-DD');
        fecha2 = end.format('YYYY-MM-DD');
        //alert(fecha1); 
        //console.log(, ' dias de diferencia'); 
    }); 
});