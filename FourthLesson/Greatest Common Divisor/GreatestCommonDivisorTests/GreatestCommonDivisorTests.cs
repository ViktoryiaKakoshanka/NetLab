using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Greatest_Common_Divisor.Controller;

namespace GreatestCommonDivisorTests
{
    [TestClass]
    public class GreatestCommonDivisorTests
    {
        [TestMethod]
        public void EuclideanGcdAlgorithmTest_returned_GCD()
        {
            int actual;
            int count = 0;
            var arr = new int[][]
            {
                new[] {30, 18 },
                new[] {0, 18 },
                new[] {0, 0 },
                new[] {-5, 45 },
                new[] { 18, 30 }
            };

            var expected = new int[] { 6, 18, 1, 5, 6};
            foreach (var item in arr)
            {
                actual = new EuclideanGcdAlgorithm().Calculate(item).Gcd;
                Assert.AreEqual(expected[count], actual);
                count++;
            }
        }

        [TestMethod]
        public void EuclideanGcdAlgorithmTest_30_18_42_returned_6()
        {
            var arr = new[] { 30, 18, 42 };
            var a = new EuclideanGcdAlgorithm().Calculate(arr).Gcd;
            Assert.AreEqual(6, a);
        }

        [TestMethod]
        public void StainGcdAlgorithmTest_returned_GCD()
        {
            int actual;
            int count = 0;
            var arr = new int[4][];
            arr[0] = new[] { 30, 18 };
            arr[1] = new[] { 0, 18 };
            arr[2] = new[] { 0, 0 };
            arr[3] = new[] { -5, 45 };

            var expected = new int[] { 6, 18, 1, 5 };
            foreach (var item in arr)
            {
                actual = new StainGcdAlgorithm().Calculate(item).Gcd;
                Assert.AreEqual(expected[count], actual);
                count++;
            }
        }
    }
}
