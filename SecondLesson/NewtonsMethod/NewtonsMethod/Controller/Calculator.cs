using System;

namespace NewtonsMethod.Controller
{
    public class Calculator : ICalculator
    {
        public double CalculateMathPow(double @base, int power) => Math.Pow(@base, power);

        public double CalculateRoot(int degree, double radicand, double accuracy)
        {
            var previousRoot = 1.0;
            var currentRoot = 1.0;
            var currentAccuracy = 0.0;

            do
            {
                currentRoot = CalculateRootByNewtonMethod(degree, radicand, previousRoot);
                currentAccuracy = Math.Abs(previousRoot - currentRoot);
                previousRoot = currentRoot;
            } while (currentAccuracy > accuracy);

            return currentRoot;
        }

        public bool ValidateRoot(double root, int power, double radicant, double accuracy)
        {
            return Math.Abs(Math.Pow(root, power) - radicant) <= accuracy;
        }

        private double CalculateRootByNewtonMethod(int degree, double radicand, double previousRoot)
        {
            var rootInPower = CalculatorHelper.RaiseToPower(previousRoot, degree - 1);

            var numerator = (degree - 1.0) * previousRoot + radicand / rootInPower;

            return numerator / degree;
        }

    }
}
