using VectorProgram.View;

namespace PolynomialProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            IConsoleView consoleView = new View.ConsoleView();
            new ProgramRun().Run(consoleView);
        }
    }
}
