using PatientsInformationAPI.Models.Domains;
using PatientsInformationAPI.Models.DTOs;

namespace PatientsInformationAPI.Repositories.Interface
{
    public interface IAllergyRepository
    {
        Task<IList<AllergyDto>> GetAllergiesAsync();
    }
}
