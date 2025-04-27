using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using QuizApp.Solver.Services;
using QuizApp.Solver.ViewModels;
using QuizApp.Solver.Helpers;
using QuizApp.Solver.Views;

namespace QuizApp.Solver;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        var dialogService = new DialogService();
        var viewModel = new MainViewModel(dialogService);

        DataContext = viewModel;
        Loaded += (s, e) => viewModel.SetNavigationService(QuizFrame.NavigationService,"QuizInfo");

    }

}