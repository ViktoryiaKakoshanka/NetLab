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
            Console.WriteLine("Введите координаты первого трехмерного вектора через пробел.");

            var userInput = ReadInputCoordsAndVerificate();
            var vector1 = ParseUserInputAndCreateVector(userInput);

            Console.WriteLine("Введите координаты второго трехмерного вектора через пробел.");
            userInput = ReadInputCoordsAndVerificate();
            var vector2 = ParseUserInputAndCreateVector(userInput);

            Console.WriteLine("Ваши вектора:");
            Console.WriteLine($"1 вектор: {vector1.ToString()}");
            Console.WriteLine($"2 вектор: {vector2.ToString()}");

            Console.WriteLine("Действия с векторами:");
            Console.WriteLine($"{vector1.ToString()} + {vector2.ToString()} = {(vector1 + vector2).ToString()}");
            Console.WriteLine($"{vector1.ToString()} - {vector2.ToString()} = {(vector1 - vector2).ToString()}");
            Console.WriteLine($"{vector1.ToString()} * {vector2.ToString()} = {(vector1 * vector2).ToString()}");

            Console.WriteLine("Введите число для произведения вектора на число:");
            var numericInput = ReadInputDoubleAndVerificate();
            Console.WriteLine($"{vector1.ToString()} * {numericInput.ToString()} = {(vector1 * numericInput).ToString()}");
            Console.WriteLine($"{vector2.ToString()} * {numericInput.ToString()} = {(vector2 * numericInput).ToString()}");
            
            Console.WriteLine($"{numericInput.ToString()} * {vector1.ToString()} = {(numericInput * vector1).ToString()}");
            Console.WriteLine($"{numericInput.ToString()} * {vector2.ToString()} = {(numericInput * vector2).ToString()}");

            Console.WriteLine($"{vector1.ToString()} == {vector2.ToString()} = {(vector1 == vector2).ToString()}");
            Console.WriteLine($"{vector1.ToString()} != {vector2.ToString()} = {(vector1 != vector2).ToString()}");

            Console.WriteLine($"Угол между {vector1.ToString()} и {vector2.ToString()} = {(vector1.AngleBetweenVectors(vector2)).ToString()}");

            Console.ReadKey();
        }

        private void WriteErrorMessage()
        {
            Console.WriteLine("Вы ввели некореектные числа.");
        }
        
        private Vector ParseUserInputAndCreateVector(string userInput)
        {
            var coords = VerificateInputData.ParseUserInput(userInput);
            return new Vector(coords[0], coords[1], coords[2]);
        }

        private string ReadInputCoordsAndVerificate()
        {
            var userInput = Console.ReadLine();
            while(!VerificateInputData.ValidateUserInputCoordsVector(userInput))
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
            while (!VerificateInputData.ValidateUserInputCoordsVector(userInput))
            {
                WriteErrorMessage();
                ReadInputDoubleAndVerificate();
            }
            double.TryParse(userInput.Replace(",", "."), NumberStyles.Number, CultureInfo.CreateSpecificCulture("en-US"), out numericInput);
            return numericInput;
        }
    }
}
