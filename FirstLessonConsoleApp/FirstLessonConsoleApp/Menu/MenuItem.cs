using FirstLessonConsoleApp.View;

namespace FirstLessonConsoleApp.Menu
{
    public abstract class MenuItem
    {
        private readonly IView _view;
        public int OrderNumber { get; }
        public string Text { get; }

        public MenuItem(int orderNumber, string text, IView view)
        {
            OrderNumber = orderNumber;
            Text = text;
            _view = view;
        }

        protected IView GetView()
        {
            return _view;
        }

        public abstract void Execute();
    }
}
