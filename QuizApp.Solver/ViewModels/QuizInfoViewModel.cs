using System.Windows.Navigation;
using QuizApp.Models;

namespace QuizApp.Solver.ViewModels
{
    class QuizInfoViewModel : BaseViewModel
    {
        private Quiz _quiz;
        private NavigationService _navigationService;
        public QuizInfoViewModel(Quiz quiz, NavigationService navigationService )
        {
            this._quiz = quiz;
            this._navigationService = navigationService;
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

    }
}
