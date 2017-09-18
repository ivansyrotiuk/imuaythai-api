using Microsoft.EntityFrameworkCore;
using MoreLinq;
using MuaythaiSportManagementSystemApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MuaythaiSportManagementSystemApi.Data
{
    public interface IDbInitializer
    {
        void Initialize();
    }

    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _context;
        private readonly ApplicationMainDbContext _mainContext;

        public DbInitializer(ApplicationDbContext context, ApplicationMainDbContext mainContext)
        {
            _context = context;
            _mainContext = mainContext;
        }

        public void Initialize()
        {
            var countries = _mainContext.Countries.ToList();
            var institutions = _mainContext.Institutions.ToList();
            var khanLevels = _mainContext.KhanLevels.ToList();
            var suspensionTypes = _mainContext.SuspensionTypes.ToList();
            var suspensions = _mainContext.Suspensions.ToList();
            var users = _mainContext.Users.ToList().DistinctBy(u => u.Id).ToList();
            var contestTypes = _mainContext.ContestTypes.ToList();
            var contestRanges = _mainContext.ContestRanges.ToList();
            var contests = _mainContext.Contests.ToList();

            var contestTypePoints = _mainContext.ContestTypePoints.ToList();
            var contestCategory = _mainContext.ContestCategories.ToList();
            var rounds = _mainContext.Rounds.ToList();
            var weightAgeCategories = _mainContext.WeightAgeCategories.ToList();
            var fightStructures = _mainContext.FightStructures.ToList();
            var contestRequests = _mainContext.ContestRequests.ToList();
            var fights = _mainContext.Fights.ToList();
            var fightJudgesMappings = _mainContext.FightJudgesMappings.ToList();
            var roles = _mainContext.Roles.ToList();
            var userRoles = _mainContext.UserRoles.ToList();


            countries.ForEach(item => NullReferencedPropeties(item));
            institutions.ForEach(item => NullReferencedPropeties(item));
            khanLevels.ForEach(item => NullReferencedPropeties(item));
            suspensionTypes.ForEach(item => NullReferencedPropeties(item));
            suspensions.ForEach(item => NullReferencedPropeties(item));
            users.ForEach(item =>
            {
                NullReferencedPropeties(item);
                item.Roles.Clear();
            });
            contestTypes.ForEach(item => NullReferencedPropeties(item));
            contestRanges.ForEach(item => NullReferencedPropeties(item));
            contests.ForEach(item => NullReferencedPropeties(item));

            contestTypePoints.ForEach(item => NullReferencedPropeties(item));
            contestCategory.ForEach(item => NullReferencedPropeties(item));
            rounds.ForEach(item => NullReferencedPropeties(item));
            weightAgeCategories.ForEach(item => NullReferencedPropeties(item));
            fightStructures.ForEach(item => NullReferencedPropeties(item));
            contestRequests.ForEach(item => NullReferencedPropeties(item));
            fights.ForEach(item => NullReferencedPropeties(item));
            fightJudgesMappings.ForEach(item => NullReferencedPropeties(item));


            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.Database.ExecuteSqlCommand("DELETE FROM [contest_db2].[dbo].[KhanLevels]");
                    _context.Database.ExecuteSqlCommand("DELETE FROM [contest_db2].[dbo].[SuspensionTypes]");
                    _context.Database.ExecuteSqlCommand("DELETE FROM [contest_db2].[dbo].[Suspensions]");
                    _context.Database.ExecuteSqlCommand("DELETE FROM [contest_db2].[dbo].[Contests]");
                    _context.Database.ExecuteSqlCommand("DELETE FROM [contest_db2].[dbo].[ContestTypes]");
                    _context.Database.ExecuteSqlCommand("DELETE FROM [contest_db2].[dbo].[ContestRanges]");
                    _context.Database.ExecuteSqlCommand("DELETE FROM [contest_db2].[dbo].[ContestRequests]");
                    _context.Database.ExecuteSqlCommand("DELETE FROM [contest_db2].[dbo].[ContestCategories]");
                    _context.Database.ExecuteSqlCommand("DELETE FROM [contest_db2].[dbo].[FightStructures]");
                    _context.Database.ExecuteSqlCommand("DELETE FROM [contest_db2].[dbo].[WeightAgeCategories]");
                    _context.Database.ExecuteSqlCommand("DELETE FROM [contest_db2].[dbo].[Rounds]");
                    _context.Database.ExecuteSqlCommand("DELETE FROM [contest_db2].[dbo].[ContestTypePoints]");
                    _context.Database.ExecuteSqlCommand("DELETE FROM [contest_db2].[dbo].[FightJudgesMappings]");
                    _context.Database.ExecuteSqlCommand("DELETE FROM [contest_db2].[dbo].[Fights]");
                    _context.Database.ExecuteSqlCommand("DELETE FROM [contest_db2].[dbo].[AspNetUserRoles]");
                    _context.Database.ExecuteSqlCommand("DELETE FROM [contest_db2].[dbo].[AspNetRoles]");
                    _context.Database.ExecuteSqlCommand("DELETE FROM [contest_db2].[dbo].[AspNetUsers]");
                    _context.Database.ExecuteSqlCommand("DELETE FROM [contest_db2].[dbo].[Institutions]");
                    _context.Database.ExecuteSqlCommand("DELETE FROM [contest_db2].[dbo].[Countries]");

                    _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [contest_db2].[dbo].[Countries] ON");
                    _context.Countries.AddRange(countries);
                    _context.SaveChanges();
                    _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [contest_db2].[dbo].[Countries] OFF");

                    _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [contest_db2].[dbo].[Institutions] ON");
                    _context.Institutions.AddRange(institutions);
                    _context.SaveChanges();
                    _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [contest_db2].[dbo].[Institutions] OFF");

                    _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [contest_db2].[dbo].[KhanLevels] ON");
                    _context.KhanLevels.AddRange(khanLevels);
                    _context.SaveChanges();
                    _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [contest_db2].[dbo].[KhanLevels] OFF");

                    _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [contest_db2].[dbo].[SuspensionTypes] ON");
                    _context.SuspensionTypes.AddRange(suspensionTypes);
                    _context.SaveChanges();
                    _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [contest_db2].[dbo].[SuspensionTypes] OFF");

                    _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [contest_db2].[dbo].[Suspensions] ON");
                    _context.Suspensions.AddRange(suspensions);
                    _context.SaveChanges();
                    _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [contest_db2].[dbo].[Suspensions] OFF");

                    _context.Roles.AddRange(roles);
                    _context.SaveChanges();

                    

                    _context.Users.AddRange(users);
                    _context.SaveChanges();

                    //_context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [contest_db2].[dbo].[AspNetUserRoles] ON");
                    _context.UserRoles.AddRange(userRoles);
                    _context.SaveChanges();
                    //_context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [contest_db2].[dbo].[AspNetUserRoles] OFF");


                    _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [contest_db2].[dbo].[ContestTypes] ON");
                    _context.ContestTypes.AddRange(contestTypes);
                    _context.SaveChanges();
                    _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [contest_db2].[dbo].[ContestTypes] OFF");

                    _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [contest_db2].[dbo].[ContestRanges] ON");
                    _context.ContestRanges.AddRange(contestRanges);
                    _context.SaveChanges();
                    _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [contest_db2].[dbo].[ContestRanges] OFF");

                    _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [contest_db2].[dbo].[Contests] ON");
                    _context.Contests.AddRange(contests);
                    _context.SaveChanges();
                    _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [contest_db2].[dbo].[Contests] OFF");

                    _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [contest_db2].[dbo].[ContestTypePoints] ON");
                    _context.ContestTypePoints.AddRange(contestTypePoints);
                    _context.SaveChanges();
                    _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [contest_db2].[dbo].[ContestTypePoints] OFF");

                    
                    _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [contest_db2].[dbo].[Rounds] ON");
                    _context.Rounds.AddRange(rounds);
                    _context.SaveChanges();
                    _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [contest_db2].[dbo].[Rounds] OFF");

                    _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [contest_db2].[dbo].[WeightAgeCategories] ON");
                    _context.WeightAgeCategories.AddRange(weightAgeCategories);
                    _context.SaveChanges();
                    _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [contest_db2].[dbo].[WeightAgeCategories] OFF");

                    _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [contest_db2].[dbo].[FightStructures] ON");
                    _context.FightStructures.AddRange(fightStructures);
                    _context.SaveChanges();
                    _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [contest_db2].[dbo].[FightStructures] OFF");

                    _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [contest_db2].[dbo].[ContestCategories] ON");
                    _context.ContestCategories.AddRange(contestCategory);
                    _context.SaveChanges();
                    _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [contest_db2].[dbo].[ContestCategories] OFF");

                    _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [contest_db2].[dbo].[ContestRequests] ON");
                    _context.ContestRequests.AddRange(contestRequests);
                    _context.SaveChanges();
                    _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [contest_db2].[dbo].[ContestRequests] OFF");

                    _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [contest_db2].[dbo].[Fights] ON");
                    _context.Fights.AddRange(fights);
                    _context.SaveChanges();
                    _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [contest_db2].[dbo].[Fights] OFF");

                    _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [contest_db2].[dbo].[FightJudgesMappings] ON");
                    _context.FightJudgesMappings.AddRange(fightJudgesMappings);
                    _context.SaveChanges();
                    _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [contest_db2].[dbo].[FightJudgesMappings] OFF");

                    dbContextTransaction.Commit();
                }
                catch (Exception e)
                {
                    dbContextTransaction.Rollback();
                  
                }
            }

        }

        private void NullReferencedPropeties(object obj)
        {
            Type type = obj.GetType();
            var properties = type.GetProperties();
            foreach(var property in properties)
            {
                var propertyType = property.PropertyType;
                if (propertyType.IsValueType || propertyType == typeof(string))
                {
                    continue;
                }

                try
                {
                    property.SetValue(obj, null);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }

        }
    }
}
