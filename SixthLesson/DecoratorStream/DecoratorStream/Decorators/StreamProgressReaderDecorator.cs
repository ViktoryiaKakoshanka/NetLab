using DecoratorStream.Model;
using DecoratorStream.View;
using System.IO;

namespace DecoratorStream.Decorators
{
    internal class StreamProgressReaderDecorator : StreamBaseDecorator
    {
        internal StreamProgressReaderDecorator(Stream stream, IView view) : base(stream, view)     { }

        public override int Read(byte[] buffer, int offset, int count)
        {
            var restBytesRead = count;
            var startBytesRead = offset;
            var previousCountPercents = 0;

            do
            {
                var countReadingBytes = Stream.Read(buffer, startBytesRead, FileData.CountBytesToRead);

                startBytesRead += countReadingBytes;
                restBytesRead -= countReadingBytes;

                previousCountPercents = ProgressReader.ShowProgressRead(previousCountPercents, startBytesRead, count, View);

            } while (restBytesRead > 0);

            View.FinishRead();

            return count;
        }
    }
}
