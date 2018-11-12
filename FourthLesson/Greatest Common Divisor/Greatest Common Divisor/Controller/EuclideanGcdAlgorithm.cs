using System;
using Greatest_Common_Divisor.Model;

namespace Greatest_Common_Divisor.Controller
{
    public class EuclideanGcdAlgorithm : IAlgorithmGcd
    {
        private GcdResult gcdResult = new GcdResult();

        public GcdResult Calculate(int[] numbers)
        {
            var iterationsCount = 0;
            if (numbers.Length == 5)
            {
                gcdResult.Gcd = GCDEuclideanAlgorithm(numbers[0], numbers[1], numbers[2], numbers[3], numbers[4], out iterationsCount);
            }
            if (numbers.Length == 4)
            {
                gcdResult.Gcd = GCDEuclideanAlgorithm(numbers[0], numbers[1], numbers[2], numbers[3], out iterationsCount);
            }
            if (numbers.Length == 3)
            {
                gcdResult.Gcd = GCDEuclideanAlgorithm(numbers[0], numbers[1], numbers[2], out iterationsCount);
            }
            if (numbers.Length == 2)
            {
                gcdResult.Gcd = GCDEuclideanAlgorithm(numbers[0], numbers[1], out iterationsCount);
            }

            gcdResult.IterationsCount = iterationsCount;
            return gcdResult;
        }

        private int GCDEuclideanAlgorithm(int firstNumber, int secondNumber, out int pass, int count = 0)
        {
            pass = count;
            if (firstNumber == 0 && secondNumber != 0)
            {
                return secondNumber;
            }
            else if (secondNumber == 0 && firstNumber != 0)
            {
                return firstNumber;
            }
            else if (firstNumber == 0 && secondNumber == 0)
            {
                return 1;
            }

            while (secondNumber != 0)
            {
                pass++;
                gcdResult.AddCalculationHistory(firstNumber, secondNumber, pass);
                secondNumber = firstNumber % (firstNumber = secondNumber);
            }
            gcdResult.AddCalculationHistory(firstNumber, firstNumber, ++pass);
            return Math.Abs(firstNumber);
        }

        private int GCDEuclideanAlgorithm(int firstNumber, int secondNumber, int thirdNumber, out int pass)
        {
            var topTwo = GCDEuclideanAlgorithm(firstNumber, secondNumber, out int step);
            var gcd = GCDEuclideanAlgorithm(topTwo, thirdNumber, out int step1, step);
            pass = step1;
            return gcd;
        }

        private int GCDEuclideanAlgorithm(int firstNumber, int secondNumber, int thirdNumber, int fourthNumber, out int pass)
        {
            var topThree = GCDEuclideanAlgorithm(firstNumber, secondNumber, thirdNumber, out int step);
            var gcd = GCDEuclideanAlgorithm(topThree, fourthNumber, out int step1, step);
            pass = step1;
            return gcd;
        }

        private int GCDEuclideanAlgorithm(int firstNumber, int secondNumber, int thirdNumber, int fourthNumber, int fifthNumber, out int pass)
        {
            var topFour = GCDEuclideanAlgorithm(firstNumber, secondNumber, thirdNumber, fourthNumber, out int step);
            var gcd = GCDEuclideanAlgorithm(topFour, fifthNumber, out int step1, step);
            pass = step1;
            return gcd;
        }

    }
}
