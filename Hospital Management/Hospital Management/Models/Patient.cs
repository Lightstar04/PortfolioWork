﻿namespace Hospital_Management.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string FirstName {  get; set; }
        public string LastName { get; set; }
        public string PhoneNumber {  get; set; }
        public DateOnly BirthDate { get; set; }
        public Gender Gender { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }

        public Patient()
        {
            Appointments = new List<Appointment>();
        }

        public override string ToString()
        {
            return $"[{Id}] {FirstName} {LastName}";
        }
    }
}
