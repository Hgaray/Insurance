$(document).ready(function () {

    inicializarSelect("#selTipoCubrimeinto", "/Poliza/GetAllTiposCubrimiento");
    inicializarSelect("#selTipoRiesgo", "/Poliza/GetAllTiposRiesgo");

    $("#btnGuardar").click(function () {

        GuardarPoliza();
    });

});




function GuardarPoliza()
{
    var parametros = new Object();

    parametros.IdPoliza = 0;
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
    var id = 1;

    $.ajax({
        url: '../Insurance/api/Poliza/PostPoliza',
        type: 'POST',
        data: parametros,
        contentType: 'application/json; charset=utf-8',        
        success: function (respuesta) {

            if (respuesta.response)
            {
                window.location.href ="/Poliza/Poliza";
            }
           
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log(textStatus + ' ' + errorThrown);
        }

    });


   
}

function inicializarSelect(Control,Url)
{
  
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


