using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InsuranceAppi.Controllers;
using InsuranceViewModel;
using InsuranceAppi;
using System.Collections.Generic;

namespace InsuranceUnitTest
{
    [TestClass]
    public class UnitTest1
    {

        private ClientesController instanciaController;
        private InsuranceAppi.Models.ClientesMock instanciaMock;
        private TestContext testContextInstance;


        public UnitTest1()
        {
            this.instanciaMock = InsuranceAppi.Models.ClientesMock.ObtenerInstancia();
            this.instanciaController = InsuranceAppi.Controllers.ClientesController.ObtenerInstancia(instanciaMock);
        }

        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }


        [TestMethod]
        public void TestMethod1()
        {
            

           var  respuesta =  this.instanciaController.GetAllCliente();

            Assert.IsTrue(true==true);


        }
    }
}
