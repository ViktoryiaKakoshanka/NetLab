using TriangleLib.View;

namespace TriangleLib
{
    class Program
    {
        static void Main(string[] args)
        {
            var run = new WorkWithATriangle();
            run.RunProgram(new ConsoleView());
        }
    }
}
