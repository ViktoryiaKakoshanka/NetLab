<<<<<<< HEAD
﻿using System;
using TriangleLib.Controller;
using TriangleLib.Model;
using TriangleLib.View;

namespace TriangleLib
{
    public class ProgramRunner
    {
        private readonly IConsoleView _consoleView;

        public ProgramRunner(IConsoleView consoleView)
        {
            _consoleView = consoleView;
=======
﻿using System.Globalization;
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
>>>>>>> RefactoringInLab
        }

        public void RunProgram()
        {
<<<<<<< HEAD
            var firstSideLength = 0.0;
            var secondSideLength = 0.0;
            var thirdSideLength = 0.0;

            RequestSidesLengths(ref firstSideLength, ref secondSideLength, ref thirdSideLength);

            var triangle = TriangleHelper.TryCreateTriangle(firstSideLength, secondSideLength, thirdSideLength);

            ShowDetails(triangle);

            FinishedRun();
        }

        private void RequestSidesLengths(ref double firstSideLength, ref double secondSideLength, ref double thirdSideLength)
        {
            firstSideLength = RequestSideLength(1);
            secondSideLength = RequestSideLength(2);
            thirdSideLength = RequestSideLength(3);
        }

        private void ShowDetails(Triangle triangle)
        {
            if (triangle == null)
            {
                _consoleView.ShowWarningMessageTriangleNotExist();
                return;
            }

            var perimeter = TriangleHelper.CalculatePerimeter(triangle);
            var area = TriangleHelper.CalculateArea(triangle);
            _consoleView.ShowDetailsTriangle(triangle.ToString(), perimeter, area);
        }

        private double RequestSideLength(int sideNumber)
        {
            _consoleView.WriteLine($"Enter length of {sideNumber} side");

            return RequestSideLength();
        }

        private double RequestSideLength()
        {
            double sideLength;
            do
            {
                var userInput = _consoleView.ReadLine();
                if (!Validator.TryParseSideLength(userInput, out sideLength))
                {
                    _consoleView.ShowWarningMessage();
                }
            } while (sideLength <= 0);
            return sideLength;
        }

        private void FinishedRun()
        {
            _consoleView.WriteLine("Would you like to start over? (yes - press Enter, no - any other key)");

            var keyInfo = _consoleView.ReadKey();

            if (keyInfo.Key != _consoleView.KeyEnter)
            {
                Environment.Exit(0);
            }

            RunProgram();
        }
    }
}
=======
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
>>>>>>> RefactoringInLab
