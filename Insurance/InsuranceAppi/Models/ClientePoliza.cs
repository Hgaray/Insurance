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

    [Table("ClientePoliza")]
    public partial class ClientePoliza:IClientePoliza
    {
        [Key]
        public int IdClientePoliza { get; set; }

        public int IdCliente { get; set; }

        public int IdPoliza { get; set; }

        public int IdEstado { get; set; }

        public int PorcentajeCobertura { get; set; }

        public virtual Clientes Clientes { get; set; }

        public virtual Poliza Poliza { get; set; }


        public List<ClientePolizaViewModel> GetAllClientePoliza()
        {
            List<ClientePolizaViewModel> respuesta = new List<ClientePolizaViewModel>();
            try
            {
                using (InsuranceContext ctx = new InsuranceContext())
                {
                    var clientesPolizas = ctx.ClientePoliza
                        .Include("Clientes")
                        .Include("Poliza")
                        .ToList();

                    if (clientesPolizas != null)
                    {
                        respuesta = clientesPolizas.Select(x => ToClientesViewModel(x)).ToList();
                    }
                    
                }
            }
            catch (Exception)
            {

                throw;
            }
            return respuesta;
        }

        public ClientePolizaViewModel GetClientePolizaById(int parametro)
        {
            ClientePolizaViewModel respuesta = new ClientePolizaViewModel();
            ClientePoliza clientePoliza = new ClientePoliza();
            try
            {
                using (InsuranceContext ctx = new InsuranceContext())
                {

                    clientePoliza = ctx.ClientePoliza
                        .Include("Clientes")
                        .Include("Poliza").Where(x => x.IdClientePoliza == parametro).SingleOrDefault();

                    respuesta = ToClientesViewModel(clientePoliza);
                }
            }
            catch (Exception)
            {

                return new ClientePolizaViewModel();
            }
            return respuesta;
        }

        public ResponseModel PutClientePoliza(ClientePoliza parametros)
        {
            ResponseModel respuesta = new ResponseModel();
            try
            {
                using (InsuranceContext ctx = new InsuranceContext())
                {

                    if (ctx.Poliza.Where(x => x.IdPoliza == parametros.IdPoliza && x.IdTipoRiesgo == (int)Maestros.TiposRiesgo.Alto).Count() > 0 && parametros.PorcentajeCobertura > 50)
                    {
                        respuesta.response = false;
                        respuesta.message = "Cuando el Riesgo de la Poliza es alto, El procentaje de cobertura no puede superar el 50%";
                    }
                    else
                    {
                        var clientePoliza = ctx.ClientePoliza.Where(x => x.IdClientePoliza == parametros.IdClientePoliza).SingleOrDefault();
                        if (clientePoliza != null)
                        {
                            clientePoliza.IdCliente = parametros.IdCliente;
                            clientePoliza.IdPoliza = parametros.IdPoliza;
                            clientePoliza.PorcentajeCobertura = parametros.PorcentajeCobertura;
                            ctx.SaveChanges();
                            respuesta.response = true;

                        }
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


        public ResponseModel PostClientePoliza(ClientePolizaViewModel parametros)
        {
            ResponseModel respuesta = new ResponseModel();
            try
            {
                using (InsuranceContext ctx = new InsuranceContext())
                {

                    if (ctx.Poliza.Where(x => x.IdPoliza == parametros.IdPoliza && x.IdTipoRiesgo == (int)Maestros.TiposRiesgo.Alto).Count() > 0 && parametros.PorcentajeCobertura>50)
                    {
                        respuesta.response = false;
                        respuesta.message = "Cuando el Riesgo de la Poliza es alto, El procentaje de cobertura no puede superar el 50%";
                    }
                    else
                    {
                        ctx.ClientePoliza.Add(new ClientePoliza
                        {
                            IdCliente = parametros.IdCliente,
                            IdPoliza = parametros.IdPoliza,
                            IdEstado = 1,
                            PorcentajeCobertura = parametros.PorcentajeCobertura

                        });
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


        public ResponseModel DeletePoliza(int parametro)
        {
            ResponseModel respuesta = new ResponseModel();
            try
            {
                using (InsuranceContext ctx = new InsuranceContext())
                {
                    var clientePoliza = ctx.ClientePoliza.Where(x => x.IdClientePoliza == parametro).SingleOrDefault();
                    if (clientePoliza != null)
                    {
                        ctx.Entry(clientePoliza).State = System.Data.Entity.EntityState.Deleted;
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




        public ClientePolizaViewModel ToClientesViewModel(ClientePoliza parametros)
        {

            try
            {
                return new ClientePolizaViewModel()
                {
                    IdClientePoliza=parametros.IdClientePoliza,
                    IdCliente = parametros.IdCliente,
                    IdPoliza = parametros.IdPoliza,
                    IdEstado = parametros.IdEstado,
                    PorcentajeCobertura = parametros.PorcentajeCobertura,
                    NombreEstado = Enum.GetName(typeof(Maestros.Estados), parametros.IdEstado),
                    Clientes= new ClientesViewModel() { Nombres = parametros.Clientes.Nombres,
                                                        Apellidos =parametros.Clientes.Apellidos,
                                                        Identificacion =parametros.Clientes.Identificacion,
                                                        IdTipoDocumento=parametros.Clientes.IdTipoDocumento},
                    Poliza= new PolizaViewModel() { Nombre=parametros.Poliza.Nombre,
                                                    Descripcion=parametros.Poliza.Descripcion}

                };
            }
            catch (Exception)
            {

                return new ClientePolizaViewModel();
            }
        }
    }





}
