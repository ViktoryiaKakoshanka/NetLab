using DecoratorStream.Model;
using DecoratorStream.View;
using System;
using System.IO;

namespace DecoratorStream
{
    public class WorkWithText : Stream
    {
        private Stream _stream;
        private IConsoleView _view;
        public WorkWithText(Stream stream, IConsoleView view) : base()
        {
            _stream = stream;
            _view = view;
        }

        public override bool CanRead => _stream.CanRead;

        public override bool CanSeek => _stream.CanSeek;

        public override bool CanWrite => _stream.CanWrite;

        public override long Length => _stream.Length;

        public override long Position { get => _stream.Position; set => _stream.Position = value; }

        public override void Flush()
        {
            _stream.Flush();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            var userInputProcessor = new UserInputProcessor(_view);
            var maybePassword = userInputProcessor.RequestPassword();

            if (string.Intern(maybePassword) == string.Intern(FileData.PASSWORD))
            {
                return _stream.Read(buffer, offset, count);
            }
            else _view.ShowMessageErrorPassword();
            return 0;
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return _stream.Seek(offset, origin);
        }

        public override void SetLength(long value)
        {
            _stream.SetLength(value);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            _stream.Write(buffer, offset, count);
        }
    }
}
