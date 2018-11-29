using DecoratorStream.View;

namespace DecoratorStream
{
    class UserInputProcessor
    {
        private IConsoleView _view;

        public UserInputProcessor(IConsoleView view)
        {
            _view = view;
        }

        public string RequestPassword()
        {
            var inputPassword = _view.ReadLine("Enter the password to read the file.");
            return inputPassword;
        }
    }
}
