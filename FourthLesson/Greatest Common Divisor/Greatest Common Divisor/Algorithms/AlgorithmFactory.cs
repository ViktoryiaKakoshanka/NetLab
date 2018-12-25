using Greatest_Common_Divisor.Model;

namespace Greatest_Common_Divisor.Algorithms
{
    public class AlgorithmFactory
    {
        public IAlgorithmGcd Algorithm(AlgorithmType type)
        {
            if (type == AlgorithmType.Euclidean)
            {
                return new EuclideanAlgorithm();
            }
            return new StainGcdAlgorithm();
        }
    }
}