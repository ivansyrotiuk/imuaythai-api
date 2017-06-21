using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using MuaythaiSportManagementSystemApi.Data;

namespace MuaythaiSportManagementSystemApi.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20170621121333_DbStructure")]
    partial class DbStructure
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("MuaythaiSportManagementSystemApi.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Accepted");

                    b.Property<int>("AccessFailedCount");

                    b.Property<DateTime>("Birthdate");

                    b.Property<string>("CoachLevel")
                        .HasMaxLength(100);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<int>("CountryId");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("Facebook")
                        .HasMaxLength(500);

                    b.Property<string>("FirstName")
                        .HasMaxLength(500);

                    b.Property<string>("Gender")
                        .HasMaxLength(10);

                    b.Property<string>("Instagram")
                        .HasMaxLength(500);

                    b.Property<int?>("InstitutionId");

                    b.Property<int>("InstitutionsId");

                    b.Property<int>("KhanLevelId");

                    b.Property<int>("KhanLevelsId")
                        .HasMaxLength(10);

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("Nationality")
                        .HasMaxLength(500);

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("Phone")
                        .HasMaxLength(60);

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("Photo")
                        .HasMaxLength(1000);

                    b.Property<string>("SecurityStamp");

                    b.Property<string>("Surname")
                        .HasMaxLength(500);

                    b.Property<string>("Twitter")
                        .HasMaxLength(500);

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<int>("Type");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.Property<string>("VK")
                        .HasMaxLength(500);

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("InstitutionId");

                    b.HasIndex("KhanLevelId");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("MuaythaiSportManagementSystemApi.Models.Contest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<int>("CountryId");

                    b.Property<DateTime>("Date");

                    b.Property<int>("Duration");

                    b.Property<int?>("InstitutionId");

                    b.Property<int>("Institutionld");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<int>("RingsCount");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("InstitutionId");

                    b.ToTable("Contests");
                });

            modelBuilder.Entity("MuaythaiSportManagementSystemApi.Models.ContestCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ContestId");

                    b.Property<int?>("FightStructureId");

                    b.HasKey("Id");

                    b.HasIndex("ContestId");

                    b.HasIndex("FightStructureId");

                    b.ToTable("ContestCategories");
                });

            modelBuilder.Entity("MuaythaiSportManagementSystemApi.Models.ContestRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Accepted");

                    b.Property<string>("AcceptedByUserId");

                    b.Property<int?>("ContestCategoryId");

                    b.Property<int?>("ContestId");

                    b.Property<DateTime>("Date");

                    b.Property<int?>("InstitutionId");

                    b.Property<int>("Type");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("AcceptedByUserId");

                    b.HasIndex("ContestCategoryId");

                    b.HasIndex("ContestId");

                    b.HasIndex("InstitutionId");

                    b.HasIndex("UserId");

                    b.ToTable("ContestRequests");
                });

            modelBuilder.Entity("MuaythaiSportManagementSystemApi.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<string>("Continent");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("MuaythaiSportManagementSystemApi.Models.Document", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("ExpirationDate");

                    b.Property<string>("Name");

                    b.Property<string>("Number");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("MuaythaiSportManagementSystemApi.Models.ExecutionBoard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ExecutionPosition");

                    b.Property<int?>("InstitutionId");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("InstitutionId");

                    b.HasIndex("UserId");

                    b.ToTable("ExecutionBoards");
                });

            modelBuilder.Entity("MuaythaiSportManagementSystemApi.Models.Fight", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BlueAthleteId");

                    b.Property<int>("ContestId");

                    b.Property<byte>("KO");

                    b.Property<DateTime>("KOTime");

                    b.Property<string>("RedAthleteId");

                    b.Property<string>("RefereeId");

                    b.Property<string>("Ring")
                        .IsRequired();

                    b.Property<DateTime>("StartDate");

                    b.Property<int>("StructureId");

                    b.Property<string>("TimeKeeperId");

                    b.Property<string>("WinnerId");

                    b.HasKey("Id");

                    b.HasIndex("BlueAthleteId");

                    b.HasIndex("ContestId");

                    b.HasIndex("RedAthleteId");

                    b.HasIndex("RefereeId");

                    b.HasIndex("StructureId");

                    b.HasIndex("TimeKeeperId");

                    b.HasIndex("WinnerId");

                    b.ToTable("Fights");
                });

            modelBuilder.Entity("MuaythaiSportManagementSystemApi.Models.FightJudgesMapping", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("FightId");

                    b.Property<string>("JudgeId");

                    b.Property<int>("Main");

                    b.HasKey("Id");

                    b.HasIndex("FightId");

                    b.HasIndex("JudgeId");

                    b.ToTable("FightJudgesMappings");
                });

            modelBuilder.Entity("MuaythaiSportManagementSystemApi.Models.FightPoint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Accepted");

                    b.Property<string>("Cautions")
                        .IsRequired();

                    b.Property<int?>("FightId");

                    b.Property<string>("JudgeId");

                    b.Property<int>("Points");

                    b.Property<int>("RoundId");

                    b.Property<string>("Wamings")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("FightId");

                    b.HasIndex("JudgeId");

                    b.ToTable("FightPoints");
                });

            modelBuilder.Entity("MuaythaiSportManagementSystemApi.Models.FightStructure", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("RoundlId");

                    b.Property<int>("WeightAgeCategoryId");

                    b.HasKey("Id");

                    b.ToTable("FightStructures");
                });

            modelBuilder.Entity("MuaythaiSportManagementSystemApi.Models.Institution", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .HasMaxLength(500);

                    b.Property<string>("City")
                        .HasMaxLength(500);

                    b.Property<string>("ContactPerson")
                        .HasMaxLength(500);

                    b.Property<int>("Countryid");

                    b.Property<string>("Email")
                        .HasMaxLength(500);

                    b.Property<string>("Facebook")
                        .HasMaxLength(500);

                    b.Property<string>("HeadCoachid")
                        .HasMaxLength(100);

                    b.Property<string>("Instagram")
                        .HasMaxLength(500);

                    b.Property<string>("Logo")
                        .HasMaxLength(1000);

                    b.Property<int>("MembersCount");

                    b.Property<string>("Name")
                        .HasMaxLength(500);

                    b.Property<string>("Owner")
                        .HasMaxLength(500);

                    b.Property<string>("Phone")
                        .HasMaxLength(100);

                    b.Property<string>("Twitter")
                        .HasMaxLength(500);

                    b.Property<string>("VK")
                        .HasMaxLength(500);

                    b.Property<string>("Website")
                        .HasMaxLength(500);

                    b.HasKey("Id");

                    b.HasIndex("Countryid");

                    b.ToTable("Institutions");
                });

            modelBuilder.Entity("MuaythaiSportManagementSystemApi.Models.InstitutionDocumentsMapping", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("DocumentId");

                    b.Property<int?>("InstitutionId");

                    b.HasKey("Id");

                    b.HasIndex("DocumentId");

                    b.HasIndex("InstitutionId");

                    b.ToTable("InstitutionDocumentsMappings");
                });

            modelBuilder.Entity("MuaythaiSportManagementSystemApi.Models.KhanLevel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Level");

                    b.Property<string>("Name")
                        .HasMaxLength(500);

                    b.HasKey("Id");

                    b.ToTable("KhanLevels");
                });

            modelBuilder.Entity("MuaythaiSportManagementSystemApi.Models.Suspension", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<DateTime>("From");

                    b.Property<int?>("SuspensionTypeId");

                    b.Property<DateTime?>("To");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("SuspensionTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("Suspensions");
                });

            modelBuilder.Entity("MuaythaiSportManagementSystemApi.Models.SuspensionType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Localization");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("SuspensionTypes");
                });

            modelBuilder.Entity("MuaythaiSportManagementSystemApi.Models.UserDocumentsMapping", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("DocumentId");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("DocumentId");

                    b.HasIndex("UserId");

                    b.ToTable("UserDocumentsMappings");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("MuaythaiSportManagementSystemApi.Models.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("MuaythaiSportManagementSystemApi.Models.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MuaythaiSportManagementSystemApi.Models.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MuaythaiSportManagementSystemApi.Models.ApplicationUser", b =>
                {
                    b.HasOne("MuaythaiSportManagementSystemApi.Models.Country", "Country")
                        .WithMany("Users")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MuaythaiSportManagementSystemApi.Models.Institution", "Institution")
                        .WithMany("Users")
                        .HasForeignKey("InstitutionId");

                    b.HasOne("MuaythaiSportManagementSystemApi.Models.KhanLevel", "KhanLevel")
                        .WithMany("Users")
                        .HasForeignKey("KhanLevelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MuaythaiSportManagementSystemApi.Models.Contest", b =>
                {
                    b.HasOne("MuaythaiSportManagementSystemApi.Models.Country", "Country")
                        .WithMany("Contests")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MuaythaiSportManagementSystemApi.Models.Institution", "Institution")
                        .WithMany("Contests")
                        .HasForeignKey("InstitutionId");
                });

            modelBuilder.Entity("MuaythaiSportManagementSystemApi.Models.ContestCategory", b =>
                {
                    b.HasOne("MuaythaiSportManagementSystemApi.Models.Contest", "Contest")
                        .WithMany("ContestCategories")
                        .HasForeignKey("ContestId");

                    b.HasOne("MuaythaiSportManagementSystemApi.Models.FightStructure", "FightStructure")
                        .WithMany("ContestCategories")
                        .HasForeignKey("FightStructureId");
                });

            modelBuilder.Entity("MuaythaiSportManagementSystemApi.Models.ContestRequest", b =>
                {
                    b.HasOne("MuaythaiSportManagementSystemApi.Models.ApplicationUser", "AcceptedByUser")
                        .WithMany("AcceptedContestRequests")
                        .HasForeignKey("AcceptedByUserId");

                    b.HasOne("MuaythaiSportManagementSystemApi.Models.ContestCategory", "ContestCategory")
                        .WithMany("ContestRequests")
                        .HasForeignKey("ContestCategoryId");

                    b.HasOne("MuaythaiSportManagementSystemApi.Models.Contest", "Contest")
                        .WithMany("ContestRequests")
                        .HasForeignKey("ContestId");

                    b.HasOne("MuaythaiSportManagementSystemApi.Models.Institution", "Institution")
                        .WithMany("ContestRequests")
                        .HasForeignKey("InstitutionId");

                    b.HasOne("MuaythaiSportManagementSystemApi.Models.ApplicationUser", "User")
                        .WithMany("ContestRequests")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("MuaythaiSportManagementSystemApi.Models.ExecutionBoard", b =>
                {
                    b.HasOne("MuaythaiSportManagementSystemApi.Models.Institution", "Institution")
                        .WithMany("ExecutionBoards")
                        .HasForeignKey("InstitutionId");

                    b.HasOne("MuaythaiSportManagementSystemApi.Models.ApplicationUser", "User")
                        .WithMany("ExecutionBoards")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("MuaythaiSportManagementSystemApi.Models.Fight", b =>
                {
                    b.HasOne("MuaythaiSportManagementSystemApi.Models.ApplicationUser", "BlueAthlete")
                        .WithMany("AsBlueFights")
                        .HasForeignKey("BlueAthleteId");

                    b.HasOne("MuaythaiSportManagementSystemApi.Models.Contest", "Contest")
                        .WithMany("Fights")
                        .HasForeignKey("ContestId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MuaythaiSportManagementSystemApi.Models.ApplicationUser", "RedAthlete")
                        .WithMany("AsRedFights")
                        .HasForeignKey("RedAthleteId");

                    b.HasOne("MuaythaiSportManagementSystemApi.Models.ApplicationUser", "Referee")
                        .WithMany("AsRefereeFights")
                        .HasForeignKey("RefereeId");

                    b.HasOne("MuaythaiSportManagementSystemApi.Models.FightStructure", "Structure")
                        .WithMany("Fights")
                        .HasForeignKey("StructureId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MuaythaiSportManagementSystemApi.Models.ApplicationUser", "TimeKeeper")
                        .WithMany("AsTimeKeeperFights")
                        .HasForeignKey("TimeKeeperId");

                    b.HasOne("MuaythaiSportManagementSystemApi.Models.ApplicationUser", "Winner")
                        .WithMany("WonFights")
                        .HasForeignKey("WinnerId");
                });

            modelBuilder.Entity("MuaythaiSportManagementSystemApi.Models.FightJudgesMapping", b =>
                {
                    b.HasOne("MuaythaiSportManagementSystemApi.Models.Fight", "Fight")
                        .WithMany("FightJudgesMappings")
                        .HasForeignKey("FightId");

                    b.HasOne("MuaythaiSportManagementSystemApi.Models.ApplicationUser", "Judge")
                        .WithMany("FightJudgesMappings")
                        .HasForeignKey("JudgeId");
                });

            modelBuilder.Entity("MuaythaiSportManagementSystemApi.Models.FightPoint", b =>
                {
                    b.HasOne("MuaythaiSportManagementSystemApi.Models.Fight", "Fight")
                        .WithMany("FightPoints")
                        .HasForeignKey("FightId");

                    b.HasOne("MuaythaiSportManagementSystemApi.Models.ApplicationUser", "Judge")
                        .WithMany("FightPoints")
                        .HasForeignKey("JudgeId");
                });

            modelBuilder.Entity("MuaythaiSportManagementSystemApi.Models.Institution", b =>
                {
                    b.HasOne("MuaythaiSportManagementSystemApi.Models.Country", "Country")
                        .WithMany("Institutions")
                        .HasForeignKey("Countryid")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MuaythaiSportManagementSystemApi.Models.InstitutionDocumentsMapping", b =>
                {
                    b.HasOne("MuaythaiSportManagementSystemApi.Models.Document", "Document")
                        .WithMany("InstitutionDocumentsMappings")
                        .HasForeignKey("DocumentId");

                    b.HasOne("MuaythaiSportManagementSystemApi.Models.Institution", "Institution")
                        .WithMany("InstitutionDocumentsMappings")
                        .HasForeignKey("InstitutionId");
                });

            modelBuilder.Entity("MuaythaiSportManagementSystemApi.Models.Suspension", b =>
                {
                    b.HasOne("MuaythaiSportManagementSystemApi.Models.SuspensionType", "SuspensionType")
                        .WithMany("Suspensions")
                        .HasForeignKey("SuspensionTypeId");

                    b.HasOne("MuaythaiSportManagementSystemApi.Models.ApplicationUser", "User")
                        .WithMany("Suspensions")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("MuaythaiSportManagementSystemApi.Models.UserDocumentsMapping", b =>
                {
                    b.HasOne("MuaythaiSportManagementSystemApi.Models.Document", "Document")
                        .WithMany("UserDocumentsMappings")
                        .HasForeignKey("DocumentId");

                    b.HasOne("MuaythaiSportManagementSystemApi.Models.ApplicationUser", "User")
                        .WithMany("UserDocimentsMappings")
                        .HasForeignKey("UserId");
                });
        }
    }
}
