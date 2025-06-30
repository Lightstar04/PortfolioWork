using Hospital_Management.Models;
using Hospital_Management.Services;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Windows.Input;

namespace Hospital_Management.ViewModels
{
    public class VisitsViewModel : BaseViewModel
    {
        private readonly VisitService _visitService;
        public ObservableCollection<Visit> Visits { get; set; }

        public ICommand AddCommand { get; }

        public VisitsViewModel()
        {
            _visitService = new VisitService();
            Visits = new ObservableCollection<Visit>();

            AddCommand = new Command(OnAdd);

            Load();
        }

        private void Load()
        {
            var visits = _visitService.GetVisits();
            foreach (var visit in visits)
            {
                Visits.Add(visit);
            }
        }

        private void OnAdd()
        {

        }
    }
}
