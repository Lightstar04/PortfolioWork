namespace Hospital_Management.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public int PatientId {  get; set; }
        public virtual Patient Patient { get; set; }

        public int DoctorId {  get; set; }
        public virtual Doctor Doctor { get; set; }

        public Status AppointmentStatus { get; set; }
        public DateOnly Date {  get; set; }
        public TimeOnly Time { get; set; }
        public virtual Visit? Visit {  get; set; }
    }
}
