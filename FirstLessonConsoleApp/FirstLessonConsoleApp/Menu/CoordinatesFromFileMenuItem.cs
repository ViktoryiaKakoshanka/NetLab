using FirstLessonConsoleApp.View;

namespace FirstLessonConsoleApp.Menu
{
    public class CoordinatesFromFileMenuItem : MenuItem
    {
        private string _path;

        public CoordinatesFromFileMenuItem(int orderNumber, string text, IView view, string filePath) : base(orderNumber, text, view)
        {
            _path = filePath;
        }

        public override void Execute()
        {
            var coordinates = CoordinatesFromFileHelper.ReadCoordinatesFromFile(_path);

            GetView().PrintCoordinates(coordinates);
        }
    }
}
