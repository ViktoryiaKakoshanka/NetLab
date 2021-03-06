﻿using System;
using VectorProgram.Model;

namespace VectorProgram.View
{
    public class ConsoleView : IView
    {
        public void Exit()
        {
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey(true);
        }

        public string RequestInput(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }

        public void ShowErrorMessage() => Console.WriteLine("You entered incorrect numbers.");

        public void ShowVectors(Vector first, Vector second)
        {
            Console.WriteLine("Your vectors:");
            Console.WriteLine(first.ToString());
            Console.WriteLine(second.ToString());
        }

        public void ShowResultsOfVectorSum(Vector first, Vector second, Vector sumResult, Vector differenceResult)
        {
            Console.WriteLine("Actions with vectors:");
            Console.WriteLine($"{first} + {second} = {sumResult}");
            Console.WriteLine($"{first} - {second} = {differenceResult}");
        }

        public void ShowResultOfScalarProduct(Vector first, Vector second, double result)
        {
            Console.WriteLine($"Scalar product: {first} * {second} = {result}\n");
        }

        public void ShowResultOfVectorProduct(Vector first, Vector second, Vector result)
        {
            Console.WriteLine($"Vector product: {first} x {second} = {result}\n");
        }

        public void ShowResultOfProductVectorByConstant(Vector first, Vector result, double multiplier)
        {
            Console.WriteLine("Multiplication of vectors by number:");

            Console.WriteLine($"{first} * {multiplier} = {result}\n");
        }

        public void ShowResultsOfVectorsComparison(Vector first, Vector second, bool equalityResult, bool inequalityResult)
        {
            Console.WriteLine("Compare vectors:");
            Console.WriteLine($"{first} == {second} = {equalityResult}");
            Console.WriteLine($"{first} != {second} = {inequalityResult}");
            Console.WriteLine(string.Empty);
        }

        public void ShowAngleBetweenVectors(Vector first, Vector second, double angle)
        {
            Console.WriteLine($"The angle between {first} and {second} = {Math.Abs(angle)}");
            Console.WriteLine(string.Empty);
        }
    }
}
