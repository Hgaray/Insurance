using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InsuranceView.Controllers
{
    public class ClientePolizaController : Controller
    {
        // GET: ClientePoliza
        public ActionResult ClientePoliza()
        {
            return View();
        }
        public ActionResult ClientePolizaCreate()
        {
            return View();
        }
        public ActionResult ClientePolizaModify()
        {

            return View();
        }
    }
}