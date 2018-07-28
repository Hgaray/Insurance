


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

        public ClientesController()
        {

        }

        public Clientes clienteModel = new Clientes();



        public IHttpActionResult GetAllCliente()
        {
            var respuesta = clienteModel.GetAllCliente();    
            return Ok(respuesta); ;

        }
    }
}
