var pestannaVisible = 'pestanna-1-body';
function changeVisiblePestannaBody(nuevaPestannaVisible) {
    $("#" + pestannaVisible).removeClass("d-flex").addClass("d-none");
    $("#" + nuevaPestannaVisible).removeClass("d-none").addClass("d-flex");
    pestannaVisible = nuevaPestannaVisible;
}

function generarReporte() {
    var url = "/Dashboard/GenerarReporte/";

    $.ajax({
        url: url,
        cache: false,
        type: "GET",
        success: function (data) {
            $('#reporte-body').html(data);
            //if (agregarCasoIDToInputElementVal($('#TN_ID_Caso_Gasto'))) {
            //    $('#gasto-form-modal').modal('show');
            //}
        },
        error: function (reponse) {
            alert("error : " + reponse);
        }
    });
}

function saveAsPDF() {
    // get size of report page
    var reportPageHeight = $('#chart-container').innerHeight();
    var reportPageWidth = $('#chart-container').innerWidth();

    // create a new canvas object that we will populate with all other canvas objects
    var pdfCanvas = $('<canvas />').attr({
        id: "canvaspdf",
        width: reportPageWidth,
        height: reportPageHeight
    });

    // keep track canvas position
    var pdfctx = $(pdfCanvas)[0].getContext('2d');
    var pdfctxX = 0;
    var pdfctxY = 0;
    var buffer = 100;

    // for each chart.js chart
    $("canvas").each(function (index) {
        // get the chart height/width
        var canvasHeight = $(this).innerHeight();
        var canvasWidth = $(this).innerWidth();

        // draw the chart into the new canvas
        pdfctx.drawImage($(this)[0], pdfctxX, pdfctxY, canvasWidth, canvasHeight);
        pdfctxX += canvasWidth + buffer;

        // our report page is in a grid pattern so replicate that in the new canvas
        if (index % 2 === 1) {
            pdfctxX = 0;
            pdfctxY += canvasHeight + buffer;
        }
    });

    // create new pdf and add our new canvas as an image
    var pdf = new jsPDF('l', 'pt', [reportPageWidth, reportPageHeight]);
    pdf.addImage($(pdfCanvas)[0], 'PNG', 0, 0);

    // download the pdf
    pdf.save('filename.pdf');
}

$(document).ready(function () {
    changeVisiblePestannaBody('pestanna-1-body');
    //generarReporte();
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