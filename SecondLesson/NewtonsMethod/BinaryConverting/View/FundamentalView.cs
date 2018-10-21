using System;
using BinaryConverting.Model;
using BinaryConverting.Controller;

namespace BinaryConverting.View
{
    class FundamentalView
    {
        INumbers number = new Numbers();

        public void UserInput()
        {
            int decNumeric;
            var correctUserInput = new ValidationUserInput();
            Console.WriteLine("Введите неотрицательное десятичное значение целого числа");


            if ((decNumeric = correctUserInput.ValidationUserInputTryInt(Console.ReadLine())) > 0)
            {
                number.DecimalNumber = decNumeric;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Вы ввели некорректное значение.");
                Console.WriteLine("Введите неотрицательное десятичное значение целого числа:");
                UserInput();
            }
        }

        public void PrintResultByConversion()
        {
            var conversionNumeric = new ConversionNumeric();
            conversionNumeric.NumberDecimalToBinary(number);
            Console.WriteLine(number.BinaryNumber);
            Console.ReadKey(true);
        }
    }
}
