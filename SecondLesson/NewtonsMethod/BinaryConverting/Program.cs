using BinaryConverting.View;

namespace BinaryConverting
{
    class Program
    {
        static void Main(string[] args)
        {
            var mainLaunchProgram = new MainLaunchProgram();
            mainLaunchProgram.RunProgram(new ConsoleView());
        }
    }
}
