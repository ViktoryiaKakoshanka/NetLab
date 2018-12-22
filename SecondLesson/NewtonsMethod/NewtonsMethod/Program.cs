using NewtonsMethod.View;

namespace NewtonsMethod
{
    class Program
    {
        static void Main()
        {
            var start = new Startup(new ProgramView());
            start.RunProgram();
        }
    }
}