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

                if (firstNumber == secondNumber)
                {
                    intermediateResult.GreatestCommonDivisor = firstNumber;
                    intermediateResult.IterationsCount = step;
                    return intermediateResult;
                }

                if (firstNumber == 1 || secondNumber == 1)
                {
                    intermediateResult.GreatestCommonDivisor = 1;
                    intermediateResult.IterationsCount = step;
                    return intermediateResult;
                }

                if (firstNumber % 2 == 0 && secondNumber % 2 == 0)
                {
                    intermediateResult = RunAlgorithmStain(firstNumber / 2, secondNumber / 2, step);
                    intermediateResult.IterationsCount = step;
                    intermediateResult.GreatestCommonDivisor *= 2;
                    return intermediateResult;
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