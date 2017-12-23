using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IMuaythai.DataAccess.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                });

            migrationBuilder.CreateTable(
                name: "ContestRanges",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContestRanges", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContestTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContestTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true),
                    Continent = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ExpirationDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KhanLevels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Level = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhanLevels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rounds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Duration = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    RoundsCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rounds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SuspensionTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Localization = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuspensionTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeightAgeCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Gender = table.Column<string>(nullable: true),
                    MaxAge = table.Column<int>(nullable: false),
                    MaxWeight = table.Column<decimal>(nullable: false),
                    MinAge = table.Column<int>(nullable: false),
                    MinWeight = table.Column<decimal>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeightAgeCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Provinces",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CountryId = table.Column<int>(nullable: false),
                    ProvinceName = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Provinces_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FightStructures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoundId = table.Column<int>(nullable: false),
                    WeightAgeCategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FightStructures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FightStructures_Rounds_RoundId",
                        column: x => x.RoundId,
                        principalTable: "Rounds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FightStructures_WeightAgeCategories_WeightAgeCategoryId",
                        column: x => x.WeightAgeCategoryId,
                        principalTable: "WeightAgeCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoleRequests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AcceptationDate = table.Column<DateTime>(nullable: true),
                    AcceptedByUserId = table.Column<string>(nullable: true),
                    InstitutionId = table.Column<int>(nullable: true),
                    RoleId = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoleRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoleRequests_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                });

            migrationBuilder.CreateTable(
                name: "ContestRequests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AcceptanceDate = table.Column<DateTime>(nullable: false),
                    AcceptedByUserId = table.Column<string>(nullable: true),
                    ContestCategoryId = table.Column<int>(nullable: true),
                    ContestId = table.Column<int>(nullable: false),
                    InstitutionId = table.Column<int>(nullable: true),
                    IssueDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContestRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExecutionBoards",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ExecutionPosition = table.Column<int>(nullable: false),
                    InstitutionId = table.Column<int>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExecutionBoards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fights",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BlueAthleteId = table.Column<string>(nullable: true),
                    ContestId = table.Column<int>(nullable: false),
                    KO = table.Column<byte>(nullable: false),
                    KOTime = table.Column<DateTime>(nullable: false),
                    NextFightId = table.Column<int>(nullable: true),
                    RedAthleteId = table.Column<string>(nullable: true),
                    RefereeId = table.Column<string>(nullable: true),
                    Ring = table.Column<string>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    StructureId = table.Column<int>(nullable: false),
                    TimeKeeperId = table.Column<string>(nullable: true),
                    WinnerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fights_FightStructures_StructureId",
                        column: x => x.StructureId,
                        principalTable: "FightStructures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FightJudgesMappings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FightId = table.Column<int>(nullable: true),
                    JudgeId = table.Column<string>(nullable: true),
                    Main = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FightJudgesMappings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FightJudgesMappings_Fights_FightId",
                        column: x => x.FightId,
                        principalTable: "Fights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FightPoints",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Accepted = table.Column<bool>(nullable: false),
                    Cautions = table.Column<string>(nullable: false),
                    FightId = table.Column<int>(nullable: true),
                    FighterId = table.Column<string>(nullable: false),
                    JudgeId = table.Column<string>(nullable: true),
                    Points = table.Column<int>(nullable: false),
                    RoundId = table.Column<int>(nullable: false),
                    Warnings = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FightPoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FightPoints_Fights_FightId",
                        column: x => x.FightId,
                        principalTable: "Fights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Institutions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(maxLength: 500, nullable: true),
                    City = table.Column<string>(maxLength: 500, nullable: true),
                    ContactPerson = table.Column<string>(maxLength: 500, nullable: true),
                    CountryId = table.Column<int>(nullable: false),
                    Email = table.Column<string>(maxLength: 500, nullable: true),
                    Facebook = table.Column<string>(maxLength: 500, nullable: true),
                    HeadCoachId = table.Column<string>(nullable: true),
                    Instagram = table.Column<string>(maxLength: 500, nullable: true),
                    InstitutionType = table.Column<int>(nullable: false),
                    Logo = table.Column<string>(maxLength: 1000, nullable: true),
                    MembersCount = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 500, nullable: true),
                    Owner = table.Column<string>(maxLength: 500, nullable: true),
                    Phone = table.Column<string>(maxLength: 100, nullable: true),
                    Twitter = table.Column<string>(maxLength: 500, nullable: true),
                    VK = table.Column<string>(maxLength: 500, nullable: true),
                    Website = table.Column<string>(maxLength: 500, nullable: true),
                    ZipCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Institutions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Institutions_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Accepted = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Birthdate = table.Column<DateTime>(nullable: false),
                    CoachLevel = table.Column<string>(maxLength: 100, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CountryId = table.Column<int>(nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    Facebook = table.Column<string>(maxLength: 500, nullable: true),
                    FirstName = table.Column<string>(maxLength: 500, nullable: true),
                    Gender = table.Column<string>(maxLength: 10, nullable: true),
                    Instagram = table.Column<string>(maxLength: 500, nullable: true),
                    InstitutionId = table.Column<int>(nullable: true),
                    KhanLevelId = table.Column<int>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    Nationality = table.Column<string>(maxLength: 500, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(maxLength: 60, nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    Photo = table.Column<string>(maxLength: 1000, nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(maxLength: 500, nullable: true),
                    Twitter = table.Column<string>(maxLength: 500, nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    VK = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Institutions_InstitutionId",
                        column: x => x.InstitutionId,
                        principalTable: "Institutions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_KhanLevels_KhanLevelId",
                        column: x => x.KhanLevelId,
                        principalTable: "KhanLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Contests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(maxLength: 500, nullable: false),
                    AllowUnassociated = table.Column<bool>(nullable: false),
                    City = table.Column<string>(maxLength: 500, nullable: false),
                    ContestRangeId = table.Column<int>(nullable: true),
                    ContestTypeId = table.Column<int>(nullable: true),
                    CountryId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Duration = table.Column<int>(nullable: false),
                    EndRegistrationDate = table.Column<DateTime>(nullable: false),
                    Facebook = table.Column<string>(maxLength: 500, nullable: true),
                    Instagram = table.Column<string>(maxLength: 500, nullable: true),
                    InstitutionId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 500, nullable: false),
                    RingsCount = table.Column<int>(nullable: false),
                    Twitter = table.Column<string>(maxLength: 500, nullable: true),
                    VK = table.Column<string>(maxLength: 500, nullable: true),
                    Website = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contests_ContestRanges_ContestRangeId",
                        column: x => x.ContestRangeId,
                        principalTable: "ContestRanges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contests_ContestTypes_ContestTypeId",
                        column: x => x.ContestTypeId,
                        principalTable: "ContestTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contests_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contests_Institutions_InstitutionId",
                        column: x => x.InstitutionId,
                        principalTable: "Institutions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContestTypePoints",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContestRangeId = table.Column<int>(nullable: false),
                    ContestTypeId = table.Column<int>(nullable: false),
                    InstitutionId = table.Column<int>(nullable: true),
                    Points = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContestTypePoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContestTypePoints_ContestRanges_ContestRangeId",
                        column: x => x.ContestRangeId,
                        principalTable: "ContestRanges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContestTypePoints_ContestTypes_ContestTypeId",
                        column: x => x.ContestTypeId,
                        principalTable: "ContestTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContestTypePoints_Institutions_InstitutionId",
                        column: x => x.InstitutionId,
                        principalTable: "Institutions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InstitutionDocumentsMappings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DocumentId = table.Column<int>(nullable: true),
                    InstitutionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstitutionDocumentsMappings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstitutionDocumentsMappings_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InstitutionDocumentsMappings_Institutions_InstitutionId",
                        column: x => x.InstitutionId,
                        principalTable: "Institutions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reminders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Confirmed = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    SendDate = table.Column<DateTime>(nullable: false),
                    Text = table.Column<string>(maxLength: 500, nullable: true),
                    Title = table.Column<string>(maxLength: 500, nullable: true),
                    Type = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reminders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reminders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Suspensions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    From = table.Column<DateTime>(nullable: false),
                    SuspensionTypeId = table.Column<int>(nullable: true),
                    To = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suspensions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Suspensions_SuspensionTypes_SuspensionTypeId",
                        column: x => x.SuspensionTypeId,
                        principalTable: "SuspensionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Suspensions_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserDocumentsMappings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DocumentId = table.Column<int>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDocumentsMappings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserDocumentsMappings_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserDocumentsMappings_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContestDocumentsMapping",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DocumentId = table.Column<int>(nullable: true),
                    InstitutionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContestDocumentsMapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContestDocumentsMapping_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContestDocumentsMapping_Contests_InstitutionId",
                        column: x => x.InstitutionId,
                        principalTable: "Contests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContestCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContestTypePointsId = table.Column<int>(nullable: false),
                    FightStructureId = table.Column<int>(nullable: false),
                    InstitutionId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContestCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContestCategories_ContestTypePoints_ContestTypePointsId",
                        column: x => x.ContestTypePointsId,
                        principalTable: "ContestTypePoints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContestCategories_FightStructures_FightStructureId",
                        column: x => x.FightStructureId,
                        principalTable: "FightStructures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContestCategories_Institutions_InstitutionId",
                        column: x => x.InstitutionId,
                        principalTable: "Institutions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContestCategoriesMappings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContestCategoryId = table.Column<int>(nullable: false),
                    ContestId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContestCategoriesMappings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContestCategoriesMappings_ContestCategories_ContestCategoryId",
                        column: x => x.ContestCategoryId,
                        principalTable: "ContestCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContestCategoriesMappings_Contests_ContestId",
                        column: x => x.ContestId,
                        principalTable: "Contests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CountryId",
                table: "AspNetUsers",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_InstitutionId",
                table: "AspNetUsers",
                column: "InstitutionId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_KhanLevelId",
                table: "AspNetUsers",
                column: "KhanLevelId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contests_ContestRangeId",
                table: "Contests",
                column: "ContestRangeId");

            migrationBuilder.CreateIndex(
                name: "IX_Contests_ContestTypeId",
                table: "Contests",
                column: "ContestTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Contests_CountryId",
                table: "Contests",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Contests_InstitutionId",
                table: "Contests",
                column: "InstitutionId");

            migrationBuilder.CreateIndex(
                name: "IX_ContestCategoriesMappings_ContestCategoryId",
                table: "ContestCategoriesMappings",
                column: "ContestCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ContestCategoriesMappings_ContestId",
                table: "ContestCategoriesMappings",
                column: "ContestId");

            migrationBuilder.CreateIndex(
                name: "IX_ContestCategories_ContestTypePointsId",
                table: "ContestCategories",
                column: "ContestTypePointsId");

            migrationBuilder.CreateIndex(
                name: "IX_ContestCategories_FightStructureId",
                table: "ContestCategories",
                column: "FightStructureId");

            migrationBuilder.CreateIndex(
                name: "IX_ContestCategories_InstitutionId",
                table: "ContestCategories",
                column: "InstitutionId");

            migrationBuilder.CreateIndex(
                name: "IX_ContestDocumentsMapping_DocumentId",
                table: "ContestDocumentsMapping",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_ContestDocumentsMapping_InstitutionId",
                table: "ContestDocumentsMapping",
                column: "InstitutionId");

            migrationBuilder.CreateIndex(
                name: "IX_ContestRequests_AcceptedByUserId",
                table: "ContestRequests",
                column: "AcceptedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContestRequests_ContestCategoryId",
                table: "ContestRequests",
                column: "ContestCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ContestRequests_ContestId",
                table: "ContestRequests",
                column: "ContestId");

            migrationBuilder.CreateIndex(
                name: "IX_ContestRequests_InstitutionId",
                table: "ContestRequests",
                column: "InstitutionId");

            migrationBuilder.CreateIndex(
                name: "IX_ContestRequests_UserId",
                table: "ContestRequests",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContestTypePoints_ContestRangeId",
                table: "ContestTypePoints",
                column: "ContestRangeId");

            migrationBuilder.CreateIndex(
                name: "IX_ContestTypePoints_ContestTypeId",
                table: "ContestTypePoints",
                column: "ContestTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ContestTypePoints_InstitutionId",
                table: "ContestTypePoints",
                column: "InstitutionId");

            migrationBuilder.CreateIndex(
                name: "IX_ExecutionBoards_InstitutionId",
                table: "ExecutionBoards",
                column: "InstitutionId");

            migrationBuilder.CreateIndex(
                name: "IX_ExecutionBoards_UserId",
                table: "ExecutionBoards",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Fights_BlueAthleteId",
                table: "Fights",
                column: "BlueAthleteId");

            migrationBuilder.CreateIndex(
                name: "IX_Fights_ContestId",
                table: "Fights",
                column: "ContestId");

            migrationBuilder.CreateIndex(
                name: "IX_Fights_RedAthleteId",
                table: "Fights",
                column: "RedAthleteId");

            migrationBuilder.CreateIndex(
                name: "IX_Fights_RefereeId",
                table: "Fights",
                column: "RefereeId");

            migrationBuilder.CreateIndex(
                name: "IX_Fights_StructureId",
                table: "Fights",
                column: "StructureId");

            migrationBuilder.CreateIndex(
                name: "IX_Fights_TimeKeeperId",
                table: "Fights",
                column: "TimeKeeperId");

            migrationBuilder.CreateIndex(
                name: "IX_Fights_WinnerId",
                table: "Fights",
                column: "WinnerId");

            migrationBuilder.CreateIndex(
                name: "IX_FightJudgesMappings_FightId",
                table: "FightJudgesMappings",
                column: "FightId");

            migrationBuilder.CreateIndex(
                name: "IX_FightJudgesMappings_JudgeId",
                table: "FightJudgesMappings",
                column: "JudgeId");

            migrationBuilder.CreateIndex(
                name: "IX_FightPoints_FightId",
                table: "FightPoints",
                column: "FightId");

            migrationBuilder.CreateIndex(
                name: "IX_FightPoints_JudgeId",
                table: "FightPoints",
                column: "JudgeId");

            migrationBuilder.CreateIndex(
                name: "IX_FightStructures_RoundId",
                table: "FightStructures",
                column: "RoundId");

            migrationBuilder.CreateIndex(
                name: "IX_FightStructures_WeightAgeCategoryId",
                table: "FightStructures",
                column: "WeightAgeCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Institutions_CountryId",
                table: "Institutions",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Institutions_HeadCoachId",
                table: "Institutions",
                column: "HeadCoachId");

            migrationBuilder.CreateIndex(
                name: "IX_InstitutionDocumentsMappings_DocumentId",
                table: "InstitutionDocumentsMappings",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_InstitutionDocumentsMappings_InstitutionId",
                table: "InstitutionDocumentsMappings",
                column: "InstitutionId");

            migrationBuilder.CreateIndex(
                name: "IX_Provinces_CountryId",
                table: "Provinces",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Reminders_UserId",
                table: "Reminders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Suspensions_SuspensionTypeId",
                table: "Suspensions",
                column: "SuspensionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Suspensions_UserId",
                table: "Suspensions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDocumentsMappings_DocumentId",
                table: "UserDocumentsMappings",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDocumentsMappings_UserId",
                table: "UserDocumentsMappings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleRequests_AcceptedByUserId",
                table: "UserRoleRequests",
                column: "AcceptedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleRequests_RoleId",
                table: "UserRoleRequests",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleRequests_UserId",
                table: "UserRoleRequests",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoleRequests_AspNetUsers_AcceptedByUserId",
                table: "UserRoleRequests",
                column: "AcceptedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoleRequests_AspNetUsers_UserId",
                table: "UserRoleRequests",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContestRequests_AspNetUsers_AcceptedByUserId",
                table: "ContestRequests",
                column: "AcceptedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ContestRequests_AspNetUsers_UserId",
                table: "ContestRequests",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ContestRequests_Institutions_InstitutionId",
                table: "ContestRequests",
                column: "InstitutionId",
                principalTable: "Institutions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ContestRequests_ContestCategories_ContestCategoryId",
                table: "ContestRequests",
                column: "ContestCategoryId",
                principalTable: "ContestCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ContestRequests_Contests_ContestId",
                table: "ContestRequests",
                column: "ContestId",
                principalTable: "Contests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExecutionBoards_AspNetUsers_UserId",
                table: "ExecutionBoards",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExecutionBoards_Institutions_InstitutionId",
                table: "ExecutionBoards",
                column: "InstitutionId",
                principalTable: "Institutions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Fights_AspNetUsers_BlueAthleteId",
                table: "Fights",
                column: "BlueAthleteId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Fights_AspNetUsers_RedAthleteId",
                table: "Fights",
                column: "RedAthleteId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Fights_AspNetUsers_RefereeId",
                table: "Fights",
                column: "RefereeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Fights_AspNetUsers_TimeKeeperId",
                table: "Fights",
                column: "TimeKeeperId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Fights_AspNetUsers_WinnerId",
                table: "Fights",
                column: "WinnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Fights_Contests_ContestId",
                table: "Fights",
                column: "ContestId",
                principalTable: "Contests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FightJudgesMappings_AspNetUsers_JudgeId",
                table: "FightJudgesMappings",
                column: "JudgeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FightPoints_AspNetUsers_JudgeId",
                table: "FightPoints",
                column: "JudgeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Institutions_AspNetUsers_HeadCoachId",
                table: "Institutions",
                column: "HeadCoachId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Institutions_AspNetUsers_HeadCoachId",
                table: "Institutions");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ContestCategoriesMappings");

            migrationBuilder.DropTable(
                name: "ContestDocumentsMapping");

            migrationBuilder.DropTable(
                name: "ContestRequests");

            migrationBuilder.DropTable(
                name: "ExecutionBoards");

            migrationBuilder.DropTable(
                name: "FightJudgesMappings");

            migrationBuilder.DropTable(
                name: "FightPoints");

            migrationBuilder.DropTable(
                name: "InstitutionDocumentsMappings");

            migrationBuilder.DropTable(
                name: "Provinces");

            migrationBuilder.DropTable(
                name: "Reminders");

            migrationBuilder.DropTable(
                name: "Suspensions");

            migrationBuilder.DropTable(
                name: "UserDocumentsMappings");

            migrationBuilder.DropTable(
                name: "UserRoleRequests");

            migrationBuilder.DropTable(
                name: "ContestCategories");

            migrationBuilder.DropTable(
                name: "Fights");

            migrationBuilder.DropTable(
                name: "SuspensionTypes");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "ContestTypePoints");

            migrationBuilder.DropTable(
                name: "Contests");

            migrationBuilder.DropTable(
                name: "FightStructures");

            migrationBuilder.DropTable(
                name: "ContestRanges");

            migrationBuilder.DropTable(
                name: "ContestTypes");

            migrationBuilder.DropTable(
                name: "Rounds");

            migrationBuilder.DropTable(
                name: "WeightAgeCategories");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Institutions");

            migrationBuilder.DropTable(
                name: "KhanLevels");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
