

namespace InsuranceAppi.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using Models;
    public class ClientePolizaController : ApiController
    {

        ClientePoliza clientePolizaModel = new ClientePoliza();

        public ClientePolizaController()
        {

        }


        public IHttpActionResult GetAllClientePoliza()
        {
            var respuesta = clientePolizaModel.GetAllClientePoliza();

            return Ok(respuesta);
        }

        public IHttpActionResult GetClientePolizaById(int parametro)
        {
            var respuesta = clientePolizaModel.GetClientePolizaById(parametro);

            return Ok(respuesta);
        }

        public IHttpActionResult PutClientePoliza(ClientePoliza parametros)
        {
            var respuesta = clientePolizaModel.PutClientePoliza(parametros);

            return Ok(respuesta);
        }

        public IHttpActionResult PostClientePoliza(ClientePoliza parametros)
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
