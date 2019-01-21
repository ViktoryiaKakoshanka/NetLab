using FirstLessonConsoleApp.View;
using System;

namespace FirstLessonConsoleApp.Menu
{
    public class ExitMenuItem : MenuItem
    {
        public ExitMenuItem(int orderNumber, string text, IView view) : base(orderNumber, text, view)
        {
        }

        public override void Execute()
        {
            Environment.Exit(0);
        }
    }
}
