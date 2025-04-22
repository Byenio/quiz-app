using System.Windows.Input;
using System.Windows.Navigation;
using QuizApp.Models;
using System.Collections.ObjectModel;
using QuizApp.Generator.Helpers;

namespace QuizApp.Generator.ViewModels
{
    public class QuestionViewModel : BaseViewModel
    {
        private readonly Quiz _quiz;
        private readonly Question _question;
        private readonly NavigationService _navigationService;
        private readonly bool _isNewQuestion;
        private string _questionText;
        private int _questionPoints;
        private ObservableCollection<AnswerViewModel> _answers;

        public QuestionViewModel(Quiz quiz, Question question, NavigationService navigationService, bool isNewQuestion = false)
        {
            _quiz = quiz;
            _question = question;
            _navigationService = navigationService;
            _isNewQuestion = isNewQuestion;
            _questionText = question.Text;
            _questionPoints = question.Points;
            _answers = new ObservableCollection<AnswerViewModel>(
                question.Answers.Select(a => new AnswerViewModel(a.Text, a.IsCorrect)));

            SaveQuestionCommand = new RelayCommand(param => SaveQuestion(), param => CanSaveQuestion());
            CancelQuestionCommand = new RelayCommand(param => CancelQuestion());
        }

        public string QuestionNumber => _isNewQuestion ? $"{_quiz.Questions.Count + 1}" : $"{_quiz.Questions.IndexOf(_question) + 1}";

        public string QuestionText
        {
            get => _questionText;
            set
            {
                _questionText = value;
                OnPropertyChanged(nameof(QuestionText));
            }
        }

        public int QuestionPoints
        {
            get => _questionPoints;
            set
            {
                _questionPoints = value;
                OnPropertyChanged(nameof(QuestionPoints));
            }
        }

        public ObservableCollection<AnswerViewModel> Answers
        {
            get => _answers;
            set
            {
                _answers = value;
                OnPropertyChanged(nameof(Answers));
            }
        }

        public ICommand SaveQuestionCommand { get; }
        public ICommand CancelQuestionCommand { get; }

        private bool CanSaveQuestion()
        {
            return !string.IsNullOrWhiteSpace(QuestionText) &&
                   QuestionPoints > 0 &&
                   Answers.All(a => !string.IsNullOrWhiteSpace(a.Text)) &&
                   Answers.Any(a => a.IsCorrect);
        }

        private void SaveQuestion()
        {
            _question.Text = QuestionText;
            _question.Points = QuestionPoints;
            _question.Answers = Answers.Select(a => new Answer(a.Text, a.IsCorrect)).ToList();

            if (_isNewQuestion)
            {
                _quiz.Questions.Add(_question);
            }

            _navigationService.Navigate(new Views.QuestionList { DataContext = new QuestionListViewModel(_quiz, _navigationService) });
        }

        private void CancelQuestion()
        {
            _navigationService.Navigate(new Views.QuestionList { DataContext = new QuestionListViewModel(_quiz, _navigationService) });
        }
    }
}