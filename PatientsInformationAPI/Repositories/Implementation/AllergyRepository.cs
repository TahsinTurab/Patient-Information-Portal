using Microsoft.EntityFrameworkCore;
using PatientsInformationAPI.Data;
using PatientsInformationAPI.Models.Domains;
using PatientsInformationAPI.Models.DTOs;
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

        public async Task<IList<AllergyDto>> GetAllergiesAsync()
        {
            var Allergies = await dbContext.Allergies.ToListAsync();
            var AllergiesDtos = new List<AllergyDto>();
            foreach(var a in Allergies)
            {
                var AllergyDto = new AllergyDto();
                AllergyDto.ID = a.ID;
                AllergyDto.Name = a.Name;
                AllergiesDtos.Add(AllergyDto);
            }
            return AllergiesDtos;
        }
    }
}
