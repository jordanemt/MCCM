$(document).ready(function () {
    $.ajax({
        url: "/Dashboard/ObtenerRolUsuario",
        cache: false,
        type: "GET",
        success: function (data) {
            sessionStorage.Rol = data;
            if (data != 2) {
                $(".plus").show();
                $("#Usuario").show();
            }
        }
    });
});

$(window).on('beforeunload', function () {
    sessionStorage.removeItem('CasoID');
    sessionStorage.removeItem('GrupoID');
});

$(document).on("click", "#salir", function () {
    sessionStorage.clear();
});

let global = 1;
function seleccionado(seleccion) {
    global = document.getElementById('custId').value;
    if (seleccion !== global) {
        document.getElementById('custId').value = seleccion;
        global = document.getElementById('custId').value;
    }
}

function seleccionEntidad() {
    global = document.getElementById('custId').value;
    if (global == 1) {
        $('#entidadPersonaModal').modal('show');
    }
    if (global == 2) {
        $('#entidadPersonaJuridicaModal').modal('show');
    }
    if (global == 3) {
        $('#entidadVehículoModal').modal('show');
    }
    if (global == 4) {
        $('#entidadUbicacionModal').modal('show');
    }
    if (global == 5) {
        $('#entidadTelefonoModal').modal('show');
    }
    if (global == 6) {
        $('#entidadArmaModal').modal('show');
    }
    if (global == 7) {
        $('#entidadDrogaModal').modal('show');
    }
}


var pestannaVisible = 'pestanna-1-body';
function changeVisiblePestannaBody(nuevaPestannaVisible) {
    $("#" + pestannaVisible).removeClass("d-flex").addClass("d-none");
    $("#" + nuevaPestannaVisible).removeClass("d-none").addClass("d-flex");
    pestannaVisible = nuevaPestannaVisible;
    if (pestannaVisible == 'pestanna-1-body' && validarCasoSession()) {
        cargarPestanna1();
    } else if (pestannaVisible == 'pestanna-2-body' && validarCasoSession()) {
        cargarPestanna2();
    } else if (pestannaVisible == 'reporte-body') {
        $('#reporteFinal').hide();
        $('#generarReporte-form').show();
    }
}

function cargarPestanna1() {
    CargarEventos();
    CargarTareas();
    if (global == 1) {
        CargarEntidadPersona();
    } else if (global == 2) {
        CargarEntidadPersonaJuridica();
    } else if (global == 3) {
        CargarEntidadVehiculos();
    } else if (global == 4) {
        CargarEntidadUbicaciones();
    } else if (global == 5) {
        CargarEntidadTelefono();
    } else if (global == 6) {
        CargarEntidadArmas();
    } else if (global == 7) {
        CargarEntidadDrogas();
    } 
}

function cargarPestanna2() {
    listarGastos();
    listarGrupos();
}

function sumArray(array) {
    var sum = array.reduce(function (a, b) {
        return a + b;
    }, 0);

    return sum;
};

function agregarEventosReporte(data) {
    var ctx = document.getElementById('eventos-reporte').getContext('2d');
    var myChart = new Chart(ctx, {
        type: 'line',
        data: {
            labels: Object.keys(data),
            datasets: [{
                label: 'Unidades por mes',
                data: Object.values(data),
                borderWidth: 1
            }]
        },
        options: {
            title: {
                display: true,
                text: ['Eventos', 'Total: ' + sumArray(Object.values(data))],
                fontSize: 18,
                position: 'top'
            },
            scales: {
                yAxes: [{
                    ticks: {
                        beginAtZero: true
                    }
                }]
            }
        }
    });
    $('#eventos-reporte').show();
}

function agregarTareasReporte(data) {
    var ctx = document.getElementById('tareas-reporte').getContext('2d');
    var myChart = new Chart(ctx, {
        type: 'bar',
        data: {
            labels: Object.keys(data),
            datasets: [{
                label: 'Unidades',
                data: Object.values(data),
                backgroundColor: [
                    'rgba(19, 97, 223, 0.5)',
                    'rgba(145, 15, 102, 0.5)'
                ],
                borderColor: [
                    'rgba(19, 97, 223, 1)',
                    'rgba(145, 15, 102, 1)'
                ],
                borderWidth: 1
            }]
        },
        options: {
            title: {
                display: true,
                text: ['Tareas', 'Total: ' + sumArray(Object.values(data))],
                fontSize: 18,
                position: 'top'
            },
            scales: {
                yAxes: [{
                    ticks: {
                        beginAtZero: true
                    }
                }]
            }
        }
    });
    $('#tareas-reporte').show();
}

function agregarEntidadesReporte(data) {
    var ctx = document.getElementById('entidades-reporte').getContext('2d');
    var myChart = new Chart(ctx, {
        type: 'bar',
        data: {
            labels: Object.keys(data),
            datasets: [{
                label: 'Unidades',
                data: Object.values(data),
                backgroundColor: [
                    'rgba(255, 177, 64, 0.5)',
                    'rgba(19, 97, 223, 0.5)',
                    'rgba(226, 18, 18, 0.5)',
                    'rgba(145, 15, 102, 0.5)',
                    'rgba(128, 128, 128, 0.5)',
                    'rgba(168, 204, 102, 0.5)',
                    'rgba(66, 200, 212, 0.5)'
                ],
                borderColor: [
                    'rgba(255, 177, 64, 1)',
                    'rgba(19, 97, 223, 1)',
                    'rgba(226, 18, 18, 1)',
                    'rgba(145, 15, 102, 1)',
                    'rgba(128, 128, 128, 1)',
                    'rgba(168, 204, 102, 1)',
                    'rgba(66, 200, 212, 1)'
                ],
                borderWidth: 1
            }]
        },
        options: {
            title: {
                display: true,
                text: ['Entidades', 'Total: ' + sumArray(Object.values(data))],
                fontSize: 18,
                position: 'top'
            },
            scales: {
                yAxes: [{
                    ticks: {
                        beginAtZero: true
                    }
                }]
            }
        }
    });
    $('#entidades-reporte-contenedor').show();
}

function agregarGastosReporte(data) {
    var ctx = document.getElementById('gastos-reporte').getContext('2d');
    var myChart = new Chart(ctx, {
        type: 'doughnut',
        data: {
            labels: Object.keys(data),
            datasets: [{
                label: 'Total en colones',
                data: Object.values(data),
                backgroundColor: [
                    'rgba(255, 177, 64, 0.5)',
                    'rgba(19, 97, 223, 0.5)',
                    'rgba(226, 18, 18, 0.5)'
                ],
                borderColor: [
                    'rgba(255, 177, 64, 1)',
                    'rgba(19, 97, 223, 1)',
                    'rgba(226, 18, 18, 1)'
                ],
                borderWidth: 1
            }]
        },
        options: {
            title: {
                display: true,
                text: ['Gastos', 'Total: ' + sumArray(Object.values(data)) + '₡'],
                fontSize: 18,
                position: 'top'
            },
            scales: {
                yAxes: [{
                    ticks: {
                        beginAtZero: true
                    }
                }]
            }
        }
    });
    $('#gastos-reporte').show();
}

function agregarRecusrosReporte(data) {
    var ctx = document.getElementById('personal-reporte').getContext('2d');
    var myChart = new Chart(ctx, {
        type: 'bar',
        data: {
            labels: Object.keys(data),
            datasets: [{
                label: 'Unidades',
                data: Object.values(data),
                backgroundColor: [
                    'rgba(168, 204, 102, 0.5)',
                    'rgba(19, 97, 223, 0.5)'
                ],
                borderColor: [
                    'rgba(168, 204, 102, 1)',
                    'rgba(19, 97, 223, 1)'
                ],
                borderWidth: 1
            }]
        },
        options: {
            title: {
                display: true,
                text: ['Personal', 'Total: ' + sumArray(Object.values(data))],
                fontSize: 18,
                position: 'top'
            },
            scales: {
                yAxes: [{
                    ticks: {
                        beginAtZero: true
                    }
                }]
            }
        }
    });
    $('#personal-reporte').show();
}

function generarReporte() {
    if (sessionStorage.CasoID == null) {
        alert("Debe seleccionar un caso");
        return 0;
    }
    var url = "/Dashboard/GenerarReporte/";
    $('#generarReporte-form').hide();
    $('#spinner-contenedor').show();
    agregarSpinnerCargando($("#spinner-contenedor"));
    $.ajax({
        url: url,
        cache: false,
        type: "GET",
        data: {
            CasoID: sessionStorage.CasoID,
            Inicio: fechaInicioReporte,
            Final: fechaFinalReporte,
            Eventos: $('#Eventos').prop('checked'),
            TareasTerminadas: $('#TareasTerminadas').prop('checked'),
            TareasPendientes: $('#TareasPendientes').prop('checked'),
            Persona: $('#Persona').prop('checked'),
            PersonaJuridica: $('#PersonaJuridica').prop('checked'),
            EntidadVehiculo: $('#EntidadVehiculo').prop('checked'),
            Ubicacion: $('#Ubicacion').prop('checked'),
            Telefono: $('#Telefono').prop('checked'),
            Arma: $('#Arma').prop('checked'),
            Droga: $('#Droga').prop('checked'),
            Operativo: $('#Operativo').prop('checked'),
            Combustible: $('#Combustible').prop('checked'),
            Personal: $('#Personal').prop('checked'),
            Vehiculo: $('#Vehiculo').prop('checked')
        },
        success: function (data) {
            if (data.eventos != null) {
                agregarEventosReporte(data.eventos);
                $('#bitacora-reporte-contenedor').show();
            }
            if (data.tareas != null) {
                agregarTareasReporte(data.tareas);
                $('#bitacora-reporte-contenedor').show();
            }
            if (data.entidades != null) {
                agregarEntidadesReporte(data.entidades);
            }
            if (data.gastos != null) {
                agregarGastosReporte(data.gastos);
                $('#recursos-reporte-contenedor').show();
            }
            if (data.recursos != null) {
                agregarRecusrosReporte(data.recursos);
                $('#recursos-reporte-contenedor').show();
            }
            $('#spinner-contenedor').hide();
            $("#spinnerCargando").remove();
            $("#nombre-caso-reporte").html($("#reporte-nombre-caso").val());
            $('#reporteFinal').show();
        },
        error: function (reponse) {
            alert("error : " + reponse);
        }
    });
}

var fechaInicioReporte;
var fechaFinalReporte;
$(document).ready(function () {


    $(document).ready(function () {
        selected = true;
        $('#BtnSeleccionar').click(function () {
            if (selected) {
                $('#bitacora input[type=checkbox]').prop("checked", true);
                $('#recursos input[type=checkbox]').prop("checked", true);
                $('#entidades input[type=checkbox]').prop("checked", true);
                $('#BtnSeleccionar').val('Deseleccionar');
            } else {
                $('#bitacora input[type=checkbox]').prop("checked", false);
                $('#recursos input[type=checkbox]').prop("checked", false);
                $('#entidades input[type=checkbox]').prop("checked", false);
                $('#BtnSeleccionar').val('Seleccionar');
            }
            selected = !selected;
        });
    });

    $('#picker').daterangepicker({
        "showDropdowns": true,
        "showWeekNumbers": true,
        "showISOWeekNumbers": true,
        "linkedCalendars": false,
        "showCustomRangeLabel": false,
        "opens": "center"
    }, function (start, end, label) {
            fechaInicioReporte = start.format('YYYY-MM-DD');
            fechaFinalReporte = end.format('YYYY-MM-DD');
    });
});