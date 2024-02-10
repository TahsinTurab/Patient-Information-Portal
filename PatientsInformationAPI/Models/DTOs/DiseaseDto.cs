using PatientsInformationAPI.Models.RelationshipModel;
using System.ComponentModel.DataAnnotations;

namespace PatientsInformationAPI.Models.DTOs
{
    public class DiseaseDto
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
    }
}
