using Hospital_Management.Models;
using Hospital_Management.ViewModels.Dialogs;
using System.Windows;

namespace Hospital_Management.Views.Dialogs
{
    /// <summary>
    /// Interaction logic for PatientDetailsDialog.xaml
    /// </summary>
    public partial class PatientDetailsDialog : Window
    {
        public PatientDetailsDialog(Patient patient)
        {
            InitializeComponent();

            DataContext = new PatientDetailsViewModel(patient);
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
