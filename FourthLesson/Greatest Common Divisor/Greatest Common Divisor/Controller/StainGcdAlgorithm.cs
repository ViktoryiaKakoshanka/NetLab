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

        private int GCDStainAlgorithm(int a, int b, out int pass, int count = 0)
        {
            count++;
            pass = count;
            gcdResult.AddCalculationHistory(a, b, pass);

            if (a == 0 && b == 0)
                return 1;
            if (a == 0)
                return b;
            if (b == 0)
                return a;
            if (a == b)
                return a;
            if (a == 1 || b == 1)
                return 1;
            if ((a & 1) == 0)
                return ((b & 1) == 0)
                    ? GCDStainAlgorithm(a >> 1, b >> 1, out pass, count) << 1
                    : GCDStainAlgorithm(a >> 1, b, out pass, count);
            else
                return ((b & 1) == 0)
                    ? GCDStainAlgorithm(a, b >> 1, out pass, count)
                    : GCDStainAlgorithm(b, a > b ? a - b : b - a, out pass, count);
        }
    }
}
