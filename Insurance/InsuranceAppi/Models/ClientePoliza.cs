namespace InsuranceAppi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using Entities;

    [Table("ClientePoliza")]
    public partial class ClientePoliza
    {
        [Key]
        public int IdClientePoliza { get; set; }

        public int? IdCliente { get; set; }

        public int? IdPoliza { get; set; }

        public int? IdEstado { get; set; }

        public virtual Clientes Clientes { get; set; }

        public virtual Poliza Poliza { get; set; }


        public List<ClientePoliza> GetAllClientePoliza()
        {
            List<ClientePoliza> respuesta = new List<ClientePoliza>();
            try
            {
                using (InsuranceContext ctx = new InsuranceContext())
                {
                    respuesta = ctx.ClientePoliza
                        .Include("Clientes")
                        .Include("Poliza")
                        .ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return respuesta;
        }

        public ClientePoliza GetClientePolizaById(int parametro)
        {
            var respuesta = new ClientePoliza();
            try
            {
                using (InsuranceContext ctx = new InsuranceContext())
                {

                    respuesta = ctx.ClientePoliza
                        .Include("Clientes")
                        .Include("Poliza").SingleOrDefault();
                }
            }
            catch (Exception)
            {

                return new ClientePoliza();
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
                    var clientePoliza = ctx.ClientePoliza.Where(x => x.IdClientePoliza == parametros.IdClientePoliza).SingleOrDefault();
                    if (clientePoliza != null)
                    {
                        clientePoliza.IdCliente = parametros.IdCliente;
                        clientePoliza.IdPoliza = parametros.IdPoliza;
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


        public ResponseModel PostClientePoliza(ClientePoliza parametros)
        {
            ResponseModel respuesta = new ResponseModel();
            try
            {
                using (InsuranceContext ctx = new InsuranceContext())
                {
                    ctx.ClientePoliza.Add(new ClientePoliza
                    {
                        IdCliente = parametros.IdCliente,
                        IdPoliza = parametros.IdPoliza,
                        IdEstado = 1,

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
    }





}
