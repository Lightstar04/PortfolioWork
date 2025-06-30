using Hospital_Management.Data;
using Hospital_Management.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management.Services
{
    public class VisitService
    {
        private readonly HospitalDbContext _context;
        public VisitService()
        {
            _context = new HospitalDbContext();
        }

        public List<Visit> GetVisits()
        {
            var query = _context.Visits
                .Include(x => x.Appointment)
                .ThenInclude(p => p.Patient)
                .AsNoTracking()
                .AsQueryable();

            return query.ToList();
        }

        public Visit? GetVisitById(int id)
            => _context.Visits.FirstOrDefault(x => x.Id == id);

        public void Create(Visit visit)
        {
            _context.Visits.Add(visit);
            _context.SaveChanges();
        }

        public void Update(Visit visit)
        {
            _context.Visits.Update(visit);
            _context.SaveChanges();
        }

        public void Delete(Visit visit)
        {
            _context.Visits.Remove(visit);
            _context.SaveChanges();
        }
    }
}
