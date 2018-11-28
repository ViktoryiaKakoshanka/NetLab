namespace BinaryConverting.View
{
    interface IConsoleView
    {
        void WriteLine(string text);
        string ReadLine();
        string ReadLine(string message);
        void WaitForAnyKeyPress();
        void Clear();
    }
}
