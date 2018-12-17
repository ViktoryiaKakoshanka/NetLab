using System.Configuration;
using System.IO;
using DecoratorStream.View;

namespace DecoratorStream.Decorators
{
    public class StreamRequestPasswordDecorator : StreamBaseDecorator
    {
        private readonly IView _view;
        internal StreamRequestPasswordDecorator(Stream stream, IView view) : base(stream)
        {
            _view = view;
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            var password = _view.RequestPassword();

            if (password == ConfigurationManager.AppSettings["filePassword"])
            {
                return base.Read(buffer, offset, count);
            }
            _view.ShowMessageErrorPassword();
            return 0;
        }
    }
}