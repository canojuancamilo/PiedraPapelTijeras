// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

let opcionesJugador = [];

let ManejarError = function (Mensaje) {
    $('#mensajeError').html(Mensaje);
    $('#mensajeError').fadeIn();
    setTimeout(function () {
        $('#mensajeError').fadeOut();
    }, 5000);
};

let EliminarTurnosPartida = function () {
    let urlFormEliminarTurno = $("#urlEliminarTurnos").val();
    MostrarSpinner();

    $.ajax({
        url: urlFormEliminarTurno,
        type: "Get",
        success: function (data) {
            $("#contenedorLayout").html(data);
            OcultarSpinner();
        },
        error: function (error) {
            ManejarError(error.responseJSON.error);
            OcultarSpinner();
        }
    });
};

let alerta = function (message, title, cb, type) {
    if (typeof swal !== 'undefined') {
        swal.fire({
            title: title || '',
            text: message,
            icon: type || null,
            //icon: type,//"warning", "error", "success" and "info".
            confirmButtonText: 'Aceptar'
        }).then((result) => {
            if (result.isConfirmed) {
                cb();
            }
        });
    }
};

let Confirmar = function (message, title, cbNuevoJuego, cbReiniciarJuego, type) {
    if (typeof swal !== 'undefined') {
        swal.fire({
            title: title || '',
            text: message,
            icon: type || null,
            showCancelButton: true,
            confirmButtonColor: '#28a745',
            confirmButtonText: 'Nuevo juego',
            cancelButtonColor: '#007bff',
            cancelButtonText: 'Reiniciar juego'
        }).then((result) => {
            if (result.isConfirmed) {
                cbNuevoJuego();
            } else if (result.dismiss === swal.DismissReason.cancel) {
                cbReiniciarJuego();
            }
        });
    }
};

let IniciarNuevaRonda = function (urlIniciarRonda) {
    MostrarSpinner();

    $.ajax({
        url: urlIniciarRonda,
        type: "Get",
        success: function (data) {
            $("#contenedorLayout").html(data);
            OcultarSpinner();
        },
        error: function (error) {
            ManejarError(error.responseJSON.error);
            OcultarSpinner();
        }
    });
};

function MostrarSpinner() {
    $(".cargando").show();
}

function OcultarSpinner() {

    $(".cargando").hide();
}

$("#contenedorLayout").on("submit", "#formularioIniciarPartida", function (e) {
    e.preventDefault();

    if ($(this).valid()) {
        MostrarSpinner();
        $("#iniciarPartidaBtn").prop('disabled', true).html('<span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span> Iniciando...');
        let urlForm = $(this).data("url");
        $.ajax({
            url: urlForm,
            type: "POST",
            data: $(this).serialize(),
            success: function (data) {
                $("#contenedorLayout").html(data);
                $("#iniciarPartidaBtn").prop('disabled', false).html('Iniciar partida');
                OcultarSpinner();
            },
            error: function (error) {
                $("#iniciarPartidaBtn").prop('disabled', false).html('Iniciar partida');
                ManejarError(error.responseJSON.error);
                OcultarSpinner();
            }
        });
    }
});

$("#contenedorLayout").on("click", ".contenedorOpcion", function (e) {
    let idJugador = $(this).data("id_jugador");
    let opcion = $(this).data("opcion");

    opcionesJugador.push({ "idJugador": idJugador, "opcion": opcion });

    $(".contendorJugadoresTurno").show();
    $(".contendorJugadoresTurno" + idJugador).hide();

    if (opcionesJugador.length == 2) {
        MostrarSpinner();
        var ganador = ValidarGanador(opcionesJugador);
        opcionesJugador = [];
        GuardarTurno(ganador);
    }
});

let ValidarGanador = function (opciones) {
    if (opciones[0].opcion == opciones[1].opcion) {
        return null;
    } else if (
        (opciones[0].opcion === 1 && opciones[1].opcion === 3) ||
        (opciones[0].opcion === 2 && opciones[1].opcion === 1) ||
        (opciones[0].opcion === 3 && opciones[1].opcion === 2)
    ) {
        return opciones[0].idJugador;
    } else {
        return opciones[1].idJugador;
    }
};

let GuardarTurno = function (idGanador) {
    MostrarSpinner();
    setTimeout(function () {
        let urlForm = $("#urlGuardarTurno").val();
        let IdPartida = $("#inputIdPartida").val();

        $.ajax({
            url: urlForm,
            type: "POST",
            data: { IdPartida: IdPartida, Ganador: idGanador },
            success: function (data) {
                if (data.finPartida) {
                    Confirmar("El ganador de esta partida fue: " + data.ganador + ".", "Fin partida",
                        function () { location.reload(); },
                        function () { EliminarTurnosPartida(); });
                }
                else {
                    $('#mensajeInfo').html("Aun no tenemos un ganador de la partida.");
                    $('#mensajeInfo').fadeIn();
                    setTimeout(function () {
                        $('#mensajeInfo').fadeOut();
                    }, 5000);
                    let urlIniciarRonda = $("#urlIniciarRonda").val();
                    IniciarNuevaRonda(urlIniciarRonda);
                }

                OcultarSpinner();
            },
            error: function (error) {
                ManejarError(error.responseJSON.error);
                OcultarSpinner();
            }
        });
    }, 1000);
};
