using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GreatestCommonDivisorProgram.Controller;

namespace GreatestCommonDivisorTests
{
    [TestClass]
    public class GreatestCommonDivisorTests
    {
        GreatestCommonDivisor gcd = new GreatestCommonDivisor();
        [TestMethod]
        public void GCDEuclideanAlgorithmTest_returned_GCD()
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

            var expected = new int[] { 6, 1, 1, 5, 6};
            foreach (var item in arr)
            {
                gcd = new GreatestCommonDivisor();
                actual = gcd.GCDEuclideanAlgorithm(item[0], item[1], out int pass);
                Assert.AreEqual(expected[count], actual);
                count++;
            }
        }

        [TestMethod]
        public void GCDEuclideanAlgorithmTest_30_18_42_returned_6()
        {
            var a = gcd.GCDEuclideanAlgorithm(30, 18, 42, out int pass);
            Assert.AreEqual(6, a);
        }

        [TestMethod]
        public void GCDStainAlgorithmTest_returned_GCD()
        {
            int actual;
            int count = 0;
            var arr = new int[4][];
            arr[0] = new[] { 30, 18 };
            arr[1] = new[] { 0, 18 };
            arr[2] = new[] { 0, 0 };
            arr[3] = new[] { -5, 45 };

            var expected = new int[] { 6, 1, 1, 5 };
            foreach (var item in arr)
            {
                actual = gcd.GCDEuclideanAlgorithm(item[0], item[1], out int pass);
                Assert.AreEqual(expected[count], actual);
                count++;
            }
        }
    }
}
