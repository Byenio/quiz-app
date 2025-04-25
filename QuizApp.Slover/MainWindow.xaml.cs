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
using QuizApp.Slover.Services;
using QuizApp.Slover.ViewModels;
using QuizApp.Slover.Helpers;

namespace QuizApp.Slover;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        var dialogService = new DialogService();
        var viewModel = new MainViewModel(dialogService);

        DataContext = viewModel;
    }

}