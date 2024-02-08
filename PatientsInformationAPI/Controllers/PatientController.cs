using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatientsInformationAPI.Repositories.Interface;

namespace PatientsInformationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientRepository patientRepository;

        public PatientController(IPatientRepository patientRepository)
        {
            this.patientRepository = patientRepository;
        }


    }
}
