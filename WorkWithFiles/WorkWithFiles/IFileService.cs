namespace WorkWithFiles
{
    public interface IFileService
    {
        string Open(string filePath);
        void Save(string filePath, string text);
    }
}
