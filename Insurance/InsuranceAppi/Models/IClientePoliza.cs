using InsuranceAppi.Entities;
using InsuranceViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceAppi.Models
{
    public interface IClientePoliza
    {
        List<ClientePolizaViewModel> GetAllClientePoliza();

        ClientePolizaViewModel GetClientePolizaById(int parametro);

        ResponseModel PutClientePoliza(ClientePoliza parametros);

        ResponseModel PostClientePoliza(ClientePolizaViewModel parametros);

        ResponseModel DeletePoliza(int parametro);


        ClientePolizaViewModel ToClientesViewModel(ClientePoliza parametros);
    }
}
