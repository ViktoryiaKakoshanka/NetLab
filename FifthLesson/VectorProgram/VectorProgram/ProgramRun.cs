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
            var vectors = CreateVectors();

            ShowVectors(vectors[0], vectors[1]);

            ShowResultsActionsWithVectors(vectors[0], vectors[1]);

            CompareVectors(vectors[0], vectors[1]);

            ShowVectorMultiplication(vectors[0], vectors[1]);

            ShowAngleBetweenVectors(vectors[0], vectors[1]);

            ShowMultiplicationVectorsByNumber(vectors[0], vectors[1]);

            Console.ReadKey(true);
        }

        private Vector[] CreateVectors()
        {
            Vector vectorFirst = GetUserVector("first");
            Vector vectorSecond = GetUserVector("second");

            return new[] { vectorFirst, vectorSecond };
        }

        private void ShowVectors(Vector first, Vector second)
        {
            Console.WriteLine("Your vectors:");
            Console.WriteLine($"1 vector: {first}");
            Console.WriteLine($"2 vector: {second}\n");
        }

        private void ShowResultsActionsWithVectors(Vector first, Vector second)
        {
            Console.WriteLine("Actions with vectors:");
            Console.WriteLine($"{first} + {second} = {(first + second)}");
            Console.WriteLine($"{first} - {second} = {(first - second)}");
            Console.WriteLine($"{first} * {second} = {(first * second)}");
            Console.WriteLine(string.Empty);
        }

        private void CompareVectors(Vector first, Vector second)
        {
            Console.WriteLine("Compare vectors:");
            Console.WriteLine($"{first} == {second} = {(first == second)}");
            Console.WriteLine($"{first} != {second} = {(first != second)}");
            Console.WriteLine(string.Empty);
        }

        private void ShowVectorMultiplication(Vector first, Vector second)
        {
            var vectorMultiplication = Vector.CalculateVectorMultiplicate(first, second);
            Console.WriteLine($"VectorMultiplication: {first} x {second} = {VectorMultiplication}");
            Console.WriteLine(string.Empty);
        }

        private void ShowAngleBetweenVectors(Vector vectorFirst, Vector vectorSecond)
        {
            var angle = vectorFirst.CalculateAngleBetweenVectors(vectorSecond);
            Console.WriteLine($"The angle between {vectorFirst} and {vectorSecond} = {Math.Abs(angle)}");
            Console.WriteLine(string.Empty);
        }

        private void ShowMultiplicationVectorsByNumber(Vector first, Vector second)
        {
            var numericMultiplier = GetUserNumericMultiplier();
            Console.WriteLine("Multiplication of vectors by number:");

            Console.WriteLine($"{first} * {numericMultiplier} = {(first * numericMultiplier)}");
            Console.WriteLine($"{second} * {numericMultiplier} = {(second * numericMultiplier)}");
            Console.WriteLine(string.Empty);
            Console.WriteLine($"{numericMultiplier} * {first} = {(numericMultiplier * first)}");
            Console.WriteLine($"{numericMultiplier} * {second} = {(numericMultiplier * second)}");
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
        
        private void WriteErrorMessage() => Console.WriteLine("You entered non-correct numbers.");
    }
}
