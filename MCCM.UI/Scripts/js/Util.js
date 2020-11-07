function agregarCasoIDToInputElementVal(e) {
    if (sessionStorage.CasoID != null) {
        e.val(sessionStorage.CasoID);
        return true;
    } else {
        alert('Debe seleccionar un caso');
        return false;
    }
}

function agregarGrupoIDToInputElementVal(e) {
    if (sessionStorage.GrupoID != null) {
        e.val(sessionStorage.GrupoID);
        return true;
    } else {
        alert('Debe seleccionar un grupo');
        return false;
    }
}

function sobreescribirJQueryMessages() {
    jQuery.extend(jQuery.validator.messages, {
        required: "Este campo es necesario",
        remote: "Please fix this field.",
        email: "Please enter a valid email address.",
        url: "Please enter a valid URL.",
        date: "Please enter a valid date.",
        dateISO: "Please enter a valid date (ISO).",
        number: "Solo se permiten números",
        digits: "Please enter only digits.",
        creditcard: "Please enter a valid credit card number.",
        equalTo: "Please enter the same value again.",
        accept: "Please enter a value with a valid extension.",
        maxlength: jQuery.validator.format("Please enter no more than {0} characters."),
        minlength: jQuery.validator.format("Please enter at least {0} characters."),
        rangelength: jQuery.validator.format("Please enter a value between {0} and {1} characters long."),
        range: jQuery.validator.format("Please enter a value between {0} and {1}."),
        max: jQuery.validator.format("Please enter a value less than or equal to {0}."),
        min: jQuery.validator.format("Please enter a value greater than or equal to {0}.")
    });
}


function agregarSpinnerCargando(elemento) {
    elemento.append(
        '<div class="d-flex align-items-center justify-content-center h-100">' +
            '<div class= "spinner-border text-primary" role = "status" >' +
                '<span class="sr-only">Cargando...</span>'+
            '</div >' +
        '</div >'
    );
}
