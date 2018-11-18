namespace PolynomialProgram.View
{
    public interface IConsoleView
    {
        void WriteLine(string text);
        string ReadLine(string message);
        void ReadKey();
        void WriteErrorMessage();
    }
}
