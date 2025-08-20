using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using JobAppManager.ViewModel;

namespace JobAppManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel vm;
        public MainWindow()
        {
            vm = new MainWindowViewModel();
            DataContext = vm;
            InitializeComponent();
            
        }
        private void MainGrid_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            // If the click target is NOT part of the DataGrid or form controls:
            var clickedElement = e.OriginalSource as DependencyObject;

            // Traverse visual tree upward to see if the click was inside the DataGrid or StackPanel (the form)
            var parent = VisualTreeHelper.GetParent(clickedElement);
            while (parent != null)
            {
                if (parent is DataGrid || parent is StackPanel)
                    return; // clicked inside something we want to ignore

                parent = VisualTreeHelper.GetParent(parent);
            }

            // Otherwise, it's in whitespace → clear the selection
            if (DataContext is MainWindowViewModel vm)
            {
                vm.SelectedJob = null;
            }
        }

    }
}