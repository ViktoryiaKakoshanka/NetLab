using System;
using DecoratorStream.View;
using System.IO;

namespace DecoratorStream.Decorators
{
    internal class StreamProgressReportingDecorator : StreamBaseDecorator
    {
        public const int CountBytesToRead = 1;
        private readonly IView _view;

        internal StreamProgressReportingDecorator(Stream stream, IView view) : base(stream)
        {
            _view = view;
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            var countBytesForReading = GetByteCountToRead(offset, count);

            while (countBytesForReading > 0)
            {
                var readBytes = base.Read(buffer, offset, countBytesForReading);

                offset += readBytes;
                countBytesForReading = GetByteCountToRead(offset, count);

                ProgressReporter.ShowProgress(offset, count, _view);
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
