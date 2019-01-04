using System;
using Greatest_Common_Divisor.Model;

namespace Greatest_Common_Divisor.Algorithms
{
    public class StainAlgorithm : IAlgorithm
    {
        public GcdResult Calculate(int[] numbers)
        {
            return AlgorithmStain(numbers[0], numbers[1]);
        }

        private static GcdResult AlgorithmStain(int firstNumber, int secondNumber, int count = 0, GcdResult result = null)
        {
            if (result == null)
            {
                result = new GcdResult();
            }

            while (true)
            {
                count++;
                result.AddCalculationHistory(firstNumber, secondNumber, count);

                if (firstNumber == secondNumber)
                {
                    result.GreatestCommonDivisor = firstNumber;
                    result.IterationsCount = count;
                    return result;
                }

                if (firstNumber == 1 || secondNumber == 1)
                {
                    result.GreatestCommonDivisor = 1;
                    result.IterationsCount = count;
                    return result;
                }

                if (firstNumber % 2 == 0 && secondNumber % 2 == 0)
                {
                    result = AlgorithmStain(firstNumber / 2, secondNumber / 2, count);
                    result.IterationsCount = count;
                    result.GreatestCommonDivisor *= 2;
                    return result;
                }

                if (firstNumber % 2 == 0)
                {
                    firstNumber = firstNumber / 2;
                    continue;
                }

                if (secondNumber % 2 == 0)
                {
                    secondNumber = secondNumber / 2;
                    continue;
                }

                var firstNumber1 = firstNumber;
                firstNumber = secondNumber;
                secondNumber = Math.Abs(firstNumber1 - secondNumber);
            }
        }
    }
}
