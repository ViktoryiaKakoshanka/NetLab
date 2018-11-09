using System;
using TriangleLib.Controller;
using TriangleLib.Model;
using TriangleLib.View;

namespace TriangleLib
{
    class WorkWithATriangle
    {
        private IConsoleView _view;
        private double a = 0, b = 0, c = 0;

        public void RunProgram(IConsoleView view)
        {
            a = 0;
            b = 0;
            c = 0;
            Triangle triangle;
            _view = view;

            _view.Clear();

            CallUserInput(ref a, '1');
            CallUserInput(ref b, '2');
            CallUserInput(ref c, '3');
            

            triangle = TryCreateTriangle( a, b, c);
            PrintDetails(triangle, view);
            FinishedRun();
        }

        private static Triangle TryCreateTriangle(double a, double b, double c)
        {
            Triangle triangle = null;
            if (ValidateTriangleHelper.ValidateTriangle(a, b, c))
            {
                triangle = new Triangle(a, b, c);
            }
            return triangle;
        }

        private static void PrintDetails(Triangle triangle, IConsoleView view)
        {
            if(triangle!=null)
            {
                view.PrintDetailsTriangle(triangle);
            }
            else
            {
                view.WarningMessageTriangleNotExist();
            }
        }

        private void CallUserInput(ref double side, char sideNumber)
        {
            while (side <= 0)
            {
                VerifySideUser(ref side, sideNumber);
            }
        }

        private void VerifySideUser(ref double side, char sideNumber)
        {
            _view.WriteLine($"Enter the value of {sideNumber} side");
            side = ValidateTriangleHelper.TryParseInputtingSide(_view.ReadLine());
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
