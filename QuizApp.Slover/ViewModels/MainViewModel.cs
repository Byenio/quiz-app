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
        private Quiz _quiz;
        private IDialogService _dialogService;
        public RelayCommand LoadQuizCommand => new RelayCommand(execute => LoadQuiz());

        public MainViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService ?? throw new ArgumentNullException(nameof(dialogService));
            _quiz = new Quiz(string.Empty, string.Empty);
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
        }
    }
}
