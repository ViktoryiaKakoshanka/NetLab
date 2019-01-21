using System.Windows;
using Microsoft.Win32;

namespace WorkWithFiles
{
    public class DialogService : IDialogService
    {
        public string FilePath { get; set; }

        public bool ShowOpenFileDialog()
        {
            var openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() != true)
            {
                return false;
            }

            FilePath = openFileDialog.FileName;
            return true;
        }

        public bool ShowSaveFileDialog()
        {
            var saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() != true)
            {
                return false;
            }

            FilePath = saveFileDialog.FileName;
            return true;
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}