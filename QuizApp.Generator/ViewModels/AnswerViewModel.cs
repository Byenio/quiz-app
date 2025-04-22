using QuizApp.Generator.ViewModels;

public class AnswerViewModel : BaseViewModel
{
    private string _text;
    private bool _isCorrect;

    public AnswerViewModel()
    {
        _text = String.Empty;
        _isCorrect = false;
    }

    public AnswerViewModel(string text, bool isCorrect)
    {
        _text = text;
        _isCorrect = isCorrect;
    }

    public string Text
    {
        get => _text;
        set
        {
            _text = value;
            OnPropertyChanged(nameof(Text));
        }
    }

    public bool IsCorrect
    {
        get => _isCorrect;
        set
        {
            _isCorrect = value;
            OnPropertyChanged(nameof(IsCorrect));
        }
    }
}