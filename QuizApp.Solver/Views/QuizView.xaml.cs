using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QuizApp.Solver.Views
{

    public partial class QuizView : Page
    {
        public QuizView()
        {
            InitializeComponent();
        }

        private void QuizView_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
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
