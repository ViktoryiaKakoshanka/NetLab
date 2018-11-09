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
            var correctInput = false;
            power = CallUserInput(correctInput, ValidationInputMethods.Power, "Введите стеепнь корня");
            numericalRoot = CallUserInput(correctInput, ValidationInputMethods.Numerical, "Введите число под корнем");
            accurancy = CallUserInput(correctInput, ValidationInputMethods.Аccurancy, "Введите точность вычисления от 0 до 1");
            
            var convert = new ParseData();
            radicalSign = new RadicalSign(convert.StringConvertingToDouble(numericalRoot), convert.StringConvertingToInt(power), convert.StringConvertingToDouble(accurancy));
        }
        
        public void MethodComparisonNewtonAndPow()
        {
            var calc = new Calculation();
            double resultMethodNewton = calc.RadicalSignByMethodNewton(radicalSign);
            double resultMathPow = Math.Round(calc.MathPow(radicalSign), 5);

            radicalSign.PrintData();
            Console.WriteLine($"Newton's method is {resultMethodNewton}");
            Console.WriteLine("Check");
            Console.WriteLine($"{radicalSign.GetResult()} to degree {radicalSign.GetPower()} equally {resultMathPow}");
            Console.ReadKey(true);
        }
        
        private string CallUserInput(bool correctInput, ValidationInputMethods method, string helpMessage)
        {
            var userInput = string.Empty;
            while(!correctInput)
            {
                VerifyUserInput(method, helpMessage, ref correctInput, out userInput);
            }
            return userInput;
        }

        private void VerifyUserInput(ValidationInputMethods method, string helpMessage, ref bool correctInput, out string userInput)
        {
            Console.WriteLine(helpMessage);
            userInput = Console.ReadLine();
            if (method == ValidationInputMethods.Power)  correctInput = ValidationInput.InputUserPower(userInput);
            if (method == ValidationInputMethods.Numerical)  correctInput = ValidationInput.InputUserNumericalRoot(userInput);
            if (method == ValidationInputMethods.Аccurancy) correctInput = ValidationInput.InputUserАccurancy(userInput);
            if (!correctInput) MessageExceptionUserInput();
        }

        private void MessageExceptionUserInput()
        {
            Console.WriteLine("You entered incorrect data");
        }

    }
}
