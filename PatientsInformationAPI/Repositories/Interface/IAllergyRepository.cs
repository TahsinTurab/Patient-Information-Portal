using PatientsInformationAPI.Models.Domains;

namespace PatientsInformationAPI.Repositories.Interface
{
    public interface IAllergyRepository
    {
        Task<IList<Allergy>> GetAllergiesAsync();
    }
}
