using PatientsInformationAPI.Data;
using PatientsInformationAPI.Models.Domains;
using PatientsInformationAPI.Repositories.Interface;

namespace PatientsInformationAPI.Repositories.Implementation
{
    public class PatientRepository : IPatientRepository
    {
        private readonly ApplicationDbContext dbContext;

        public PatientRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> CreateAsync(Patient patient)
        {
            await dbContext.PatientsInforamtion.AddAsync(patient);
            await dbContext.SaveChangesAsync();
            return true;
        }
    }
}
