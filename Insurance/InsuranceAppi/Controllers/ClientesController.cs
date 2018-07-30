


namespace InsuranceAppi.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using Models;
    using System.Web.Http.Description;
    using System.Web.Script.Serialization;
    public class ClientesController : ApiController
    {

        private IClientes clienteModel;

        

        public ClientesController()
        {
            clienteModel = Clientes.ObtenerInstancia();
        }

        public ClientesController(ClientesMock parametro)
        {
            clienteModel = ClientesMock.ObtenerInstancia();
        }

        public static ClientesController ObtenerInstancia(ClientesMock clienteMock)
        {
            return new ClientesController(clienteMock);
        }


        public IHttpActionResult GetAllCliente()
        {
            var respuesta = clienteModel.GetAllCliente();    
            return Ok(respuesta); ;

        }
    }
}
