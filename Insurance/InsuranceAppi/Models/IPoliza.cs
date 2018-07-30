
namespace InsuranceAppi.Models
{
    using InsuranceAppi.Entities;
    using InsuranceViewModel;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IPoliza
    {

        List<PolizaViewModel> GetAllPoliza();

         PolizaViewModel GetPolizaById(int parametro);

         ResponseModel PutPoliza(PolizaViewModel parametros);
        


        ResponseModel PostPoliza(PolizaViewModel parametros);
        

         ResponseModel DeletePoliza(int parametro);
    }
}
