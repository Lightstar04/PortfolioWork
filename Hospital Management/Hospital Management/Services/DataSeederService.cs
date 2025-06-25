using Bogus;
using Bogus.DataSets;
using Hospital_Management.Data;
using Hospital_Management.Models;
using System.Security.Cryptography.X509Certificates;

namespace Hospital_Management.Services
{
    public static class DataSeederService
    {
        private static Faker faker = new();
        public static void SeedDatabase()
        {
            using var context = new HospitalDbContext();

            CreatePatients(context);
            CreateDoctors(context);
            CreateSpecializations(context);
            CreateDoctorSpecialization(context);
        }

        private static void CreatePatients(HospitalDbContext context)
        {
            if (context.Patients.Any()) return;

            for(int i = 0; i < 100; i++)
            {
                var patient = new Patient();

                var (randomGender, fakerGender) = GetGender();
                patient.FirstName = faker.Name.FirstName(fakerGender);
                patient.LastName = faker.Name.LastName(fakerGender);
                patient.PhoneNumber = faker.Phone.PhoneNumber("+998##-###-##-##");
                patient.BirthDate = GetRandomBirthdate();
                patient.Gender = randomGender;

                context.Patients.Add(patient);
            }
            context.SaveChanges();
        }

        private static void CreateDoctors(HospitalDbContext context)
        {
            if (context.Doctors.Any()) return;

            for(int i = 0; i < 20; i++)
            {
                var doctor = new Doctor();
                doctor.FirstName = faker.Name.FirstName();
                doctor.LastName = faker.Name.LastName();
                doctor.PhoneNumber = faker.Phone.PhoneNumber("+998##-###-##-##");

                context.Doctors.Add(doctor);
            }
            context.SaveChanges();
        }

        private static void CreateSpecializations(HospitalDbContext context)
        {
            if (context.Specializations.Any()) return;

            var values = Enum.GetNames(typeof(DoctorSpecializationType));

            if(values is null) return;

            foreach(var value in values)
            {
                var specialization = new Specialization()
                {
                    Name = value,
                    Description = faker.Lorem.Text(),
                };
                context.Specializations.Add(specialization);
            }
            context.SaveChanges();
        }

        private static void CreateDoctorSpecialization(HospitalDbContext context)
        {
            if(context.DoctorSpecializations.Any()) return;

            var doctorIds = context.Doctors.Select(x => x.Id).ToArray();
            var specializationIds = context.Specializations.Select(x => x.Id).ToArray();

            foreach(var doctorId in doctorIds)
            {
                var specializationCount = faker.Random.Number(1, 3);
                HashSet<int> specializations = new();

                for(int i = 0; i < specializationCount; i++)
                {
                    var randomSpecializationId = faker.PickRandom(specializationIds);
                    specializations.Add(randomSpecializationId);
                }
                foreach(var specializationId in specializations)
                {
                    var doctorSpecialization = new DoctorSpecialization()
                    {
                        DoctorId = doctorId,
                        SpecializationId = specializationId
                    };
                    context.DoctorSpecializations.Add(doctorSpecialization);
                }
                context.SaveChanges();
            }
        }

        private static DateOnly GetRandomBirthdate()
        {
            var minDate = new DateOnly(1940, 1, 1);
            var maxDate = new DateOnly(2023, 12, 31);

            return faker.Date.BetweenDateOnly(minDate, maxDate);
        }

        private static (Gender, Name.Gender) GetGender()
        {

            var randomGender = faker.Random.Enum<Gender>();
            var fakerGender = randomGender == Gender.Male ? Name.Gender.Male : Name.Gender.Female;

            return (randomGender, fakerGender);
        }

    }
}
