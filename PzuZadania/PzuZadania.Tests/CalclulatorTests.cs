using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace PzuZadania.Tests
{
    [TestClass]
    public class CalclulatorTests
    {
        [TestMethod]
        public void SumShouldReturnSum()
        {
            // Arrange
            Calculator calculator = new Calculator();
            int x = 2, y = 4;
            int expected = 6;
            int actual;

            // Act
            actual = calculator.Sum(x, y);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SubtractShouldReturnDifference()
        {
            // Arrange
            Calculator calculator = new Calculator();
            int x = 2, y = 4;
            int expected = -2;
            int actual;

            // Act
            actual = calculator.Subtract(x, y);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MultiplyShouldReturnQuotient()
        {
            // Arrange
            Calculator calculator = new Calculator();
            int x = 2, y = 4;
            int expected = 8;
            int actual;

            // Act
            actual = calculator.Multiply(x, y);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DivideShouldReturnProduct()
        {
            // Arrange
            Calculator calculator = new Calculator();
            int x = 2, y = 4;
            float expected = 0.5f;
            float actual;

            // Act
            actual = calculator.Divide(x, y);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ModuloShouldReturnRemainderOfDivision()
        {
            // Arrange
            Calculator calculator = new Calculator();
            int x = 2, y = 4;
            int expected = 2;
            float actual;

            // Act
            actual = calculator.Modulo(x, y);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ModuloShouldThrowExceptionWhenSecondParameterIsZero()
        {
            // Arrange
            Calculator calculator = new Calculator();
            int x = 2, y = 0;

            // Act & Assert
            Assert.ThrowsException<DivideByZeroException>(() => calculator.Modulo(x, y));
        }
    }
}
