namespace Greatest_Common_Divisor.GCDAlgorithm
{
    public class GcdAlgorithmFactory
    {
        public IAlgorithmGcd GetAlgorithm(GcdAlgorithmType algorithmType)
        {
            if(algorithmType == GcdAlgorithmType.Euclidian)
            {
                return new EuclideanGcdAlgorithm();
            }

            return new StainGcdAlgorithm();
        }
    }
}
