using PatientsInformationAPI.Models.Enums;
using PatientsInformationAPI.Models.RelationshipModel;
using System.ComponentModel.DataAnnotations;

namespace PatientsInformationAPI.Models.Domains
{
    public class Patient
    {

        [Required]
        public Guid ID { get; set; } = Guid.NewGuid();
        [Required]
        public string Name { get; set; }
        [Required]
        public Epilepsy HasEpilepsy { get; set; }
        public string Disease { get; set; }
        public ICollection<NCD_Details>? NCDs { get; set; }
        public ICollection<Allergies_Details>? Allergies { get; set; }

    }
}
