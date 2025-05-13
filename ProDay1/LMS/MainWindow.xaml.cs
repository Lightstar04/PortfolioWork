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
    }
}