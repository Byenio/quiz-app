using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

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
            if (sender is not ListViewItem item || item.DataContext is not object question) return;
            
            if (DataContext is ViewModels.QuestionListViewModel vm)
            {
                vm.EditQuestionCommand.Execute(question);
            }
        }
        
        private void QuestionListView_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            var scrollViewer = FindVisualChild<ScrollViewer>(QuestionListView);
            double scrollAmount = e.Delta > 0 ? -1 : 1;
            const double scrollMultiplier = 1;
            scrollViewer.ScrollToVerticalOffset(scrollViewer.VerticalOffset + scrollAmount * scrollMultiplier);
            e.Handled = true;
        }
        
        private static T FindVisualChild<T>(DependencyObject obj) where T : DependencyObject
        {
            for (var i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                var child = VisualTreeHelper.GetChild(obj, i);
                if (child is T t)
                    return t;
                var childOfChild = FindVisualChild<T>(child);
                
                return childOfChild;
            }
            return null;
        }
    }
}