﻿using QuizApp.Models;
using QuizApp.Solver.Services;
using QuizApp.Solver.Helpers;
using QuizApp.Solver.Services.Interfaces;
using System.IO;
using System.Windows.Navigation;
using System.Collections.ObjectModel;
using System.Windows.Threading;

namespace QuizApp.Solver.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public object CurrentView { get; set; }

        private Quiz _quiz;
        private ObservableCollection<Question> _questions;
        private IDialogService _dialogService;
        private NavigationService _navigationService;

        private DispatcherTimer _timer;
        private TimeSpan _elapsedTime;
        public string ElapsedTimeDisplay => _elapsedTime.ToString(@"hh\:mm\:ss");

        public QuizViewModel QuizVM { get; set; }


        public RelayCommand LoadQuizCommand => new RelayCommand(execute => LoadQuiz(), canExecute=> IsQuizLoaded == false);
        public RelayCommand StartQuizCommand => new RelayCommand(execute => StartQuiz(), canExecute => IsQuizLoaded == true && IsQuizStarted == false);
        public RelayCommand CheckQuizCommand => new RelayCommand(execute => StopQuiz(), canExecute => IsQuizStarted == true);

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

        private bool _isQuizStarted;
        public bool IsQuizStarted
        {
            get => _isQuizStarted;
            set
            {
                _isQuizStarted = value;
                OnPropertyChanged(nameof(IsQuizStarted));
            }
        }

        private bool _isQuizLoaded;
        public bool IsQuizLoaded
        {
            get => _isQuizLoaded;
            set
            {
                _isQuizLoaded = value;
                OnPropertyChanged(nameof(IsQuizLoaded));
            }
        }

        private int _score;
        public int Score
        {
            get => _score;
            set
            {
                _score = value;
                OnPropertyChanged(nameof(Score));
            }
        }
        private int _totalPoints;
        public int TotalPoints
        {
            get => _totalPoints;
            set
            {
                _totalPoints = value;
                OnPropertyChanged(nameof(TotalPoints));
            }
        }
        private string _scoreDisplay;
        public string ScoreDisplay
        {
            get => _scoreDisplay;
            set
            {
                _scoreDisplay = value;
                OnPropertyChanged(nameof(ScoreDisplay));
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
            IsQuizStarted = false;
            TotalPoints = _quiz.GetTotalPoints();
            ScoreDisplay = $"Wynik: {Score} / {TotalPoints}";
            SetNavigationService(_navigationService,"QuizInfo");

        }

        private void StartQuiz()
        {
            SetNavigationService(_navigationService, "Quiz");
            IsQuizStarted = true;
            QuizVM.IsQuizStarted = true;
            StartTimer();
        }

        private void StopQuiz()
        {
            StopTimer();
            Score = QuizVM.CheckQuiz();
            ScoreDisplay = $"Wynik: {Score} / {TotalPoints}";
            IsQuizStarted = false;
            QuizVM.IsQuizStarted = false;
            IsQuizLoaded = false;
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
