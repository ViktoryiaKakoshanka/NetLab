using TriangleLib.View;

namespace TriangleLib
{
    class Program
    {
        static void Main()
        {
            var run = new WorkWithATriangle(new ConsoleView());
            run.RunProgram();
        }
    }
}
