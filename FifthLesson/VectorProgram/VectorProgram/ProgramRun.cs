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

            ShowResultsActionsWithVectors(vectorFirst, vectorSecond);

            CompareVectors(vectorFirst, vectorSecond);

            ShowVectorMultiplication(vectorFirst, vectorSecond);

            ShowAngleBetweenVectors(vectorFirst, vectorSecond);

            ShowMultiplicationVectorsByNumber(vectorFirst, vectorSecond);

            ReadKey();
        }

        private void ShowAngleBetweenVectors(Vector vectorFirst, Vector vectorSecond)
        {
            var angle = vectorFirst.CalculateAngleBetweenVectors(vectorSecond);
            WriteLine($"The angle between {vectorFirst} and {vectorSecond} = {Math.Abs(angle)}");
            WriteLine(string.Empty);
        }

        private void CompareVectors(Vector first, Vector second)
        {
            WriteLine("Compare vectors:");
            WriteLine($"{first} == {second} = {(first == second)}");
            WriteLine($"{first} != {second} = {(first != second)}");
            WriteLine(string.Empty);
        }

        private void ShowMultiplicationVectorsByNumber(Vector first, Vector second)
        {
            var numericMultiplier = GetUserNumericMultiplier();
            WriteLine("Multiplication of vectors by number:");

            WriteLine($"{first} * {numericMultiplier} = {(first * numericMultiplier)}");
            WriteLine($"{second} * {numericMultiplier} = {(second * numericMultiplier)}");
            WriteLine(string.Empty);
            WriteLine($"{numericMultiplier} * {first} = {(numericMultiplier * first)}");
            WriteLine($"{numericMultiplier} * {second} = {(numericMultiplier * second)}");
        }

        private void ShowResultsActionsWithVectors(Vector first, Vector second)
        {
            WriteLine("Actions with vectors:");
            WriteLine($"{first} + {second} = {(first + second)}");
            WriteLine($"{first} - {second} = {(first - second)}");
            WriteLine($"{first} * {second} = {(first * second)}");
            WriteLine(string.Empty);
        }

        private void ShowVectors(Vector first, Vector second)
        {
            WriteLine("Your vectors:");
            WriteLine($"1 vector: {first}");
            WriteLine($"2 vector: {second}\n");
        }

        private void ShowVectorMultiplication(Vector first, Vector second)
        {
            var VectorMultiplication = Vector.CalculateVectorMultiplicate(first, second);
            WriteLine($"VectorMultiplication: {first} x {second} = {VectorMultiplication}");
            WriteLine(string.Empty);
        }

        private Vector GetUserVector(string orderByVectors)
        {
            var userInput = RequestUserInput(DataType.Vector, $"Enter the coordinates of the {orderByVectors} three-dimensional vector separated by a space:");
            return ParseUserInputAndCreateVector(userInput);
        }

        private double GetUserNumericMultiplier()
        {
            double numericInput;
            var userInput = RequestUserInput(DataType.Multiplier, "Enter a number to produce a vector by a number:");

            double.TryParse(userInput.Replace(",", "."), NumberStyles.Number, CultureInfo.CreateSpecificCulture("en-US"), out numericInput);
            return numericInput;
        }
                
        private Vector ParseUserInputAndCreateVector(string userInput)
        {
            var coords = DataParser.ParseStringToArray(userInput);
            return new Vector(coords[0], coords[1], coords[2]);
        }
        
        private string RequestUserInput(DataType dataType, string welcomMessage)
        {
            var userInput = string.Empty;
            var correctInput = false;

            while (!correctInput)
            {
                userInput = ReadLine(welcomMessage);
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

        private string ReadLine(string text)
        {
            WriteLine(text);
            return Console.ReadLine();
        }

        private void WriteLine(string text) => Console.WriteLine(text);

        private void WriteErrorMessage() => WriteLine("You entered non-correct numbers.");

        private void ReadKey() => Console.ReadKey(true);
    }
}
