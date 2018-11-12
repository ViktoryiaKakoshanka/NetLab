using System;
using TriangleLib.Controller;
using TriangleLib.Model;
using TriangleLib.View;

namespace TriangleLib
{
    class WorkWithATriangle
    {
        private IConsoleView _view;

        public void RunProgram(IConsoleView view)
        {
            var firstSide = 0.0;
            var secondSide = 0.0;
            var thirdSide = 0.0;

            Triangle triangle;
            _view = view;

            _view.Clear();

            EnterInputData(ref firstSide, '1');
            EnterInputData(ref secondSide, '2');
            EnterInputData(ref thirdSide, '3');
            

            triangle = TryCreateTriangle( firstSide, secondSide, thirdSide);
            ShowDetails(triangle, view);
            FinishedRun();
        }

        private static Triangle TryCreateTriangle(double firstSide, double secondSide, double thirdSide)
        {
            Triangle triangle = null;
            if (ValidatingTriangleHelper.ValidateTriangle(firstSide, secondSide, thirdSide))
            {
                triangle = new Triangle(firstSide, secondSide, thirdSide);
            }
            return triangle;
        }

        private static void ShowDetails(Triangle triangle, IConsoleView view)
        {
            if(triangle != null)
            {
                view.PrintDetailsTriangle(triangle);
            }
            else
            {
                view.ShowWarningMessageTriangleNotExist();
            }
        }

        private void EnterInputData(ref double side, char sideNumber)
        {
            while (side <= 0)
            {
                VerifySideUser(ref side, sideNumber);
            }
        }

        private void VerifySideUser(ref double side, char sideNumber)
        {
            _view.WriteLine($"Enter the value of {sideNumber} side");
            side = ValidatingTriangleHelper.TryParseInputtingSide(_view.ReadLine());
            if (side == 0.0) _view.WarningMessage();
        }



        private void FinishedRun()
        {
            _view.WriteLine("Would you like to start over? (yes - press Enter, no - any keyboard key)");

            var keyInfo = _view.ReadKey();
            if(keyInfo.Key == ConsoleKey.Enter)
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
