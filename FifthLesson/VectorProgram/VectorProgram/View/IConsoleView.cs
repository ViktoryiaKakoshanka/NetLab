namespace VectorProgram.View
{
    public interface IConsoleView
    {
        string ReadLine(string message);
        void WaitForAnyKeyPress();
        void WriteErrorMessage();
    }
}
