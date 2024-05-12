using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientManagmentSystem.API.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int MeetingTypeId { get; set; }
        public int PatientId { get; set; }

    }
}