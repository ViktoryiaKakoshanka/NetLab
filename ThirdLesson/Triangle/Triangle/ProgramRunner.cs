using System.Globalization;
using TriangleLib.Helpers;
using TriangleLib.View;
using TriangleLib.Model;

namespace TriangleLib
{
    internal class ProgramRunner
    {
        private readonly IConsoleView _view;

        public ProgramRunner(IConsoleView view)
        {
            _view = view;
        }

        public void RunProgram()
        {
            var triangle = CreateTriangle();
            
            ShowDetails(triangle);

            _view.Exit();
        }

        private Triangle CreateTriangle()
        {
            var firstEdge = RequestSide('1');
            var secondEdge = RequestSide('2');
            var thirdEdge = RequestSide('3');

            return TryCreateTriangle(firstEdge, secondEdge, thirdEdge);
        }

        private static Triangle TryCreateTriangle(double firstEdge, double secondEdge, double thirdEdge)
        {
            return Validator.ValidateTriangle(firstEdge, secondEdge, thirdEdge) ? new Triangle(firstEdge, secondEdge, thirdEdge) : null;
        }

        private void ShowDetails(Triangle triangle)
        {
            if(triangle != null)
            {
                var perimeter = TriangleHelper.CalculatePerimeter(triangle);
                var area = TriangleHelper.CalculateArea(triangle);
                _view.ShowTriangleDetails(triangle, perimeter, area);
            }
            else
            {
                _view.ShowMessageTriangleDoesNotExist();
            }
        }

        private double RequestSide(char sideNumber)
        {
            string userInput;
            double edge;

            do
            {
                userInput = _view.RequestInput($"Enter the value of {sideNumber} edge");
                
            } while (!double.TryParse(userInput, NumberStyles.Number, CultureInfo.CreateSpecificCulture("en-US"), out edge) && edge <= 0);

            return edge;
        }
    }
}