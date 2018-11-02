using System;
using System.Collections.Generic;

namespace GreatestCommonDivisorProgram.Controller
{
    public class GreatestCommonDivisor
    {
        private IDictionary<int, int[]> intermediateData = new Dictionary<int, int[]>();
        
        public int GCDEuclideanAlgorithm(int a, int b, out int pass, int count = 0)
        {
            pass = count;
            if (a == 0 || b == 0)
            {
                return 1;
            }
            while (b != 0)
            {
                pass++;
                AddIntermediateData(a, b, pass);
                b = a % (a = b);
            }
            AddIntermediateData(a, a, ++pass);
            return Math.Abs(a);
        }

        public int GCDEuclideanAlgorithm(int a, int b, int c, out int pass)
        {

            int topTwo = GCDEuclideanAlgorithm(a, b, out int step);
            var gcd = GCDEuclideanAlgorithm(topTwo, c, out int step1, step);
            pass = step1;
            return gcd;
        }

        public int GCDEuclideanAlgorithm(int a, int b, int c, int x, out int pass)
        {
            var gcd = GCDEuclideanAlgorithm(GCDEuclideanAlgorithm(GCDEuclideanAlgorithm(a, b, out int step), c, out int step1), x, out int step2);
            pass = step2;
            return gcd;
        }

        public int GCDEuclideanAlgorithm(int a, int b, int c, int x, int y, out int pass)
        {
            var gcd = GCDEuclideanAlgorithm(GCDEuclideanAlgorithm(GCDEuclideanAlgorithm(GCDEuclideanAlgorithm(a, b, out int step), c, out int step1), x, out int step2), y, out int step3);
            pass = step3;
            return gcd;
        }

        public int GCDStainAlgorithm(int a, int b, out int step)
        {
            var count = 0;
            count++;
            step = count;
            AddIntermediateData(a, b, count);

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
                    ? GCDStainAlgorithm(a >> 1, b >> 1, out step) << 1
                    : GCDStainAlgorithm(a >> 1, b, out step);
            else
                return ((b & 1) == 0)
                    ? GCDStainAlgorithm(a, b >> 1, out step)
                    : GCDStainAlgorithm(b, a > b ? a - b : b - a, out step);
        }

        private void AddIntermediateData(int a, int b, int step)
        {
            intermediateData.Add(step, new[] { a, b });
        }

        public void ClearIntermediateData()
        {
            intermediateData.Clear();
        }

        public Dictionary<int, int[]> KeyValuePairs()
        {
            return intermediateData;
        }
    }
}
