using PatientsInformationAPI.Models.RelationshipModel;

namespace PatientsInformationAPI.Models.Domains
{
    public class Allergy
    {
        public Guid ID { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public ICollection<Allergies_Details> Patients { get; set; }
    }
}
