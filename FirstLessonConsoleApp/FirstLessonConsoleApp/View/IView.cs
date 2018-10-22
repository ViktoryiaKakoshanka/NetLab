using FirstLessonConsoleApp.Menu;
using FirstLessonConsoleApp.Model;
using System.Collections.Generic;

namespace FirstLessonConsoleApp.View
{
    public interface IView
    {
        void PrintMenuItems(ICollection<MenuItem> menuItems);
        void PrintCoordinates(ICollection<Coordinate> coordinates);
        void PrintMessage(string message);
        string PromptInput(string promptText);
        string ReadLine();
        void PressAnyKeyToContinue();
        void ClearScreen();
    }
}
