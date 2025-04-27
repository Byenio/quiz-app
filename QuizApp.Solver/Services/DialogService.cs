using System.Windows;
using Microsoft.Win32;
using QuizApp.Solver.Services.Interfaces;

namespace QuizApp.Solver.Services
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