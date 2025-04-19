using System.Windows.Input;
using System.Windows.Navigation;
using QuizApp.Model;
using QuizApp.Generator.Services;
using System.IO;
using QuizApp.Generator.Helpers;

namespace QuizApp.Generator.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private Quiz _quiz;
        private NavigationService _navigationService;
        private DialogService _dialogService;

        public MainViewModel()
        {
            _quiz = new Quiz(String.Empty, String.Empty);

            SaveFileCommand = new RelayCommand(param => SaveFile(param));
            LoadFileCommand = new RelayCommand(param => LoadFile(param));
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

        public ICommand SaveFileCommand { get; }
        public ICommand LoadFileCommand { get; }

        public void SetNavigationService(NavigationService navigationService)
        {
            _navigationService = navigationService;
            _navigationService.Navigate(new Views.QuestionList { DataContext = new QuestionListViewModel(_quiz, _navigationService) });
        }

        private void SaveFile(object parameter)
        {
            if (string.IsNullOrEmpty(QuizName))
            {
                _dialogService.ShowError("Please enter a quiz name.", "Error");
                return;
            }

            if (string.IsNullOrEmpty(QuizDescription))
            {
                _dialogService.ShowError("Please enter a quiz description.", "Error");
                return;
            }

            var filePath = parameter as string;
            if (string.IsNullOrEmpty(filePath))
            {
                _dialogService.ShowError("No file selected.", "Error");
                return;
            }

            try
            {
                FileService.SaveQuiz(_quiz, filePath);
            }
            catch (IOException ex)
            {
                _dialogService.ShowError($"Error saving quiz: {ex.Message}", "Error");
            }
        }

        private void LoadFile(object parameter)
        {
            var filePath = parameter as string;
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
                _navigationService.Navigate(new Views.QuestionList { DataContext = new QuestionListViewModel(_quiz, _navigationService) });
            }
            catch (IOException ex)
            {
                _dialogService.ShowError($"Error loading quiz: {ex.Message}", "Error");
            }
        }
    }
}