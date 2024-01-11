// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$("#formularioIniciarPartida").on("submit", function (e) {
    debugger;
    e.preventDefault();

    if ($(this).valid()) {
        let urlForm = $(this).data("url");
        $.ajax({
            url: urlForm, 
            type: "POST",
            data: $(this).serialize(), 
            success: function (data) {
                $("#contenedorLayout").html(data);
            },
            error: function (error) {
                debugger;
                $('#mensajeError').html(error.responseJSON.error);

                $('#mensajeError').fadeIn();
                setTimeout(function () {
                    $('#mensajeError').fadeOut();
                }, 5000);
            }
        });
    }
});