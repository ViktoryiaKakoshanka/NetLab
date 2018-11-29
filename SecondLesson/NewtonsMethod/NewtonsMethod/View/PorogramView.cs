using System;

namespace NewtonsMethod.View
{
    public class PorogramView : IProgramView
    {
        public void WaitForAnyKeyPress() => Console.ReadKey(true);

        public string ReadLine(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }

        public void WriteLine(string text) =>  Console.WriteLine(text);

        public void ShowErrorMessageUserInput() => Console.WriteLine("You entered incorrect data");
    }
}
