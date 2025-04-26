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
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Threading;

namespace QuizApp.Slover.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public object CurrentView { get; set; }

        private Quiz _quiz;
        private ObservableCollection<Question> _questions;
        private IDialogService _dialogService;
        private NavigationService _navigationService;
        private bool _isQuizLoaded;
        private bool _isQuizStarted;

        private DispatcherTimer _timer;
        private TimeSpan _elapsedTime;
        public string ElapsedTimeDisplay => _elapsedTime.ToString(@"hh\:mm\:ss");

        public QuizViewModel QuizVM { get; set; }


        public RelayCommand LoadQuizCommand => new RelayCommand(execute => LoadQuiz(), canExecute=> _isQuizLoaded == false);
        public RelayCommand StartQuizCommand => new RelayCommand(execute => StartQuiz(), canExecute => _isQuizLoaded == true && _isQuizStarted == false);
        public RelayCommand CheckQuizCommand => new RelayCommand(execute => StopQuiz(), canExecute => _isQuizStarted == true);

        public MainViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService ?? throw new ArgumentNullException(nameof(dialogService));
            _quiz = new Quiz(string.Empty, string.Empty);
            _questions = new ObservableCollection<Question>(_quiz.Questions);
            _isQuizLoaded = false;
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(1); 
            _timer.Tick += Timer_Tick;
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

        public ObservableCollection<Question> Questions
        {
            get => _questions;
            set
            {
                _questions = value;
                OnPropertyChanged(nameof(Questions));
            }
        }

        public Quiz Quiz => _quiz;

        public void SetNavigationService(NavigationService navigationService, string where)
        {
            _navigationService = navigationService;
            if (where == "Quiz")
            {
                QuizVM = new QuizViewModel(_quiz, _navigationService);
                _navigationService.Navigate(new Views.QuizView { DataContext = QuizVM });
            }
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
            StartTimer();
        }

        private void StopQuiz()
        {
            QuizVM.CheckQuiz();
            StopTimer();
            _isQuizStarted = false;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            _elapsedTime = _elapsedTime.Add(TimeSpan.FromSeconds(1));
            OnPropertyChanged(nameof(ElapsedTimeDisplay));
        }

        public void StartTimer()
        {
            _elapsedTime = TimeSpan.Zero;
            _timer.Start();
            OnPropertyChanged(nameof(ElapsedTimeDisplay));
        }

        public void StopTimer()
        {
            _timer.Stop();
        }

    }
}
