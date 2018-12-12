using System.Configuration;
using System.IO;
using DecoratorStream.View;

namespace DecoratorStream.Decorators
{
    public class RequestPasswordDecorator : BaseDecoratorStream
    {
        public RequestPasswordDecorator(Stream stream, IConsoleView view) : base(stream, view) { }

        public override int Read(byte[] buffer, int offset, int count)
        {
            var password = ConsoleView.RequestPassword();

            if (string.Intern(password) != string.Intern(ConfigurationManager.AppSettings["filePassword"]))
            {
                ConsoleView.ShowMessageErrorPassword();
                return 0;
            }

            return Stream.Read(buffer, offset, count);
        }
    }
}
