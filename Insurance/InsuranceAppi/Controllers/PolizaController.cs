﻿

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
        Poliza polizaModel = new Poliza();


        public PolizaController()
        {

        }

        [HttpGet]
        public IHttpActionResult GetAllPoliza()
        {

            var respuesta = polizaModel.GetAllPoliza();
            return Ok(respuesta);
        }

        [HttpGet]
        public IHttpActionResult GetAPolizaById(int parametro)
        {

            var respuesta = polizaModel.GetAPolizaById(parametro);
            return Ok(respuesta);
        }


        [HttpPut]
        public IHttpActionResult PutPoliza(Poliza parametros)
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
