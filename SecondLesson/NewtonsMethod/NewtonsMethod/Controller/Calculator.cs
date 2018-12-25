using System;

namespace NewtonsMethod.Controller
{
<<<<<<< HEAD
    public class Calculator
    {
        public static double CalculateRadicalSign(IRadicalSign radicalSign)
        {
            var root = CalculateRadicalWithAccuracy(radicalSign);
            radicalSign.SetRoot(root);
            return root;
        }
        
        public static double CalculateRootNumber(IRadicalSign radicalSign) => Math.Pow(radicalSign.Root, radicalSign.Power);

        private static double CalculateRadicalWithAccuracy(IRadicalSign radicalSign)
        {
            double currentAccuracy;
            var previousRadical = 1.0;
            double currentRadical;

            do
            {
                currentRadical = CalculateCurrentRadical(radicalSign, previousRadical);
                currentAccuracy = Math.Abs(previousRadical - currentRadical);
                previousRadical = currentRadical;

            } while (currentAccuracy > radicalSign.Accuracy);
=======
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
>>>>>>> master

            return currentRoot;
        }

<<<<<<< HEAD
        private static double CalculateCurrentRadical(IRadicalSign radicalSign, double previousRadical)
        {
            var previousPower = ErectInDegree(previousRadical, radicalSign.Power - 1);
            var firstPartCalculation = 1.0 / radicalSign.Power;
            var secondPartCalculation = (radicalSign.Power - 1.0) * previousRadical + radicalSign.Number / previousPower;

            return firstPartCalculation * secondPartCalculation;
        }
        
        private static double ErectInDegree(double number, int power)
        {
            if (power <= 1)
            {
                return number;
            }

            return number * ErectInDegree(number, --power);
=======
        public bool ValidateRoot(double root, int power, double radicant, double accuracy)
        {
            return Math.Abs(Math.Pow(root, power) - radicant) <= accuracy;
        }

        private double CalculateRootByNewtonMethod(int degree, double radicand, double previousRoot)
        {
            var rootInPower = CalculatorHelper.RaiseToPower(previousRoot, degree - 1);

            var numerator = (degree - 1.0) * previousRoot + radicand / rootInPower;

            return numerator / degree;
>>>>>>> master
        }
    }
}