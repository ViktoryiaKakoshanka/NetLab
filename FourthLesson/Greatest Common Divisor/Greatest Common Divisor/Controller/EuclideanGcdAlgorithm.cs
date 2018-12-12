using System;
using Greatest_Common_Divisor.Model;

namespace Greatest_Common_Divisor.Controller
{
    public class EuclideanGcdAlgorithm : IAlgorithmGcd
    {
        private readonly GcdResult _result = new GcdResult();

        public GcdResult Calculate(int[] numbers)
        {
            var iterationsCount = 0;
            if (numbers.Length == 5)
            {
                _result.Gcd = AlgorithmEuclidean(numbers[0], numbers[1], numbers[2], numbers[3], numbers[4], out iterationsCount);
            }
            if (numbers.Length == 4)
            {
                _result.Gcd = AlgorithmEuclidean(numbers[0], numbers[1], numbers[2], numbers[3], out iterationsCount);
            }
            if (numbers.Length == 3)
            {
                _result.Gcd = AlgorithmEuclidean(numbers[0], numbers[1], numbers[2], out iterationsCount);
            }
            if (numbers.Length == 2)
            {
                _result.Gcd = AlgorithmEuclidean(numbers[0], numbers[1], out iterationsCount);
            }

            _result.IterationsCount = iterationsCount;
            return _result;
        }

        private int AlgorithmEuclidean(int firstNumber, int secondNumber, out int pass, int count = 0)
        {
            pass = count;
            if (firstNumber == 0 && secondNumber != 0)
            {
                return secondNumber;
            }

            if (secondNumber == 0 && firstNumber != 0)
            {
                return firstNumber;
            }

            if (firstNumber == 0 && secondNumber == 0)
            {
                return 1;
            }

            while (secondNumber != 0)
            {
                pass++;
                _result.AddCalculationHistory(firstNumber, secondNumber, pass);
                secondNumber = firstNumber % (firstNumber = secondNumber);
            }
            _result.AddCalculationHistory(firstNumber, firstNumber, ++pass);
            return Math.Abs(firstNumber);
        }

        private int AlgorithmEuclidean(int firstNumber, int secondNumber, int thirdNumber, out int pass)
        {
            var topTwo = AlgorithmEuclidean(firstNumber, secondNumber, out var step);
            var gcd = AlgorithmEuclidean(topTwo, thirdNumber, out var step1, step);
            pass = step1;
            return gcd;
        }

        private int AlgorithmEuclidean(int firstNumber, int secondNumber, int thirdNumber, int fourthNumber, out int pass)
        {
            var topThree = AlgorithmEuclidean(firstNumber, secondNumber, thirdNumber, out var step);
            var gcd = AlgorithmEuclidean(topThree, fourthNumber, out var step1, step);
            pass = step1;
            return gcd;
        }

        private int AlgorithmEuclidean(int firstNumber, int secondNumber, int thirdNumber, int fourthNumber, int fifthNumber, out int pass)
        {
            var topFour = AlgorithmEuclidean(firstNumber, secondNumber, thirdNumber, fourthNumber, out var step);
            var gcd = AlgorithmEuclidean(topFour, fifthNumber, out var step1, step);
            pass = step1;
            return gcd;
        }

    }
}
