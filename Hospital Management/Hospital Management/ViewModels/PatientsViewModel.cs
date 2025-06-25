using Hospital_Management.Models;
using Hospital_Management.Services;
using Hospital_Management.Views.Dialogs;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Hospital_Management.ViewModels
{
    public class PatientsViewModel : BaseViewModel
    {
        private readonly PatientService _patientService;
        
        private string _searchText;
        public string SearchText
        {
            get => _searchText;
            set
            {
                SetProperty(ref _searchText, value);
                SearchPatients(value);
            }
        }

        public ICommand AddCommand { get; }
        public List<Patient> patientsList;
        public ObservableCollection<Patient> Patients { get; set; }

        public PatientsViewModel()
        {
            _patientService = new PatientService();
            Patients = new ObservableCollection<Patient>();
            patientsList = new List<Patient>();
            AddCommand = new Command(OnAdd);

            Load();
        }

        private void Load()
        {
            var patients = _patientService.GetPatients();

            foreach (var patient in patients)
            {
                Patients.Add(patient);
                patientsList.Add(patient);
            }
        }

        private void SearchPatients(string searchText)
        {
            var patients = patientsList.Where(x => x.FirstName.Contains(searchText) ||
                x.LastName.Contains(searchText) ||
                x.PhoneNumber.Contains(searchText));

            Patients.Clear();
            foreach (var patient in patients)
            {
                Patients.Add(patient);
            }
        }

        private void OnAdd()
        {
            var dialog = new PatientDialog();
            dialog.ShowDialog();
        }
    }
}
