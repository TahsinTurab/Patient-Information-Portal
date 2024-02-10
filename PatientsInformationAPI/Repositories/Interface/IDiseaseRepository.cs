using PatientsInformationAPI.Models.Domains;
using PatientsInformationAPI.Models.DTOs;

namespace PatientsInformationAPI.Repositories.Interface
{
    public interface IDiseaseRepository
    {
        Task<IList<DiseaseDto>> GetDiseasesAsync();
    }
}
