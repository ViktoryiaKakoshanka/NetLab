using Microsoft.VisualStudio.TestTools.UnitTesting;
using VectorProgram.Model;
using System.Diagnostics;
using VectorProgram.Helpers;

namespace VectorProgramTests
{
    [TestClass]
    public class VectorTests
    {
        private Vector _firstVector;
        private Vector _secondVector;
        
        [TestInitialize]
        public void TestInitialize()
        {
            _firstVector = new Vector(1, 2, 3);
            _secondVector = new Vector(7, 8, 9);
        }

        [TestMethod]
        public void SumOfVectors_ReturnNewVector_Test()
        {
            var expected = new Vector(8, 10, 12);
            var actual = _firstVector + _secondVector;

            Debug.WriteLine($"expect = {expected} actual = {actual}");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DifferenceOfVectors_ReturnNewVector_Test()
        {
            var expected = new Vector(-6, -6, -6);
            var actual = _firstVector - _secondVector;

            Debug.WriteLine($"expect = {expected} actual = {actual}");
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void MultiplicationVectorsByNumber_ReturnNewVector_Test()
        {
            var expected = new Vector(-3, -6, -9);
            var actual = _firstVector * -3;

            Debug.WriteLine($"{_firstVector} * (-3): expect = {expected} actual = {actual}");
            
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ScalarMultiplicationOfVectors_ReturnNumber_Test()
        {
            const int expected = 50;
            var actual = VectorHelper.CalculateScalarProduct(_firstVector, _secondVector);

            Debug.WriteLine($"{_firstVector} * {_secondVector}: expect = {expected} actual = {actual}");
            
            Assert.AreEqual(expected, actual);
        }
    }
}