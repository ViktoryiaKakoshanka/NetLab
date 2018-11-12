using NewtonsMethod.Model;

namespace NewtonsMethod.Controller
{
    public interface ICalculator
    {
        double CalculateRadicalSign(IRadicalSign radicalSign);
        double CalculateMathPow(IRadicalSign radicalSign);
    }
}
