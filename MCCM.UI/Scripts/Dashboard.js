function changeVisiblePestannaBody(name) {
    $("#pestanna-1-panel-body").css("visibility", "collapse");
    $("#pestanna-2-panel-body").css("visibility", "collapse");
    $("#reporte-panel-body").css("visibility", "collapse");

    $('#' + name).css("visibility", "visible");
}