using VectorProgram.View;

namespace VectorProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            IConsoleView consoleView = new ConsoleView();
            new ProgramRun(consoleView).Run();
        }
    }
}
