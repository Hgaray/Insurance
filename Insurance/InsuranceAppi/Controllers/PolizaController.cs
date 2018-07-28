

namespace InsuranceAppi.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using Models;
    public class PolizaController : ApiController
    {
        Poliza polizaModel = new Poliza();


        public PolizaController()
        {

        }


        public IHttpActionResult GetAllPoliza()
        {
            var respuesta = polizaModel.GetAllPoliza();
            return Ok(respuesta); 
        }

        public IHttpActionResult GetAPolizaById(int parametro)
        {
            var respuesta = polizaModel.GetAPolizaById(parametro);
            return Ok(respuesta);
        }

        public IHttpActionResult PutPoliza(Poliza parametros)
        {
            var respuesta = polizaModel.PutPoliza(parametros);
            return Ok(respuesta);
        }

        public IHttpActionResult PostPoliza(Poliza parametros)
        {
            var respuesta = polizaModel.PostPoliza(parametros);
            return Ok(respuesta);
        }

        public IHttpActionResult DeletePoliza(int parametro)
        {
            var respuesta = polizaModel.DeletePoliza(parametro);
            return Ok(respuesta);
        }
    }
}
