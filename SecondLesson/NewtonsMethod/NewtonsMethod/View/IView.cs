namespace NewtonsMethod.View
{
    public interface IView
    {
        string RequestInput(string message);
        void ShowErrorMessageUserInput();
        void PrintCompareResult(double number, int rootPower, double rootNewton, double rootMath);
    }
}