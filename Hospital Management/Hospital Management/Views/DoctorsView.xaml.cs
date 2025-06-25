using Hospital_Management.ViewModels;
using System.Windows.Controls;

namespace Hospital_Management.Views
{
    /// <summary>
    /// Interaction logic for DoctorsView.xaml
    /// </summary>
    public partial class DoctorsView : UserControl
    {
        public DoctorsView()
        {
            InitializeComponent();

            DataContext = new DoctorsViewModel();
        }
    }
}
