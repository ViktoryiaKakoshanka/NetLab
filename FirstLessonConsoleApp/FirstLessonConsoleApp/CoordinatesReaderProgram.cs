using FirstLessonConsoleApp.Menu;
using FirstLessonConsoleApp.View;
using System.Collections.Generic;

namespace FirstLessonConsoleApp
{
    public class CoordinatesReaderProgram
    {
        private readonly IView _view;
        private readonly ICollection<MenuItem> _menuItems = new List<MenuItem>();

        public CoordinatesReaderProgram(IView view, string coordinatesFilePath)
        {
            _view = view;
            InitializeMenuItems(coordinatesFilePath);
        }

        public void RunProgram()
        {
            while (true)
            {
                _view.ClearScreen();
                _view.PrintMenuItems(_menuItems);

                var userInput = _view.PromptInput("Enter the menu item number");
                var menuItem = TryGetMenuItem(userInput);

                ExecuteMenuItem(menuItem);
            }
        }

        private void ExecuteMenuItem(MenuItem menuItem)
        {
            if (menuItem == null)
            {
                _view.PrintMessage("Enter the correct menu item number.");
                return;
            }

            _view.ClearScreen();
            menuItem.Execute();
            _view.PressAnyKeyToContinue();
        }

        private void InitializeMenuItems(string coordinatesFilePath)
        {
            _menuItems.Add(new ReadCoordinatesFromConsoleMenuItem(1, "input coordinates from the keyboard", _view));
            _menuItems.Add(new ReadCoordinatesFromFileMenuItem(2, "input coordinates from file", _view, coordinatesFilePath));
            _menuItems.Add(new ExitMenuItem(3, "exit", _view));
        }

        private MenuItem TryGetMenuItem(string userInput)
        {
            return !int.TryParse(userInput, out var index) ? null : FindMenuItemByIndex(index);
        }

        private MenuItem FindMenuItemByIndex(int index)
        {
            MenuItem selectedItem = null;

            foreach (var item in _menuItems)
            {
                if (item.OrderNumber == index)
                {
                    selectedItem = item;
                    break;
                }
            }

            return selectedItem;
        }
    }
}
