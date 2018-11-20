using Microsoft.VisualStudio.TestTools.UnitTesting;
using VectorProgram.Model;
using System.Diagnostics;

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
        public void DifferenceOfVectors_returnedVectorDifference()
        {
            var expect = new Vector(-6, -6, -6);
            var actual = firstVector - secondVector;

            Debug.WriteLine($"expect = {expect} actual = {actual}");
            Assert.AreEqual(expect, actual);
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
        public void ScalarMultiplicationOfVectors_returnedScalarMultiplication()
        {
            var expect = 50;
            var actual = firstVector * secondVector;

            Debug.WriteLine($"{firstVector} * {secondVector}: expect = {expect} actual = {actual}");
            
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void Equals_returnedTrue()
        {
            var copyFirstVector = firstVector;
            var newVector = new Vector(1, 2, 3);
            bool actual;

            Debug.WriteLine($"firstVector {firstVector}");
            Debug.WriteLine($"copyFirstVector {copyFirstVector}");
            Debug.WriteLine($"newVector {newVector}");

            actual = Vector.Equals(copyFirstVector, firstVector);
            Debug.WriteLine($"Equals(copyFirstVector, firstVector) = {actual};");
            Assert.IsTrue(actual);

            actual = Vector.Equals(newVector, firstVector);
            Debug.WriteLine($"Equals(newVector, firstVector) = {actual}");
            Assert.IsTrue(actual);

            actual = newVector == firstVector;
            Debug.WriteLine($"newVector == firstVector: {actual}");
            Assert.IsTrue(actual);

            Debug.WriteLine($"Check the correctness of the property Equals:");
            Debug.WriteLine($"x.Equals(x) = true");
            Assert.IsTrue(firstVector.Equals(firstVector));

            Debug.WriteLine($"x.Equals(у) = y.Equals(x)");
            Assert.AreEqual(firstVector.Equals(secondVector), secondVector.Equals(firstVector));
            
            Debug.WriteLine($"If x.Equals(у) = true and y.Equals(z) = true then x.Equals(z) = true");
            actual = firstVector.Equals(copyFirstVector) && copyFirstVector.Equals(newVector) && firstVector.Equals(newVector);
            Assert.IsTrue(actual);
        }


        [TestMethod]
        public void Equals_returnedFalse()
        {
            var newVector = new Vector(1, 2, 3);

            bool actual;
            actual = Vector.Equals(secondVector, firstVector);
            Assert.IsFalse(actual);

            actual = newVector != firstVector;
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void GetHashCode_returnedEqualGetHashCode()
        {
            var copyFirstVector = firstVector;
            var newVector = new Vector(1, 2, 3);

            var hashCodeFirstVector = firstVector.GetHashCode();
            var hashCopyFirstVector = copyFirstVector.GetHashCode();
            var hashNewVector = newVector.GetHashCode();

            Debug.WriteLine($"HashCode first Vector {firstVector} = {hashCodeFirstVector}");
            Debug.WriteLine($"HashCode copy first Vector {copyFirstVector} = {hashCopyFirstVector}");
            Debug.WriteLine($"HashCode new Vector {newVector} = {hashNewVector}");

            Assert.AreEqual(hashCodeFirstVector, hashCopyFirstVector);
            Assert.AreEqual(hashCopyFirstVector, hashNewVector);
            Assert.AreEqual(hashCodeFirstVector, hashNewVector);
        }
    }
}
