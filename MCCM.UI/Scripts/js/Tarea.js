$('#ModalFormTarea').on('show.bs.modal', function (e) {
    if (e.relatedTarget != null) {
        $.ajax({
            type: "GET",
            url: "/Tarea/ObtenerCatalogoUsuarios"
        }).done(function (data) {
            let usuarios = JSON.parse(data);
            $("#TN_ID_Usuario").empty();
            for (let i = 0; i < usuarios.length; i++) {
                $("#TN_ID_Usuario").append(
                    "<option value='" + usuarios[i].TN_ID_Usuario + "'>Cod:" + usuarios[i].TC_Identificacion + " " + usuarios[i].TC_Nombre_Completo + "</option >"
                );
            }
            $("#TN_ID_Usuario").selectpicker("refresh");
            iniciarCalendarioTarea(moment());
        });
    } else {
        $("#TN_ID_Caso").show();
        $("#tituloFormModal").html("Modificar Caso");
        $("#btnRegistrarCaso").hide();
        $("#btnModificarCaso").show();
        $("#btnEliminarCaso").show();
        $("#TN_ID_Input").show();
    }
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

$(document).on("click", "#btnRegistrarTarea", function (e) {
    e.preventDefault();
    var form = new FormData($("#FormTarea")[0]);
    alert(sessionStorage.CasoID);
    $.ajax({
        type: "POST",
        url: "/Tarea/InsertarTarea",
        data: { "tarea": Object.fromEntries(form), "TF_Fecha": $("#TF_Fecha_Tarea").val(), "caso": sessionStorage.CasoID }
    }).done(function (data) {
        $("#ModalFormTarea").modal("hide");
    });
});

function iniciarCalendarioTarea(fecha) {
    $('#TF_Fecha_Tarea').daterangepicker({
        "singleDatePicker": true,
        "timePicker": true,
        "timePicker24Hour": true,
        "starDate": fecha,
        locale: {
            format: 'YYYY/M/DD HH:mm'
        }
    });
}

function CargarTareas() {
    $.ajax({
        type: "GET",
        url: "/Tarea/ListarTarea",
        data: { "caso": sessionStorage.CasoID }
    }).done(function (data) {
        let tareas = new Array();
        tareas = JSON.parse(data);

        $("#tareas-body").empty();
        for (let i = 0; i < tareas.length; i++) {
            $("#tareas-body").append(
            '<div class="card tarea">'+
                '<div class="card-header">'+
                    '<div>Tarea # 1</div>'+
                '<div>' +
                '<a href="#" class="editarTarea" id="' + tareas[i].TN_ID_Tarea + '"><span><i class="fa fa-pencil" aria-hidden="true"></i></span></a>'+
                '<a href="#" class="borrar borrarTarea" id="' + tareas[i].TN_ID_Tarea + '"><span><i class="fa fa-trash" data-toggle="modal"'+ 
                            'data - target="#ModalMensaje" aria - hidden="true" ></i ></span ></a > '+
                 '</div>'+
                '</div>'+
            '<div class="card-body" style="padding:0px!important">'+
                 '<h6><small>Asignado:' + tareas[i].T_Usuario + '</small></h6 > ' +
                 '<h6><small>Fecha/Hora: ' + tareas[i].TF_Fecha + '</small></h6>' +
                 '<h6><small>Diligencia: ' + tareas[i].TC_Diligencia + '</small></h6>' +
                 '<h6><small>Lugar: ' + tareas[i].TC_Lugar + '</small></h6>' +
             '</div>'+
            '</div>'
            )
        }
    })
}


