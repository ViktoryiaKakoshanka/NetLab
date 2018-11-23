namespace VectorProgram.View
{
    public interface IConsoleView
    {
        void WriteLine(string text);
        string ReadLine(string message);
        void PressKeyToContinue();
        void WriteErrorMessage();
    }
}
