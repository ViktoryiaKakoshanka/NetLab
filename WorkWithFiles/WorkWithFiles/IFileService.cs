namespace WorkWithFiles
{
    public interface IFileService
    {
        string ReadFile(string filePath);
        void Save(string filePath, string text);
    }
}
