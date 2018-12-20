using BinaryConverting.View;

namespace BinaryConverting
{
    internal class Program
    {
        private static void Main()
        {
            var runner = new ProgramRunner(new ConsoleView());
            runner.RunProgram();
        }
    }
}
