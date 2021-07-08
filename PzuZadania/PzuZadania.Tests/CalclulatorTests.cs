using Microsoft.VisualStudio.TestTools.UnitTesting;

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
    }
}
