namespace NewtonsMethod.View
{
    public interface IProgramView
    {
        void WriteLine(string text);
        void WaitForAnyKeyPress();
        string ReadLine(string message);
        void ShowErrorMessageUserInput();
    }
}
