using Hospital_Management.Data;
using Hospital_Management.Models;
using Hospital_Management.ViewModels.Dialogs;
using System.Windows;

namespace Hospital_Management.Views.Dialogs
{
    /// <summary>
    /// Interaction logic for PatientUpdateDialog.xaml
    /// </summary>
    public partial class PatientUpdateDialog : Window
    {
        private static HospitalDbContext _context = new();
        public PatientUpdateDialog(Patient patient)
        {
            InitializeComponent();

            DataContext = new PatientDetailsViewModel(patient);
        }

        private void Cancelled_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void Saved_Click(object sender, RoutedEventArgs e)
        {
            _context.SaveChanges();
        }
    }
}
