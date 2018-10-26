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
            double a = 0, b = 0, c = 0;
            Triangle triangle;
            _view = view;

            Console.Clear();

            while (a <= 0)
            {
                InputSideUser(ref a, '1', view);
            }

            while (b <= 0)
            {
                InputSideUser(ref b, '2', view);
            }

            while (c <= 0)
            {
                InputSideUser(ref c, '3', view);
            }

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

        private void InputSideUser(ref double side, char sideNumber, IConsoleView view)
        {
            Console.WriteLine($"Введите значение {sideNumber} строны");
            side = ValidateTriangleHelper.TryParseInputtingSide(Console.ReadLine());
            if (side == 0.0) view.WarningMessage();
        }

        private void FinishedRun()
        {
            Console.WriteLine("Желаете начать заново? (да — нажмите Enter, нет — любую клавишу клавиатуры)");

            ConsoleKeyInfo keyInfo = Console.ReadKey();
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
