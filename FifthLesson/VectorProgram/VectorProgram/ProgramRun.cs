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

            ShowResultsActionsWithVectors(vectors);

            CompareVectors(vectors[0], vectors[1]);
            
            ShowAngleBetweenVectors(vectors[0], vectors[1]);
            
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

        private void ShowResultsActionsWithVectors(Vector[] vectors)
        {
            ShowResultsSimpleActionsWithVectors(vectors[0], vectors[1]);
            ShowVectorsMultiplication(vectors[0], vectors[1]);
            ShowMultiplicationVectorsByNumber(vectors[0], vectors[1]);
        }

        private void CompareVectors(Vector first, Vector second)
        {
            Console.WriteLine("Compare vectors:");
            Console.WriteLine($"{first} == {second} = {(first == second)}");
            Console.WriteLine($"{first} != {second} = {(first != second)}");
            Console.WriteLine(string.Empty);
        }

        private void ShowAngleBetweenVectors(Vector vectorFirst, Vector vectorSecond)
        {
            var angle = vectorFirst.CalculateAngleBetweenVectors(vectorSecond);
            Console.WriteLine($"The angle between {vectorFirst} and {vectorSecond} = {Math.Abs(angle)}");
            Console.WriteLine(string.Empty);
        }

        private void ShowResultsSimpleActionsWithVectors(Vector first, Vector second)
        {
            Console.WriteLine("Actions with vectors:");
            Console.WriteLine($"{first} + {second} = {(first + second)}");
            Console.WriteLine($"{first} - {second} = {(first - second)}");
            Console.WriteLine($"{first} * {second} = {(first * second)}");
            Console.WriteLine(string.Empty);
        }

        private void ShowVectorsMultiplication(Vector first, Vector second)
        {
            var vectorMultiplication = Vector.CalculateVectorsMultiplication(first, second);
            Console.WriteLine($"VectorMultiplication: {first} x {second} = {vectorMultiplication}");
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
            var userInput = RequestUserInput(DataType.Multiplier, "Enter multiplier:");
            return DataParser.DoubleTryParse(userInput);
        }
                
        private Vector ParseUserInputAndCreateVector(string userInput)
        {
            var coords = DataParser.ParseStringToArray(userInput);
            return new Vector(coords[0], coords[1], coords[2]);
        }
        
        private string RequestUserInput(DataType dataType, string welcomeMessage)
        {
            var userInput = string.Empty;
            var isUserInputCorrect = false;

            while (!isUserInputCorrect)
            {
                Console.WriteLine(welcomeMessage);
                userInput = Console.ReadLine();
                isUserInputCorrect = ValidateUserInput(dataType, userInput);
            }
            
            return userInput;
        }

        private bool ValidateUserInput(DataType dataType, string userInput)
        {
            var isUserInputCorrect = false;
            isUserInputCorrect = Validator.ValidateInput(dataType, userInput);
            if (!isUserInputCorrect) WriteErrorMessage();
            return isUserInputCorrect;
        }
        
        private void WriteErrorMessage() => Console.WriteLine("You entered incorrect numbers.");
    }
}
