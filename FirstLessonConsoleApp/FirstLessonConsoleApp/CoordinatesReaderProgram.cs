using FirstLessonConsoleApp.Menu;
using FirstLessonConsoleApp.View;
using System.Collections.Generic;

namespace FirstLessonConsoleApp
{
    public class CoordinatesReaderProgram
    {
        private IView _view;
        private ICollection<MenuItem> _menuItems = new List<MenuItem>();

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

                var userInput = _view.PromptInput("Введите номер элемента меню");
                var menuItem = TryGetMenuItem(userInput);

                ExecuteMenuItem(menuItem);
            }
        }

        private void ExecuteMenuItem(MenuItem menuItem)
        {
            if (menuItem == null)
            {
                _view.PrintMessage("Введите правильный номер элемента меню");
                return;
            }

            _view.ClearScreen();
            menuItem.Execute();
            _view.PressAnyKeyToContinue();
        }

        private void InitializeMenuItems(string coordinatesFilePath)
        {
            _menuItems.Add(new ReadCoordinatesFromConsoleMenuItem(1, "ввод координат с клавиатуры", _view));
            _menuItems.Add(new ReadCoordinatesFromFileMenuItem(2, "ввод координат из файла", _view, coordinatesFilePath));
            _menuItems.Add(new ExitMenuItem(3, "выход", _view));
        }

        private MenuItem TryGetMenuItem(string userInput)
        {
            var index = 0;

            if (!int.TryParse(userInput, out index))
            {
                return null;
            }

            return FindMenuItemByIndex(index);
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
