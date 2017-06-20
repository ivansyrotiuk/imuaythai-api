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

            builder.Entity<ApplicationUser>()
                .HasMany(h => h.Suspensions)
                .WithOne()
                .HasForeignKey(p => p.Id);

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

    }
}
