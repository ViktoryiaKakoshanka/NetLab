using FirstLessonConsoleApp.Menu;
using FirstLessonConsoleApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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
            if(coordinates == null || !coordinates.Any())
            {
                return;
            }

            PrintMessage("Formatted coordinate output");
            coordinates.ToList().ForEach(Console.WriteLine);
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

        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void PressAnyKeyToContinue()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadKey(true);
        }

        public void ClearScreen()
        {
            Console.Clear();
        }
    }
}
