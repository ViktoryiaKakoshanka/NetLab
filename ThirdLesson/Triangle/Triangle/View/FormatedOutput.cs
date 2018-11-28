using System;

namespace TriangleLib.View
{
    public class FormatedOutput
    {
        private IConsoleView _view;

        public FormatedOutput(IConsoleView view)
        {
            _view = view;
        }

        public void ShowWarningMessage()
        {
            _view.WriteLine("You entered an incorrect value for the side of the triangle.\nThe value must be greater than 0. ");
        }

        public void PrintPerimetrTriangle(double perimetr)
        {
            _view.WriteLine($"Perimeter of a triangle: {perimetr}");
        }

        public void PrintAreaTriangle(double square)
        {
            _view.WriteLine($"Area of ​​a triangle: {square}");
        }

        public void PrintDetailsTriangle(string triangle, double perimeter, double area)
        {
            _view.WriteLine($"Sides of a triangle: {triangle}");
            _view.WriteLine($"Perimeter of a triangle: {perimeter}");
            _view.WriteLine($"Area of ​​a triangle: {Math.Round(area, 6)}");
        }

        public void ShowWarningMessageTriangleNotExist()
        {
            _view.WriteLine($"There is no such triangle.");
        }
    }
}
