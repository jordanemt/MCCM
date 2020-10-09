function changeVisiblePestannaBody(name) {
    $("#pestanna-1-body").hide();
    $("#pestanna-2-body").hide();
    $("#reporte-body").hide();

    $('#' + name).show();
}

$(document).ready(function () {
    changeVisiblePestannaBody('pestanna-2-body');
});