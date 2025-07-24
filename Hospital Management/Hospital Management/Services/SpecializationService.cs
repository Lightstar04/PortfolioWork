using Hospital_Management.Data;
using Hospital_Management.Models;

namespace Hospital_Management.Services
{
    public class SpecializationService
    {
        private readonly HospitalDbContext _context;

        public SpecializationService()
        {
            _context = new HospitalDbContext();
        }

        public List<Specialization> GetAll()
        {
            return _context.Specializations.ToList();
        }
    }
}
