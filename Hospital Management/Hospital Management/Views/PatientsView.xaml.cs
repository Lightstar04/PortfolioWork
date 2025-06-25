using Hospital_Management.ViewModels;
using System.Windows.Controls;

namespace Hospital_Management.Views
{
    /// <summary>
    /// Interaction logic for PatientsView.xaml
    /// </summary>
    public partial class PatientsView : UserControl
    {
        public PatientsView()
        {
            InitializeComponent();

            DataContext = new PatientsViewModel();
        }
    }
}
