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

        private void EmployeesWindow_Click(object sender, RoutedEventArgs e)
        {
            var window = new EmployeeWindow();
            window.Owner = this;
            window.Show();
        }

        private void DepartmentsWindow_Click(object sender, RoutedEventArgs e)
        {
            var window = new DepartmentWindow();
            window.Owner = this;
            window.Show();
        }
    }
}