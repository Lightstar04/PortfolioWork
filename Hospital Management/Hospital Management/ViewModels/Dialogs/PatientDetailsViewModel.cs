using Hospital_Management.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MvvmHelpers;
using System.Collections.ObjectModel;

namespace Hospital_Management.ViewModels.Dialogs
{
    public class PatientDetailsViewModel : BaseViewModel
    {
        private string _appointmentsTitle = "";
        public string AppointmentsTitle
        {
            get => _appointmentsTitle;
            set => SetProperty(ref _appointmentsTitle, value);
        }

        private string _historyLabel = "";
        public string HistoryLabel
        {
            get => _historyLabel;
            set => SetProperty(ref _historyLabel, value);
        }

        public string FirstName {  get; set; }
        public string LastName { get; set; }
        public string PhoneNumber {  get; set; }
        public DateOnly BirthDate { get; set; }
        public Gender Gender { get; set; }
        public ObservableCollection<Appointment> Appointments { get; }
        public ObservableCollection<Visit> Visits { get; }

        public PatientDetailsViewModel(Patient patient)
        {
            ArgumentNullException.ThrowIfNull(patient);

            FirstName = patient.FirstName;
            LastName = patient.LastName;
            PhoneNumber = patient.PhoneNumber;
            BirthDate = patient.BirthDate;
            Gender = patient.Gender;

            Appointments = new ObservableCollection<Appointment>(patient.Appointments);
            AppointmentsTitle = Appointments.Count > 0 ? "Recent appointments" : $"{FirstName} {LastName} has no recent appointments";

            var visits = patient.Appointments
                .Where(x => x.Visit != null)
                .Select(x => x.Visit);
            Visits = new ObservableCollection<Visit>(visits);
            HistoryLabel = Visits.Count > 0 ? "Recent visits" : $"{FirstName} {LastName} has no visits yet!";
        }
    }
}
