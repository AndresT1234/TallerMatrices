using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Taller1_Matrices
{
    [TestClass]
    public class PruebasAssertTests
    {
        [TestMethod]
        public void Potencia_Matriz2X2_Potencia3()
        {
            // Arrange
            Matriz matriz = new Matriz(2, 2);
            matriz.GetMatrix()[0, 0] = 2;
            matriz.GetMatrix()[0, 1] = 2;
            matriz.GetMatrix()[1, 0] = 2;
            matriz.GetMatrix()[1, 1] = 2;

            // Act
            Matriz resultado = matriz.Potencia(3);

            // Assert
            Assert.AreEqual(32, resultado.GetMatrix()[0, 0]);
            Assert.AreEqual(32, resultado.GetMatrix()[0, 1]);
            Assert.AreEqual(32, resultado.GetMatrix()[1, 0]);
            Assert.AreEqual(32, resultado.GetMatrix()[1, 1]);
        }

        [TestMethod]
        public void Potencia_Matriz2X2_Potencia5()
        {
            // Arrange
            Matriz matriz = new Matriz(2, 2);
            matriz.GetMatrix()[0, 0] = 1;
            matriz.GetMatrix()[0, 1] = 2;
            matriz.GetMatrix()[1, 0] = 3;
            matriz.GetMatrix()[1, 1] = 4;

            // Act
            Matriz resultado = matriz.Potencia(5);

            // Assert
            Assert.AreEqual(1069, resultado.GetMatrix()[0, 0]);
            Assert.AreEqual(1558, resultado.GetMatrix()[0, 1]);
            Assert.AreEqual(2337, resultado.GetMatrix()[1, 0]);
            Assert.AreEqual(3406, resultado.GetMatrix()[1, 1]);
        }

        [TestMethod]
        public void Potencia_Matriz3x3_Potencia3()
        {
            // Arrange
            Matriz matriz = new Matriz(3, 3);
            matriz.GetMatrix()[0, 0] = 1;
            matriz.GetMatrix()[0, 1] = 2;
            matriz.GetMatrix()[0, 2] = 3;
            matriz.GetMatrix()[1, 0] = 4;
            matriz.GetMatrix()[1, 1] = 5;
            matriz.GetMatrix()[1, 2] = 6;
            matriz.GetMatrix()[2, 0] = 7;
            matriz.GetMatrix()[2, 1] = 8;
            matriz.GetMatrix()[2, 2] = 9;

            // Act
            Matriz resultado = matriz.Potencia(3);

            // Assert
            Assert.AreEqual(468, resultado.GetMatrix()[0, 0]);
            Assert.AreEqual(576, resultado.GetMatrix()[0, 1]);
            Assert.AreEqual(684, resultado.GetMatrix()[0, 2]);
            Assert.AreEqual(1062, resultado.GetMatrix()[1, 0]);
            Assert.AreEqual(1305, resultado.GetMatrix()[1, 1]);
            Assert.AreEqual(1548, resultado.GetMatrix()[1, 2]);
            Assert.AreEqual(1656, resultado.GetMatrix()[2, 0]);
            Assert.AreEqual(2034, resultado.GetMatrix()[2, 1]);
            Assert.AreEqual(2412, resultado.GetMatrix()[2, 2]);
        }
        
    }
}