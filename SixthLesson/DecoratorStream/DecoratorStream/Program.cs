using DecoratorStream.View;

namespace DecoratorStream
{
    class Program
    {
        static void Main(string[] args)
        {
            IView consoleView = new ConsoleView();
            new ProgramRunner(consoleView).Run();
        }
    }
}
