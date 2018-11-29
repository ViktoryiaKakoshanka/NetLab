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
        public void Equals_IdenticalPolynomialsEqual_Test()
        {
            var newPolynomialFirst = new Polynomial(_polynomialFirst);

            Debug.WriteLine($"firstPolynomial {_polynomialFirst}");
            Debug.WriteLine($"newPolynomialFirst {newPolynomialFirst}");

            var actual = newPolynomialFirst.Equals(_polynomialFirst);
            Debug.WriteLine($"newPolynomialFirst.Equals(firstPolynomial) = {actual}");
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void Equals_CheckCorrectnessReflexivity_Test()
        {
            Debug.WriteLine($"x.Equals(x) = true");
            Assert.IsTrue(_polynomialFirst.Equals(_polynomialFirst));
        }

        [TestMethod]
        public void Equals_CheckCorrectnessSymmetry_Test()
        {
            Debug.WriteLine($"x.Equals(у) = y.Equals(x)");
            Assert.AreEqual(_polynomialFirst.Equals(_polynomialSecond), _polynomialSecond.Equals(_polynomialFirst));
        }

        [TestMethod]
        public void Equals_CheckCorrectnessTransitivity_Test()
        {
            var copyFirstPolynomial = new Polynomial(_polynomialFirst);
            var newPolynomialFirst = new Polynomial(_polynomialFirst);

            Debug.WriteLine($"If x.Equals(у) = true and y.Equals(z) = true then x.Equals(z) = true");
            var actual = _polynomialFirst.Equals(copyFirstPolynomial) && copyFirstPolynomial.Equals(newPolynomialFirst) && _polynomialFirst.Equals(newPolynomialFirst);
            Assert.IsTrue(actual);
        }


        [TestMethod]
        public void Equals_DifferentPolynomialsNotEqual_Test()
        {
            var actual = _polynomialSecond.Equals(_polynomialFirst);
            Debug.WriteLine($"polynomialSecond.Equals(firstPolynomial) = {actual}");
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void GetHashCode_ForSamePolynomialsEqual_Test()
        {
            var newPolynomialFirst = new Polynomial(_polynomialFirst);

            var hashCodeFirstPolynomial = _polynomialFirst.GetHashCode();
            var hashNewPolynomial = newPolynomialFirst.GetHashCode();

            Debug.WriteLine($"HashCode first Polynomial {_polynomialFirst} = {hashCodeFirstPolynomial}");
            Debug.WriteLine($"HashCode new Polynomial {newPolynomialFirst} = {hashNewPolynomial}");
            
            Assert.AreEqual(hashCodeFirstPolynomial, hashNewPolynomial);
        }

        [TestMethod]
        public void SumOfPolynomials_returnNewPolynomial_Test()
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
        public void DifferenceOfPolynomials_returnNewPolynomial_Test()
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
        public void MultiplicateOfPolynomials_returnNewPolynomial_Test()
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
        public void MultiplyNumberByPolynomial_returnNewPolynomial_Test()
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
