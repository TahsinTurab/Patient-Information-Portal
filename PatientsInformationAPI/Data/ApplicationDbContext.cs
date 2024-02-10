using PatientsInformationAPI.Models.Domains;
using Microsoft.EntityFrameworkCore;
using PatientsInformationAPI.Models.Enums;
using PatientsInformationAPI.Models.RelationshipModel;

namespace PatientsInformationAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Patient> PatientsInforamtion { get; set; }
        public DbSet<Disease> DiseaseInformation { get; set; }
        public DbSet<NCD> NCD { get; set; }
        public DbSet<Allergy> Allergies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>()
            .Property(e => e.HasEpilepsy)
            .HasConversion<int>();
        }
    }
}