using System;
using Greatest_Common_Divisor.Model;

namespace Greatest_Common_Divisor.Controller
{
    public class EuclideanGcdAlgorithm : IAlgorithmGcd
    {
        private GcdResult gcdResult = new GcdResult();

        public GcdResult Calculate(int[] numbers)
        {
            var iterationsCount = 0;
            if (numbers.Length == 5)
            {
                gcdResult.Gcd = GCDEuclideanAlgorithm(numbers[0], numbers[1], numbers[2], numbers[3], numbers[4], out iterationsCount);
            }
            if (numbers.Length == 4)
            {
                gcdResult.Gcd = GCDEuclideanAlgorithm(numbers[0], numbers[1], numbers[2], numbers[3], out iterationsCount);
            }
            if (numbers.Length == 3)
            {
                gcdResult.Gcd = GCDEuclideanAlgorithm(numbers[0], numbers[1], numbers[2], out iterationsCount);
            }
            if (numbers.Length == 2)
            {
                gcdResult.Gcd = GCDEuclideanAlgorithm(numbers[0], numbers[1], out iterationsCount);
            }
            
            gcdResult.IterationsCount = iterationsCount;
            return gcdResult;
        }
        
        private int GCDEuclideanAlgorithm(int a, int b, out int pass, int count = 0)
        {
            pass = count;
            if (a == 0 && b!=0)
            {
                return b;
            }
            else if (b == 0 && a!=0)
            {
                return a;
            }
            else if(a==0 && b==0)
            {
                return 1;
            }

            while (b != 0)
            {
                pass++;
                gcdResult.AddCalculationHistory(a, b, pass);
                b = a % (a = b);
            }
            gcdResult.AddCalculationHistory(a, a, ++pass);
            return Math.Abs(a);
        }

        private int GCDEuclideanAlgorithm(int a, int b, int c, out int pass)
        {

            var topTwo = GCDEuclideanAlgorithm(a, b, out int step);
            var gcd = GCDEuclideanAlgorithm(topTwo, c, out int step1, step);
            pass = step1;
            return gcd;
        }

        private int GCDEuclideanAlgorithm(int a, int b, int c, int d, out int pass)
        {
            var topThree = GCDEuclideanAlgorithm(a, b, c, out int step);
            var gcd = GCDEuclideanAlgorithm(topThree, d, out int step1, step);
            pass = step1;
            return gcd;
        }

        private int GCDEuclideanAlgorithm(int a, int b, int c, int d, int e, out int pass)
        {
            var topFour = GCDEuclideanAlgorithm(a, b, c, d, out int step);
            var gcd = GCDEuclideanAlgorithm(topFour, e, out int step1, step);
            pass = step1;
            return gcd;
        }

    }
}
