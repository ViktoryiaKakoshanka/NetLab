using NewtonsMethod.Model;

namespace NewtonsMethod.View
{
    public interface IView
    {
        string RequestInput(string message);
        void ShowErrorMessageUserInput();
        void PrintNumberRoot(double number, int power, double result);
        void PrintCompareResult(int compareResult, double delta);
    }
}
