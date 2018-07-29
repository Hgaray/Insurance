$(document).ready(function () {


    var idPoliza = $.get("idPoliza");

    inicializarSelect("#selTipoCubrimeinto", "/Poliza/GetAllTiposCubrimiento");
    inicializarSelect("#selTipoRiesgo", "/Poliza/GetAllTiposRiesgo");


    consultarPoliza(idPoliza);


    $("#btnGuardar").click(function () {

        ModificarPoliza();
    });

});






function ModificarPoliza()
{
    var parametros = new Object();

    parametros.IdPoliza = $("#lblIdPoliza").text();
    parametros.Nombre = $("#txtNombrePoliza").val();
    parametros.Descripcion = $("#txtDescripcion").val();
    parametros.IdTipoCubrimiento = $("#selTipoCubrimeinto").val();
    parametros.FechaInicio = $("#dtFechaInicioPoliza").val();
    parametros.MesesCobertura = $("#txtMesesCobertura").val();
    parametros.ValorPoliza = $("#txtValorPoliza").val();
    parametros.IdTipoRiesgo = $("#selTipoRiesgo").val();
    parametros.TipoCubrimiento = "";
    parametros.TipoRiesgo = "";

    parametros = JSON.stringify(parametros);


    $.ajax({
        url: '../../Insurance/api/Poliza/PutPoliza',
        type: 'PUT',
        data: parametros,
        contentType: 'application/json; charset=utf-8',
        success: function (respuesta) {

            if (respuesta.response) {
                alert("Se ha modificado con exito el registro");
                window.location.href = "/Poliza/Poliza";
            }

        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log(textStatus + ' ' + errorThrown);
        }

    });


}


function consultarPoliza(parametro)
{


    $.ajax({
        url: '../../Insurance/api/Poliza/GetPolizaById/?parametro=' + parametro,
        datatype: 'JSON',
        type: 'GET',
        contentType: 'application/json; charset=utf-8',
        data: parametro,
        success: function (respuesta) {

            $("#lblIdPoliza").text(respuesta.IdPoliza);
            $("#txtNombrePoliza").val(respuesta.Nombre);
            var FechaInicio = new Date(respuesta.FechaInicio);
            var Anio = FechaInicio.getFullYear() ;
            var mes = FechaInicio.getMonth() < 10 ? "0" + FechaInicio.getMonth() : FechaInicio.getMonth();
            var dia = FechaInicio.getDay() < 10 ? "0" + FechaInicio.getDay() : FechaInicio.getDay();

            var fechaDefinitiva = Anio + "-" + mes + "-" + dia;
            $("#dtFechaInicioPoliza").attr("value", fechaDefinitiva);         

            $("#txtMesesCobertura").val(respuesta.MesesCobertura); 
            $("#txtValorPoliza").val(respuesta.ValorPoliza);

            $("#selTipoCubrimeinto").val(respuesta.IdTipoCubrimiento).attr("selected", "selected");
            $("#selTipoRiesgo").val(respuesta.IdTipoRiesgo).attr("selected", "selected");
            $("#txtDescripcion").val(respuesta.Descripcion);

        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log(textStatus + ' ' + errorThrown);
        }

    });
}


function inicializarSelect(Control, Url) {

    $.ajax({
        datatype: 'JSON',
        type: 'GET',
        url: Url,
        success: function (respuesta) {

            var SelectOptions = "";

            $.each(respuesta, function (indice, item) {

                SelectOptions += "<option value='" + item.Id + "'>" + item.Nombre + "</option>";


            });

            $(Control).append(SelectOptions);
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