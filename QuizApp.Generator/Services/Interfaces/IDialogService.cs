namespace QuizApp.Generator.Services.Interfaces
{
    public interface IDialogService
    {
        bool ShowConfirmation(string message, string caption);
        void ShowError(string message, string title);
        bool ShowWarning(string message, string caption);

        string ShowSaveFileDialog(string filter, string defaultExt);
        string ShowOpenFileDialog(string filter, string defaultExt);
    }
}