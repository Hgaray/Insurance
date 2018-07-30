

namespace InsuranceAppi.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using Models;
    using InsuranceViewModel;
    using InsuranceAppi.Entities;

    public class ClientePolizaController : ApiController
    {

       
        Poliza polizaModel = new Poliza();


        IClientePoliza clientePolizaModel;
        public ClientePolizaController()
        {
            clientePolizaModel = new ClientePoliza();
        }


        public IHttpActionResult GetAllClientePoliza()
        {
            var ClientesPolizas = clientePolizaModel.GetAllClientePoliza();

            var respuesta = ClientesPolizas.Select(x => new
            {
                x.IdClientePoliza,
                x.IdCliente,
                x.IdPoliza,
                x.IdEstado,
                x.NombreEstado,
                x.PorcentajeCobertura,
                NombreCliente = (x.Clientes.Nombres + " " + x.Clientes.Apellidos),
                NombrePoliza = x.Poliza.Nombre,
                x.Poliza.MesesCobertura,
                FechaInicioPoliza = x.Poliza.FechaInicio
            }).ToList();

            return Ok(respuesta);
        }

        public IHttpActionResult GetClientePolizaById(int parametro)
        {            


            var ClientePoliza = clientePolizaModel.GetClientePolizaById(parametro);
            var respuesta = new
            {
                IdClientePoliza= ClientePoliza.IdClientePoliza,
                PorcentajeCobertura=ClientePoliza.PorcentajeCobertura,                
                NombreCliente = (ClientePoliza.Clientes.Nombres + " " + ClientePoliza.Clientes.Apellidos),
                NombrePoliza = ClientePoliza.Poliza.Nombre,
                IdCliente= ClientePoliza.IdCliente,
                IdPoliza=ClientePoliza.IdPoliza

            };

            return Ok(respuesta);

           
        }

        public IHttpActionResult PutClientePoliza(ClientePoliza parametros)
        {
            var respuesta = clientePolizaModel.PutClientePoliza(parametros);

            return Ok(respuesta);
        }

        public IHttpActionResult PostClientePoliza(ClientePolizaViewModel parametros)
        {            
            var respuesta = clientePolizaModel.PostClientePoliza(parametros);
            return Ok(respuesta);
        }

        public IHttpActionResult DeletePoliza(int parametro)
        {
            var respuesta = clientePolizaModel.DeletePoliza(parametro);

            return Ok(respuesta);
        }

        

    }
}
