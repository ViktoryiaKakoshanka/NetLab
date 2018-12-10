using DecoratorStream.Model;
using DecoratorStream.View;
using System.IO;

namespace DecoratorStream
{
    public abstract class BaseDecoratorStream : Stream
    {
        protected Stream Stream { get; private set; }
        protected IConsoleView ConsoleView { get; private set; }

        public BaseDecoratorStream(Stream stream, IConsoleView view) : base()
        {
            Stream = stream;
            ConsoleView = view;
        }

        public override bool CanRead => Stream.CanRead;

        public override bool CanSeek => Stream.CanSeek;

        public override bool CanWrite => Stream.CanWrite;

        public override long Length => Stream.Length;

        public override long Position { get => Stream.Position; set => Stream.Position = value; }

        public override void Flush() => Stream.Flush();

        public override int Read(byte[] buffer, int offset, int count) => Stream.Read(buffer, offset, count);

        public override long Seek(long offset, SeekOrigin origin) => Stream.Seek(offset, origin);

        public override void SetLength(long value) => Stream.SetLength(value);

        public override void Write(byte[] buffer, int offset, int count) => Stream.Write(buffer, offset, count);
    }
}
