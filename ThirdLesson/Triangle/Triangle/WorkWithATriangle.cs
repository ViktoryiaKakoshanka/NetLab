using System;
using TriangleLib.Controller;
using TriangleLib.Model;
using TriangleLib.View;

namespace TriangleLib
{
    class WorkWithATriangle
    {
        private IConsoleView _view;
        private FormatedOutput _formatedOutput;

        public void RunProgram(IConsoleView view)
        {
            var firstSide = 0.0;
            var secondSide = 0.0;
            var thirdSide = 0.0;

            _view = view;
            _formatedOutput = new FormatedOutput(_view);
            
            _view.Clear();

            GetSidesOfTriangle(ref firstSide, ref secondSide, ref thirdSide);

            var triangle = TryCreateTriangle(firstSide, secondSide, thirdSide);

            ShowDetails(triangle, view);

            FinishedRun();
        }

        private void GetSidesOfTriangle(ref double firstSide, ref double secondSide, ref double thirdSide)
        {
            firstSide = RequestUserInput('1');
            secondSide = RequestUserInput('2');
            thirdSide = RequestUserInput('3');
        }

        private static Triangle TryCreateTriangle(double firstSide, double secondSide, double thirdSide)
        {
            Triangle triangle = null;
            var isValidatingTriangle = Validator.ValidateTriangle(firstSide, secondSide, thirdSide);

            if (isValidatingTriangle)
            {
                triangle = new Triangle(firstSide, secondSide, thirdSide);
            }
            return triangle;
        }

        private void ShowDetails(Triangle triangle, IConsoleView view)
        {
            if(triangle != null)
            {
                var perimeter = TriangleCalculations.CalculateThePerimeter(triangle);
                var area = TriangleCalculations.CalculateTheArea(triangle);
                _formatedOutput.ShowDetailsTriangle(triangle.ToString(), perimeter, area);
            }
            else
            {
                _formatedOutput.ShowWarningMessageTriangleNotExist();
            }
        }

        private double RequestUserInput(char sideNumber)
        {
            var side = 0.0;
            while (side <= 0)
            {
                side = VerifySideUser(side, sideNumber);
            }
            return side;
        }

        private double VerifySideUser(double side, char sideNumber)
        {
            _view.WriteLine($"Enter the value of {sideNumber} side");
            side = Validator.TryParseSide(_view.ReadLine());
            if (side == 0.0)
            {
                _formatedOutput.ShowWarningMessage();
            }
            return side;
        }
        
        private void FinishedRun()
        {
            _view.WriteLine("Would you like to start over? (yes - press Enter, no - any keyboard key)");

            var keyInfo = _view.ReadKey();
            if(keyInfo.Key == _view.keyEnter)
            {
                RunProgram(_view);
            }
            else
            {
                Environment.Exit(0);
            }
        }


    }
}
