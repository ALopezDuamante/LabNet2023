using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Practica2;

namespace PracticaTests
{
    [TestClass]
    public class TestEjercicio1
    {
        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void Ejercicio1_DevuelveException()
        {
            //Arrange
            int dividendo = 1;
            int divisor = 0;

            //Act
            MetodosEx.Ejercicio2();

            //Assert
        }
    }
}
