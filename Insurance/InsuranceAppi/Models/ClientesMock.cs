using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InsuranceViewModel;

namespace InsuranceAppi.Models
{
    public class ClientesMock:IClientes
    {
        public static ClientesMock ObtenerInstancia()
        {
            return new ClientesMock();
        }

        public List<ClientesViewModel> GetAllCliente()
        {
            List<ClientesViewModel> respuesta = new List<ClientesViewModel>();


            respuesta.Add(new ClientesViewModel() { IdCliente=1,Nombres="Pruebas"});
            return respuesta;

        }
    }
}