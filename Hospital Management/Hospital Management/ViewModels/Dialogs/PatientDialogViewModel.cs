using Hospital_Management.Models;
using Hospital_Management.Services;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Input;

namespace Hospital_Management.ViewModels.Dialogs
{
    public class PatientDialogViewModel : BaseViewModel
    {
        private readonly PatientService _patientService;

        public string FirstName {  get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public DateOnly BirthDate { get; set; }
        public Gender SelectedGender { get; set; }

        public ICommand SaveCommand { get; }

        public PatientDialogViewModel()
        {
            SaveCommand = new Command(OnSave);
            _patientService = new PatientService();
        }

        private void OnSave()
        {
            var patient = new Patient()
            {
                FirstName = this.FirstName,
                LastName = this.LastName,
                PhoneNumber = this.PhoneNumber,
                BirthDate = this.BirthDate,
                Gender = this.SelectedGender
            };

            _patientService.Create(patient);
        }
    }
}
