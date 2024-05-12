using PatientManagmentSystem.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientManagmentSystem.API.Services
{
    public interface IRepository
    {
        List<Patient> GetPatients();
        List<Appointment> GetAppointments();
        List<MeetingType> GetMeetingTypes();
    }
}