using PatientsInformationAPI.Models.Domains;

namespace PatientsInformationAPI.Models.RelationshipModel
{
    public class Diseases_Details
    {
        public Guid PatientID { get; set; }
        public Patient Patient { get; set; }
        public Guid DiseaseID { get; set; }
        public Disease Disease { get; set; }
    }
}
