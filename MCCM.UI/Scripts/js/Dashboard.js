var pestannaVisible = 'pestanna-1-body';
function changeVisiblePestannaBody(nuevaPestannaVisible) {
    $("#" + pestannaVisible).removeClass("d-flex").addClass("d-none");
    $("#" + nuevaPestannaVisible).removeClass("d-none").addClass("d-flex");
    pestannaVisible = nuevaPestannaVisible;
}

$(document).ready(function () {
    changeVisiblePestannaBody('pestanna-1-body');
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