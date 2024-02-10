using Microsoft.EntityFrameworkCore;
using PatientsInformationAPI.Data;
using PatientsInformationAPI.Models.Domains;
using PatientsInformationAPI.Models.DTOs;
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

        public async Task<IList<DiseaseDto>> GetDiseasesAsync()
        {
            var Diseases = await dbContext.DiseaseInformation.ToListAsync();
            var DiseasesDtos = new List<DiseaseDto>();
            foreach(var d in Diseases)
            {
                var DiseaseDto = new DiseaseDto();
                DiseaseDto.ID = d.ID;
                DiseaseDto.Name = d.Name;  
                DiseasesDtos.Add(DiseaseDto);
            }
            return DiseasesDtos;
        }
    }
}
