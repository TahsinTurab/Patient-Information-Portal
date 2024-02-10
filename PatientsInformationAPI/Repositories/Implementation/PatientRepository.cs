using Microsoft.EntityFrameworkCore;
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

        public async Task<Patient> DeleteAsync(Guid ID)
        {
            var Dbitem = await dbContext.PatientsInforamtion.FirstOrDefaultAsync(e => e.ID == ID);
            if (Dbitem != null)
            {
                dbContext.PatientsInforamtion.Remove(Dbitem);
                dbContext.SaveChanges();
            }
            return Dbitem;
        }

        public async Task<Patient> UpdateAsync(Patient patient)
        {
            var Dbitem = await dbContext.PatientsInforamtion.FirstOrDefaultAsync(e => e.ID == patient.ID);
           
            if (Dbitem != null)
            {
                Dbitem.Name = patient.Name;
                Dbitem.Disease = patient.Disease;
                Dbitem.HasEpilepsy = patient.HasEpilepsy;
                Dbitem.Allergies = patient.Allergies;
                Dbitem.NCDs = patient.NCDs;
                dbContext.SaveChanges();
            }
            return Dbitem;
        }
    }
}
