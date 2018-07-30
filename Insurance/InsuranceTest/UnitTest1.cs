using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InsuranceViewModel;


namespace InsuranceTest
{
    [TestClass]
    public class UnitTest1
    {

        InsuranceAppi.Models.ClientePoliza clientePoliza = new InsuranceAppi.Models.ClientePoliza();

        [TestMethod]
        public void TestMethod1()
        {

            ClientePolizaViewModel parametros = new ClientePolizaViewModel();

            parametros.IdCliente = 1;
            parametros.IdPoliza = 13;
            parametros.PorcentajeCobertura = 80;
            var respuesta = clientePoliza.PostClientePoliza(parametros);

            Assert.IsTrue(respuesta.response);
        }
    }
}
