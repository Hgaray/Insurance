namespace InsuranceAppi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using InsuranceViewModel;

    public partial class Clientes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Clientes()
        {
            ClientePoliza = new HashSet<ClientePoliza>();
        }

        [Key]
        public int IdCliente { get; set; }

        [StringLength(100)]
        public string Nombres { get; set; }

        [StringLength(100)]
        public string Apellidos { get; set; }

        public int IdTipoDocumento { get; set; }

        [StringLength(30)]
        public string Identificacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClientePoliza> ClientePoliza { get; set; }





        public List<ClientesViewModel> GetAllCliente()
        {
            List<ClientesViewModel> respuesta = new List<ClientesViewModel>();
            try
            { 
                using (InsuranceContext ctx = new InsuranceContext())
                {
                    var clientes = ctx.Clientes.ToList();
                    if (clientes != null)
                    {
                        respuesta = clientes.Select(x => ToClientesViewModel(x)).ToList();
                    }
                }
            }
            catch (Exception)
            {

                return new List<ClientesViewModel>();
            }
            return respuesta;
        }

        public ClientesViewModel ToClientesViewModel(Clientes parametros)
        {

            try
            {
                return new ClientesViewModel() {

                    IdCliente=parametros.IdCliente,
                    Nombres=parametros.Nombres,
                    Apellidos=parametros.Apellidos,
                    IdTipoDocumento=parametros.IdTipoDocumento,
                    Identificacion = parametros.Identificacion

                };
            }
            catch (Exception)
            {

                return new ClientesViewModel();
            }
        }
    }
}
