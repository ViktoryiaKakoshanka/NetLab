using PolynomialProgram.View;

namespace PolynomialProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            IConsoleView consoleView = new ConsoleView();
            new ProgramRun().Run(consoleView);
        }
    }
}
