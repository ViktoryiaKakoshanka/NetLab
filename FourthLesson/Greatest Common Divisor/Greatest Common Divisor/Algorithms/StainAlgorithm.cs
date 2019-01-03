using Greatest_Common_Divisor.Model;

namespace Greatest_Common_Divisor.Algorithms
{
    public class StainAlgorithm : IAlgorithm
    {
        public GcdResult Calculate(int[] numbers)
        {
            var result = new GcdResult();
            var iterationsCount = 0;

            result.GreatestCommonDivisor = RunAlgorithmStain(numbers[0], numbers[1], result, ref iterationsCount);
            result.NumberOfIterations = iterationsCount;

            return result;
        }
        
        private static int RunAlgorithmStain(int firstNumber, int secondNumber, GcdResult result, ref int pass)
        {
            pass++;
            result.AddCalculationHistory(firstNumber, secondNumber, pass);

            if (firstNumber == 0 && secondNumber == 0)
            {
                return 1;
            }

            if (firstNumber == 0)
            {
                return secondNumber;
            }

            if (secondNumber == 0 || firstNumber == secondNumber)
            {
                return firstNumber;
            }

            if (firstNumber == 1 || secondNumber == 1)
            {
                return 1;
            }

            if ((firstNumber & 1) == 0)
            {
                return (secondNumber & 1) == 0
                    ? RunAlgorithmStain(firstNumber >> 1, secondNumber >> 1, result, ref pass) << 1
                    : RunAlgorithmStain(firstNumber >> 1, secondNumber, result, ref pass);
            }

            return (secondNumber & 1) == 0
                ? RunAlgorithmStain(firstNumber, secondNumber >> 1, result, ref pass)
                : RunAlgorithmStain(secondNumber, firstNumber > secondNumber ? firstNumber - secondNumber : secondNumber - firstNumber, result, ref pass);
        }
    }
}