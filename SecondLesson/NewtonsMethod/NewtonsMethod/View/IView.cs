using NewtonsMethod.Model;

namespace NewtonsMethod.View
{
    public interface IView
    {
        string RequestInput(string message);
        void ShowErrorMessageUserInput();
        void PrintCompareResult(IRadicalSign radicalSign, double radicalSignMethodNewton, double radicalSignMathPow);
    }
}
