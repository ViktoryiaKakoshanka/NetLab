using Greatest_Common_Divisor.Model;

namespace Greatest_Common_Divisor.Algorithms
{
    public class EuclideanAlgorithm : IAlgorithm
    {
        public GcdResult Calculate(int[] numbers)
        {
            if (numbers.Length == 5)
            {
                return RunAlgorithmEuclidean(numbers[0], numbers[1], numbers[2], numbers[3], numbers[4]);
            }

            if (numbers.Length == 4)
            {
                return RunAlgorithmEuclidean(numbers[0], numbers[1], numbers[2], numbers[3]);
            }

            if (numbers.Length == 3)
            {
                return RunAlgorithmEuclidean(numbers[0], numbers[1], numbers[2]);
            }

            return numbers.Length == 2 ? RunAlgorithmEuclidean(numbers[0], numbers[1]) : new GcdResult();
        }

        private static GcdResult RunAlgorithmEuclidean(int first, int second, GcdResult result = null)
        {
            if (result == null)
            {
                result = new GcdResult();
            }

            while (second != 0)
            {
                result.IterationsCount++;
                result.AddCalculationHistory(first, second, result.IterationsCount);
                second = first % (first = second);
            }

            result.AddCalculationHistory(first, first, ++result.IterationsCount);
            result.GreatestCommonDivisor = first;

            return result;
        }

        private static GcdResult RunAlgorithmEuclidean(int first, int second, int thirdNumber)
        {
            var topTwo = RunAlgorithmEuclidean(first, second);
            return RunAlgorithmEuclidean(topTwo.GreatestCommonDivisor, thirdNumber, topTwo);
        }

        private static GcdResult RunAlgorithmEuclidean(int first, int second, int thirdNumber, int fourthNumber)
        {
            var topThree = RunAlgorithmEuclidean(first, second, thirdNumber);
            return RunAlgorithmEuclidean(topThree.GreatestCommonDivisor, fourthNumber, topThree);
        }

        private static GcdResult RunAlgorithmEuclidean(int first, int second, int thirdNumber, int fourthNumber, int fifthNumber)
        {
            var topFour = RunAlgorithmEuclidean(first, second, thirdNumber, fourthNumber);
            return RunAlgorithmEuclidean(topFour.GreatestCommonDivisor, fifthNumber, topFour);
        }
    }
}