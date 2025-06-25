using Hospital_Management.Models;
using Hospital_Management.Services;
using MvvmHelpers;
using System.Collections.ObjectModel;

namespace Hospital_Management.ViewModels
{
    public class DoctorsViewModel : BaseViewModel
    {
        private readonly DoctorService _doctorService;

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

        public List<Doctor> doctorsList;
        public ObservableCollection<Doctor> Doctors { get; set; }

        public DoctorsViewModel()
        {
            _doctorService = new DoctorService();
            doctorsList = new List<Doctor>();
            Doctors = new ObservableCollection<Doctor>();

            Load();
        }

        private void Load()
        {
            var doctors = _doctorService.GetDoctors();

            foreach(var doctor in doctors)
            {
                Doctors.Add(doctor);
                doctorsList.Add(doctor);
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
