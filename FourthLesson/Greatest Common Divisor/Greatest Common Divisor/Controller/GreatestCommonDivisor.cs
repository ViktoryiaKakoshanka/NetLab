using System;
using System.Collections.Generic;

namespace GreatestCommonDivisorProgram.Controller
{
    public static class GreatestCommonDivisor
    {
        private static int count = 0;
        private static Dictionary<int, int[]> intermediateData = new Dictionary<int, int[]>();

        public static void ResetCount()
        {
            count = 0;
        }

        public static int GCDEuclideanAlgorithm(int a, int b, out int pass)
        {
            if (a == 0 || b == 0)
            {
                pass = count;
                return 1;
            }
            while (b != 0)
            {
                count++;
                AddIntermediateData(a, b, count);
                b = a % (a = b);
            }
            pass = count;
            AddIntermediateData(a, a, count+1);
            return Math.Abs(a);
        }

        public static int GCDEuclideanAlgorithm(int a, int b, int c, out int pass)
        {
            var gcd = GCDEuclideanAlgorithm(GCDEuclideanAlgorithm(a, b, out int step), c, out int step1);
            pass = step1;
            return gcd;
        }

        public static int GCDEuclideanAlgorithm(int a, int b, int c, int x, out int pass)
        {
            var gcd = GCDEuclideanAlgorithm(GCDEuclideanAlgorithm(GCDEuclideanAlgorithm(a, b, out int step), c, out int step1), x, out int step2);
            pass = step2;
            return gcd;
        }

        public static int GCDEuclideanAlgorithm(int a, int b, int c, int x, int y, out int pass)
        {
            var gcd = GCDEuclideanAlgorithm(GCDEuclideanAlgorithm(GCDEuclideanAlgorithm(GCDEuclideanAlgorithm(a, b, out int step), c, out int step1), x, out int step2), y, out int step3);
            pass = step3;
            return gcd;
        }

        public static int GCDStainAlgorithm(int a, int b, out int step)
        {
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

        private static void AddIntermediateData(int a, int b, int step)
        {
            intermediateData.Add(step, new[] { a, b });
        }

        public static void ClearIntermediateData()
        {
            intermediateData.Clear();
        }

        public static Dictionary<int, int[]> KeyValuePairs()
        {
            return intermediateData;
        }
    }
}
