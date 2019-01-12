using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using IMuaythai.DataAccess.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IMuaythai.DataAccess.Contexts
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>()
                .HasMany(e => e.Roles)
                .WithOne()
                .HasForeignKey(e => e.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<UserDocumentsMapping>()
                .HasOne(h => h.User)
                .WithMany(h => h.UserDocimentsMappings)
                .HasForeignKey(p => p.UserId);

            builder.Entity<ContestRequest>()
                .HasOne(h => h.User)
                .WithMany(h => h.ContestRequests)
                .HasForeignKey(h => h.UserId);

            builder.Entity<Suspension>()
                .HasOne(h => h.User)
                .WithMany(h => h.Suspensions)
                .HasForeignKey(h => h.UserId);

            builder.Entity<ContestRequest>()
                .HasOne(h => h.User)
                .WithMany(h => h.ContestRequests)
                .HasForeignKey(h => h.UserId);

            builder.Entity<ContestRequest>()
                .HasOne(h => h.AcceptedByUser)
                .WithMany(h => h.AcceptedContestRequests)
                .HasForeignKey(h => h.AcceptedByUserId);

            builder.Entity<Fight>()
                .HasOne(h => h.BlueAthlete)
                .WithMany(h => h.AsBlueFights)
                .HasForeignKey(p => p.BlueAthleteId);

            builder.Entity<Fight>()
                .HasOne(h => h.RedAthlete)
                .WithMany(h => h.AsRedFights)
                .HasForeignKey(p => p.RedAthleteId);

            builder.Entity<Fight>()
                .HasOne(h => h.Referee)
                .WithMany(h => h.AsRefereeFights)
                .HasForeignKey(p => p.RefereeId);

            builder.Entity<Fight>()
                .HasOne(h => h.TimeKeeper)
                .WithMany(h => h.AsTimeKeeperFights)
                .HasForeignKey(p => p.TimeKeeperId);

            builder.Entity<Institution>()
                .HasOne(h => h.HeadCoach)
                .WithMany()
                .HasForeignKey(k => k.HeadCoachId);

            builder.Entity<Institution>()
                .HasOne(h => h.Country)
                .WithMany()
                .HasForeignKey(k => k.CountryId);


            builder.Entity<Contest>()
                .HasOne(c => c.Institution)
                .WithMany(i => i.Contests)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ApplicationUser>()
                .HasOne(c => c.Institution)
                .WithMany(i => i.Users)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<FightPoint>()
                .HasOne(h => h.Fighter)
                .WithMany(u => u.FightPoints)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<FightPoint>()
                .HasOne(h => h.Judge)
                .WithMany(u => u.JudgeFightPoints)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Fight>()
                .HasOne(h => h.ContestCategory)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict).IsRequired(false);

           
            builder.Entity<License>()
                .HasOne(h => h.LicenseType)
                .WithMany(h => h.Licenses)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<GymLicense>()
                .HasOne(h => h.Institution)
                .WithMany(h => h.Licenses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasForeignKey(h => h.InstitutionId);

            builder.Entity<FighterLicense>()
                .HasOne(h => h.Fighter)
                .WithMany(h => h.FighterLicenses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasForeignKey(h => h.FighterId);

            builder.Entity<CoachLicense>()
                .HasOne(h => h.Coach)
                .WithMany(h => h.CoachLicenses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasForeignKey(h => h.CoachId);

            builder.Entity<JudgeLicense>()
                .HasOne(h => h.Judge)
                .WithMany(h => h.JudgeLicenses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasForeignKey(h => h.JudgeId);

            builder.Entity<License>()
                .HasDiscriminator<LicenseKinds>("Kind")
                .HasValue<GymLicense>(LicenseKinds.Gym)
                .HasValue<CoachLicense>(LicenseKinds.Coach)
                .HasValue<JudgeLicense>(LicenseKinds.Judge)
                .HasValue<FighterLicense>(LicenseKinds.Fighter);


        }

        public virtual DbSet<Document> Documents { get; set; }
        public virtual DbSet<UserDocumentsMapping> UserDocumentsMappings { get; set; }
        public virtual DbSet<InstitutionDocumentsMapping> InstitutionDocumentsMappings { get; set; }

        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<KhanLevel> KhanLevels { get; set; }
        public virtual DbSet<Suspension> Suspensions { get; set; }
        public virtual DbSet<SuspensionType> SuspensionTypes { get; set; }

        public virtual DbSet<Institution> Institutions { get; set; }
        public virtual DbSet<ExecutionBoard> ExecutionBoards { get; set; }

        public virtual DbSet<Contest> Contests { get; set; }
        public virtual DbSet<ContestRequest> ContestRequests { get; set; }
        public virtual DbSet<ContestCategory> ContestCategories { get; set; }

        public virtual DbSet<Fight> Fights { get; set; }
        public virtual DbSet<FightJudgesMapping> FightJudgesMappings { get; set; }
        public virtual DbSet<FightPoint> FightPoints { get; set; }
        public virtual DbSet<FightStructure> FightStructures { get; set; }

        public virtual DbSet<ContestTypePoints> ContestTypePoints { get; set; }
        public virtual DbSet<ContestRange> ContestRanges { get; set; }
        public virtual DbSet<ContestType> ContestTypes { get; set; }
        public virtual DbSet<Reminder> Reminders { get; set; }
        public virtual DbSet<Province> Provinces { get; set; }
        public virtual DbSet<UserRoleRequest> UserRoleRequests { get; set; }
        public virtual DbSet<Round> Rounds { get; set; }
        public virtual DbSet<WeightAgeCategory> WeightAgeCategories { get; set; }
        public virtual DbSet<ContestCategoriesMapping> ContestCategoriesMappings { get; set; }
        public virtual DbSet<ContestRing> ContestRings { get; set; }
        public virtual DbSet<LicenseType> LicenseTypes { get; set; }
        public virtual DbSet<FighterLicense> FighterLicenses { get; set; }
        public virtual DbSet<JudgeLicense> JudgeLicenses { get; set; }
        public virtual DbSet<CoachLicense> CoachLicenses { get; set; }
        public virtual DbSet<GymLicense> GymLicenses { get; set; }
        public virtual DbSet<License> Licenses { get; set; }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            SetModifiedDate();

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override int SaveChanges()
        {
            SetModifiedDate();
            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            SetModifiedDate();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        private void SetModifiedDate()
        {
            var editedEntities = ChangeTracker.Entries().Where(e => e.State == EntityState.Modified && e.Entity is Entity)
                .ToList();

            editedEntities.ForEach(entity => { entity.Property("Modified").CurrentValue = DateTime.UtcNow; });
        }
    }
}
