using System.Windows;
using Microsoft.Win32;

namespace BinaryTreeApplication.Services
{
    public class DialogService : IDialogService
    {
        public string FilePath { get; private set; }

        public bool ShowOpenFileDialog()
        {
            return ShowFileDialog(new OpenFileDialog());
        }

        public bool ShowSaveFileDialog()
        {
            return ShowFileDialog(new SaveFileDialog());
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        private bool ShowFileDialog(FileDialog dialog)
        {
            if (dialog.ShowDialog() != true)
            {
                return false;
            }

            FilePath = dialog.FileName;
            return true;
        }
    }
}
