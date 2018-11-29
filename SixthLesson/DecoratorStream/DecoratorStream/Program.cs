using DecoratorStream.View;

namespace DecoratorStream
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
