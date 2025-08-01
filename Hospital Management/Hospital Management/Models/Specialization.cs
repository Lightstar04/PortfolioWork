﻿namespace Hospital_Management.Models
{
    public class Specialization
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<DoctorSpecialization> Doctors {  get; set; }

        public Specialization()
        {
            Doctors = new List<DoctorSpecialization>();
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
