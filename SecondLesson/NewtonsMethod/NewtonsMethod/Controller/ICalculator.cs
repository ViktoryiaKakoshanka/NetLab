namespace NewtonsMethod.Controller
{
    public interface ICalculator
    {
        double CalculateRoot(int degree, double radicand, double accuracy);
        double CalculateMathPow(double @base, int power);
        bool ValidateRoot(double root, int power, double radicant, double accuracy);
    }
}
