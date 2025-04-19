using System.Windows;
using Microsoft.Win32;
using QuizApp.Generator.ViewModels;

namespace QuizApp.Generator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var viewModel = new MainViewModel();
            DataContext = viewModel;
            Loaded += (s, e) => viewModel.SetNavigationService(ContentGrid.NavigationService);
        }

        private void SaveQuiz_Click(object sender, RoutedEventArgs e)
        {
            var saveFileDialog = new SaveFileDialog
            {
                Filter = "Quiz files (*.quiz)|*.quiz",
                DefaultExt = "quiz"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                var viewModel = DataContext as MainViewModel;
                viewModel?.SaveFileCommand.Execute(saveFileDialog.FileName);
            }
        }

        private void LoadQuiz_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Quiz files (*.quiz)|*.quiz"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                var viewModel = DataContext as MainViewModel;
                viewModel?.LoadFileCommand.Execute(openFileDialog.FileName);
            }
        }
    }
}