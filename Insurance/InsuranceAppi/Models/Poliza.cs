namespace InsuranceAppi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using Entities;
    using InsuranceViewModel;
    using System.Runtime;

    [Table("Poliza")]
    public partial class Poliza: IPoliza
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Poliza()
        {
            ClientePoliza = new HashSet<ClientePoliza>();
        }

        [Key]
        public int IdPoliza { get; set; }

        [StringLength(100)]
        public string Nombre { get; set; }

        [StringLength(500)]
        public string Descripcion { get; set; }

        public int IdTipoCubrimiento { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaInicio { get; set; }

        public int MesesCobertura { get; set; }

        public int ValorPoliza { get; set; }

        public int IdTipoRiesgo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClientePoliza> ClientePoliza { get; set; }


        public List<PolizaViewModel> GetAllPoliza()
        {
            List<PolizaViewModel> respuesta = new List<PolizaViewModel>();
            try
            {
                using (InsuranceContext ctx = new InsuranceContext())
                {
                    var polizas = ctx.Poliza.ToList();

                    if (polizas != null)
                    {
                        respuesta = polizas.Select(x => ToPolizaViewModel(x)).ToList();
                    }
                    
                }
            }
            catch (Exception)
            {

                return new List<PolizaViewModel>();
            }
            return respuesta;
        }

        public PolizaViewModel GetPolizaById(int parametro)
        {
            PolizaViewModel respuesta = new PolizaViewModel();
            try
            {
                using (InsuranceContext ctx = new InsuranceContext())
                {
                    
                    var poliza = ctx.Poliza.Where(x => x.IdPoliza == parametro).SingleOrDefault();

                    if (poliza != null)
                    {
                        respuesta = ToPolizaViewModel(poliza);
                    }
                    
                }
            }
            catch (Exception)
            {

                return new PolizaViewModel();
            }
            return respuesta;
        }

        public ResponseModel PutPoliza(PolizaViewModel parametros)
        {
            ResponseModel respuesta = new ResponseModel();
            try
            {
                using (InsuranceContext ctx = new InsuranceContext())
                {
                    var poliza = ctx.Poliza.Where(x => x.IdPoliza == parametros.IdPoliza).SingleOrDefault();
                    if(poliza != null)
                    {
                        poliza.Nombre = parametros.Nombre;
                        poliza.Descripcion = parametros.Descripcion;
                        poliza.IdTipoCubrimiento = parametros.IdTipoCubrimiento;
                        poliza.FechaInicio = parametros.FechaInicio;
                        poliza.MesesCobertura = parametros.MesesCobertura;
                        poliza.ValorPoliza = parametros.ValorPoliza;
                        poliza.IdTipoRiesgo = parametros.IdTipoRiesgo;
                        ctx.SaveChanges();
                        respuesta.response = true;                        
                            
                    }
                }
            }
            catch (Exception ex)
            {
                respuesta.response = false;
                respuesta.message = ex.InnerException.Message.ToString();
                return respuesta;
               
            }
            return respuesta;

        }       


        public ResponseModel PostPoliza(PolizaViewModel parametros)
        {
            ResponseModel respuesta = new ResponseModel();
            try
            {
                using (InsuranceContext ctx = new InsuranceContext())
                {
                    ctx.Poliza.Add(new Poliza() {

                        
                        Nombre = parametros.Nombre,
                        Descripcion=parametros.Descripcion,
                        IdTipoCubrimiento=parametros.IdTipoCubrimiento,
                        FechaInicio=parametros.FechaInicio,
                        MesesCobertura=parametros.MesesCobertura,
                        ValorPoliza=parametros.ValorPoliza,
                        IdTipoRiesgo=parametros.IdTipoRiesgo
                    });
                    ctx.SaveChanges();

                    respuesta.response = true;
                }
            }
            catch (Exception ex)
            {
                respuesta.response = false;
                respuesta.message = ex.InnerException.Message.ToString();
                return respuesta;

            }
            return respuesta;
        }

        public ResponseModel DeletePoliza(int parametro)
        {
            ResponseModel respuesta = new ResponseModel();
            try
            {
                using (InsuranceContext ctx = new InsuranceContext())
                {
                    var poliza = ctx.Poliza.Where(x => x.IdPoliza == parametro).SingleOrDefault();
                    if (poliza != null)
                    {
                        ctx.Entry(poliza).State = System.Data.Entity.EntityState.Deleted;
                        ctx.SaveChanges();
                        respuesta.response = true;

                    }
                }
            }
            catch (Exception ex)
            {
                respuesta.response = false;
                respuesta.message = ex.InnerException.Message.ToString();
                return respuesta;

            }
            return respuesta;

        }


        public PolizaViewModel ToPolizaViewModel(Poliza parametros)
        {

            try
            {
                return new PolizaViewModel()
                {

                    IdPoliza=parametros.IdPoliza,
                    Nombre=parametros.Nombre,
                    Descripcion=parametros.Descripcion,
                    IdTipoCubrimiento=parametros.IdTipoCubrimiento,
                    FechaInicio=parametros.FechaInicio,
                    MesesCobertura=parametros.MesesCobertura,
                    ValorPoliza=parametros.ValorPoliza,
                    IdTipoRiesgo=parametros.IdTipoRiesgo,
                    TipoCubrimiento = Enum.GetName(typeof(Maestros.TiposCubrimeinto), parametros.IdTipoCubrimiento),
                    TipoRiesgo = Enum.GetName(typeof(Maestros.TiposRiesgo), parametros.IdTipoRiesgo),

                };
            }
            catch (Exception)
            {

                return new PolizaViewModel();
            }
        }
    }
}
