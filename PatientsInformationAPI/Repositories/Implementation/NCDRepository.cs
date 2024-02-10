using Microsoft.EntityFrameworkCore;
using PatientsInformationAPI.Data;
using PatientsInformationAPI.Models.Domains;
using PatientsInformationAPI.Models.DTOs;
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

        public async Task<IList<NCDDto>> GetNCDsAsync()
        {
            var NCDs =  await dbContext.NCD.ToListAsync();
            var NCDDtos = new List<NCDDto>();
            foreach(var NCD in NCDs)
            {
                var NCDDto = new NCDDto();
                NCDDto.ID = NCD.ID;
                NCDDto.Name = NCD.Name;
                NCDDtos.Add(NCDDto);
            }
            return NCDDtos;
        }
    }
}
