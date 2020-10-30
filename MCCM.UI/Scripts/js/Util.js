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