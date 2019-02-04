namespace BinaryTreeApplication.Services
{
    public interface IDialogService
    {
        string FilePath { get; }

        bool ShowOpenFileDialog();
        bool ShowSaveFileDialog();

        void ShowMessage(string message);
    }
}
