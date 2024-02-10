using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using PatientsInformationAPI.Models.Domains;
using PatientsInformationAPI.Models.DTOs;
using PatientsInformationAPI.Models.Enums;
using PatientsInformationAPI.Models.RelationshipModel;
using PatientsInformationMVC.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Web.Http.Controllers;

namespace PatientsInformationMVC.Controllers
{
    public class PortalController : Controller
    {

        private readonly HttpClient httpClient;
        private readonly HttpClientHandler httpHandler;

        public PortalController()
        {
            httpClient = new HttpClient();
            httpHandler = new HttpClientHandler();
            httpHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, SslPolicyErrors) => { return true; };
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.SuccessMessage = TempData["SuccessMessage"] as string;
            var patientViewModel = new PatientViewModel();
            using (var httpClient = new HttpClient(httpHandler))
            {
                var responseNCDs = await httpClient.GetAsync("https://localhost:7205/api/Patient/GetNCDs/NCDs");
                string dataNCDs = responseNCDs.Content.ReadAsStringAsync().Result;
                var NCDs = JsonConvert.DeserializeObject<List<NCDDto>>(dataNCDs);
                patientViewModel.NCDsSelectList = new List<SelectListItem>();
                foreach (var ncd in NCDs)
                {
                    patientViewModel.NCDsSelectList.Add(new SelectListItem { Text = ncd.Name, Value = ncd.ID.ToString() });
                }

                var responseDiseases = await httpClient.GetAsync("https://localhost:7205/api/Patient/GetDiseases/Diseases");
                string dataDiseases = responseDiseases.Content.ReadAsStringAsync().Result;
                var Diseases = JsonConvert.DeserializeObject<List<DiseaseDto>>(dataDiseases);
                patientViewModel.DiseasesSelectList = new List<SelectListItem>();

                foreach (var disease in Diseases)
                {
                    patientViewModel.DiseasesSelectList.Add(new SelectListItem { Text = disease.Name, Value = disease.Name });
                }

                patientViewModel.EpilepsySelectList = new List<SelectListItem>();
                patientViewModel.EpilepsySelectList.Add(new SelectListItem { Text = "No", Value = "0" });
                patientViewModel.EpilepsySelectList.Add(new SelectListItem { Text = "Yes", Value = "1" });

                var responseAllergies = await httpClient.GetAsync("https://localhost:7205/api/Patient/GetAllergies/Allergies");
                string dataAllergies = responseAllergies.Content.ReadAsStringAsync().Result;
                var Allergies = JsonConvert.DeserializeObject<List<AllergyDto>>(dataAllergies);
                patientViewModel.AllergiesSelectList = new List<SelectListItem>();
                foreach (var allergy in Allergies)
                {
                    patientViewModel.AllergiesSelectList.Add(new SelectListItem { Text = allergy.Name, Value = allergy.ID.ToString() });
                }
            }

            return View(patientViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(PatientViewModel model)
        {
            var patient = new Patient();
            patient.ID = Guid.NewGuid();
            patient.Name = model.PatientName;

            Epilepsy hasEpilepsy = (Epilepsy)(Int32.Parse(model.SelectedEpilepsy));
            patient.HasEpilepsy = hasEpilepsy;

            var selectedDisease = model.SelectedDisease;
            if(selectedDisease != null)
            {
                patient.Disease = selectedDisease;
            }
            patient.NCDs = new List<NCD_Details>();
            var selectedNCDs = model.SelectedNCDs;
            if(selectedNCDs != null) 
            {
                foreach (var ncd in selectedNCDs)
                {
                    var ncd_details = new NCD_Details();
                    ncd_details.NCDID = Guid.Parse(ncd);
                    ncd_details.PatientID = patient.ID;
                    patient.NCDs.Add(ncd_details);
                }
            }
            

            var selectedAllergies = model.SelectedAllergies;
            patient.Allergies = new List<Allergies_Details>();
            if(selectedAllergies != null)
            {
                foreach (var allergy in selectedAllergies)
                {
                    var allergy_details = new Allergies_Details();
                    allergy_details.PatientID = patient.ID;
                    allergy_details.AllergiesID = Guid.Parse(allergy);
                    patient.Allergies.Add(allergy_details);
                }
            }
            var patientJSON = JsonConvert.SerializeObject(patient);

            var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:7205/api/Patient/Create/CreatePaitientInformation");
            request.Content = new StringContent(patientJSON, Encoding.UTF8, "application/json");

            // Send the request and get the response
            var response = await httpClient.SendAsync(request);

            // Check if the request was successful
            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
            }

            TempData["SuccessMessage"] = "Inserted successfully!";
            return RedirectToAction(nameof(Index));
        }
    }
}
