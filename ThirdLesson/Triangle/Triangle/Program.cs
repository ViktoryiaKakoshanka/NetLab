using TriangleLib.View;

namespace TriangleLib
{
    class Program
    {
        static void Main(string[] args)
        {
            IConsoleView view = new ConsoleView();
            var run = new WorkWithATriangle();
            run.RunProgram(view);
        }
    }
}
