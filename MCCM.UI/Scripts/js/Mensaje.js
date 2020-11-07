let boton;

$(document).on("click", '.borrar', function () {
    boton = $(this);
})

$(document).on("click", ".btnEliminarMensaje", function () {
    
    if (boton.attr('class').split(' ')[1] == "borrarEvento") {
        eliminarEvento(boton.attr('id'), boton);
    } else if (boton.attr('class').split(' ')[1] == "borrarTarea") {
        eliminarTarea(boton.attr('id'), boton);
    } else if (boton.attr('class').split(' ')[1] == "borrarGasto") {
        eliminarGastoPorId(boton.attr('id'));
    } else if (boton.attr('class').split(' ')[1] == "borrarGrupo") {
        eliminarGrupoPorId(boton.attr('id'));
    } else if (boton.attr('class').split(' ')[1] == "borrarVehiculo") {
        eliminarGrupo_VehiculoPorId(boton.attr('id'));
    }
    else if (boton.attr('class').split(' ')[1] == "borrarEntidadDroga") {
        eliminarDroga(boton.attr('id'));
    } else if (boton.attr('class').split(' ')[1] == "borrarEntidadTelefono") {
        eliminarTelefono(boton.attr('id'), boton);
    }
    else if (boton.attr('class').split(' ')[1] == "borrarEntidadArma") {
        eliminarArma(boton.attr('id'), boton);
    }
    else if (boton.attr('class').split(' ')[1] == "borrarUbicacion") {
        eliminarUbicacion(boton.attr('id'), boton);
    }
    else if (boton.attr('class').split(' ')[1] == "borrarEntidadVehiculo") {
        eliminarEntidadVehiculo(boton.attr('id'), boton);
    }
    else if (boton.attr('class').split(' ')[1] == "borrarPersonaJuridica") {
        eliminarPersonaJuridica(boton.attr('id'), boton);
    }
    else if (boton.attr('class').split(' ')[1] == "borrarEntidadPersona") {
        eliminarPersona(boton.attr('id'), boton);
    }
    
});



