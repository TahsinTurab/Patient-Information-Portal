using PatientsInformationAPI.Models.Domains;
using PatientsInformationAPI.Models.DTOs;

namespace PatientsInformationAPI.Repositories.Interface
{
    public interface INCDRepository
    {
        Task<IList<NCDDto>> GetNCDsAsync();
    }
}
