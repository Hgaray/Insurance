$(document).ready(function () {


    var idPoliza = $.get("idPoliza");

    consultarClientePoliza(idPoliza);
    $("#btnGuardar").click(function () {

        ModificarClientePoliza();
    });
    
});


function ModificarClientePoliza()
{
    parametros = {};
    parametros.IdClientePoliza = $("#lblIdClientePoliza").text();
    parametros.IdCliente = $("#selCliente").val();
    parametros.IdPoliza = $("#selPoliza").val();   
    parametros.PorcentajeCobertura = $("#txtPorcentajeCobertura").val();

    parametros = JSON.stringify(parametros);


    $.ajax({
        url: '../../Insurance/api/ClientePoliza/PutClientePoliza',
        type: 'PUT',
        data: parametros,
        contentType: 'application/json; charset=utf-8',
        success: function (respuesta) {

            if (respuesta.response) {
                alert("Se ha modificado con exito el registro");
                window.location.href = "/ClientePoliza/ClientePoliza";
            }
            else
            {
                alert(respuesta.message);
            }

        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log(textStatus + ' ' + errorThrown);
        }

    });
}

function consultarClientePoliza(parametro)
{

    $.ajax({
        url: '../../Insurance/api/ClientePoliza/GetClientePolizaById/?parametro=' + parametro,
        datatype: 'JSON',
        type: 'GET',
        contentType: 'application/json; charset=utf-8',
        data: parametro,
        success: function (respuesta) {

            var SelectOptions = "";
            SelectOptions += "<option value='" + respuesta.IdCliente + "'>" + respuesta.NombreCliente + "</option>";
            $("#selCliente").append(SelectOptions);

            SelectOptions = "";
            SelectOptions += "<option value='" + respuesta.IdPoliza + "'>" + respuesta.NombrePoliza + "</option>";
            $("#selPoliza").append(SelectOptions);

            $("#txtPorcentajeCobertura").val(respuesta.PorcentajeCobertura);

            $("#lblIdClientePoliza").text(respuesta.IdClientePoliza);

        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log(textStatus + ' ' + errorThrown);
        }

    });
}

$.get = function (key) {
    key = key.replace(/[\[]/, '\\[');
    key = key.replace(/[\]]/, '\\]');
    var pattern = "[\\?&]" + key + "=([^&#]*)";
    var regex = new RegExp(pattern);
    var url = unescape(window.location.href);
    var results = regex.exec(url);
    if (results === null) {
        return null;
    } else {
        return results[1];
    }
}