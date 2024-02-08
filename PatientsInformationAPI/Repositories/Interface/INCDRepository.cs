using PatientsInformationAPI.Models.Domains;

namespace PatientsInformationAPI.Repositories.Interface
{
    public interface INCDRepository
    {
        Task<IList<NCD>> GetNCDsAsync();
    }
}
