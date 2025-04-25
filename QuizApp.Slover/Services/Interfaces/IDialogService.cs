namespace QuizApp.Slover.Services.Interfaces
{
    public interface IDialogService
    {
        bool ShowConfirmation(string message, string caption);

        void ShowError(string message, string title);

        string ShowOpenFileDialog(string filter, string defaultExt);
    }
}