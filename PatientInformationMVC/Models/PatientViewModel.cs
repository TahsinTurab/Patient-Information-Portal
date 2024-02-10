using Microsoft.AspNetCore.Mvc.Rendering;
using PatientsInformationAPI.Models.Domains;
using System.ComponentModel.DataAnnotations;

namespace PatientsInformationMVC.Models
{
    public class PatientViewModel
    {
        [Required(ErrorMessage = "Patient Name is required")]
        [Display(Name = "Patient Name*")]
        public string PatientName { get; set; }

        [Display(Name = "Disease Name*")]
        [Required(ErrorMessage = "Selection of Disease is required")]
        public string SelectedDisease {  get; set; }

        [Display(Name = "Epilepsy*")]
        [Required(ErrorMessage = "Selection of Epilepsy is required")]
        public string SelectedEpilepsy { get; set; }
        public List<string> SelectedNCDs { get; set; }
        public List<string> SelectedAllergies { get; set; }
        public List<SelectListItem> DiseasesSelectList { get; set; }
        public List<SelectListItem> EpilepsySelectList { get; set; }
        public List<SelectListItem> NCDsSelectList { get; set; }
        public List<SelectListItem> AllergiesSelectList { get; set; }
    }
}
