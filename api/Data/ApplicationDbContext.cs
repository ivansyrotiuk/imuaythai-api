using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MuaythaiSportManagementSystemApi.Models;

namespace MuaythaiSportManagementSystemApi.Data
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

    }
}
