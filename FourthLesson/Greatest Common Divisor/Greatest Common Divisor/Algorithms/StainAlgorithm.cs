using System;
using Greatest_Common_Divisor.Model;

namespace Greatest_Common_Divisor.Algorithms
{
    public class StainAlgorithm : IAlgorithm
    {
        public GcdResult Calculate(int[] numbers)
        {
            return RunAlgorithmStain(numbers[0], numbers[1]);
        }

        private static GcdResult RunAlgorithmStain(int firstNumber, int secondNumber, int step = 0, GcdResult intermediateResult = null)
        {
            if (intermediateResult == null)
            {
                intermediateResult = new GcdResult();
            }

            while (true)
            {
                step++;
                intermediateResult.AddCalculationHistory(firstNumber, secondNumber, step);
                intermediateResult.IterationsCount = step;

                if (firstNumber == secondNumber)
                {
                    intermediateResult.GreatestCommonDivisor = firstNumber;
                    return intermediateResult;
                }

                if (firstNumber == 1 || secondNumber == 1)
                {
                    intermediateResult.GreatestCommonDivisor = 1;
                    return intermediateResult;
                }

                if (IsEven(firstNumber) && IsEven(secondNumber))
                {
                    intermediateResult = RunAlgorithmStain(firstNumber >> 1, secondNumber >> 1, step, intermediateResult);
                    intermediateResult.GreatestCommonDivisor <<= 1;
                    return intermediateResult;
                }

                if (IsEven(firstNumber))
                {
                    firstNumber = firstNumber >> 1;
                    continue;
                }

                if (IsEven(secondNumber))
                {
                    secondNumber = secondNumber >> 1;
                    continue;
                }

                var previousFirstNumber = firstNumber;
                firstNumber = secondNumber;
                secondNumber = Math.Abs(previousFirstNumber - secondNumber);
            }
        }

        private static bool IsEven(int number)
        {
            return (number & 1) == 0;
        }
    }
}