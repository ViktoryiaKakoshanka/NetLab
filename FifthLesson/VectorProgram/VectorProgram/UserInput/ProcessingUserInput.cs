using System;
using VectorProgram.Controller;
using VectorProgram.Model;
using VectorProgram.View;

namespace VectorProgram.UserInput
{
    public class ProcessingUserInput : IProcessingUserInput
    {
        private IConsoleView _view;

        public ProcessingUserInput(IConsoleView view)
        {
            _view = view;
        }

        public string RequestUserInput(DataType dataType, string welcomeMessage)
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
            if (!isUserInputCorrect) _view.WriteErrorMessage();
            return isUserInputCorrect;
        }
    }
}
