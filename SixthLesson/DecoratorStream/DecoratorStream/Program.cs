using DecoratorStream.View;

namespace DecoratorStream
{
    internal class Program
    {
        private static void Main()
        {
            IView view = new ConsoleView();
            new ProgramRunner(view).Run();
        }
    }
}
