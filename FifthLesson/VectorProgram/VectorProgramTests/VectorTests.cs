using Microsoft.VisualStudio.TestTools.UnitTesting;
using VectorProgram.Model;
using System.Diagnostics;

namespace VectorProgramTests
{
    [TestClass]
    public class VectorTests
    {
        private readonly Vector firstVector = new Vector(1, 2, 3);
        private readonly Vector secondVector = new Vector(7, 8, 9);
        
        [TestMethod]
        public void SumOfVectors_returnedVectorSum()
        {
            var expect = new Vector(8, 10, 12);
            var actual = firstVector + secondVector;

            Debug.WriteLine($"expect = {expect.ToString()} actual = {actual.ToString()}");
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void DifferenceOfVectors_returnedVectorDifference()
        {
            var expect = new Vector(-6, -6, -6);
            var actual = firstVector - secondVector;

            Debug.WriteLine($"expect = {expect.ToString()} actual = {actual.ToString()}");
            Assert.AreEqual(expect, actual);
        }


        [TestMethod]
        public void MultiplicationVectorsByNumber_returnedVectorMultiplicationByNumber()
        {
            var expect = new Vector(-3, -6, -9);
            var actualOne = firstVector * -3;
            var actualTwo = -3 * firstVector;

            Debug.WriteLine($"{firstVector.ToString()} * (-3): expect = {expect.ToString()} actual = {actualOne.ToString()}");
            Debug.WriteLine($"(-3) * {firstVector.ToString()}: expect = {expect.ToString()} actual = {actualOne.ToString()}");
            
            Assert.AreEqual(expect, actualOne);
            Assert.AreEqual(expect, actualTwo);
            Assert.AreEqual(actualOne, actualTwo);
        }

        [TestMethod]
        public void ScalarMultiplicateOfVectors_returnedVectorScalarMultiplication()
        {
            var expect = new Vector(7, 16, 27);
            var actual = firstVector * secondVector;

            Debug.WriteLine($"{firstVector.ToString()} * {secondVector.ToString()}: expect = {expect.ToString()} actual = {actual.ToString()}");
            
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void Equals_returnedTrue()
        {
            var copyFirstVector = firstVector;
            var newVector = new Vector(1, 2, 3);
            bool actual;

            Debug.WriteLine($"firstVector {firstVector.ToString()}");
            Debug.WriteLine($"copyFirstVector {copyFirstVector.ToString()}");
            Debug.WriteLine($"newVector {newVector.ToString()}");

            actual = Vector.Equals(copyFirstVector, firstVector);
            Debug.WriteLine($"Equals(copyFirstVector, firstVector) = {actual};");
            Assert.AreEqual(true, actual);

            actual = Vector.Equals(newVector, firstVector);
            Debug.WriteLine($"Equals(newVector, firstVector) = {actual}");
            Assert.AreEqual(true, actual);

            actual = newVector == firstVector;
            Debug.WriteLine($"newVector == firstVector: {actual}");
            Assert.AreEqual(true, actual);

            Debug.WriteLine($"Check the correctness of the property Equals:");
            Debug.WriteLine($"x.Equals(x) = true");
            Assert.AreEqual(true, firstVector.Equals(firstVector));

            Debug.WriteLine($"x.Equals(у) = y.Equals(x)");
            Assert.AreEqual(firstVector.Equals(secondVector), secondVector.Equals(firstVector));
            
            Debug.WriteLine($"If x.Equals(у) = true and y.Equals(z) = true then x.Equals(z) = true");
            actual = firstVector.Equals(copyFirstVector) && copyFirstVector.Equals(newVector) && firstVector.Equals(newVector);
            Assert.AreEqual(true, actual);
        }


        [TestMethod]
        public void Equals_returnedFalse()
        {
            var newVector = new Vector(1, 2, 3);

            bool actual;
            actual = Vector.Equals(secondVector, firstVector);
            Assert.AreEqual(false, actual);

            actual = newVector != firstVector;
            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void GetHashCode_returnedEqualGetHashCode()
        {
            var copyFirstVector = firstVector;
            var newVector = new Vector(1, 2, 3);

            var hashCodeFirstVector = firstVector.GetHashCode();
            var hashCopyFirstVector = copyFirstVector.GetHashCode();
            var hashNewVector = newVector.GetHashCode();

            Debug.WriteLine($"HashCode first Vector {firstVector.ToString()} = {hashCodeFirstVector.ToString()}");
            Debug.WriteLine($"HashCode copy first Vector {copyFirstVector.ToString()} = {hashCopyFirstVector.ToString()}");
            Debug.WriteLine($"HashCode new Vector {newVector.ToString()} = {hashNewVector.ToString()}");

            Assert.AreEqual(hashCodeFirstVector, hashCopyFirstVector);
            Assert.AreEqual(hashCopyFirstVector, hashNewVector);
            Assert.AreEqual(hashCodeFirstVector, hashNewVector);
        }
    }
}
