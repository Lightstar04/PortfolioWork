﻿using Hospital_Management.Extensions;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital_Management.Models
{
    public class Visit
    {
        public int Id { get; set; }
        public string Comments {  get; set; }
        public decimal TotalDue {  get; set; }
        public int AppointmentId { get; set; }
        public virtual Appointment Appointment { get; set; }

        [NotMapped]
        public string CommentsShort => Comments.GetShort();
    }
}
