using PatientsInformationAPI.Models.Domains;

namespace PatientsInformationAPI.Models.RelationshipModel
{
    public class NCD_Details
    {
        public Guid PatientID { get; set; }
        public Patient Patient { get; set; }
        public Guid NCDID { get; set; }
        public NCD NCD { get; set; }
    }
}
