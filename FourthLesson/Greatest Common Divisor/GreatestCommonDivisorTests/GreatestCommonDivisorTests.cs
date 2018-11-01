using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GreatestCommonDivisorProgram.Controller;

namespace GreatestCommonDivisorTests
{
    [TestClass]
    public class GreatestCommonDivisorTests
    {
        [TestMethod]
        public void GCDEuclideanAlgorithmTest_30_18_returned_6()
        {
            var a = GreatestCommonDivisor.GCDEuclideanAlgorithm(30, 18);
            Assert.AreEqual(6, a);
        }

        [TestMethod]
        public void GCDEuclideanAlgorithmTest_30_18_42_returned_6()
        {
            var a = GreatestCommonDivisor.GCDEuclideanAlgorithm(30, 18, 42);
            Assert.AreEqual(6, a);
        }
    }
}
