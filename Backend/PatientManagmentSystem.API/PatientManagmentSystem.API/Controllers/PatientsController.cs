using PatientManagmentSystem.API.Models;
using PatientManagmentSystem.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace PatientManagmentSystem.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PatientsController : ApiController
    {
        private readonly PatientService _patientService;

        public PatientsController()
        {
            _patientService = new PatientService(new DummyRepository());
        }

        [HttpGet]
        public IHttpActionResult GetPatients(string searchTerm = null, int skip = 0, int take = 10)
        {
            var patients = _patientService.GetPatients(searchTerm, skip, take);
            return Ok(patients);
        }

    }
}