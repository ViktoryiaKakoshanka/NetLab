using DecoratorStream.Model;
using DecoratorStream.View;
using System.IO;

namespace DecoratorStream.Decorators
{
    internal class ProgressReadDecorator : BaseDecoratorStream
    {
        internal ProgressReadDecorator(Stream stream, IView view) : base(stream, view)     { }

        public override int Read(byte[] buffer, int offset, int count)
        {
            var restBytesRead = count;
            var startBytesRead = offset;

            do
            {
                var countReadingBytes = Stream.Read(buffer, startBytesRead, FileData.CountBytesToRead);

                startBytesRead += countReadingBytes;
                restBytesRead -= countReadingBytes;

                new ProgressRead(ConsoleView).ShowProgressRead(startBytesRead, count);

            } while (restBytesRead > 0);
            return count;
        }


        
    }
}
