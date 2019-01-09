using FirstLessonConsoleApp.Menu;
using FirstLessonConsoleApp.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstLessonConsoleApp.View
{
    public class ConsoleView : IView
    {
        public void PrintMenuItems(ICollection<MenuItem> menuItems)
        {
            Console.OutputEncoding = Encoding.Unicode;
            PrintMessage("Menu:");

            foreach(var item in menuItems)
            {
                PrintMessage($"{item.OrderNumber} - {item.Text}");
            }

            Console.WriteLine();
        }

        public void PrintCoordinates(ICollection<Coordinate> coordinates)
        {
            PrintMessage("Formatted coordinate output");
            foreach(var coordinate in coordinates)
            {
                Console.WriteLine(coordinate);
            }
        }

        public void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }

        public string PromptInput(string promptText)
        {
            Console.Write($"{promptText}: ");
            return Console.ReadLine();
        }

        public string RequestInput()
        {
            return Console.ReadLine();
        }

        public void ContinueProgram()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadKey(true);
        }

        public void Clear()
        {
            Console.Clear();
        }
    }
}
