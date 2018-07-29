
namespace InsuranceViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ClientePolizaViewModel
    {
        public int IdClientePoliza { get; set; }

        public int IdCliente { get; set; }

        public int IdPoliza { get; set; }

        public int IdEstado { get; set; }

        public int PorcentajeCobertura { get; set; }

        public string NombreEstado { get; set; }

        public virtual ClientesViewModel Clientes { get; set; }

        public virtual PolizaViewModel Poliza { get; set; }
    }
}
