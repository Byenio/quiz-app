using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;
using QuizApp.Generator.Helpers;
using QuizApp.Generator.Services;
using QuizApp.Generator.ViewModels;

namespace QuizApp.Generator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            var dialogService = new DialogService();
            var fileService = new FileService();
            var viewModel = new MainViewModel(dialogService, fileService);

            DataContext = viewModel;
            Loaded += (s, e) => viewModel.SetNavigationService(ContentGrid.NavigationService);
        }

        private void SaveQuiz_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = DataContext as MainViewModel;
            viewModel?.SaveQuizCommand.Execute(null);
        }

        private void LoadQuiz_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = DataContext as MainViewModel;
            viewModel?.LoadQuizCommand.Execute(null);
        }

        private void ClearAll_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = DataContext as MainViewModel;
            viewModel?.ClearQuizCommand.Execute(null);
        }
    }
}