using TriangleLib.View;

namespace TriangleLib
{
    internal class Program
    {
        private static void Main()
        {
            var run = new ProgramRunner(new ConsoleView());
            run.RunProgram();
        }
    }
}