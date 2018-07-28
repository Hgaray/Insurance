using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InsuranceViewModel;
using Newtonsoft.Json;

namespace InsuranceView.Controllers
{
    public class PolizaController : Controller
    {
        // GET: Poliza
        public ActionResult Poliza()
        {
            return View();
        }

        public ActionResult PolizaCreate()
        {
            return View();
        }

        public ActionResult PolizaModify()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetAllTiposCubrimiento()
        {
            var idtiposCubribiento = Enum.GetValues(typeof(Maestros.TiposCubrimeinto)).Cast<int>().ToList();
            List<MaestroGenerico> respuesta = new List<MaestroGenerico>();


            foreach (var item in idtiposCubribiento)
            {
                respuesta.Add(new MaestroGenerico()
                {
                    Id = item,
                    Nombre = Enum.GetName(typeof(Maestros.TiposCubrimeinto), item)
                });
            }

            return Json(respuesta, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public JsonResult GetAllTiposRiesgo()
        {
            var idtiposRiesgo = Enum.GetValues(typeof(Maestros.TiposRiesgo)).Cast<int>().ToList();
            List<MaestroGenerico> respuesta = new List<MaestroGenerico>();


            foreach (var item in idtiposRiesgo)
            {
                respuesta.Add(new MaestroGenerico()
                {
                    Id = item,
                    Nombre = Enum.GetName(typeof(Maestros.TiposRiesgo), item)
                });
            }

            return Json(respuesta, JsonRequestBehavior.AllowGet);

        }


       



    }
}