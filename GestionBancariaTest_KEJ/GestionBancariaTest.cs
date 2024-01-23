using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using GestionBancariaAppNS;

namespace GestionBancariaTest_KEJ
{
    [TestClass]
    public class GestionBancariaTest
    {
        [TestMethod]
        public void TestMethod1()
        {
        }
        [TestMethod]
        public void ValidarReintegro()
        {
            //Variables para el caso de pruebas
            double saldoInicial = 1000;
            double reintegro = 250;
            double saldoEsperado = 750;

            GestionBancariaApp miAplicacion = new GestionBancariaApp(saldoInicial);

            //Metodo que se va a probar
            miAplicacion.RealizarReintegro(reintegro);

            //Aqui se compara si el saldo esperado es igual a lo que devolvío la aplicacion, con una precisión de 0,001 si esto no se cumple
            //dará error
            Assert.AreEqual(saldoEsperado, miAplicacion.ObtenerSaldo(), 0.001, "Se produjo un error al realizar el reintegro, saldo incorrecto");
        }

        [TestMethod]
        public void RelizarReingresoTest()
        {
            GestionBancariaApp miApp = new GestionBancariaApp();

            // Casos de prueba para RealizarIngreso
            Assert.AreEqual(0, miApp.RealizarIngreso(50));// Cantidad válida
            Assert.AreEqual(1, miApp.RealizarIngreso(0));// Cantidad no válida
        }

        [TestMethod]
        public void RealizarReintegroTest()
        {
            //Genero un objeto de la aplicación le otorgo 1000 de saldo para iniciar las pruebas
            GestionBancariaApp miApp = new GestionBancariaApp(1000);

            miApp.RealizarReintegro(250);

            //Casos de prueba para el reintegro
            Assert.AreEqual(0, miApp.RealizarReintegro(50));//Cantidad valida
            Assert.AreEqual(1, miApp.RealizarReintegro(-10));//Cantidad no valida
            Assert.AreEqual(750, miApp.ObtenerSaldo(), 0.001, "Error al hacer el reintegro");//Saldo insuficiente, devuelve 2
        }
    }
 
}
