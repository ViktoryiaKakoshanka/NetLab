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
            var numbers = new[]
            {
                new[] {30, 18 },
                new[] {0, 18 },
                new[] {0, 0 },
                new[] {-5, 45 },
                new[] { 18, 30 }
            };

            var expected = new[] { 6, 18, 1, 5, 6};

            for (var i = 0; i < numbers.Length; i++)
            {
                var actual = new EuclideanAlgorithm().Calculate(numbers[i]).GreatestCommonDivisor;
                Assert.AreEqual(expected[i], actual);
            }
        }

        [TestMethod]
        public void TestEuclideanGcdAlgorithm_30_18_42_returned_6()
        {
            var arr = new[] { 30, 18, 42 };
            var a = new EuclideanAlgorithm().Calculate(arr).GreatestCommonDivisor;
            Assert.AreEqual(6, a);
        }

        [TestMethod]
        public void TestStainGcdAlgorithm_GCD()
        {
            var numbers = new[]
            {
                new[] {30, 18 },
                new[] {0, 18 },
                new[] {0, 0 },
                new[] {-5, 45 }
            };

            var expected = new[] { 6, 18, 1, 5 };

            for (var i = 0; i < numbers.Length; i++)
            {
                var actual = new StainAlgorithm().Calculate(numbers[i]).GreatestCommonDivisor;
                Assert.AreEqual(expected[i], actual);
            }
        }
    }
}
