using LMS.Views;
using System.Windows;

namespace LMS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Stack_Click(object sender, RoutedEventArgs e)
        {
            var window = new StackPanelWindow();
            window.Owner = this;
            window.Show();
        }

        private void Grid_Click(object sender, RoutedEventArgs e)
        {
            var window = new GridWindow();
            window.Owner = this;
            window.Show();
        }

        private void DataGrid_Click(object sender, RoutedEventArgs e)
        {
            var window = new DataGrid();
            window.Show();
        }

        private void InputWindow_Click(object sender, RoutedEventArgs e)
        {
            var window = new InputWindow();
            window.Show();
        }

        private void EmployeesWindow_Click(object sender, RoutedEventArgs e)
        {
            var window = new EmployeeWindow();
            window.Show();
        }
    }
}