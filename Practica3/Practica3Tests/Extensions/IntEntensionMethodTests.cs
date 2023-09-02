using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practica3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica3.Tests
{
    [TestClass()]
    public class IntEntensionMethodTests
    {
        [TestMethod()]
        public void SumarCincuentaTest()
        {
            //Arrange
            int numero = 50;

            //Act
            numero = numero.SumarCincuenta();

            //Assert
            Assert.AreEqual(numero, 100);
        }

        [TestMethod()]
        public void DividirALaMitadTest()
        {
            //Arrange
            int numero = 50;

            //Act
            numero = numero.DividirALaMitad();

            //Assert
            Assert.AreEqual(numero, 25);
        }
    }
}