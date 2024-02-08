using Microsoft.EntityFrameworkCore;
using PatientsInformationAPI.Data;
using PatientsInformationAPI.Models.Domains;
using PatientsInformationAPI.Repositories.Interface;

namespace PatientsInformationAPI.Repositories.Implementation
{
    public class NCDRepository : INCDRepository
    {
        private readonly ApplicationDbContext dbContext;

        public NCDRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IList<NCD>> GetNCDsAsync()
        {
            return await dbContext.NCD.ToListAsync();
        }
    }
}
