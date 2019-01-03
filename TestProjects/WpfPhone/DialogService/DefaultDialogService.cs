using System.Windows;
using Microsoft.Win32;

namespace WpfPhone.DialogService
{
    public class DefaultDialogService : IDialogService
    {
        public string FilePath { get; set; }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        public bool OpenFileDialog()
        {
            var openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() != true)
            {
                return false;
            }

            FilePath = openFileDialog.FileName;
            return true;
        }

        public bool SaveFileDialog()
        {
            var saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() != true)
            {
                return false;
            }

            FilePath = saveFileDialog.FileName;
            return true;
        }
    }
}
