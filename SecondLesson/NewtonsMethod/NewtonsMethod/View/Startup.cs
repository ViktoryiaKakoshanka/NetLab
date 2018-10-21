using NewtonsMethod.Controller;
using NewtonsMethod.Model;
using System;

namespace NewtonsMethod.View
{
    public class Startup
    {
        IRadicalSign radicalSign;

        public void UserInput()
        {
            string numericalRoot, power, accurancy;
            var correctInput = true;

            do
            {
                if (!correctInput)
                {
                    Console.Clear();
                    MessageExceptionUserInput();
                }

                Console.WriteLine("Введите стеепнь корня");
                power = Console.ReadLine();
                correctInput = false;
            } while (!ValidationInput.InputUserPower(power));

            correctInput = true;

            do
            {
                if (!correctInput)
                {
                    Console.Clear();
                    MessageExceptionUserInput();
                }

                Console.WriteLine("Введите стеепнь число под корнем");
                numericalRoot = Console.ReadLine();
                correctInput = false;
            } while (!ValidationInput.InputUserNumericalRoot(numericalRoot));

            correctInput = true;

            do
            {
                if (!correctInput)
                {
                    Console.Clear();
                    MessageExceptionUserInput();
                }

                Console.WriteLine("Введите точность вычисления от 0 до 1");
                accurancy = Console.ReadLine();
                correctInput = false;
            } while (!ValidationInput.InputUserАccurancy(accurancy));

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
            double resultMethodNewton = calc.RadicalSignByMethodNewton(radicalSign);
            double resultMathPow = calc.MathPow(radicalSign);

            radicalSign.PrintData();
            Console.WriteLine($"Методом Ньютона равен {resultMethodNewton}");
            Console.WriteLine("Проверка");
            Console.WriteLine($"{radicalSign.GetResult()} в степени {radicalSign.GetPower()} равно {resultMathPow}");
            Console.ReadKey(true);
        }
    }
}
