﻿$(document).ready(function () {


    GetAllPoliza();


   
});


function EliminarPoliza(parametro)
{
     

    $.ajax({
        url: '../Insurance/api/Poliza/DeletePoliza/?parametro=' + parametro,
        datatype: 'JSON',
        type: 'DELETE',       
        contentType: 'application/json; charset=utf-8',
        data: parametro,
        success: function (respuesta) {

            if (respuesta.response) {
                window.location.href = "/Poliza/Poliza";
            }

        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log(textStatus + ' ' + errorThrown);
        }

    });

}



function GetAllPoliza() {



    datos = {};

    var form = $("#frm-alumno-curso");
    $.ajax({
        datatype: 'JSON',
        type: 'GET',
        url: '../Insurance/api/Poliza/GetAllPoliza',
        success: function (respuesta) {

            var tablaBody = "";

            $.each(respuesta, function (indice, item) {

                tablaBody += "<tr><td style='display: none;'>" + item.IdPoliza + "</td><td>" + item.Nombre + "</td><td>" + item.Descripcion + "</td><td>" + item.TipoCubrimiento + "</td><td>" +
                    item.FechaInicio + "</td><td>" + item.MesesCobertura + "</td><td>" + item.ValorPoliza + "</td><td>" + item.TipoRiesgo +
                    "</td><td><a href='/Poliza/PolizaModify/?idPoliza=" + item.IdPoliza + "' class='btn btn-info btnEditar' role='button'>Editar</a><a href='#' class='btn btn-danger btnEliminar' role='button' id='" + item.IdPoliza + "'>Eliminar</a></td></tr>";

            });

            $('#tblPolizas tbody').append(tablaBody);


            $(".btnEliminar").click(function () {

                var idPoliza = $(this).attr('id');
                EliminarPoliza(idPoliza);

            });
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log(textStatus + ' ' + errorThrown);
        }

    });
}
