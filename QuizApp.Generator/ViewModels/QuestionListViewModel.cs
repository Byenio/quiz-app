using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Navigation;
using QuizApp.Generator.Helpers;
using QuizApp.Generator.Services;
using QuizApp.Generator.Services.Interfaces;
using QuizApp.Models;

namespace QuizApp.Generator.ViewModels
{
    public class QuestionListViewModel : BaseViewModel
    {
        private readonly Quiz _quiz;
        private readonly NavigationService _navigationService;
        private readonly IDialogService _dialogService;
        private ObservableCollection<Question> _questions;

        public QuestionListViewModel(Quiz quiz, NavigationService navigationService, IDialogService dialogService)
        {
            _quiz = quiz;
            _navigationService = navigationService;
            _dialogService = new DialogService();
            _questions = new ObservableCollection<Question>(_quiz.Questions);
            EditQuestionCommand = new RelayCommand(param => EditQuestion(param));
            AddQuestionCommand = new RelayCommand(param => AddQuestion(param));
            DeleteQuestionCommand = new RelayCommand(param => DeleteQuestion(param));
        }

        public ObservableCollection<Question> Questions
        {
            get => _questions;
            set
            {
                _questions = value;
                OnPropertyChanged(nameof(Questions));
            }
        }

        public ICommand EditQuestionCommand { get; }
        public ICommand AddQuestionCommand { get; }
        public ICommand DeleteQuestionCommand { get; }

        private void EditQuestion(object parameter)
        {
            if (parameter is Question question)
            {
                _navigationService.Navigate(new Views.QuestionEditor
                {
                    DataContext = new QuestionViewModel(_quiz, question, _navigationService, _dialogService)
                });
            }
        }

        private void AddQuestion(object parameter)
        {
            var newQuestion = new Question(string.Empty, new List<Answer>
            {
                new Answer("", false),
                new Answer("", false),
                new Answer("", false),
                new Answer("", true)
            }, 1);
            _navigationService.Navigate(new Views.QuestionEditor
            {
                DataContext = new QuestionViewModel(_quiz, newQuestion, _navigationService, _dialogService, true)
            });
        }

        private void DeleteQuestion(object parameter)
        {
            if (parameter is Question question)
            {
                var result = _dialogService.ShowConfirmation("Are you sure you want to delete this question?",
                    "Confirm question deletion");
                if (!result) return;
                
                _quiz.Questions.Remove(question);
                Questions.Remove(question);
            }
        }
    }
}