﻿namespace BinaryConverting.Controller
{
    public class ValidateUserInputHelper
    {
        public static int ValidationUserInputTryInt(string userInput)
        {
            int resultValidation = 0;
            resultValidation = int.Parse(userInput);
            return resultValidation;
        }
    }
}