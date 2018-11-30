using System.IO;
using DecoratorStream.Model;
using DecoratorStream.View;

namespace DecoratorStream.Decorators
{
    public  class PasswordRequestBeforeReading : BaseDecoratorStream
    {
        private Stream _stream;
        private IConsoleView _view;

        public PasswordRequestBeforeReading(Stream stream, IConsoleView view) : base(stream, view)
        {
            _stream = stream;
            _view = view;
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            var userInputProcessor = new UserInputProcessor(_view);
            var password = userInputProcessor.RequestPassword();

            if (string.Intern(password) == string.Intern(FileData.PASSWORD))
            {
                return _stream.Read(buffer, offset, count);
            }
            else _view.ShowMessageErrorPassword();
            return 0;
        }
    }
}
