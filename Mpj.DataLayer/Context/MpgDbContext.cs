

using Microsoft.EntityFrameworkCore;
using Mpj.DataLayer.Entities.EmploymentForm;
using Mpj.DataLayer.Entities.ProvinceAndCity;

namespace Mpj.DataLayer.Context
{
   
    public class MpgDbContext : DbContext
    {
        public MpgDbContext(DbContextOptions<MpgDbContext> options) : base(options)
        {


        }

        public DbSet<Employment> Employments { get; set; }
        public DbSet<EducationalRecode> EducationalRecodes { get; set; }
        public DbSet<WorkExperience> WorkExperiences { get; set; }
        public DbSet<Sponsorship> Sponsorships { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<RegistrationDocuments> RegistrationDocuments { get; set; }
        public DbSet<EditedItemsForEmployment> EditedItemsForEmployments { get; set; }
        #region on model creating

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(s => s.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            modelBuilder.Entity<Employment>()
                .HasQueryFilter(u => !u.IsDelete);
            modelBuilder.Entity<EducationalRecode>()
                .HasQueryFilter(u => !u.IsDelete);

            modelBuilder.Entity<WorkExperience>()
                .HasQueryFilter(r => !r.IsDelete);

            modelBuilder.Entity<Sponsorship>()
                .HasQueryFilter(r => !r.IsDelete);

            base.OnModelCreating(modelBuilder);
        }

        #endregion
    }
}
