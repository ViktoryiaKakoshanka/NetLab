using Microsoft.VisualStudio.TestTools.UnitTesting;
using VectorProgram.Model;
using System.Diagnostics;
using VectorProgram.Controller;

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
        public void SumOfVectors_returnNewVector_Test()
        {
            var expected = new Vector(8, 10, 12);
            var actual = _firstVector + _secondVector;

            Debug.WriteLine($"expect = {expected} actual = {actual}");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DifferenceOfVectors_returnNewVector_Test()
        {
            var expected = new Vector(-6, -6, -6);
            var actual = _firstVector - _secondVector;

            Debug.WriteLine($"expect = {expected} actual = {actual}");
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void MultiplicationVectorsByNumber_returnNewVector_Test()
        {
            var expected = new Vector(-3, -6, -9);
            var actualOne = _firstVector * -3;
            var actualTwo = -3 * _firstVector;

            Debug.WriteLine($"{_firstVector} * (-3): expect = {expected} actual = {actualOne}");
            Debug.WriteLine($"(-3) * {_firstVector}: expect = {expected} actual = {actualOne}");
            
            Assert.AreEqual(expected, actualOne);
            Assert.AreEqual(expected, actualTwo);
        }

        [TestMethod]
        public void ScalarMultiplicationOfVectors_returnNumber_Test()
        {
            var expected = 50;
            var actual = VectorHelper.ScalarProduct(_firstVector, _secondVector);

            Debug.WriteLine($"{_firstVector} * {_secondVector}: expect = {expected} actual = {actual}");
            
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Equals_IdenticalVectorsEqual_Test()
        {
            var newVector = new Vector(1, 2, 3);

            Debug.WriteLine($"firstVector {_firstVector}");
            Debug.WriteLine($"newVector {newVector}");

            var actual = newVector.Equals(_firstVector);
            Debug.WriteLine($"Equals(newVector, firstVector) = {actual};");
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void Equals_CheckCorrectnessReflexivity_Test()
        {
            Debug.WriteLine("Check the correctness of the property Equals:");
            Debug.WriteLine("x.Equals(x) = true");
            Assert.IsTrue(_firstVector.Equals(_firstVector));
        }

        [TestMethod]
        public void Equals_CheckCorrectnessSymmetry_Test()
        {
            Debug.WriteLine("x.Equals(у) = y.Equals(x)");
            Assert.AreEqual(_firstVector.Equals(_secondVector), _secondVector.Equals(_firstVector));
        }

        [TestMethod]
        public void Equals_CheckCorrectnessTransitivity_Test()
        {
            var newVector = new Vector(1, 2, 3);
            var newFirstVector = new Vector(_firstVector);

            Debug.WriteLine("If x.Equals(у) = true and y.Equals(z) = true then x.Equals(z) = true");
            var actual = _firstVector.Equals(newFirstVector) && newFirstVector.Equals(newVector) && _firstVector.Equals(newVector);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void Equals_DifferentVectorsNotEqual_Test()
        {
            var actual = _secondVector.Equals(_firstVector);
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void GetHashCode_ForSameVectorsEqual_Test()
        {
            var newVector = new Vector(1, 2, 3);

            var hashCodeFirstVector = _firstVector.GetHashCode();
            var hashCodeNewVector = newVector.GetHashCode();

            Debug.WriteLine($"HashCode first Vector {_firstVector} = {hashCodeFirstVector}");
            Debug.WriteLine($"HashCode new Vector {newVector} = {hashCodeNewVector}");
            
            Assert.AreEqual(hashCodeFirstVector, hashCodeNewVector);
        }
    }
}
