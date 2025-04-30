using System.Windows.Input;
using System.Windows.Navigation;
using QuizApp.Models;
using QuizApp.Generator.Services;
using System.IO;
using QuizApp.Generator.Helpers;
using QuizApp.Generator.Services.Interfaces;
using QuizApp.Generator.Views;

namespace QuizApp.Generator.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private Quiz _quiz;
        private NavigationService _navigationService;
        private IDialogService _dialogService;
        private IFileService _fileService;

        public MainViewModel(IDialogService dialogService, IFileService fileService)
        {
            _dialogService = dialogService ?? throw new ArgumentNullException(nameof(dialogService));
            _fileService = fileService ?? throw new ArgumentNullException(nameof(fileService));
            _quiz = new Quiz(string.Empty, string.Empty);

            SaveQuizCommand = new RelayCommand(SaveQuiz);
            LoadQuizCommand = new RelayCommand(LoadQuiz);
            ClearQuizCommand = new RelayCommand(ClearQuiz);
        }


        public string QuizName
        {
            get => _quiz.Name;
            set
            {
                _quiz.Name = value;
                OnPropertyChanged(nameof(QuizName));
            }
        }

        public string QuizDescription
        {
            get => _quiz.Description;
            set
            {
                _quiz.Description = value;
                OnPropertyChanged(nameof(QuizDescription));
            }
        }

        public Quiz Quiz => _quiz;

        public ICommand SaveQuizCommand { get; }
        public ICommand LoadQuizCommand { get; }
        public ICommand ClearQuizCommand { get; }

        public void SetNavigationService(NavigationService navigationService)
        {
            _navigationService = navigationService;
            _navigationService.Navigate(new Views.QuestionList { DataContext = new QuestionListViewModel(_quiz, _navigationService, _dialogService) });
        }

        private void SaveQuiz(object parameter)
        {
            if (string.IsNullOrWhiteSpace(QuizName))
            {
                _dialogService.ShowError("Please enter a quiz name.", "Error");
                return;
            }

            if (string.IsNullOrEmpty(QuizDescription))
            {
                _dialogService.ShowError("Please enter a quiz description.", "Error");
                return;
            }

            var filePath = _dialogService.ShowSaveFileDialog("Quiz files (*.quiz)|*.quiz", "quiz");
            
            if (string.IsNullOrWhiteSpace(filePath))
            {
                _dialogService.ShowError("No file selected.", "Error");
                return;
            }

            try
            {
                _fileService.SaveQuiz(_quiz, filePath);
            }
            catch (IOException ex)
            {
                _dialogService.ShowError($"Error saving quiz: {ex.Message}", "Error");
            }
        }

        private void LoadQuiz(object parameter)
        {
            var filePath = _dialogService.ShowOpenFileDialog("Quiz files (*quiz)|*.quiz", "quiz");
            
            if (string.IsNullOrEmpty(filePath))
            {
                _dialogService.ShowError("No file selected.", "Error");
                return;
            }

            try
            {
                var quiz = _fileService.LoadQuiz(filePath);
                _quiz.Questions.Clear();
                foreach (var question in quiz.Questions)
                {
                    _quiz.Questions.Add(question);
                }
                QuizName = quiz.Name;
                QuizDescription = quiz.Description;
                _navigationService.Navigate(new Views.QuestionList { DataContext = new QuestionListViewModel(_quiz, _navigationService, _dialogService) });
            }
            catch (IOException ex)
            {
                _dialogService.ShowError($"Error loading quiz: {ex.Message}", "Error");
            }
        }

        private void ClearQuiz(object parameter)
        {
            bool confirmed = _dialogService.ShowWarning("You're about to clear all the data.", "Warning");

            if (!confirmed) return;
            
            QuizName = string.Empty;
            QuizDescription = string.Empty;
            _quiz.Questions.Clear();

            _navigationService.Navigate(new Views.QuestionList 
            { 
                DataContext = new QuestionListViewModel(_quiz, _navigationService, _dialogService) 
            });
        }
    }
}