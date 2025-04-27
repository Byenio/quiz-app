using dotenv.net;
using System.Windows;

namespace QuizApp.Solver;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        DotEnv.Load();
    }
}
