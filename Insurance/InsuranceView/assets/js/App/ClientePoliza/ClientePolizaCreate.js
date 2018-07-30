
$(document).ready(function () {


    GetAllCliente();
    GetAllPoliza();

    

    $("#btnGuardar").click(function () {

        GuardarClientePoliza();
    });


    $("#selPoliza").change(function () {

        var parametro = $("#selPoliza").val();
        consultarDetallePoliza(parametro);
    });
    
});



function consultarDetallePoliza(parametro) {


    $.ajax({
        url: '../../Insurance/api/Poliza/GetPolizaById/?parametro=' + parametro,
        datatype: 'JSON',
        type: 'GET',
        contentType: 'application/json; charset=utf-8',
        data: parametro,
        success: function (respuesta) {

            $("#lblTipoRiesgo").text(respuesta.TipoRiesgo);
            $("#lblMeses").text(respuesta.MesesCobertura);
            $("#lblFechaInicio").text(respuesta.MesesCobertura); 
            $("#lblValorPoliza").text(respuesta.ValorPoliza);
            $("#lblTipoCubrimiento").text(respuesta.TipoCubrimiento);
            $("#lblDescripcion").text(respuesta.Descripcion);

        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log(textStatus + ' ' + errorThrown);
        }

    });
}


function GuardarClientePoliza()
{

    var parametros = new Object();

    parametros.IdClientePoliza = 0;
    parametros.IdCliente = $("#selCliente").val();
    parametros.IdPoliza = $("#selPoliza").val();
    parametros.PorcentajeCobertura = $("#txtPorcentajeCobertura").val();
   

    parametros = JSON.stringify(parametros);

    $.ajax({
        url: '../Insurance/api/ClientePoliza/PostClientePoliza',
        type: 'POST',
        data: parametros,
        contentType: 'application/json; charset=utf-8',
        success: function (respuesta) {

            if (respuesta.response) {
                alert("Se ha Guardado con exito el registro");
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

function GetAllPoliza() {



    datos = {};
    
    $.ajax({
        datatype: 'JSON',
        type: 'GET',
        url: '../Insurance/api/Poliza/GetAllPoliza',
        success: function (respuesta) {

            var SelectOptions = "";

            $.each(respuesta, function (indice, item) {

                SelectOptions += "<option value='" + item.IdPoliza + "'>" + item.Nombre + "</option>";


            });

            $("#selPoliza").append(SelectOptions);

            var parametro = $("#selPoliza").val();
            consultarDetallePoliza(parametro);
            
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log(textStatus + ' ' + errorThrown);
        }

    });
}




function GetAllCliente(control, url) {



    datos = {};

    var form = $("#frm-alumno-curso");
    $.ajax({
        datatype: 'JSON',
        type: 'GET',
        url: '../Insurance/api/clientes/GetAllCliente',
        success: function (respuesta) {

            var SelectOptions = "";

            $.each(respuesta, function (indice, item) {

                SelectOptions += "<option value='" + item.IdCliente + "'>" + (item.Nombres+" "+item.Apellidos)+ "</option>";


            });

            $("#selCliente").append(SelectOptions);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log(textStatus + ' ' + errorThrown);
        }

    });
}
