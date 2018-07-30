

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

    public class PolizaController : ApiController
    {
        IPoliza polizaModel;


        public PolizaController()
        {
            polizaModel = new Poliza();
        }

        [HttpGet]
        public IHttpActionResult GetAllPoliza()
        {

            var respuesta = polizaModel.GetAllPoliza();
            return Ok(respuesta);
        }

        [HttpGet]
        public IHttpActionResult GetPolizaById(int parametro)
        {

            var respuesta = polizaModel.GetPolizaById(parametro);
            return Ok(respuesta);
        }


        [HttpPut]
        public IHttpActionResult PutPoliza(PolizaViewModel parametros)
        {
            var respuesta = polizaModel.PutPoliza(parametros);
            return Ok(respuesta);
        }


        [HttpPost]
        public IHttpActionResult PostPoliza(PolizaViewModel parametros)
        {

            var respuesta = polizaModel.PostPoliza(parametros);
            return Ok(respuesta);
        }


        [HttpDelete]
        public IHttpActionResult DeletePoliza(int parametro)
        {
            var respuesta = polizaModel.DeletePoliza(parametro);
            return Ok(respuesta);
        }
    }
}
