using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Give_Pro.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebApplication1.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string UserType { get; set; }
        public virtual ICollection<Jobs> Jobss { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<Give_Pro.Models.Category> Categories { get; set; }

        public System.Data.Entity.DbSet<Give_Pro.Models.AdvantagesWork> AdvantagesWorks { get; set; }

        public System.Data.Entity.DbSet<Give_Pro.Models.Age> Ages { get; set; }

        public System.Data.Entity.DbSet<Give_Pro.Models.Countries> Countries { get; set; }

        public System.Data.Entity.DbSet<Give_Pro.Models.CompanyActivity> CompanyActivities { get; set; }

        public System.Data.Entity.DbSet<Give_Pro.Models.Always> Always { get; set; }

        public System.Data.Entity.DbSet<Give_Pro.Models.Currency> Currencies { get; set; }

        public System.Data.Entity.DbSet<Give_Pro.Models.Gender> Genders { get; set; }

        public System.Data.Entity.DbSet<Give_Pro.Models.DrivingLicense> DrivingLicenses { get; set; }

        public System.Data.Entity.DbSet<Give_Pro.Models.EducationLevel> EducationLevels { get; set; }

        public System.Data.Entity.DbSet<Give_Pro.Models.LevelArmy> LevelArmies { get; set; }

        public System.Data.Entity.DbSet<Give_Pro.Models.LevelComputer> LevelComputers { get; set; }

        public System.Data.Entity.DbSet<Give_Pro.Models.LevelEnglish> LevelEnglishes { get; set; }

        public System.Data.Entity.DbSet<Give_Pro.Models.LevelOffice> LevelOffices { get; set; }

        public System.Data.Entity.DbSet<Give_Pro.Models.MonthlySalary> MonthlySalaries { get; set; }

        public System.Data.Entity.DbSet<Give_Pro.Models.Nationalities> Nationalities { get; set; }

        public System.Data.Entity.DbSet<Give_Pro.Models.StaffSize> StaffSizes { get; set; }

        public System.Data.Entity.DbSet<Give_Pro.Models.Timeswork> Timesworks { get; set; }

        public System.Data.Entity.DbSet<Give_Pro.Models.Weekend> Weekends { get; set; }

        public System.Data.Entity.DbSet<Give_Pro.Models.WorkHours> WorkHours { get; set; }

        public System.Data.Entity.DbSet<Give_Pro.Models.YearsExperience> YearsExperiences { get; set; }

        public System.Data.Entity.DbSet<Give_Pro.Models.RequiredWorkers> RequiredWorkers { get; set; }

        public System.Data.Entity.DbSet<Give_Pro.Models.Governorates> Governorates { get; set; }

        public System.Data.Entity.DbSet<Give_Pro.Models.Cities> Cities { get; set; }

        public System.Data.Entity.DbSet<Give_Pro.Models.Jobs> Jobs { get; set; }

        public System.Data.Entity.DbSet<Give_Pro.Models.ResearcherProfile> ResearcherProfiles { get; set; }

        public System.Data.Entity.DbSet<Give_Pro.Models.ApplyForJob> ApplyForJobs { get; set; }

        public System.Data.Entity.DbSet<Give_Pro.Models.PublisherProfile> PublisherProfiles { get; set; }

        public System.Data.Entity.DbSet<WebApplication1.Models.EditprofileViewModel> EditprofileViewModels { get; set; }
    }
}