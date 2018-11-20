using Microsoft.VisualStudio.TestTools.UnitTesting;
using TriangleLib.Controller;

namespace TriangleTests
{
    [TestClass]
    public class ValidateTriangleHelperTests
    {
        [TestMethod]
        public void ValidateTriangleTest_returnedTrue()
        {
            var a = 1.0;
            var b = 2.0;
            var c = new double[] { 1.0, 2.0, 3.0, 4.0 };
            var expected = new bool[] { true, true, true, false };
            bool actual;

            for (var i = 0; i < c.Length; i++)
            {
                actual = Validator.ValidateTriangle(a, b, c[i]);

                Assert.AreEqual(expected[i], actual, $"Validate Triangle: expected={expected[i]}, actual={actual}");
            }
        }

        [TestMethod]
        public void TryParseInputtingSideTest_returnedDouble()
        {
            var diferentVariants = new string[] { "3.0", "3,0", "kj", " " };
            var expectedVariants = new double[] { 3.0, 3.0, 0.0, 0.0 };

            for (var i = 0; i<diferentVariants.Length; i++)
            {
                var actual = Validator.TryParseInputtingSide(diferentVariants[i]);
                Assert.AreEqual(expectedVariants[i], actual, $"expected={expectedVariants[i]}, actual={actual}");
            }
        }
    }
}
