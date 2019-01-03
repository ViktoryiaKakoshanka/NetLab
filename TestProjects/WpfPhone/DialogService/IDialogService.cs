namespace WpfPhone.DialogService
{
    public interface IDialogService
    {
        string FilePath { get; set; }
        void ShowMessage(string message);
        bool OpenFileDialog();
        bool SaveFileDialog();
    }
}
