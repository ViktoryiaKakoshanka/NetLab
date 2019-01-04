using System.IO;
using System.Text;

namespace WorkWithFiles
{
    public class FileService
    {
        public string Open(string filePath)
        {
            byte[] text;
            using (var fileStream = new FileStream(filePath, FileMode.Open))
            {
                fileStream.Read(text = new byte[(int)fileStream.Length], 0, (int)fileStream.Length);
            }
            return Encoding.UTF8.GetString(text);
        }

        public void Save(string filePath, string text)
        {
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                fileStream.Write(Encoding.ASCII.GetBytes(text), 0, text.Length);
            }
        }
    }
}
