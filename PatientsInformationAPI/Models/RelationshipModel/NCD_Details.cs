using PatientsInformationAPI.Models.Domains;

namespace PatientsInformationAPI.Models.RelationshipModel
{
    public class NCD_Details
    {
        public Guid ID { get; set; }
        public Guid PatientID { get; set; }
        public Guid NCDID { get; set; }
    }
}
