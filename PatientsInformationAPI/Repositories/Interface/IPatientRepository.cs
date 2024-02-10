using PatientsInformationAPI.Models.Domains;

namespace PatientsInformationAPI.Repositories.Interface
{
    public interface IPatientRepository
    {
        Task<bool> CreateAsync(Patient patient);
        Task<Patient> DeleteAsync(Guid ID);
        Task<Patient> UpdateAsync(Patient patient);
    }
}
