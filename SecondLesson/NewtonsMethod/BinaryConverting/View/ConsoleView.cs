﻿using System;
using BinaryConverting.Model;
using BinaryConverting.Controller;

namespace BinaryConverting.View
{
    class ConsoleView: IConsoleView
    {
        public void PrintResultByConversion(INumbers number)
        {
            Console.WriteLine("Результат:");
            Console.WriteLine($"Десятичное число:{number.DecimalNumber}");
            Console.WriteLine($"Двоичное число:{number.BinaryNumber}");

            Console.ReadKey(true);
        }

        public void WarningMessage(string messEx = null)
        {
            Console.Clear();
            Console.WriteLine($"{messEx} Необходимо повторить ввод значения. ");
        }
    }
}
