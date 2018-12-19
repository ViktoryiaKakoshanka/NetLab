using Greatest_Common_Divisor.Model;

namespace Greatest_Common_Divisor.Controller
{
    public class StainGcdAlgorithm : IAlgorithmGcd
    {
        private readonly GcdResult _result = new GcdResult();

        public GcdResult Calculate(int[] numbers)
        {
            _result.GreatestCommonDivisor = AlgorithmStain(numbers[0], numbers[1], out int iterationsCount);
            _result.NumberOfIterations = iterationsCount;
            return _result;
        }
        
        private int AlgorithmStain(int firstNumber, int secondNumber, out int pass, int count = 0)
        {
            count++;
            pass = count;
            _result.AddCalculationHistory(firstNumber, secondNumber, pass);

            if (firstNumber == 0 && secondNumber == 0)
            {
                return 1;
            }

            if (firstNumber == 0)
            {
                return secondNumber;
            }

            if (secondNumber == 0)
            {
                return firstNumber;
            }

            if (firstNumber == secondNumber)
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
                    ? AlgorithmStain(firstNumber >> 1, secondNumber >> 1, out pass, count) << 1
                    : AlgorithmStain(firstNumber >> 1, secondNumber, out pass, count);

            }

            return (secondNumber & 1) == 0
                ? AlgorithmStain(firstNumber, secondNumber >> 1, out pass, count)
                : AlgorithmStain(secondNumber, firstNumber > secondNumber ? firstNumber - secondNumber : secondNumber - firstNumber, out pass, count);
        }
    }
}
