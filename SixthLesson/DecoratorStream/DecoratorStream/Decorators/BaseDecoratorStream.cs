using DecoratorStream.Model;
using DecoratorStream.View;
using System.IO;

namespace DecoratorStream
{
    public abstract class BaseDecoratorStream : Stream
    {
        private Stream _stream;
        private IConsoleView _view;
        public BaseDecoratorStream(Stream stream, IConsoleView view) : base()
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
            return _stream.Read(buffer, offset, count);
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
