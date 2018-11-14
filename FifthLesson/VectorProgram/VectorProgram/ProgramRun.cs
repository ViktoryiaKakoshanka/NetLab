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

            ShowMultiplicationAndVectors(vectorFirst, vectorSecond);

            CompareVectors(vectorFirst, vectorSecond);

            ShowVectorMultiplication(vectorFirst, vectorSecond);

            ShowAngleBetweenVectors(vectorFirst, vectorSecond);

            ReadKey();
        }

        private void ShowAngleBetweenVectors(Vector vectorFirst, Vector vectorSecond)
        {
            var angle = vectorFirst.AngleBetweenVectors(vectorSecond);
            WriteLine($"The angle between {vectorFirst.ToString()} and {vectorSecond.ToString()} = {angle.ToString()}");
        }

        private void CompareVectors(Vector first, Vector second)
        {
            WriteLine("Compare vectors:");
            WriteLine($"{first.ToString()} == {second.ToString()} = {(first == second).ToString()}");
            WriteLine($"{first.ToString()} != {second.ToString()} = {(first != second).ToString()}");
        }

        private void ShowMultiplicationAndVectors(Vector first, Vector second)
        {
            var numericMultiplier = GetUserNumericMultiplier();
            WriteLine("Multiplication of vectors by number:");

            WriteLine($"{first.ToString()} * {numericMultiplier.ToString()} = {(first * numericMultiplier).ToString()}");
            WriteLine($"{second.ToString()} * {numericMultiplier.ToString()} = {(second * numericMultiplier).ToString()}\n");

            WriteLine($"{numericMultiplier.ToString()} * {first.ToString()} = {(numericMultiplier * first).ToString()}");
            WriteLine($"{numericMultiplier.ToString()} * {second.ToString()} = {(numericMultiplier * second).ToString()}");
        }

        private void ShowActionsWithVectors(Vector first, Vector second)
        {
            WriteLine("Actions with vectors:");
            WriteLine($"{first.ToString()} + {second.ToString()} = {(first + second).ToString()}");
            WriteLine($"{first.ToString()} - {second.ToString()} = {(first - second).ToString()}");
            WriteLine($"{first.ToString()} * {second.ToString()} = {(first * second).ToString()}");
        }

        private void ShowVectors(Vector first, Vector second)
        {
            WriteLine("Your vectors:");
            WriteLine($"1 vector: {first.ToString()}");
            WriteLine($"2 vector: {second.ToString()}");
        }

        private void ShowVectorMultiplication(Vector first, Vector second)
        {
            var VectorMultiplication = Vector.VectorMultiplicate(first, second);
            WriteLine($"VectorMultiplication = {VectorMultiplication}");
        }

        private Vector GetUserVector(string orderByVectors)
        {
            var userInput = RequestUserInput(DataType.Vector, $"Enter the coordinates of the {orderByVectors} three-dimensional vector separated by a space.");
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
            WriteLine("You entered non-correct numbers.");
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

        private void WriteLine(string text)
        {
            Console.WriteLine(text);
        }

        private string ReadLine(string text)
        {
            WriteLine(text);
            return Console.ReadLine();
        }

        private void ReadKey()
        {
            Console.ReadKey(true);
        }
    }
}
