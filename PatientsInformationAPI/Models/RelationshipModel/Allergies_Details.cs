using PatientsInformationAPI.Models.Domains;

namespace PatientsInformationAPI.Models.RelationshipModel
{
    public class Allergies_Details
    {
        public Guid ID { get; set; }
        public Guid PatientID { get; set; }
        public Guid AllergiesID { get; set; }
    }
}
