using PatientManagmentSystem.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientManagmentSystem.API.Services
{
    public class DummyRepository : IRepository
    {
        private List<Patient> _patients;
        private List<Appointment> _appointments;
        private List<MeetingType> _meetingTypes;

        public DummyRepository()
        {
            _patients = new List<Patient>
            {
                new Patient { Id = 1, Name = "John Doe" },
                new Patient { Id = 2, Name = "Jane Smith" },
                new Patient { Id = 3, Name = "Michael Johnson" },
                new Patient { Id = 4, Name = "Emily Brown" },
                new Patient { Id = 5, Name = "William Davis" },
                new Patient { Id = 6, Name = "Olivia Wilson" },
                new Patient { Id = 7, Name = "James Taylor" },
                new Patient { Id = 8, Name = "Sophia Martinez" },
                new Patient { Id = 9, Name = "Logan Anderson" },
                new Patient { Id = 10, Name = "Emma Thomas" },
                new Patient { Id = 11, Name = "Benjamin Garcia" },
                new Patient { Id = 12, Name = "Ava Rodriguez" },
                new Patient { Id = 13, Name = "Mason Lopez" },
                new Patient { Id = 14, Name = "Isabella Perez" },
                new Patient { Id = 15, Name = "Ethan Williams" },
                new Patient { Id = 16, Name = "Amelia Smith" }
          
            };

     
            _meetingTypes = new List<MeetingType>
            {
                new MeetingType { Id = 1, Type = "General Checkup" },
                new MeetingType { Id = 2, Type = "Dental Appointment" },
                new MeetingType { Id = 3, Type = "Cardiology Consultation" },
                 new MeetingType { Id = 4, Type = "A medical examination" },
                new MeetingType { Id = 5, Type = "Cardiology ConsultationGynecologist" },
                new MeetingType { Id = 6, Type = "Pediatrician" }

            };


            _appointments = new List<Appointment>
            {
                new Appointment { Id = 1, Date = DateTime.Parse("2024-05-15"), MeetingTypeId = 1, PatientId = 1 },
                new Appointment { Id = 2, Date = DateTime.Parse("2024-06-10"), MeetingTypeId = 2, PatientId = 1 },
                new Appointment { Id = 3, Date = DateTime.Parse("2024-05-20"), MeetingTypeId = 6, PatientId = 2 },
                new Appointment { Id = 4, Date = DateTime.Parse("2024-06-25"), MeetingTypeId = 3, PatientId = 2 },
                new Appointment { Id = 5, Date = DateTime.Parse("2024-05-30"), MeetingTypeId = 2, PatientId = 3 },
                new Appointment { Id = 6, Date = DateTime.Parse("2024-06-30"), MeetingTypeId = 3, PatientId = 3 },
                new Appointment { Id = 7, Date = DateTime.Parse("2024-05-22"), MeetingTypeId = 5, PatientId = 3 },
                new Appointment { Id = 8, Date = DateTime.Parse("2024-05-15"), MeetingTypeId = 1, PatientId = 4 },
                new Appointment { Id = 2, Date = DateTime.Parse("2024-06-10"), MeetingTypeId = 2, PatientId = 4 },
                new Appointment { Id = 9, Date = DateTime.Parse("2024-05-20"), MeetingTypeId = 1, PatientId = 5 },
                new Appointment { Id = 10, Date = DateTime.Parse("2024-06-25"), MeetingTypeId = 3, PatientId =5 },
                new Appointment { Id = 11, Date = DateTime.Parse("2024-05-30"), MeetingTypeId = 2, PatientId = 6 },
                new Appointment { Id = 12, Date = DateTime.Parse("2024-06-30"), MeetingTypeId = 3, PatientId = 6 },
                new Appointment { Id = 13, Date = DateTime.Parse("2024-05-22"), MeetingTypeId = 4, PatientId = 6 },
                 new Appointment { Id = 14, Date = DateTime.Parse("2024-05-15"), MeetingTypeId = 4, PatientId = 8 },
                new Appointment { Id = 15, Date = DateTime.Parse("2024-06-10"), MeetingTypeId = 2, PatientId = 10},
                new Appointment { Id = 16, Date = DateTime.Parse("2024-03-20"), MeetingTypeId = 1, PatientId = 9 },
                new Appointment { Id = 17, Date = DateTime.Parse("2024-02-25"), MeetingTypeId = 3, PatientId = 11 },
                new Appointment { Id = 18, Date = DateTime.Parse("2024-08-30"), MeetingTypeId = 2, PatientId = 13 },
                new Appointment { Id = 19, Date = DateTime.Parse("2024-07-30"), MeetingTypeId = 4, PatientId = 14 },
                new Appointment { Id = 20, Date = DateTime.Parse("2024-05-25"), MeetingTypeId = 6, PatientId = 16 }

            };
        }

        public List<Patient> GetPatients()
        {
            return _patients;
        }

        public List<Appointment> GetAppointments()
        {
            return _appointments;
        }

        public List<MeetingType> GetMeetingTypes()
        {
            return _meetingTypes;
        }
    }
}