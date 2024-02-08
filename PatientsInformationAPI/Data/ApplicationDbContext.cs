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

            modelBuilder.Entity<Diseases_Details>()
            .HasKey(dd => new { dd.DiseaseID, dd.PatientID });

            modelBuilder.Entity<Diseases_Details>()
                .HasOne(dd => dd.Disease)
                .WithMany(p => p.Patients)
                .HasForeignKey(dd => dd.PatientID);

            modelBuilder.Entity<Diseases_Details>()
                .HasOne(dd => dd.Patient)
                .WithMany(p => p.Diseases)
                .HasForeignKey(dd => dd.DiseaseID);


            modelBuilder.Entity<NCD_Details>()
            .HasKey(nd => new { nd.NCDID, nd.PatientID });

            modelBuilder.Entity<NCD_Details>()
                .HasOne(nd => nd.NCD)
                .WithMany(p => p.Patients)
                .HasForeignKey(nd => nd.PatientID);

            modelBuilder.Entity<NCD_Details>()
                .HasOne(dd => dd.Patient)
                .WithMany(n => n.NCDs)
                .HasForeignKey(dd => dd.NCDID);


            modelBuilder.Entity<Allergies_Details>()
            .HasKey(ad => new { ad.AllergiesID, ad.PatientID });

            modelBuilder.Entity<Allergies_Details>()
                .HasOne(ad => ad.Allergy)
                .WithMany(p => p.Patients)
                .HasForeignKey(nd => nd.PatientID);

            modelBuilder.Entity<Allergies_Details>()
                .HasOne(ad => ad.Patient)
                .WithMany(a => a.Allergies)
                .HasForeignKey(dd => dd.AllergiesID);
        }
    }
}