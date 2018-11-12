using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorProgram.Controller;
using VectorProgram.Model;

namespace VectorProgram
{
    class ProgramRun
    {
        public void Run()
        {
            Vector vectorFirst = EnterUserData("first");
            Vector vectorSecond = EnterUserData("second");

            ShowVectorsAndActions(vectorFirst, vectorSecond);
            ShowMultiplicationAndVectors(vectorFirst, vectorSecond);
            CompareVectors(vectorFirst, vectorSecond);

            Console.WriteLine($"The angle between {vectorFirst.ToString()} and {vectorSecond.ToString()} = {(vectorFirst.AngleBetweenVectors(vectorSecond)).ToString()}");

            Console.ReadKey();
        }

        private static void CompareVectors(Vector vectorFirst, Vector vectorSecond)
        {
            Console.WriteLine($"{vectorFirst.ToString()} == {vectorSecond.ToString()} = {(vectorFirst == vectorSecond).ToString()}");
            Console.WriteLine($"{vectorFirst.ToString()} != {vectorSecond.ToString()} = {(vectorFirst != vectorSecond).ToString()}");
        }

        private void ShowMultiplicationAndVectors(Vector vectorFirst, Vector vectorSecond)
        {
            Console.WriteLine("Enter a number to produce a vector by a number:");
            var numericInput = ReadInputDoubleAndVerificate();
            Console.WriteLine($"{vectorFirst.ToString()} * {numericInput.ToString()} = {(vectorFirst * numericInput).ToString()}");
            Console.WriteLine($"{vectorSecond.ToString()} * {numericInput.ToString()} = {(vectorSecond * numericInput).ToString()}");

            Console.WriteLine($"{numericInput.ToString()} * {vectorFirst.ToString()} = {(numericInput * vectorFirst).ToString()}");
            Console.WriteLine($"{numericInput.ToString()} * {vectorSecond.ToString()} = {(numericInput * vectorSecond).ToString()}");
        }

        private static void ShowVectorsAndActions(Vector vectorFirst, Vector vectorSecond)
        {
            Console.WriteLine("Your vectors:");
            Console.WriteLine($"1 vector: {vectorFirst.ToString()}");
            Console.WriteLine($"2 vector: {vectorSecond.ToString()}");

            Console.WriteLine("Actions with vectors:");
            Console.WriteLine($"{vectorFirst.ToString()} + {vectorSecond.ToString()} = {(vectorFirst + vectorSecond).ToString()}");
            Console.WriteLine($"{vectorFirst.ToString()} - {vectorSecond.ToString()} = {(vectorFirst - vectorSecond).ToString()}");
            Console.WriteLine($"{vectorFirst.ToString()} * {vectorSecond.ToString()} = {(vectorFirst * vectorSecond).ToString()}");
        }

        private Vector EnterUserData(string orderByVectors)
        {
            Console.WriteLine($"Enter the coordinates of the {orderByVectors} three-dimensional vector separated by a space.");
            var userInput = ReadInputCoordsAndVerificate();
            return ParseUserInputAndCreateVector(userInput);
        }

        private void WriteErrorMessage()
        {
            Console.WriteLine("You entered non-correct numbers.");
        }
        
        private Vector ParseUserInputAndCreateVector(string userInput)
        {
            var coords = VerificateInputData.ParseUserInput(userInput);
            return new Vector(coords[0], coords[1], coords[2]);
        }

        private string ReadInputCoordsAndVerificate()
        {
            var userInput = Console.ReadLine();
            while(!VerificateInputData.VerifyInputDataCoordsVector(userInput))
            {
                WriteErrorMessage();
                ReadInputCoordsAndVerificate(); break;
            }
            return userInput;
        }

        private double ReadInputDoubleAndVerificate()
        {
            var userInput = Console.ReadLine();
            double numericInput;
            while (!VerificateInputData.VerifyInputDataCoordsVector(userInput))
            {
                WriteErrorMessage();
                ReadInputDoubleAndVerificate();
            }
            double.TryParse(userInput.Replace(",", "."), NumberStyles.Number, CultureInfo.CreateSpecificCulture("en-US"), out numericInput);
            return numericInput;
        }
    }
}
