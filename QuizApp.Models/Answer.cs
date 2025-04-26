using System.ComponentModel;

namespace QuizApp.Models
{
    public class Answer : INotifyPropertyChanged
    {
        public string Text { get; set; }
        public bool IsCorrect { get; set; }

        private bool _isSelected;
        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                if (_isSelected != value)
                {
                    _isSelected = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsSelected)));
                }
            }
        }

        public Answer(string text, bool isCorrect)
        {
            Text = text ?? throw new ArgumentNullException(nameof(text));
            IsCorrect = isCorrect;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
