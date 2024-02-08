using PatientsInformationAPI.Models.Domains;

namespace PatientsInformationAPI.Models.RelationshipModel
{
    public class Allergies_Details
    {
        public Guid PatientID { get; set; }
        public Patient Patient { get; set; }
        public Guid AllergiesID { get; set; }
        public Allergy Allergy { get; set; }
    }
}
