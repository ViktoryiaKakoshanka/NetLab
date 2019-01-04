using Greatest_Common_Divisor.Algorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GreatestCommonDivisorTests
{
    [TestClass]
    public class GreatestCommonDivisorTests
    {
        [TestMethod]
        public void TestEuclideanGcdAlgorithm_GCD()
        {
            var euclideanAlgorithm = new EuclideanAlgorithm();
            var numbers = new[]
            {
                new[] {30, 18 },
                new[] {5, 45 },
                new[] { 18, 30 }
            };

            var expected = new[] { 6, 5, 6};

            for (var i = 0; i < numbers.Length; i++)
            {
                var actual = euclideanAlgorithm.Calculate(numbers[i]).GreatestCommonDivisor;
                Assert.AreEqual(expected[i], actual);
            }
        }

        [TestMethod]
        public void TestEuclideanGcdAlgorithm_30_18_42_returned_6()
        {
            var numbers = new[] { 30, 18, 42 };
            var euclideanAlgorithm = new EuclideanAlgorithm();

            var actual = euclideanAlgorithm.Calculate(numbers).GreatestCommonDivisor;

            Assert.AreEqual(6, actual);
        }

        [TestMethod]
        public void TestStainGcdAlgorithm_GCD()
        {
            var stainAlgorithm = new StainAlgorithm();
            var numbers = new[]
            {
                new[] {30, 18 },
                new[] {5, 45 },
                new[] { 18, 30 }
            };

            var expected = new[] { 6, 5, 6 };

            for (var i = 0; i < numbers.Length; i++)
            {
                var actual = stainAlgorithm.Calculate(numbers[i]).GreatestCommonDivisor;
                Assert.AreEqual(expected[i], actual);
            }
        }
    }
}
