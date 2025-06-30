using Hospital_Management.Extensions;
using Hospital_Management.Models;
using Hospital_Management.Services;
using Hospital_Management.Views.Dialogs;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System.Collections.ObjectModel;
using System.Windows;
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

        private Patient _selectedPatient;
        public Patient SelectedPatient
        {
            get => _selectedPatient;
            set => SetProperty(ref _selectedPatient, value);
        }

        public ICommand AddCommand { get; }
        public ICommand ShowDetailsCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }

        public List<Patient> patientsList;

        public ObservableCollection<Patient> Patients { get; set; }

        public PatientsViewModel()
        {
            _patientService = new PatientService();
            Patients = new ObservableCollection<Patient>();
            patientsList = new List<Patient>();

            AddCommand = new Command(OnAdd);
            ShowDetailsCommand = new Command(OnShowDetails);
            EditCommand = new Command<Patient>(OnEdit);
            DeleteCommand = new Command<Patient>(OnDelete);

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

        private void OnShowDetails()
        {
            if(SelectedPatient is null)
            {
                return;
            }
            var dialog = new PatientDetailsDialog(SelectedPatient);
            dialog.ShowDialog();
        }

        private void OnEdit(Patient patient)
        {
            var dialog = new PatientUpdateDialog(patient);
            dialog.ShowDialog();
        }

        private void OnDelete(Patient patient)
        {
            var result = MessageBoxExtension.QuestionMessage($"Are you sure to delete: {patient.FirstName} {patient.LastName}");

            if (result == MessageBoxResult.No)
            {
                return;
            }
            _patientService.Delete(patient);

            MessageBoxExtension.SuccessMessage("Patient was removed successfully");
        }
    }
}
