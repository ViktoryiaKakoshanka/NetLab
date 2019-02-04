using System.Windows;
using Microsoft.Win32;

namespace BinaryTreeApplication
{
    public class DialogService
    {
        public string FilePath { get; set; }

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

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}
