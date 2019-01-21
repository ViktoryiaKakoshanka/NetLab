namespace WorkWithFiles
{
    public interface IDialogService
    {
        string FilePath { get; set; }

        bool ShowOpenFileDialog();
        bool ShowSaveFileDialog();
        void ShowMessage(string message);
    }
}
