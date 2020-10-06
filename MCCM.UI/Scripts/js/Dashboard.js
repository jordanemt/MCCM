function changeVisiblePestannaBody(name) {
    $("#pestanna-1-body").hide();
    $("#pestanna-2-body").hide();
    $("#reporte-body").hide();

    $('#' + name).show();
}

changeVisiblePestannaBody('pestanna-1-body');