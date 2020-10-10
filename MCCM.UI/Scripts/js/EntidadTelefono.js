$(document).ready(function () {

    $.validator.addMethod("DefaultProveedor", function (value, element, arg) {
        return arg !== value;
    }, "Debe elegir un Proveedor");

    $("#FormEntidadTelefono").validate({
        rules: {
            TN_Numero: {
                required: true,
                minlength: 8
            },
            TN_ID_Proveedor: { DefaultProveedor: "Selecciones un proveedor..." },
            TC_Creado_Por_Telefono: {
                required: true
            }
        },
        messages: {
            TN_Numero: {
                required:"El campo Numero Telefono no puede quedar en blanco",
                number: "Este campo debe ser un valor numerico",
                minlength: "El número de telefono debe ser de al menos 8 digitos"   
            },
            TN_ID_Proveedor: { DefaultProveedor: "Por Favor, seleccione un proveedor" },
            TC_Creado_Por_Telefono: {
                    required:"Debe especificar quien registró la entidad telefono."
            }

        },
        submitHandler: function (form) {
            // do other things for a valid form
            return false;
        }
    });
});



$("#FormEntidadTelefono").submit(function (e) {
    e.preventDefault();
    if ($(this).valid()) {
        var form = new FormData($("#FormEntidadTelefono")[0]);
        let url;

        AccionesEntidadTelefonoForm(form, url);
    } else {
        alert("NO es valido");
    }
});

function AccionesEntidadTelefonoForm(form, url) {
    //alert(JSON.stringify(Object.fromEntries(form)));
    $.ajax({
        type: "POST",
        url: "/E_Telefono/Insertar_E_Telefono",
        data: form,
        contentType: false,
        cache: false,
        processData: false,
    }).done(function (data) {
        alert(data);
        $("#entidadTelefonoModal").modal("hide");

    });
}

$(document).on("click", ".editarEntidadTelefono", function () {

    $("#TD_ID_Telefono").val("1");
    $("#TN_Numero_Telefono").val("0000-00000");
    $("#TC_Comentario_Telefono").val("Telefono Importante");
    $("#divFMT").show();
    $("#divMPT").show();
    $("#divFCT").show();
    $("#TF_Fecha_Creacion_Telefono").val("10/09/2020 5:00PM");
    $("#TC_Creado_Por_Telefono").val("Maikel Matamoros Zúñiga");
    $("#TC_Modificado_Por_Telefono").val("");
    $('#TB_Verificado_Telefono').attr('checked', false);
    $("#btnModificarEntidadTelefono").show();
    $("#btnInsertarEntidadTelefono").hide();
    $("#entidadTelefonoModal").modal("show");

});



$(document).ready(function () {

    $('#TF_Fecha_Nacimiento').daterangepicker({
        "singleDatePicker": true,
        "startDate": "09/29/2020",
        "endDate": "10/05/2020"
    }, function (start, end, label) {
        console.log('New date range selected: ' + start.format('YYYY-MM-DD') + ' to ' + end.format('YYYY-MM-DD') + ' (predefined range: ' + label + ')');
    });

})