﻿using Hospital_Management.Data;
using Hospital_Management.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management.Services
{
    public class DoctorService
    {
        private readonly HospitalDbContext _context;
        public DoctorService()
        {
            _context = new HospitalDbContext();
        }

        public List<Doctor> GetDoctors(string search = "")
        {
            var query = _context.Doctors
                .AsNoTracking()
                .AsQueryable();

            if(!string.IsNullOrEmpty(search))
            {
                query = query.Where(x => x.FirstName.Contains(search) || 
                x.LastName.Contains(search) ||
                x.PhoneNumber.Contains(search));
            }

            return query.ToList();
        }

        public Doctor? GetDoctorById(int id)
            => _context.Doctors.FirstOrDefault(x => x.Id == id);

        public void Create(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            _context.SaveChanges();
        }
        public void Update(Doctor doctor)
        {
            _context.Doctors.Update(doctor);
            _context.SaveChanges();
        }
        public void Delete(Doctor doctor)
        {
            _context.Doctors.Remove(doctor);
            _context.SaveChanges();
        }
    }
}
