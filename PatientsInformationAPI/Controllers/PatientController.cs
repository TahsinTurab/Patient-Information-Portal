using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatientsInformationAPI.Models.Domains;
using PatientsInformationAPI.Repositories.Implementation;
using PatientsInformationAPI.Repositories.Interface;
using System.Text.Json;
namespace PatientsInformationAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientRepository patientRepository;
        private readonly INCDRepository NCDRepository;
        private readonly IAllergyRepository allergyRepository;
        private readonly IDiseaseRepository diseaseRepository;

        public PatientController(IDiseaseRepository diseaseRepository, IPatientRepository patientRepository, IAllergyRepository allergyRepository, INCDRepository NCDRepository)
        {
            this.patientRepository = patientRepository;
            this.NCDRepository = NCDRepository;
            this.allergyRepository = allergyRepository;
            this.diseaseRepository = diseaseRepository;
        }

        [HttpGet("NCDs")]
        public async Task<object> GetNCDs()
        {
            var NCDs = await NCDRepository.GetNCDsAsync();
            return JsonSerializer.Serialize(NCDs);
        }

        [HttpGet("Allergies")]
        public async Task<object> GetAllergies()
        {
            var Allergies = await allergyRepository.GetAllergiesAsync();
            return JsonSerializer.Serialize(Allergies);
        }

        [HttpGet("Diseases")]
        public async Task<object> GetDiseases()
        {
            var Diseases = await diseaseRepository.GetDiseasesAsync();
            return JsonSerializer.Serialize(Diseases);
        }

        [HttpPost("CreatePaitientInformation")]
        public async Task<IActionResult> Create(Patient patient)
        {
            try
            {
                var isSaved = await patientRepository.CreateAsync(patient);
                if (isSaved==false)
                {
                    BadRequest("Can't Save");
                }
            }
            catch(Exception ex)
            {
                return BadRequest("Can't Save");
            }

            return Ok("Saved Successfully");
        }

        [HttpPut]
        public async Task<IActionResult> Update(Patient patient)
        {
            var DbItem = await patientRepository.UpdateAsync(patient);
            if (DbItem != null)
            {
                return Ok(DbItem);
            }
            else
            {
                return BadRequest("Not Found!");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id) 
        {
            var DbItem = await patientRepository.DeleteAsync(id);
            if (DbItem != null)
            {
                return Ok(DbItem);
            }
            else
            {
                return BadRequest("Not Found!");
            }
        }
    }
}
