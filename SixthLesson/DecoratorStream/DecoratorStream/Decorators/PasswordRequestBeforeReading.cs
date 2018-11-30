using System.IO;
using DecoratorStream.Model;
using DecoratorStream.View;

namespace DecoratorStream.Decorators
{
    public class PasswordRequestBeforeReading : BaseDecoratorStream
    {
        public PasswordRequestBeforeReading(Stream stream, IConsoleView view) : base(stream, view) { }

        public override int Read(byte[] buffer, int offset, int count)
        {
            var userInputProcessor = new UserInputProcessor(ConsoleView);
            var password = userInputProcessor.RequestPassword();

            if (string.Intern(password) != string.Intern(FileData.PASSWORD))
            {
                ConsoleView.ShowMessageErrorPassword();
                return 0;
            }

            return Stream.Read(buffer, offset, count);
        }
    }
}
