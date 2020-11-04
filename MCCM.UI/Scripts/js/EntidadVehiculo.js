$(document).ready(function () {
    cargarVehiculoMarca();
    cargarVehiculoClase();
    cargarVehiculoColor();

});
/*Fecha*/
function iniciarCalendarioVehiculo(fecha) {
    $('#TN_Anno_Vehiculo').datepicker({
        format: " yyyy",
        viewMode: "years",
        minViewMode: "years"
    });
}
/* Agregar Vehiculo*/
$(document).on("click", "#btnInsertarEntidadVehiculo", function (e) {
    e.preventDefault();
    if ($("#FormEntidadVehiculo").valid()) {
        $("#TN_ID_Caso_Vehiculo").val(sessionStorage.CasoID);
        var form = new FormData($("#FormEntidadVehiculo")[0]);
        form.append("TB_Verificado", $("#TB_Verificado_Vehiculo").is(":checked"));
        alert(JSON.stringify(Object.fromEntries(form)));
        $.ajax({
            type: "POST",
            url: "/E_Vehiculo/Insertar_E_Vehiculo",
            data: form,
            contentType: false,
            cache: false,
            processData: false,
        }).done(function (data) {
            $("#entidadVehículoModal").modal("hide");
            CargarEntidadVehiculos();
        });
    } else {
        alert("NO es valido");
    }
});


/*Editar*/

$(document).on("click", ".editarEntidadVehiculo", function () {
    $.ajax({
        type: "GET",
        url: "/E_Vehiculo/Obtener_E_VehiculoPorID",
        data: { "ID": $(this).attr('ID') }
    }).done(function (data) {
        let entidadVehiculo = new Array();
        entidadVehiculo = JSON.parse(data);
        alert(JSON.stringify(data));
        $("#tituloEntidadVehiculo").html("Modificar Vehiculo");
        $("#TB_Fotografia_Vehiculo").val(entidadVehiculo.TB_Fotografia);
        $("#divVehiculoID").show();
        $("#TN_ID_Vehiculo").val(entidadVehiculo.TN_ID_Vehiculo);
        $("#TC_Placa_Vehiculo").val(entidadVehiculo.TC_Placa);
        $('#TN_ID_Marca_Vehiculo').selectpicker('val', entidadVehiculo.TN_ID_Marca_Vehiculo);
        $('#TN_ID_Marca_Vehiculo').selectpicker('refresh');
        $('#TN_ID_Clase_Vehiculo').selectpicker('val', entidadVehiculo.TN_ID_Clase_Vehiculo);
        $('#TN_ID_Clase_Vehiculo').selectpicker('refresh');
        $('#TN_ID_Color_Vehiculo').selectpicker('val', entidadVehiculo.TN_ID_Color_Vehiculo);
        $('#TN_ID_Color_Vehiculo').selectpicker('refresh');
        $("#TC_Estilo_Vehiculo").val(entidadVehiculo.TC_Estilo);
        $("#TN_Anno_Vehiculo").val(entidadVehiculo.TN_Anno);
        $("#TC_Creado_Por_Vehiculo").val(entidadVehiculo.TC_Creado_Por);
        $("#fechaCreacion_Row_V").show();
        $("#TF_Fecha_Creacion_Vehiculo").val(entidadVehiculo.TF_Fecha_Creacion);
        $("#fechaModificación_Row_V").show();
        $("TF_Fecha_Modificacion_Vehiculo").val(entidadVehiculo.TF_Fecha_Modificacion);
        $("#modificadoPor_Row_V").show();
        $("#TC_Modificado_Por_Vehiculo").val(entidadVehiculo.TC_Modificado_Por);
        $('#TB_Verificado_Vehiculo').attr('checked', entidadVehiculo.TB_Verificado);
        $("#btnInsertarEntidadVehiculo").hide();
        $("#btnModificarEntidadVehiculo").show();
        $("#entidadVehículoModal").modal("show");
    });
});

$('#entidadVehículoModal').on('hidden.bs.modal', function () {
    $("#FormEntidadVehiculo")[0].reset();
    $("#tituloEntidadVehiculo").html("Insertar Vehiculo");
    $("#fechaCreacion_Row_V").hide();
    $("#fechaModificación_Row_V").hide();
    $("#modificadoPor_Row_V").hide();
    $("#btnInsertarEntidadVehiculo").show();
    $("#btnModificarEntidadVehiculo").hide();
    $('#TN_ID_Marca_Vehiculo').selectpicker('refresh');
    $('#TN_ID_Clase_Vehiculo').selectpicker('refresh');
    $('#TN_ID_Color_Vehiculo').selectpicker('refresh');
    $("label.error").hide();
})

/*Cargar Vehiculos*/
function CargarEntidadVehiculos() {
    $.ajax({
        type: "GET",
        url: "/E_Vehiculo/Listar_E_Vehiculo",
        data: { "caso": sessionStorage.CasoID }
    }).done(function (data) {
        let entidadVehiculos = new Array();
        entidadVehiculos = JSON.parse(data);

        $("#entidades-body").empty();
        for (let i = 0; i < entidadVehiculos.length; i++) {

            $("#entidades-body").append(
                '<div class="card" id="cartaEntidadVehiculo"' + entidadVehiculos[i].TN_ID_Vehiculo + 'style="width: 18rem;">' +

                '<div class="card-header">' +
                '<div>Entidad Vehiculo #' + entidadVehiculos[i].TN_ID_Vehiculo + '</div>' +
                '<div>' +
                ' <a href="#" class="editarEntidadVehiculo" id="' + entidadVehiculos[i].TN_ID_Vehiculo + '"><span><i class="fa fa-pencil" aria-hidden="true"></i></span></a>' +
                '<a href="#" class="borrar borrarVehiculo" id="' + entidadVehiculos[i].TN_ID_Vehiculo + '"><span><i class="fa fa-trash" data-toggle="modal" data-target="#ModalMensaje" aria-hidden="true"></i></span></a>' +
                '</div>' +

                '</div>' +
                '<div class="card-body" style="padding:0px!important">' +
                '<div class="container">' +
                '<div class="row">' +
                '<div class="col-sm-6">' +
                '<img src="' + entidadVehiculos[i].TC_Imagen + '" class="img-thumbnail" alt="Cinque Terre" width="304" height="50">' +
                '</div>' +

                '<div class="col-sm-6">' +
                '<div class="row">' +
                '<div class="col-sm-6">' +
                '<h6><span class="w-100 badge badge-primary">Placa</span></h6>' +
                '</div>' +
                '<div class="col-sm-6" >' +
                '<small>' + entidadVehiculos[i].TC_Placa + '</small>' +
                '</div>' +
                '</div>' +

                '<div class="row">' +
                '<div class="col-sm-6">' +
                ' <h6><span class="w-100 badge badge-primary">Marca:</span></h6>' +
                '</div>' +
                '<div class="col-sm-6">' +
                '<p>' + entidadVehiculos[i].TC_Marca + '</p>' +
                '</div>' +
                '</div>' +

                '<div class="row">' +
                '<div class="col-sm-6">' +
                '<h6><span class="w-100 badge badge-primary">Estilo:</span></h6>' +
                '</div>' +

                '<div class="col-sm-6">' +
                '<small>' + entidadVehiculos[i].TC_Estilo + '</small>' +
                '</div>' +
                '</div>' +
                '</div>' +

                '<div>' +

                '</div>' +
                '</div>' +
                '</div>' +
                '</div>' +

                '</div>'
            );
        }
    });
}



/*Eliminar Vehiculo*/

function eliminarVehiculo(entidadVehiculoID) {
    $.ajax({
        type: "POST",
        url: "/E_Vehiculo/Eliminar_E_VehiculoPorID",
        data: { "entidadVehiculoID": entidadVehiculoID }
    }).done(function (data) {

    });
}


//*Modificar Vehiculo
$(document).on("click", "#btnModificarEntidadVehiculo", function (e) {
    e.preventDefault();
    $("#TN_ID_Caso").val(sessionStorage.CasoID);
    var form = new FormData($("#FormEntidadVehiculo")[0]);
    form.append("TB_Verificado", $("#TB_Verificado_Vehiculo").is(":checked"));
    alert(JSON.stringify(Object.fromEntries(form)));
    $.ajax({
        type: "POST",
        url: "/E_Vehiculo/Modificar_E_Vehiculo",
        data: form,
        contentType: false,
        cache: false,
        processData: false,
    }).done(function (data) {
        $("#entidadVehículoModal").modal("hide");
        CargarEntidadVehiculos();
    });
});

/*Cargar Vehiculo Marca*/
function cargarVehiculoMarca() {
    $.ajax({
        type: "GET",
        url: "/C_VehiculoMarca/ListarVehiculoMarca",
    }).done(function (data) {
        let marca = JSON.parse(data);
        $("#TN_ID_Marca_Vehiculo").empty();
        var s;
        for (var i = 0; i < marca.length; i++) {
            s += '<option value="' + marca[i].TN_ID_Marca_Vehiculo + '">' + marca[i].TC_Descripcion + '</option>';
        }
        $("#TN_ID_Marca_Vehiculo").html(s);
        $('#TN_ID_Marca_Vehiculo').selectpicker('refresh');


    });

}

/*Cargar Vehiculo Clase*/
function cargarVehiculoClase() {
    $.ajax({
        type: "GET",
        url: "/C_VehiculoClase/ListarVehiculoClase",
    }).done(function (data) {
        let clase = JSON.parse(data);
        $("#TN_ID_Clase_Vehiculo").empty();
        var s;
        for (var i = 0; i < clase.length; i++) {
            s += '<option value="' + clase[i].TN_ID_Clase_Vehiculo + '">' + clase[i].TC_Descripcion + '</option>';
        }
        $("#TN_ID_Clase_Vehiculo").html(s);
        $('#TN_ID_Clase_Vehiculo').selectpicker('refresh');



    });
}



/*Cargar Vehiculo Color*/
function cargarVehiculoColor() {
    $.ajax({
        type: "GET",
        url: "/C_VehiculoColor/ListarVehiculoColor",
    }).done(function (data) {
        let color = JSON.parse(data);
        $("#TN_ID_Color_Vehiculo").empty();
        var s;
        for (var i = 0; i < color.length; i++) {
            s += '<option value="' + color[i].TN_ID_Color_Vehiculo + '">' + color[i].TC_Descripcion + '</option>';
        }
        $("#TN_ID_Color_Vehiculo").html(s);
        $('#TN_ID_Color_Vehiculo').selectpicker('refresh');

    });
}

/*Insertar Vehiculo Marca*/
$(document).on("click", "#btnAgregar_C_MarcaVehiculo", function (e) {
    e.preventDefault();
    if ($("#Form_C_MarcaVehiculo").valid()) {
        var form = new FormData($("#Form_C_MarcaVehiculo")[0]);
        $.ajax({
            type: "POST",
            url: "/C_VehiculoMarca/InsertarVehiculoMarca",
            data: Object.fromEntries(form)
        }).done(function (data) {
            $("#modal_C_MarcaVehiculo").modal("hide");
            cargarVehiculoMarca();
        });
    } else {
        alert("NO es valido");
    }
});

/*Insertar Vehiculo Clase*/
$(document).on("click", "#btnAgregar_C_ClaseVehiculo", function (e) {
    e.preventDefault();
    if ($("#Form_C_ClaseVehiculo").valid()) {
        var form = new FormData($("#Form_C_ClaseVehiculo")[0]);
        $.ajax({
            type: "POST",
            url: "/C_VehiculoClase/InsertarVehiculoClase",
            data: Object.fromEntries(form)
        }).done(function (data) {
            $("#modal_C_ClaseVehiculo").modal("hide");
            cargarVehiculoMarca();
        });
    } else {
        alert("NO es valido");
    }
});

/*Insertar Vehiculo Color*/
$(document).on("click", "#btnAgregar_C_ColorVehiculo", function (e) {
    e.preventDefault();
    if ($("#Form_C_ClaseVehiculo").valid()) {
        var form = new FormData($("#Form_C_ClaseVehiculo")[0]);
        $.ajax({
            type: "POST",
            url: "/C_VehiculoColor/C_VehiculoColorNegocio",
            data: Object.fromEntries(form)
        }).done(function (data) {
            $("#modal_C_ColorVehiculo").modal("hide");
            cargarVehiculoMarca();
        });
    } else {
        alert("NO es valido");
    }
});