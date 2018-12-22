using DecoratorStream.Decorators;
using DecoratorStream.View;
using System.Configuration;
using System.IO;

namespace DecoratorStream
{
    public class ProgramRunner
    {
        private readonly IView _view;
        private readonly string _filePath;
        
        public ProgramRunner(IView view)
        {
            _view = view;
            _filePath = ConfigurationManager.AppSettings["filePath"];
        }

        public void Run()
        {
            ReadFile();
            _view.Exit();
        }

        private void ReadFile()
        {
            using (var fileStream = CreateStream(_filePath, _view))
            {
                var buffer = new byte[fileStream.Length];
                fileStream.Read(buffer, 0, (int)fileStream.Length);
            }
        }

        private static Stream CreateStream(string filePath, IView view)
        {
            Stream stream = File.OpenRead(filePath);
            stream = new StreamProgressReportingDecorator(stream, view);

            return new StreamRequestPasswordDecorator(stream, view);
        }
    }
}
