
$(document).ready(function () {


    GetAllClientePoliza();
    

});



function EliminarClientePoliza(parametro) {


    $.ajax({
        url: '../Insurance/api/ClientePoliza/DeleteClientePoliza/?parametro=' + parametro,
        datatype: 'JSON',
        type: 'DELETE',
        contentType: 'application/json; charset=utf-8',
        data: parametro,
        success: function (respuesta) {

            if (respuesta.response) {
                alert("Se ha agregado con exito el registro");
                window.location.href = "/ClientePoliza/ClientePoliza";
            }

        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log(textStatus + ' ' + errorThrown);
        }

    });

}


function GetAllClientePoliza() {



    datos = {};

    var form = $("#frm-alumno-curso");
    $.ajax({
        datatype: 'JSON',
        type: 'GET',
        url: '../Insurance/api/ClientePoliza/GetAllClientePoliza',
        success: function (respuesta) {

            var tablaBody = "";

            $.each(respuesta, function (indice, item) {

                tablaBody += "<tr><td style='display: none;'>" + item.IdClientePoliza + "</td><td>" + item.NombreCliente + "</td><td>" + item.NombrePoliza + "</td><td>" + item.PorcentajeCobertura + "</td><td>" +
                    item.NombreEstado +
                    "</td><td><a href='/ClientePoliza/ClientePolizaModify/?idPoliza=" + item.IdClientePoliza + "' class='btn btn-info btnEditar' role='button'>Editar</a><a href='#' class='btn btn-danger btnEliminar' role='button' id='" + item.IdClientePoliza + "'>Eliminar</a></td></tr>";

            });

            $('#tblClientePoliza tbody').append(tablaBody);


            $(".btnEliminar").click(function () {

                var idPoliza = $(this).attr('id');
                EliminarClientePoliza(idPoliza);

            });
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log(textStatus + ' ' + errorThrown);
        }

    });
}