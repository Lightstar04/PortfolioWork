﻿using Hospital_Management.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management.Data
{
    public class HospitalDbContext : DbContext
    {
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Specialization> Specializations { get; set; }
        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<Visit> Visits { get; set; }
        public virtual DbSet<DoctorSpecialization> DoctorSpecializations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DatabaseConstants.CONNECTION_STRING);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>()
                .ToTable(nameof(Patient));
            modelBuilder.Entity<Patient>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<Doctor>()
                .ToTable(nameof(Doctor));
            modelBuilder.Entity<Doctor>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<Specialization>()
                .ToTable(nameof(Specialization));
            modelBuilder.Entity<Specialization>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<Appointment>()
                .ToTable(nameof(Appointment));
            modelBuilder.Entity<Appointment>()
                .HasKey(e => e.Id);
            modelBuilder.Entity<Appointment>()
                .HasOne(e => e.Visit)
                .WithOne(x => x.Appointment)
                .HasForeignKey<Visit>(e => e.AppointmentId);

            modelBuilder.Entity<Visit>()
                .ToTable(nameof(Visit));
            modelBuilder.Entity<Visit>()
                .HasKey(e => e.Id);
            modelBuilder.Entity<Visit>()
                .HasOne(e => e.Appointment)
                .WithOne(x => x.Visit)
                .HasForeignKey<Visit>(e => e.AppointmentId);
            modelBuilder.Entity<Visit>()
                .Property(e => e.TotalDue)
                .HasColumnType("money");

            modelBuilder.Entity<DoctorSpecialization>()
                .ToTable(nameof(DoctorSpecialization));
            modelBuilder.Entity<DoctorSpecialization>()
                .HasKey(e => e.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
