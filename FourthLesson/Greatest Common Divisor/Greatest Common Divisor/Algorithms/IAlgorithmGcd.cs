using Greatest_Common_Divisor.Model;

namespace Greatest_Common_Divisor.Algorithms
{
    public interface IAlgorithmGcd
    {
        GcdResult Calculate(int[] numbers);
    }
}