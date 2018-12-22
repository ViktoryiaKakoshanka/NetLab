namespace BinaryConverting.View
{
    public interface IConsoleView
    {
        string ReadLine(string message);
<<<<<<< HEAD
=======
        void WaitForAnyKeyPress();
        void ShowConvertionResult(int number, string binaryNumber);
        void ShowWarningMessageForRepeat(string messEx = null);
        void ShowMessageFormatException();
        void ShowMessageArgumentNullException();
>>>>>>> master
    }
}
