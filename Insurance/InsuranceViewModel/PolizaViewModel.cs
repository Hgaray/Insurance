
namespace InsuranceViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Text;

   public  class PolizaViewModel
    {


        public int IdPoliza { get; set; }

       
        public string Nombre { get; set; }

        
        public string Descripcion { get; set; }

        public int IdTipoCubrimiento { get; set; }

       
        public DateTime FechaInicio { get; set; }

        public int MesesCobertura { get; set; }

        public int ValorPoliza { get; set; }

        public int IdTipoRiesgo { get; set; }
    }
}
