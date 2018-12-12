﻿using VectorProgram.Controller;
using VectorProgram.Model;
using VectorProgram.View;

namespace VectorProgram.UserInput
{
    public class UserInputProcessor : IUserInputProcessor
    {
        private readonly IConsoleView _view;

        public UserInputProcessor(IConsoleView view)
        {
            _view = view;
        }

        public string RequestInput(DataType dataType, string welcomeMessage)
        {
            var userInput = string.Empty;
            var isUserInputCorrect = false;

            while (!isUserInputCorrect)
            {
                userInput = _view.ReadLine(welcomeMessage);
                isUserInputCorrect = ValidateUserInput(dataType, userInput);
            }

            return userInput;
        }

        private bool ValidateUserInput(DataType dataType, string userInput)
        {
            var isUserInputCorrect = Validator.ValidateInput(dataType, userInput);
            if (!isUserInputCorrect) _view.WriteErrorMessage();

            return isUserInputCorrect;
        }
    }
}
