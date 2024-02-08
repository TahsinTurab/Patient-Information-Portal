using Microsoft.EntityFrameworkCore;
using PatientsInformationAPI.Data;
using PatientsInformationAPI.Models.Domains;
using PatientsInformationAPI.Repositories.Interface;

namespace PatientsInformationAPI.Repositories.Implementation
{
    public class AllergyRepository : IAllergyRepository
    {
        private readonly ApplicationDbContext dbContext;

        public AllergyRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IList<Allergy>> GetAllergiesAsync()
        {
            return await dbContext.Allergies.ToListAsync();
        }
    }
}
