using System.Windows;
using Microsoft.Win32;
using QuizApp.Generator.Services.Interfaces;

namespace QuizApp.Generator.Services
{
    public class DialogService : IDialogService
    {
        public bool ShowConfirmation(string message, string caption)
        {
            return MessageBox.Show(message, caption, MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes;
        }

        public void ShowError(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public bool ShowWarning(string message, string caption)
        {
            return MessageBox.Show(message, caption, MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK;
        }

        public string ShowSaveFileDialog(string filter, string defaultExt)
        {
            var dialog = new SaveFileDialog
            {
                Filter = filter,
                DefaultExt = defaultExt,
            };
            
            return dialog.ShowDialog() == true ? dialog.FileName : null;
        }

        public string ShowOpenFileDialog(string filter, string defaultExt)
        {
            var dialog = new OpenFileDialog
            {
                Filter = filter
            };

            return dialog.ShowDialog() == true ? dialog.FileName : null;
        }
    }
}