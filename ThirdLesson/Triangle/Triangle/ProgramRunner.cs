using System.Globalization;
using TriangleLib.Helpers;
using TriangleLib.View;
using TriangleLib.Model;

namespace TriangleLib
{
    internal class ProgramRunner
    {
        private readonly IView _view;

        public ProgramRunner(IView view)
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
            var firstEdge = RequestEdge(1);
            var secondEdge = RequestEdge(2);
            var thirdEdge = RequestEdge(3);

            return CreateTriangle(firstEdge, secondEdge, thirdEdge);
        }

        private static Triangle CreateTriangle(double firstEdge, double secondEdge, double thirdEdge)
        {
            return TriangleValidator.Validate(firstEdge, secondEdge, thirdEdge) ? new Triangle(firstEdge, secondEdge, thirdEdge) : null;
        }

        private void ShowDetails(Triangle triangle)
        {
            if (triangle == null)
            {
                _view.ShowMessageTriangleDoesNotExist();
                return;
            }

            var perimeter = TriangleHelper.CalculatePerimeter(triangle);
            var area = TriangleHelper.CalculateArea(triangle);
            _view.ShowTriangleDetails(triangle, perimeter, area);

        }

        private double RequestEdge(int edgeNumber)
        {
            string userInput;
            double edge;

            do
            {
                userInput = _view.RequestInput($"Enter the value of {edgeNumber} edge");
                
            } while (!double.TryParse(userInput, NumberStyles.Number, CultureInfo.CreateSpecificCulture("en-US"), out edge) || edge <= 0);

            return edge;
        }
    }
}