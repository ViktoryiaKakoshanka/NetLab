using System;
using System.Globalization;
using VectorProgram.Controller;
using VectorProgram.Model;

namespace VectorProgram
{
    class ProgramRun
    {
        public void Run()
        {
            Vector vectorFirst = GetUserVector("first");
            Vector vectorSecond = GetUserVector("second");

            ShowVectors(vectorFirst, vectorSecond);
            ShowActionsWithVectors(vectorFirst, vectorSecond);
            
            var numericInput = GetUserNumericMultiplier();
            ShowMultiplicationAndVectors(vectorFirst, vectorSecond, numericInput);

            CompareVectors(vectorFirst, vectorSecond);

            Console.WriteLine($"The angle between {vectorFirst.ToString()} and {vectorSecond.ToString()} = {(vectorFirst.AngleBetweenVectors(vectorSecond)).ToString()}");

            Console.ReadKey();
        }

        private void CompareVectors(Vector vectorFirst, Vector vectorSecond)
        {
            Console.WriteLine($"{vectorFirst.ToString()} == {vectorSecond.ToString()} = {(vectorFirst == vectorSecond).ToString()}");
            Console.WriteLine($"{vectorFirst.ToString()} != {vectorSecond.ToString()} = {(vectorFirst != vectorSecond).ToString()}");
        }

        private void ShowMultiplicationAndVectors(Vector vectorFirst, Vector vectorSecond, double numericMultiplier)
        {
            Console.WriteLine($"{vectorFirst.ToString()} * {numericMultiplier.ToString()} = {(vectorFirst * numericMultiplier).ToString()}");
            Console.WriteLine($"{vectorSecond.ToString()} * {numericMultiplier.ToString()} = {(vectorSecond * numericMultiplier).ToString()}");

            Console.WriteLine($"{numericMultiplier.ToString()} * {vectorFirst.ToString()} = {(numericMultiplier * vectorFirst).ToString()}");
            Console.WriteLine($"{numericMultiplier.ToString()} * {vectorSecond.ToString()} = {(numericMultiplier * vectorSecond).ToString()}");
        }

        private void ShowActionsWithVectors(Vector vectorFirst, Vector vectorSecond)
        {
            Console.WriteLine("Actions with vectors:");
            Console.WriteLine($"{vectorFirst.ToString()} + {vectorSecond.ToString()} = {(vectorFirst + vectorSecond).ToString()}");
            Console.WriteLine($"{vectorFirst.ToString()} - {vectorSecond.ToString()} = {(vectorFirst - vectorSecond).ToString()}");
            Console.WriteLine($"{vectorFirst.ToString()} * {vectorSecond.ToString()} = {(vectorFirst * vectorSecond).ToString()}");
        }

        private void ShowVectors(Vector vectorFirst, Vector vectorSecond)
        {
            Console.WriteLine("Your vectors:");
            Console.WriteLine($"1 vector: {vectorFirst.ToString()}");
            Console.WriteLine($"2 vector: {vectorSecond.ToString()}");
        }

        private Vector GetUserVector(string orderByVectors)
        {
            var userInput = RequestUserInput( DataType.Vector, $"Enter the coordinates of the {orderByVectors} three-dimensional vector separated by a space.");
            return ParseUserInputAndCreateVector(userInput);
        }

        private double GetUserNumericMultiplier()
        {
            double numericInput;
            var userInput = RequestUserInput(DataType.Multiplier, "Enter a number to produce a vector by a number:");

            double.TryParse(userInput.Replace(",", "."), NumberStyles.Number, CultureInfo.CreateSpecificCulture("en-US"), out numericInput);
            return numericInput;
        }

        private void WriteErrorMessage()
        {
            Console.WriteLine("You entered non-correct numbers.");
        }
        
        private Vector ParseUserInputAndCreateVector(string userInput)
        {
            var coords = DataParser.ParseUserInput(userInput);
            return new Vector(coords[0], coords[1], coords[2]);
        }
        
        private string RequestUserInput(DataType dataType, string welcomMessage)
        {
            var userInput = string.Empty;
            var correctInput = false;

            while (!correctInput)
            {
                Console.WriteLine(welcomMessage);
                userInput = Console.ReadLine();
                correctInput = ValidateUserInput(dataType, userInput);
            }
            
            return userInput;
        }

        private bool ValidateUserInput(DataType dataType, string userInput)
        {
            var correctInput = false;
            correctInput = Validator.ValidateInput(dataType, userInput);
            if (!correctInput) WriteErrorMessage();
            return correctInput;
        }

    }
}
