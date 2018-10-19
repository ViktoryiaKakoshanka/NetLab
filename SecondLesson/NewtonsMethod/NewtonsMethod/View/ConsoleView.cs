using NewtonsMethod.Controller;
using NewtonsMethod.Model;
using System;

namespace NewtonsMethod.View
{
    class ConsoleView
    {
        RadicalSign radicalSign;

        public void UserInput()
        {
            string numericalRoot, power, accurancy;
            var correct = true;

            do
            {
                if (!correct)
                {
                    Console.Clear();
                    MessageExceptionUserInput();
                }

                Console.WriteLine("Введите стеепнь корня");
                power = Console.ReadLine();
                correct = false;
            } while (!new ValidationData().InputUserPower(power));

            correct = true;

            do
            {
                if (!correct)
                {
                    Console.Clear();
                    MessageExceptionUserInput();
                }

                Console.WriteLine("Введите стеепнь число под корнем");
                numericalRoot = Console.ReadLine();
                correct = false;
            } while (!new ValidationData().InputUserNumericalRoot(numericalRoot));

            correct = true;

            do
            {
                if (!correct)
                {
                    Console.Clear();
                    MessageExceptionUserInput();
                }

                Console.WriteLine("Введите точность вычисления от 0 до 1");
                accurancy = Console.ReadLine();
                correct = false;
            } while (!new ValidationData().InputUserАccurancy(accurancy));

            var convert = new ParseData();
            radicalSign = new RadicalSign(convert.StringConvertingToDouble(numericalRoot), convert.StringConvertingToInt(power), convert.StringConvertingToDouble(accurancy));
        }

        public void MessageExceptionUserInput()
        {
            Console.WriteLine("Вы ввели некорректные данные");
        }

        public void MethodComparisonNewtonAndPow()
        {
            var calc = new Calculation();
            double resultMethodNewton = calc.ComputationRootByMethodNewton(radicalSign);
            double resultMathPow = calc.MathPow(radicalSign);

            radicalSign.PrintData();
            Console.WriteLine($"Методом Ньютона равен {resultMethodNewton}");
            Console.WriteLine("Проверка");
            Console.WriteLine($"{radicalSign.GetResult()} в степени {radicalSign.GetPower()} равно {resultMathPow}");
            Console.ReadKey(true);
        }
    }
}
