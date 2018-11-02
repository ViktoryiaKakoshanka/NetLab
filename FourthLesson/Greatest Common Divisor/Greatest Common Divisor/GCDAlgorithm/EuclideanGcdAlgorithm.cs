using Greatest_Common_Divisor.Model;
using GreatestCommonDivisorProgram.Controller;

namespace Greatest_Common_Divisor.GCDAlgorithm
{
    public class EuclideanGcdAlgorithm : IAlgorithmGcd
    {
        public GcdResult Calculate(int[] numbers)
        {
            var iterationsCount = 0;
            var gcdResult = new GcdResult();

            if (numbers.Length == 5)
            {
                gcdResult.Gcd = GreatestCommonDivisor.GCDEuclideanAlgorithm(numbers[0], numbers[1], numbers[2], numbers[3], numbers[4]);
            }
            if (numbers.Length == 4)
            {
                gcdResult.Gcd = GreatestCommonDivisor.GCDEuclideanAlgorithm(numbers[0], numbers[1], numbers[2], numbers[3]);
            }
            if (numbers.Length == 3)
            {
                gcdResult.Gcd = GreatestCommonDivisor.GCDEuclideanAlgorithm(numbers[0], numbers[1], numbers[2]);
            }
            if (numbers.Length == 2)
            {
                gcdResult.Gcd = GreatestCommonDivisor.GCDEuclideanAlgorithm(numbers[0], numbers[1], out iterationsCount);
                gcdResult.IterationsCount = iterationsCount;
            }
            return gcdResult;
        }
    }
}
