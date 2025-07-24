using Hospital_Management.Models;
using Hospital_Management.Services;
using MvvmHelpers;
using System.Collections.ObjectModel;

namespace Hospital_Management.ViewModels
{
    public class DoctorsViewModel : BaseViewModel
    {
        private readonly DoctorService _doctorService;
        private readonly SpecializationService _specializationService;

        private string _searchText;
        public string SearchText
        {
            get => _searchText;
            set
            {
                SetProperty(ref _searchText, value);
                SearchDoctors(value);
            }
        }

        private Specialization _selectedSpecialization;
        public Specialization SelectedSpecialization
        {
            get => _selectedSpecialization;
            set => SetProperty(ref _selectedSpecialization, value);
        }

        public List<Doctor> doctorsList;
        public ObservableCollection<Doctor> Doctors { get; set; }
        public ObservableCollection<Specialization> Specializations { get; set; }

        public DoctorsViewModel()
        {
            _doctorService = new DoctorService();
            _specializationService = new SpecializationService();

            doctorsList = new List<Doctor>();
            
            Doctors = new ObservableCollection<Doctor>();
            Specializations = new ObservableCollection<Specialization>();

            Load();
        }

        private void Load()
        {
            var doctors = _doctorService.GetDoctors();
            var specializations = _specializationService.GetAll();

            foreach(var doctor in doctors)
            {
                Doctors.Add(doctor);
                doctorsList.Add(doctor);
            }

            foreach(var specialization in specializations)
            {
                Specializations.Add(specialization);
            }
        }

        private void SearchDoctors(string searchText)
        {
            var doctors = doctorsList.Where(x => x.FirstName.Contains(searchText) || 
            x.LastName.Contains(searchText) ||
            x.PhoneNumber.Contains(searchText));

            Doctors.Clear();
            foreach(var doctor in doctors)
            {
                Doctors.Add(doctor);
            }
        }
    }
}
