using TriangleLib.View;

namespace TriangleLib
{
    class Program
    {
        static void Main(string[] args)
        {
            var run = new ProgramRunner(new ConsoleView());
            run.RunProgram();
        }
    }
}
