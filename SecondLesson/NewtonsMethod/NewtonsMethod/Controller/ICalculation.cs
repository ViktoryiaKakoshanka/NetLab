using NewtonsMethod.Model;

namespace NewtonsMethod.Controller
{
    public interface ICalculator
    {
        double CalculateRadicalSignByMethodNewton(IRadicalSign radicalSign);
        double MathPow(IRadicalSign radicalSign);
    }
}
