// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

let opcionesJugador = [];

$("#contenedorLayout").on("submit", "#formularioIniciarPartida", function (e) {
    e.preventDefault();


    if ($(this).valid()) {
        $("#iniciarPartidaBtn").prop('disabled', true).html('<span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span> Iniciando...');
        let urlForm = $(this).data("url");
        $.ajax({
            url: urlForm,
            type: "POST",
            data: $(this).serialize(),
            success: function (data) {
                $("#contenedorLayout").html(data);
                $("#iniciarPartidaBtn").prop('disabled', false).html('Iniciar partida');
            },
            error: function (error) {
                $("#iniciarPartidaBtn").prop('disabled', false).html('Iniciar partida');
                $('#mensajeError').html(error.responseJSON.error);

                $('#mensajeError').fadeIn();
                setTimeout(function () {
                    $('#mensajeError').fadeOut();
                }, 5000);
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
        var ganador = ValidarGanador(opcionesJugador);
        opcionesJugador = [];
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
    let urlForm = $("#urlGuardarTurno").val();
    let IdPartida = $("#inputIdPartida").val();

    $.ajax({
        url: urlForm,
        type: "POST",
        data: { IdPartida: IdPartida, Ganador: idGanador },
        success: function (data) {
            if (finPartida) {
                alerta("El ganador de esta partida fue: " + data.ganador + ", se iniciara una nueva partida con nuevos jugadores.", "Fin partida", function () { location.reload(); })
            }
            else {
                $('#mensajeInfo').html("Aun no tenemos un ganador.");
                $('#mensajeError').fadeIn();
                setTimeout(function () {
                    $('#mensajeError').fadeOut();
                }, 5000);
                let urlIniciarRonda = $("#urlIniciarRonda").val();
                IniciarNuevaRonda(urlIniciarRonda);
            }

            $("#contenedorLayout").html(data);
        },
        error: function (error) {
            $('#mensajeError').html(error.responseJSON.error);
            $('#mensajeError').fadeIn();
            setTimeout(function () {
                $('#mensajeError').fadeOut();
            }, 5000);
        }
    });
};

let IniciarNuevaRonda = function (urlIniciarRonda) {
    $.ajax({
        url: urlIniciarRonda,
        type: "Get",
        success: function (data) {
            $("#contenedorLayout").html(data);
        },
        error: function (error) {
            $('#mensajeError').html(error.responseJSON.error);
            $('#mensajeError').fadeIn();
            setTimeout(function () {
                $('#mensajeError').fadeOut();
            }, 5000);
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