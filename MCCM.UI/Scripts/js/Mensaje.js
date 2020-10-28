let boton; 

$(document).on("click", '.borrar', function () {
    boton = $(this);
})

$(document).on("click", ".btnEliminarMensaje", function () {
    $("#ModalMensaje").modal("hide");
    if (boton.attr('class').split(' ')[1] == "borrarEvento") {
        eliminarEvento(boton.attr('id'));
        //alert("Se elimino el evento #" + boton.attr('id'));
    } else if (boton.attr('class').split(' ')[1] == "borrarTarea") {
        alert("Se elimino el tarea #" + boton.attr('id'));
    } else if (boton.attr('class').split(' ')[1] == "borrarGasto") {
        eliminarGastoPorId(boton.attr('id'));
    } else if (boton.attr('class').split(' ')[1] == "borrarGrupo") {
        eliminarGrupoPorId(boton.attr('id'));
    } else if (boton.attr('class').split(' ')[1] == "borrarVehiculo") {
        alert('Se ha borrado el vehículo');
        boton.parent().parent().parent().remove();
    }
    else if (boton.attr('class').split(' ')[1] == "borrarEntidadDroga") {
        eliminarDroga(boton.attr('id'));
    }
    boton.parent().parent().parent().remove();
});



