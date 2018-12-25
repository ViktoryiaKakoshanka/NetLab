using NewtonsMethod.View;

namespace NewtonsMethod
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