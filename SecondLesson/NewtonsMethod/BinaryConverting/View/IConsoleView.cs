namespace BinaryConverting.View
{
    interface IConsoleView
    {
        void WriteLine(string text);
        string ReadLine();
        string ReadLine(string message);
        void WaitForAnyKeyPress();
        void ShowConvertionResult(int number, string binaryNumber);
        void ShowWarningMessageForRepeat(string messEx = null);
        void ShowMessageFormatException();
        void ShowMessageArgumentNullException();
    }
}
