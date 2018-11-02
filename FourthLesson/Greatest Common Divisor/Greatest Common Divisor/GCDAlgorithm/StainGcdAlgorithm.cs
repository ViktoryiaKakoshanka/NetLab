using Greatest_Common_Divisor.Model;
using GreatestCommonDivisorProgram.Controller;

namespace Greatest_Common_Divisor.GCDAlgorithm
{
    public class StainGcdAlgorithm : IAlgorithmGcd
    {
        public GcdResult Calculate(int[] numbers)
        {
            var iterationsCount = 0;
            var gcdResult = new GcdResult
            {
                Gcd = GreatestCommonDivisor.GCDStainAlgorithm(numbers[0], numbers[1], out iterationsCount),
                IterationsCount = iterationsCount
            };

            return gcdResult;
        }
    }
}
