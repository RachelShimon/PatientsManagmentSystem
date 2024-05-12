using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientManagmentSystem.API.Services
{
    public class PatientService
    {
        private readonly IRepository _repository;

        public PatientService(IRepository repository)
        {
            _repository = repository;
        }

        public List<PatientViewModel> GetPatients(string searchTerm = null, int skip = 0, int take = 10)
        {
          
            var patients = _repository.GetPatients();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                if (int.TryParse(searchTerm, out int id))
                {
                    patients = patients.Where(p => p.Id == id).ToList();
                }
                else
                {
                    patients = patients.Where(p => p.Name.Contains(searchTerm)).ToList(); 
                }
            }

            patients = patients.Skip(skip).Take(take).ToList();

            var patientViewModels = patients.Select(p => new PatientViewModel
            {
                Id = p.Id,
                Name = p.Name,
                NextAppointment = GetNextAppointment(p.Id),
                AppointmentType = GetNextAppointmentType(p.Id)
            }).ToList();

            return patientViewModels;
        }

        private string GetNextAppointment(int patientId)
        {
            var appointments = _repository.GetAppointments().Where(a => a.PatientId == patientId).ToList();

            if (appointments.Count == 0)
            {
                return "No appointments";
            }

            var nextAppointment = appointments.Where(a => a.Date >= DateTime.Today)
                                              .OrderBy(a => a.Date)
                                              .FirstOrDefault();

            return nextAppointment != null ? nextAppointment.Date.ToShortDateString() : appointments.Last().Date.ToShortDateString();
        }

        private string GetNextAppointmentType(int patientId)
        {
            var nextAppointment = _repository.GetAppointments()
                                             .Where(a => a.PatientId == patientId && a.Date >= DateTime.Today)
                                             .OrderBy(a => a.Date)
                                             .FirstOrDefault();

            if (nextAppointment == null)
            {
                return "No appointments";
            }

            var meetingType = _repository.GetMeetingTypes().FirstOrDefault(mt => mt.Id == nextAppointment.MeetingTypeId);

            return meetingType != null ? meetingType.Type : "Unknown";
        }


    }

    public class PatientViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NextAppointment { get; set; }
        public string AppointmentType { get; set; }
    }
}