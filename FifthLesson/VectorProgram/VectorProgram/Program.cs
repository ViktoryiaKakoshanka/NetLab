using VectorProgram.View;

namespace VectorProgram
{
    internal class Program
    {
        private static void Main()
        {
            new ProgramRunner(new ConsoleView()).Run();
        }
    }
}
