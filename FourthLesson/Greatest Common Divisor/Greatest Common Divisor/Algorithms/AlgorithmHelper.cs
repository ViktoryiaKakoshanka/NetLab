using Greatest_Common_Divisor.Model;

namespace Greatest_Common_Divisor.Algorithms
{
    public static class AlgorithmHelper
    {
        public static GcdResult Calculate(int[] numbers, AlgorithmType algorithmType)
        {
            var algorithm = GetAlgorithm(algorithmType);
            return algorithm.Calculate(numbers);
        }
        
        private static IAlgorithm GetAlgorithm(AlgorithmType algorithmType)
        {
            return new AlgorithmFactory().CreateAlgorithm(algorithmType);
        }
    }
}