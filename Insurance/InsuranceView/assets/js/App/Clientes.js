$(document).ready(function () {


    
    GetAllCliente();
});

function GetAllCliente()
{
   
         
       
        datos = {};

        var form = $("#frm-alumno-curso");
        $.ajax({
            datatype: 'JSON',
            type: 'GET',
            url: '../Insurance/api/clientes/GetAllCliente',
            success: function (respuesta) {

                var tablaBody = "";

                $.each(respuesta, function (indice, item) {

                    tablaBody += "<tr><td>" + item.IdCliente + "</td><td>" + item.Nombres + "</td><td>" + item.Apellidos + "</td><td>" + item.NombreTipoDocumento + "</td><td>" + item.Identificacion + "</td></tr>"

                });

                $('#tblClientes tbody').append(tablaBody);
            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.log(textStatus + ' ' + errorThrown);
            }

        });
}

