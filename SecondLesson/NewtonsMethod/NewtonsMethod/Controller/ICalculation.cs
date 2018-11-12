using NewtonsMethod.Model;

namespace NewtonsMethod.Controller
{
    public interface ICalculation
    {
        double RadicalSignByMethodNewton(IRadicalSign radicalSign);
        double MathPow(IRadicalSign radicalSign);
    }
}
