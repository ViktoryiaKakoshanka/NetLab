using System.Configuration;
using System.IO;
using DecoratorStream.View;

namespace DecoratorStream.Decorators
{
    public class StreamRequestPasswordDecorator : StreamBaseDecorator
    {
        internal StreamRequestPasswordDecorator(Stream stream, IView view) : base(stream, view) { }

        public override int Read(byte[] buffer, int offset, int count)
        {
            var password = View.RequestPassword();

            if (string.Intern(password) == string.Intern(ConfigurationManager.AppSettings["filePassword"]))
            {
                return Stream.Read(buffer, offset, count);
            }
            View.ShowMessageErrorPassword();
            return 0;
        }
    }
}