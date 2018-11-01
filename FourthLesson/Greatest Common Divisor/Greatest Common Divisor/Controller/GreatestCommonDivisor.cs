namespace GreatestCommonDivisorProgram.Controller
{
    public static class GreatestCommonDivisor
    {
        public static int GCDEuclideanAlgorithm(int a, int b, out int pass)
        {
            var count = 0;

            SwitchIfNeeded(ref a, ref b);

            while (b != 0)
            {
                a = a % b;
                SwitchIfNeeded(ref a, ref b);
                count++;
            }

            pass = count;

            return a;
        }

        public static int GCDEuclideanAlgorithm(int a, int b, int c)
        {
            int topTwo = GCDEuclideanAlgorithm(a, b, out int step);
            var resultGcd = GCDEuclideanAlgorithm(topTwo, c, out int step1);
            return resultGcd;
        }
        
        public static int GCDEuclideanAlgorithm(int a, int b, int c, int d)
        {
            var topThree = GCDEuclideanAlgorithm(a, b, c);
            var resultGcd = GCDEuclideanAlgorithm(topThree, d, out int step);
            return resultGcd;
        }

        public static int GCDEuclideanAlgorithm(int a, int b, int c, int d, int e)
        {
            var topFour = GCDEuclideanAlgorithm(a, b, c, d);
            var resultGcd = GCDEuclideanAlgorithm(topFour, e, out int step);
            return resultGcd;
        }

        public static int GCDStainAlgorithm(int a, int b, out int step, int previousSteps = 0)
        {
            step = ++previousSteps;

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
                    ? GCDStainAlgorithm(a >> 1, b >> 1, out step, step) << 1
                    : GCDStainAlgorithm(a >> 1, b, out step, step);
            else
                return ((b & 1) == 0)
                    ? GCDStainAlgorithm(a, b >> 1, out step, step)
                    : GCDStainAlgorithm(b, a > b ? a - b : b - a, out step, step);
        }

        private static void SwitchIfNeeded(ref int first, ref int second)
        {
            if(first >= second)
            {
                return;
            }

            first += second;
            second = first - second;
            first = first - second;
        }
    }
}
