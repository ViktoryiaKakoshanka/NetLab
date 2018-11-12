using NewtonsMethod.Controller;
using NewtonsMethod.Model;
using System;

namespace NewtonsMethod.View
{
    public class Startup
    {

        public void InitializeDataByUser(IRadicalSign radicalSign)
        {
            string numericalRoot, power, accurancy;
            var correctInput = false;

            power = EnterUserData(correctInput, InputedParams.Power, "Enter the root stem");
            numericalRoot = EnterUserData(correctInput, InputedParams.Numerical, "Enter the number under the root");
            accurancy = EnterUserData(correctInput, InputedParams.Аccurancy, "Enter a calculation accuracy from 0 to 1");
            
            var convert = new DataParser();
            radicalSign = new RadicalSign(convert.TransformStringToDouble(numericalRoot), 
                convert.TransformStringToInt(power), 
                convert.TransformStringToDouble(accurancy));
        }
        
        public void CompareMethodsNewtonAndPow(IRadicalSign radicalSign)
        {
            var calc = new Calculator();
            double radicalSignMethodNewton = Math.Round(calc.CalculateRadicalSign(radicalSign), 5);
            double radicalSignMathPow = Math.Round(calc.CalculateMathPow(radicalSign), 5);
            PrintCompareResult(radicalSign, radicalSignMethodNewton, radicalSignMathPow);
        }

        private static void PrintCompareResult(IRadicalSign radicalSign, double radicalSignMethodNewton, double radicalSignMathPow)
        {
            Console.WriteLine(radicalSign.ToString());
            Console.WriteLine($"Newton's method is {radicalSignMethodNewton}");
            Console.WriteLine("Check");
            Console.WriteLine($"{radicalSign.Result} to degree {radicalSign.Power} equally {radicalSignMathPow}");
            Console.ReadKey(true);
        }

        private string EnterUserData(bool correctInput, InputedParams method, string helpMessage)
        {
            Console.WriteLine(helpMessage);
            var userInput = Console.ReadLine();

            while (!correctInput)
            {
                VerifyUserInput(method, helpMessage, ref correctInput, userInput);
            }
            return userInput;
        }

        private void VerifyUserInput(InputedParams method, string helpMessage, ref bool correctInput, string userInput)
        {
            if (method == InputedParams.Power)  correctInput = InputValidation.ValidateUserInputPower(userInput);
            if (method == InputedParams.Numerical)  correctInput = InputValidation.ValidateUserInputNumericalRoot(userInput);
            if (method == InputedParams.Аccurancy) correctInput = InputValidation.ValidateUserInputАccurancy(userInput);
            if (!correctInput) ShowErrorMessageUserInput();
        }

        private void ShowErrorMessageUserInput()
        {
            Console.WriteLine("You entered incorrect data");
        }

    }
}
