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
            Console.WriteLine("Введите неотрицательное десятичное значение целого числа");

            

            try
            {
                decNumeric = ValidationUserInputHelper.ValidationUserInputTryInt(Console.ReadLine());
                number.DecimalNumber = decNumeric;
            }
            catch (Exception e)
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
