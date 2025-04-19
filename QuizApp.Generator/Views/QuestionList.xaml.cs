using System.Windows.Controls;
using System.Windows.Input;

namespace QuizApp.Generator.Views
{
    public partial class QuestionList : Page
    {
        public QuestionList()
        {
            InitializeComponent();
        }

        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (sender is ListViewItem item && item.DataContext is object question)
            {
                if (DataContext is ViewModels.QuestionListViewModel vm)
                {
                    vm.EditQuestionCommand.Execute(question);
                }
            }
        }
    }
}