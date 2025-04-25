using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizApp.Models;
using QuizApp.Slover.Services;
using QuizApp.Slover.Helpers;
using QuizApp.Slover.Services.Interfaces;
using System.IO;
using System.Windows.Navigation;
using System.Windows.Input;

namespace QuizApp.Slover.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public object CurrentView { get; set; }

        private Quiz _quiz;
        private IDialogService _dialogService;
        private NavigationService _navigationService;
        private bool _isQuizLoaded;
        private bool _isQuizStarted;

        public RelayCommand LoadQuizCommand => new RelayCommand(execute => LoadQuiz(), canExecute=> _isQuizLoaded == false);
        public RelayCommand StartQuizCommand => new RelayCommand(execute => StartQuiz(), canExecute => _isQuizLoaded == true && _isQuizStarted == false);

        public MainViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService ?? throw new ArgumentNullException(nameof(dialogService));
            _quiz = new Quiz(string.Empty, string.Empty);
            _isQuizLoaded = false;
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

        public void SetNavigationService(NavigationService navigationService, string where)
        {
            _navigationService = navigationService;
            if (where == "Quiz")
                _navigationService.Navigate(new Views.QuizView { DataContext = new QuizViewModel(_quiz, _navigationService) });
            else if (where == "QuizInfo")
                _navigationService.Navigate(new Views.QuizInfoView { DataContext = new QuizInfoViewModel(_quiz, _navigationService) });
        }

        private void LoadQuiz()
        {
            var filePath = _dialogService.ShowOpenFileDialog("Quiz files (*quiz)|*.quiz", "quiz");

            if (string.IsNullOrEmpty(filePath))
            {
                _dialogService.ShowError("No file selected.", "Error");
                return;
            }

            try
            {
                var quiz = FileService.LoadQuiz(filePath);
                _quiz.Questions.Clear();
                foreach (var question in quiz.Questions)
                {
                    _quiz.Questions.Add(question);
                }
                QuizName = quiz.Name;
                QuizDescription = quiz.Description;
            }
            catch (IOException ex)
            {
                _dialogService.ShowError($"Error loading quiz: {ex.Message}", "Error");
            }
            _isQuizLoaded = true;
            SetNavigationService(_navigationService,"QuizInfo");

        }

        private void StartQuiz()
        {
            SetNavigationService(_navigationService, "Quiz");
            _isQuizStarted = true;
        }
    }
}
