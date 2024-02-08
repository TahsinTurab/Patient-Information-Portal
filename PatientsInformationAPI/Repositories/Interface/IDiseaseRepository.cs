using PatientsInformationAPI.Models.Domains;

namespace PatientsInformationAPI.Repositories.Interface
{
    public interface IDiseaseRepository
    {
        Task<IList<Disease>> GetDiseasesAsync();
    }
}
