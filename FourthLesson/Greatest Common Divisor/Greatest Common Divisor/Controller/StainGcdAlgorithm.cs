using Greatest_Common_Divisor.Model;

namespace Greatest_Common_Divisor.Controller
{
    public class StainGcdAlgorithm : IAlgorithmGcd
    {
        private GcdResult gcdResult = new GcdResult();

        public GcdResult Calculate(int[] numbers)
        {
            gcdResult.Gcd = GCDStainAlgorithm(numbers[0], numbers[1], out int iterationsCount);
            gcdResult.IterationsCount = iterationsCount;
            return gcdResult;
        }
        
        private int GCDStainAlgorithm(int firstNumber, int secondNumber, out int pass, int count = 0)
        {
            count++;
            pass = count;
            gcdResult.AddCalculationHistory(firstNumber, secondNumber, pass);

            if (firstNumber == 0 && secondNumber == 0)
                return 1;
            if (firstNumber == 0)
                return secondNumber;
            if (secondNumber == 0)
                return firstNumber;
            if (firstNumber == secondNumber)
                return firstNumber;
            if (firstNumber == 1 || secondNumber == 1)
                return 1;
            if ((firstNumber & 1) == 0)
                return ((secondNumber & 1) == 0)
                    ? GCDStainAlgorithm(firstNumber >> 1, secondNumber >> 1, out pass, count) << 1
                    : GCDStainAlgorithm(firstNumber >> 1, secondNumber, out pass, count);
            else
                return ((secondNumber & 1) == 0)
                    ? GCDStainAlgorithm(firstNumber, secondNumber >> 1, out pass, count)
                    : GCDStainAlgorithm(secondNumber, firstNumber > secondNumber ? firstNumber - secondNumber : secondNumber - firstNumber, out pass, count);
        }
    }
}
