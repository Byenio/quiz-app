namespace QuizApp.Generator.Services.Interfaces
{
    public interface IDialogService
    {
        bool ShowConfirmation(string message, string caption);
    
        void ShowError(string message, string title);

        string ShowSaveFileDialog(string filter, string defaultExt);
        string ShowOpenFileDialog(string filter, string defaultExt);
    }
}