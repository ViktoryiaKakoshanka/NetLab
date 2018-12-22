using Microsoft.VisualStudio.TestTools.UnitTesting;
using PolynomialProgram.Model;
using System.Collections.Generic;
using System.Diagnostics;
using PolynomialProgram.Helpers;

namespace PolynomialProgramTests
{
    [TestClass]
    public class PolynomialTests
    {
        private Polynomial _polynomialFirst;
        private Polynomial _polynomialSecond;

        [TestInitialize]
        public void TestInitialize()
        {
            var monomialsFirst = new Dictionary<int, double>()
            {
                {0, -5},
                {2, 3}
            };

            var monomialsSecond = new Dictionary<int, double>()
            {
                {0, 4},
                {2, -3},
                {5, -0.5}
            };

            _polynomialFirst = new Polynomial(2, monomialsFirst);
            _polynomialSecond = new Polynomial(5, monomialsSecond);
        }

        [TestMethod]
        public void Sum_returnNewPolynomial_Test()
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
        public void Subtract_ReturnNewPolynomial_Test()
        {
            var expectMonomials = new Dictionary<int, double>
            {
                {0, -9},
                {2, 6},
                {5, 0.5}
            };
            var expected = new Polynomial(5, expectMonomials);
            var actual = _polynomialFirst - _polynomialSecond;

            Debug.WriteLine($"expected = {expected} actual = {actual}");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Multiply_ReturnNewPolynomial_Test()
        {
            var expectMonomials = new Dictionary<int, double>()
            {
                {0, -20},
                {2, 27},
                {4, -9},
                {5, 2.5},
                {7, -1.5},
            };
            var expected = new Polynomial(7, expectMonomials);
            var actual = _polynomialFirst * _polynomialSecond;

            Debug.WriteLine($"expected = {expected} actual = {actual}");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MultiplyByConstant_ReturnNewPolynomial_Test()
        {
            var expectMonomials = new Dictionary<int, double>()
            {
                {0, -8},
                {2, 6},
                {5, 1}
            };
            var expected = new Polynomial(5, expectMonomials);
            var actual = _polynomialSecond * (-2);

            Debug.WriteLine($"expected = {expected} actual = {actual}");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToString_CorrectedOutput_Test()
        {
            const string expected = "-0.5x^5-3x^2+4";
            Assert.AreEqual(expected, _polynomialSecond.ToString());
        }

        [TestMethod]
        public void ImprovePolynomial_CorrectedPolynomial_Test()
        {
            var monomials = new Dictionary<int, double>()
            {
                {0, 4},
                {1, 0},
                {2, -3},
                {3, 0},
                {4, 0},
                {5, 0},
                {6, 0}
            };
            
            var polynomial = new Polynomial(6, monomials);

            var expected = new Polynomial(2, new Dictionary<int, double>
            {
                {0, 4},
                {1, 0},
                {2, -3}
            });

            Assert.AreEqual(expected, polynomial.CorrectPolynomial());
        }
    }
}
