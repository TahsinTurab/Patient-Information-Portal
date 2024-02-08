using PatientsInformationAPI.Models.RelationshipModel;
using System.ComponentModel.DataAnnotations;

namespace PatientsInformationAPI.Models.Domains
{
    public class Disease
    {
        public Guid ID { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public ICollection<Diseases_Details> Patients { get; set; }
    }
}
