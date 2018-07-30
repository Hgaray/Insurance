using InsuranceViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceAppi.Models
{
    public interface IClientes
    {

        List<ClientesViewModel>  GetAllCliente();

    }
}
