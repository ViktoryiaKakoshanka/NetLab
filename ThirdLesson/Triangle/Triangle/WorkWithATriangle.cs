using System;
using TriangleLib.Controller;
using TriangleLib.View;
using TriangleLib.Model;

namespace TriangleLib
{
    class WorkWithATriangle
    {
        private readonly IConsoleView _consoleView;
        private readonly ITriangleView _triangleView;

        public WorkWithATriangle(ConsoleView view)
        {
            _consoleView = view;
            _triangleView = view;
        }

        public void RunProgram()
        {
            var triangle = CreateTriangle();
            
            ShowDetails(triangle);

            FinishedRun();
        }

        private Triangle CreateTriangle()
        {
            var firstSide = RequestUserInput('1');
            var secondSide = RequestUserInput('2');
            var thirdSide = RequestUserInput('3');

            _consoleView.Clear();

            return TryCreateTriangle(firstSide, secondSide, thirdSide);
        }

        private static Triangle TryCreateTriangle(double firstSide, double secondSide, double thirdSide)
        {
            var isValidatingTriangle = Validator.ValidateTriangle(firstSide, secondSide, thirdSide);

            return isValidatingTriangle ? new Triangle(firstSide, secondSide, thirdSide) : null;
        }

        private void ShowDetails(Triangle triangle)
        {
            if(triangle != null)
            {
                var perimeter = TriangleCalculations.CalculateThePerimeter(triangle);
                var area = TriangleCalculations.CalculateTheArea(triangle);
                _triangleView.ShowDetailsTriangle(triangle.ToString(), perimeter, area);
            }
            else
            {
                _triangleView.ShowWarningMessageTriangleNotExist();
            }
        }

        private double RequestUserInput(char sideNumber)
        {
            var side = 0.0;
            while (side <= 0)
            {
                side = VerifySideUser(sideNumber);
            }
            return side;
        }

        private double VerifySideUser(char sideNumber)
        {
            _consoleView.WriteLine($"Enter the value of {sideNumber} side");
            var side = Validator.TryParseSide(_consoleView.ReadLine());
            if (side <= 0)
            {
                _consoleView.WriteLine("You entered an incorrect value for the side of the triangle.\nThe value must be greater than 0. ");
            }
            return side;
        }
        
        private void FinishedRun()
        {
            _consoleView.WriteLine("Would you like to start over? (yes - press Enter, no - any keyboard key)");

            var keyInfo = _consoleView.ReadKey();
            if(keyInfo.Key == _consoleView.KeyEnter)
            {
                RunProgram();
            }
            else
            {
                Environment.Exit(0);
            }
        }


    }
}
