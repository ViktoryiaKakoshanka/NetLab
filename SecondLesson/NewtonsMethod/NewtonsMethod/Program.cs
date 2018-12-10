using NewtonsMethod.View;

namespace NewtonsMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            var start = new Startup(new PorogramView());
            start.RunProgram();
        }
    }
}
