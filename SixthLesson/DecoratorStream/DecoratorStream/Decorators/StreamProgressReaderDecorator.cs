using System;
using DecoratorStream.View;
using System.IO;

namespace DecoratorStream.Decorators
{
    internal class StreamProgressReaderDecorator : StreamBaseDecorator
    {
        public const int CountBytesToRead = 1;
        private readonly IView _view;

        internal StreamProgressReaderDecorator(Stream stream, IView view) : base(stream)
        {
            _view = view;
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            var countBytesForReading = GetByteCountToRead(offset, count);
            var printedProgress = 0;

            while (countBytesForReading > 0)
            {
                var readBytes = base.Read(buffer, offset, countBytesForReading);

                offset += readBytes;
                countBytesForReading = GetByteCountToRead(offset, count);

                printedProgress = ProgressReporter.ShowProgress(printedProgress, offset, count, _view);
            }

            _view.FinishRead();

            return count;
        }

        private static int GetByteCountToRead(int readBytes, int totalBytes)
        {
            var restBytes = totalBytes - readBytes;
            return Math.Min(restBytes, CountBytesToRead);
        }
    }
}
