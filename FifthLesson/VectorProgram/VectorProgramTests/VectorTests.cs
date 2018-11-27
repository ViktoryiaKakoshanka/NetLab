using Microsoft.VisualStudio.TestTools.UnitTesting;
using VectorProgram.Model;
using System.Diagnostics;
using VectorProgram.Controller;

namespace VectorProgramTests
{
    [TestClass]
    public class VectorTests
    {
        Vector firstVector;
        Vector secondVector;
        
        [TestInitialize]
        public void TestInitialize()
        {
            firstVector = new Vector(1, 2, 3);
            secondVector = new Vector(7, 8, 9);
        }

        [TestMethod]
        public void SumOfVectors_returnedVectorSum()
        {
            var expect = new Vector(8, 10, 12);
            var actual = firstVector + secondVector;

            Debug.WriteLine($"expect = {expect} actual = {actual}");
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void DifferenceOfVectors_returnNewVector_Test()
        {
            var expected = new Vector(-6, -6, -6);
            var actual = firstVector - secondVector;

            Debug.WriteLine($"expect = {expected} actual = {actual}");
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void MultiplicationVectorsByNumber_returnedVectorMultiplicationByNumber()
        {
            var expect = new Vector(-3, -6, -9);
            var actualOne = firstVector * -3;
            var actualTwo = -3 * firstVector;

            Debug.WriteLine($"{firstVector} * (-3): expect = {expect} actual = {actualOne}");
            Debug.WriteLine($"(-3) * {firstVector}: expect = {expect} actual = {actualOne}");
            
            Assert.AreEqual(expect, actualOne);
            Assert.AreEqual(expect, actualTwo);
            Assert.AreEqual(actualOne, actualTwo);
        }

        [TestMethod]
        public void ScalarMultiplicationOfVectors_returnNumber_Test()
        {
            var expected = 50;
            var actual = VectorHelper.CalculateScalarMultiplication(firstVector, secondVector);

            Debug.WriteLine($"{firstVector} * {secondVector}: expect = {expected} actual = {actual}");
            
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Equals_returnedTrue()
        {
            var newVector = new Vector(1, 2, 3);
            bool actual;

            Debug.WriteLine($"firstVector {firstVector}");
            Debug.WriteLine($"newVector {newVector}");

            actual = newVector.Equals(firstVector);
            Debug.WriteLine($"Equals(newVector, firstVector) = {actual};");
            Assert.IsTrue(actual);
        }
        [TestMethod]
        public void CheckTheCorrectnessFirstProperty()
        {
            Debug.WriteLine($"Check the correctness of the property Equals:");
            Debug.WriteLine($"x.Equals(x) = true");
            Assert.IsTrue(firstVector.Equals(firstVector));
        }
        [TestMethod]
        public void CheckTheCorrectnessSecondProperty()
        {
            Debug.WriteLine($"x.Equals(у) = y.Equals(x)");
            Assert.AreEqual(firstVector.Equals(secondVector), secondVector.Equals(firstVector));
        }

        [TestMethod]
        public void Equals_CheckTheCorrectnessThirdProperty(Vector copyRefFirstVector, Vector newVector)
        {
            bool actual;
            Debug.WriteLine($"If x.Equals(у) = true and y.Equals(z) = true then x.Equals(z) = true");
            actual = firstVector.Equals(copyRefFirstVector) && copyRefFirstVector.Equals(newVector) && firstVector.Equals(newVector);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void Equals_DifferentVectorsNotEqual_Test()
        {
            bool actual;
            actual = secondVector.Equals(firstVector);
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void GetHashCode_ForSameVectorsAreEqual_Test()
        {
            var newVector = new Vector(1, 2, 3);

            var hashCodeFirstVector = firstVector.GetHashCode();
            var hashCodeNewVector = newVector.GetHashCode();

            Debug.WriteLine($"HashCode first Vector {firstVector} = {hashCodeFirstVector}");
            Debug.WriteLine($"HashCode new Vector {newVector} = {hashCodeNewVector}");
            
            Assert.AreEqual(hashCodeFirstVector, hashCodeNewVector);
        }
    }
}
