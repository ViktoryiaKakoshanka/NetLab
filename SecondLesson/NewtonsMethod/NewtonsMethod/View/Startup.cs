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

            power = RequestUserInput(InputedParams.Power, "Enter the root stem");
            numericalRoot = RequestUserInput(InputedParams.Numerical, "Enter the number under the root");
            accurancy = RequestUserInput(InputedParams.Аccurancy, "Enter a calculation accuracy from 0 to 1");
            
            var dataParser = new DataParser();
            var parsedNumericalRoot = dataParser.ParseStringToDouble(numericalRoot);
            var parsedPower = dataParser.ParseStringToInt(power);
            var parsedAccurancy = dataParser.ParseStringToDouble(accurancy);

            radicalSign = new RadicalSign(parsedNumericalRoot, parsedPower, parsedAccurancy);
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

        private string RequestUserInput(InputedParams method, string welcomeMessage)
        {
            var correctInput = false;
            var userInput = string.Empty;

            while (!correctInput)
            {
                Console.WriteLine(welcomeMessage);
                userInput = Console.ReadLine();
                correctInput = ValidateUserInput(method, userInput);
            }
            return userInput;
        }

        private bool ValidateUserInput(InputedParams param, string userInput)
        {
            var correctInput = Validator.ValidateInput(userInput, param);
            if (!correctInput) ShowErrorMessageUserInput();

            return correctInput;
        }

        private void ShowErrorMessageUserInput()
        {
            Console.WriteLine("You entered incorrect data");
        }

    }
}
