using Microsoft.VisualStudio.TestTools.UnitTesting;
using PolynomialProgram.Model;
using System.Collections.Generic;
using System.Diagnostics;

namespace PolynomialProgramTests
{
    [TestClass]
    public class PolynomialTests
    {
        Polynomial _polynomialFirst;
        Polynomial _polynomialSecond;

        [TestInitialize]
        public void TestInitialize()
        {
            var monomialsFirst = new Dictionary<int, double>()
            {
                {0, -5},
                {1, 0},
                {2, 3},
            };

            var monomialsSecond = new Dictionary<int, double>()
            {
                {0, 4},
                {1, 0},
                {2, -3},
                {3, 0},
                {4, 0},
                {5, -0.5},
            };

            _polynomialFirst = new Polynomial(2, monomialsFirst);
            _polynomialSecond = new Polynomial(5, monomialsSecond);
        }

        [TestMethod]
        public void Equals_returnedTrue()
        {
            var copyFirstPolynomial = _polynomialFirst;
            var newPolynomialFirst = new Polynomial(_polynomialFirst);
            bool actual;

            Debug.WriteLine($"firstPolynomial {_polynomialFirst}");
            Debug.WriteLine($"copyFirstPolynomial {copyFirstPolynomial}");
            Debug.WriteLine($"newPolynomialFirst {newPolynomialFirst}");

            actual = Equals(copyFirstPolynomial, _polynomialFirst);
            Debug.WriteLine($"Equals(copyFirstPolynomial, firstPolynomial) = {actual};");
            Assert.IsTrue(actual);

            actual = Equals(newPolynomialFirst, _polynomialFirst);
            Debug.WriteLine($"Equals(newPolynomialFirst, firstPolynomial) = {actual}");
            Assert.IsTrue(actual);

            actual = newPolynomialFirst == _polynomialFirst;
            Debug.WriteLine($"newVector == firstVector: {actual}");
            Assert.IsTrue(actual);

            Debug.WriteLine($"Check the correctness of the property Equals:");
            Debug.WriteLine($"x.Equals(x) = true");
            Assert.IsTrue(_polynomialFirst.Equals(_polynomialFirst));

            Debug.WriteLine($"x.Equals(у) = y.Equals(x)");
            Assert.AreEqual(_polynomialFirst.Equals(_polynomialSecond), _polynomialSecond.Equals(_polynomialFirst));

            Debug.WriteLine($"If x.Equals(у) = true and y.Equals(z) = true then x.Equals(z) = true");
            actual = _polynomialFirst.Equals(copyFirstPolynomial) && copyFirstPolynomial.Equals(newPolynomialFirst) && _polynomialFirst.Equals(newPolynomialFirst);
            Assert.IsTrue(actual);
        }
        
        [TestMethod]
        public void Equals_returnedFalse()
        {
            bool actual;
            actual = Polynomial.Equals(_polynomialSecond, _polynomialFirst);
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void GetHashCode_returnedEqualGetHashCode()
        {
            var copyRefFirstPolynomial = _polynomialFirst;
            var newPolynomialFirst = new Polynomial(_polynomialFirst);

            var hashCodeFirstPolynomial = _polynomialFirst.GetHashCode();
            var hashCopyFirstPolynomial = copyRefFirstPolynomial.GetHashCode();
            var hashNewPolynomial = newPolynomialFirst.GetHashCode();

            Debug.WriteLine($"HashCode first Polynomial {_polynomialFirst} = {hashCodeFirstPolynomial}");
            Debug.WriteLine($"HashCode copy ref first Polynomial {copyRefFirstPolynomial} = {hashCopyFirstPolynomial}");
            Debug.WriteLine($"HashCode new Polynomial {newPolynomialFirst} = {hashNewPolynomial}");

            Assert.AreEqual(hashCodeFirstPolynomial, hashCopyFirstPolynomial);
            Assert.AreEqual(hashCopyFirstPolynomial, hashNewPolynomial);
            Assert.AreEqual(hashCodeFirstPolynomial, hashNewPolynomial);
        }

        [TestMethod]
        public void SumOfPolynomials_returnedPolynomialSum()
        {
            var expectMonomials = new Dictionary<int, double>()
            {
                {0, -1},
                {1, 0},
                {2, 0},
                {3, 0},
                {4, 0},
                {5, -0.5},
            };
            var expected = new Polynomial(5, expectMonomials);
            var actual = _polynomialFirst + _polynomialSecond;

            Debug.WriteLine($"expected = {expected} actual = {actual}");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DifferenceOfPolynomials_returnedPolynomialDifference()
        {
            var expectMonomials = new Dictionary<int, double>()
            {
                {0, -9},
                {1, 0},
                {2, 6},
                {3, 0},
                {4, 0},
                {5, -0.5},
            };
            var expected = new Polynomial(5, expectMonomials);
            var actual = _polynomialFirst - _polynomialSecond;

            Debug.WriteLine($"expected = {expected} actual = {actual}");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MultiplicateOfPolynomials_returnedPolynomialMultiplication()
        {
            var expectMonomials = new Dictionary<int, double>()
            {
                {0, -20},
                {1, 0},
                {2, 27},
                {3, 0},
                {4, 6},
                {5, 2.5},
                {6, 0},
                {7, -1.5},
            };
            var expected = new Polynomial(7, expectMonomials);
            var actual = _polynomialFirst * _polynomialSecond;

            Debug.WriteLine($"expected = {expected} actual = {actual}");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MultiplyNumberByPolynomial_returnedPolynomialMultiplicationByNumber()
        {
            var expectMonomials = new Dictionary<int, double>()
            {
                {0, -8},
                {1, 0},
                {2, 6},
                {3, 0},
                {4, 0},
                {5, 1},
            };
            var expected = new Polynomial(5, expectMonomials);
            var actual = _polynomialSecond * (-2);

            Debug.WriteLine($"expected = {expected} actual = {actual}");
            Assert.AreEqual(expected, actual);
        }
    }
}
