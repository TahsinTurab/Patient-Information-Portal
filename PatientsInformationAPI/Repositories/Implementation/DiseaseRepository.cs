using Microsoft.EntityFrameworkCore;
using PatientsInformationAPI.Data;
using PatientsInformationAPI.Models.Domains;
using PatientsInformationAPI.Repositories.Interface;

namespace PatientsInformationAPI.Repositories.Implementation
{
    public class DiseaseRepository : IDiseaseRepository
    {
        private readonly ApplicationDbContext dbContext;

        public DiseaseRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IList<Disease>> GetDiseasesAsync()
        {
            return await dbContext.DiseaseInformation.ToListAsync();
        }
    }
}
