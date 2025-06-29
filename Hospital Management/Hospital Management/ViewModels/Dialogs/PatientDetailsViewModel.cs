using Hospital_Management.Models;
using MvvmHelpers;

namespace Hospital_Management.ViewModels.Dialogs
{
    public class PatientDetailsViewModel : BaseViewModel
    {
        public string FirstName {  get; set; }
        public string LastName { get; set; }
        public string PhoneNumber {  get; set; }
        public DateOnly BirthDate { get; set; }
        public Gender Gender { get; set; }
        public List<Appointment> Appointments = new List<Appointment>();

        public PatientDetailsViewModel(Patient patient)
        {
            ArgumentNullException.ThrowIfNull(patient);

            FirstName = patient.FirstName;
            LastName = patient.LastName;
            PhoneNumber = patient.PhoneNumber;
            BirthDate = patient.BirthDate;
            Gender = patient.Gender;

            Appointments = patient.Appointments.ToList();
        }
    }
}
