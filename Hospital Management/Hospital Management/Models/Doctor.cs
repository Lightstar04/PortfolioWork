﻿namespace Hospital_Management.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string FirstName {  get; set; }
        public string LastName { get; set; }
        public string PhoneNumber {  get; set; }
        public virtual ICollection<DoctorSpecialization> Specializations { get; set; }
        public virtual ICollection<Appointment> Appointments{ get; set; }

        public Doctor()
        {
            Specializations = new List<DoctorSpecialization>();
            Appointments = new List<Appointment>();
        }
    }
}
