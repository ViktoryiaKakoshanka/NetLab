namespace DecoratorStream.View
{
    public interface IConsoleView
    {
        void WriteLine(string text);
        string ReadLine(string message);
        void WaitForAnyKeyPress();
        void ShowMessageErrorPassword();
        void SetCursorPosition(int left, int top);
    }
}
