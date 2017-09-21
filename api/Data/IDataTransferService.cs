using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using MoreLinq;
using MuaythaiSportManagementSystemApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MuaythaiSportManagementSystemApi.Data
{
    public interface IDataTransferService
    {
        void DownloadDataFromMainDatabase();
        Task UploadDataToMainDatabase();
    }

    public class DataTransferService : IDataTransferService
    {
        private readonly ApplicationDbContext _context;
        private readonly ApplicationMainDbContext _mainContext;
        private readonly IEqualityComparer<ContestCategoriesMapping> _contestCategoriesComparer;
        private readonly IEqualityComparer<ContestCategory> _contestCategoryComparer;
        private readonly IEqualityComparer<Contest> _contestComparer;
        private readonly IEqualityComparer<ContestRange> _contestRangeComparer;
        private readonly IEqualityComparer<ContestRequest> _contestRequestComparer;
        private readonly IEqualityComparer<ContestType> _contestTypeComparer;
        private readonly IEqualityComparer<ContestTypePoints> _contestTypePointsComparer;
        private readonly IEqualityComparer<Fight> _fightComparer;
        private readonly IEqualityComparer<FightJudgesMapping> _fightJudgesMappingComparer;
        private readonly IEqualityComparer<FightStructure> _fightStructureComparer;
        private readonly IEqualityComparer<Round> _roundComparer;
        private readonly IEqualityComparer<WeightAgeCategory> _weightAgeCategoryComparer;

        public DataTransferService(ApplicationDbContext context, 
            ApplicationMainDbContext mainContext,
            IEqualityComparer<ContestCategoriesMapping> contestCategoriesComparer,
            IEqualityComparer<ContestCategory> contestCategoryComparer,
            IEqualityComparer<Contest> contestComparer,
            IEqualityComparer<ContestRange> contestRangeComparer,
            IEqualityComparer<ContestRequest> contestRequestComparer,
            IEqualityComparer<ContestType> contestTypeComparer,
            IEqualityComparer<ContestTypePoints> contestTypePointsComparer,
            IEqualityComparer<Fight> fightComparer,
            IEqualityComparer<FightJudgesMapping> fightJudgesMappingComparer,
            IEqualityComparer<FightStructure> fightStructureComparer,
            IEqualityComparer<Round> roundComparer,
            IEqualityComparer<WeightAgeCategory> weightAgeCategoryComparer)
        {
            _context = context;
            _mainContext = mainContext;
            _contestCategoriesComparer = contestCategoriesComparer;
            _contestCategoryComparer = contestCategoryComparer;
            _contestComparer = contestComparer;
            _contestRangeComparer = contestRangeComparer;
            _contestRequestComparer = contestRequestComparer;
            _contestTypeComparer = contestTypeComparer;
            _contestTypePointsComparer = contestTypePointsComparer;
            _fightComparer = fightComparer;
            _fightJudgesMappingComparer = fightJudgesMappingComparer;
            _fightStructureComparer = fightStructureComparer;
            _roundComparer = roundComparer;
            _weightAgeCategoryComparer = weightAgeCategoryComparer;
        }
        
        public void DownloadDataFromMainDatabase()
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


            countries.ForEach(NullReferencedPropeties);
            institutions.ForEach(NullReferencedPropeties);
            khanLevels.ForEach(NullReferencedPropeties);
            suspensionTypes.ForEach(NullReferencedPropeties);
            suspensions.ForEach(NullReferencedPropeties);
            users.ForEach(item =>
            {
                NullReferencedPropeties(item);
                item.Roles.Clear();
            });
            contestTypes.ForEach(NullReferencedPropeties);
            contestRanges.ForEach(NullReferencedPropeties);
            contests.ForEach(NullReferencedPropeties);
            contestTypePoints.ForEach(NullReferencedPropeties);
            contestCategory.ForEach(NullReferencedPropeties);
            rounds.ForEach(NullReferencedPropeties);
            weightAgeCategories.ForEach(NullReferencedPropeties);
            fightStructures.ForEach(NullReferencedPropeties);
            contestRequests.ForEach(NullReferencedPropeties);
            fights.ForEach(NullReferencedPropeties);
            fightJudgesMappings.ForEach(NullReferencedPropeties);


            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.Database.ExecuteSqlCommand("DELETE FROM [KhanLevels]");
                    _context.Database.ExecuteSqlCommand("DELETE FROM [SuspensionTypes]");
                    _context.Database.ExecuteSqlCommand("DELETE FROM [Suspensions]");
                    _context.Database.ExecuteSqlCommand("DELETE FROM [Contests]");
                    _context.Database.ExecuteSqlCommand("DELETE FROM [ContestTypes]");
                    _context.Database.ExecuteSqlCommand("DELETE FROM [ContestRanges]");
                    _context.Database.ExecuteSqlCommand("DELETE FROM [ContestRequests]");
                    _context.Database.ExecuteSqlCommand("DELETE FROM [ContestCategories]");
                    _context.Database.ExecuteSqlCommand("DELETE FROM [FightStructures]");
                    _context.Database.ExecuteSqlCommand("DELETE FROM [WeightAgeCategories]");
                    _context.Database.ExecuteSqlCommand("DELETE FROM [Rounds]");
                    _context.Database.ExecuteSqlCommand("DELETE FROM [ContestTypePoints]");
                    _context.Database.ExecuteSqlCommand("DELETE FROM [FightJudgesMappings]");
                    _context.Database.ExecuteSqlCommand("DELETE FROM [Fights]");
                    _context.Database.ExecuteSqlCommand("DELETE FROM [AspNetUserRoles]");
                    
                    _context.Database.ExecuteSqlCommand("DELETE FROM [AspNetUsers]");
                    _context.Database.ExecuteSqlCommand("DELETE FROM [Institutions]");
                    _context.Database.ExecuteSqlCommand("DELETE FROM [Countries]");
                    _context.Database.ExecuteSqlCommand("DELETE FROM [AspNetRoles]");

                    _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [Countries] ON");
                    _context.Countries.AddRange(countries);
                    _context.SaveChanges();
                    _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [Countries] OFF");

                    _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [Institutions] ON");
                    _context.Institutions.AddRange(institutions);
                    _context.SaveChanges();
                    _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [Institutions] OFF");

                    _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [KhanLevels] ON");
                    _context.KhanLevels.AddRange(khanLevels);
                    _context.SaveChanges();
                    _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [KhanLevels] OFF");

                    _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [SuspensionTypes] ON");
                    _context.SuspensionTypes.AddRange(suspensionTypes);
                    _context.SaveChanges();
                    _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [SuspensionTypes] OFF");

                    _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [Suspensions] ON");
                    _context.Suspensions.AddRange(suspensions);
                    _context.SaveChanges();
                    _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [Suspensions] OFF");

                    _context.Roles.AddRange(roles);
                    _context.SaveChanges();

   
                    _context.Users.AddRange(users);
                    _context.SaveChanges();

                    _context.UserRoles.AddRange(userRoles);
                    _context.SaveChanges();


                    _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [ContestTypes] ON");
                    _context.ContestTypes.AddRange(contestTypes);
                    _context.SaveChanges();
                    _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [ContestTypes] OFF");

                    _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [ContestRanges] ON");
                    _context.ContestRanges.AddRange(contestRanges);
                    _context.SaveChanges();
                    _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [ContestRanges] OFF");

                    _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [Contests] ON");
                    _context.Contests.AddRange(contests);
                    _context.SaveChanges();
                    _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [Contests] OFF");

                    _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [ContestTypePoints] ON");
                    _context.ContestTypePoints.AddRange(contestTypePoints);
                    _context.SaveChanges();
                    _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [ContestTypePoints] OFF");

                    
                    _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [Rounds] ON");
                    _context.Rounds.AddRange(rounds);
                    _context.SaveChanges();
                    _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [Rounds] OFF");

                    _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [WeightAgeCategories] ON");
                    _context.WeightAgeCategories.AddRange(weightAgeCategories);
                    _context.SaveChanges();
                    _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [WeightAgeCategories] OFF");

                    _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [FightStructures] ON");
                    _context.FightStructures.AddRange(fightStructures);
                    _context.SaveChanges();
                    _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [FightStructures] OFF");

                    _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [ContestCategories] ON");
                    _context.ContestCategories.AddRange(contestCategory);
                    _context.SaveChanges();
                    _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [ContestCategories] OFF");

                    _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [ContestRequests] ON");
                    _context.ContestRequests.AddRange(contestRequests);
                    _context.SaveChanges();
                    _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [ContestRequests] OFF");

                    _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [Fights] ON");
                    _context.Fights.AddRange(fights);
                    _context.SaveChanges();
                    _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [Fights] OFF");

                    _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [FightJudgesMappings] ON");
                    _context.FightJudgesMappings.AddRange(fightJudgesMappings);
                    _context.SaveChanges();
                    _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [FightJudgesMappings] OFF");

                    dbContextTransaction.Commit();
                }
                catch (Exception e)
                {
                    dbContextTransaction.Rollback();
                  
                }
            }

        }

        public async Task UploadDataToMainDatabase()
        {
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    Dictionary<int, int> contestTypesIdsDictionary = await UploadContestTypes();
                    Dictionary<int, int> contestRangesIdsDictionary = await UploadContestRanges();
                    Dictionary<int, int> contestTypePointsDictionary = await UploadContestPoints(contestTypesIdsDictionary, contestRangesIdsDictionary);
                    Dictionary<int, int> roundsIdsDictionary = await UploadRounds();
                    Dictionary<int, int> weightAgeCategoriesIdsDictionary = await UploadWeightAgeCategories();
                    Dictionary<int, int> fightStructuresIdsDictionary = await UploadFightCategories(roundsIdsDictionary, weightAgeCategoriesIdsDictionary);

                    dbContextTransaction.Commit();
                }
                catch (Exception e)
                {
                    dbContextTransaction.Rollback();

                }
            }
        }

        private async Task<Dictionary<int, int>> UploadFightCategories(Dictionary<int, int> roundsIdsDictionary, Dictionary<int, int> weightAgeCategoriesIdsDictionary)
        {
            var localFightStructures = await _context.FightStructures.ToListAsync();
            var remoteFightStructures = await _mainContext.FightStructures.ToListAsync();
            Dictionary<int, int> fightStructuresIdsDictionary = localFightStructures.ToDictionary(c => c.Id, c => c.Id);

            foreach (FightStructure fightStructure in localFightStructures)
            {
                fightStructure.RoundId = roundsIdsDictionary[fightStructure.RoundId];
                fightStructure.WeightAgeCategoryId = weightAgeCategoriesIdsDictionary[fightStructure.WeightAgeCategoryId];

                FightStructure remoteFightStructure = remoteFightStructures.FirstOrDefault(r => r.Id == fightStructure.Id);
                if (remoteFightStructure == null)
                {
                    int fightStructureId = fightStructure.Id;
                    fightStructure.Id = 0;
                    _mainContext.FightStructures.Add(fightStructure);
                    fightStructuresIdsDictionary[fightStructureId] = fightStructure.Id;
                    continue;
                }

                if (_fightStructureComparer.Equals(fightStructure, remoteFightStructure))
                {
                    continue;
                }

                fightStructure.DeepCopyTo(remoteFightStructure);
            }

            await _mainContext.SaveChangesAsync();

            return fightStructuresIdsDictionary;
        }

        private async Task<Dictionary<int, int>> UploadWeightAgeCategories()
        {
            var localCategories = await _context.WeightAgeCategories.ToListAsync();
            var remoteCategories = await _mainContext.WeightAgeCategories.ToListAsync();
            Dictionary<int, int> roundsIdsDictionary = localCategories.ToDictionary(c => c.Id, c => c.Id);

            foreach (WeightAgeCategory category in localCategories)
            {
                WeightAgeCategory remoteCategory = remoteCategories.FirstOrDefault(r => r.Id == category.Id);
                if (remoteCategory == null)
                {
                    int categoryId = category.Id;
                    category.Id = 0;
                    _mainContext.WeightAgeCategories.Add(category);
                    roundsIdsDictionary[categoryId] = category.Id;
                    continue;
                }

                if (_weightAgeCategoryComparer.Equals(category, remoteCategory))
                {
                    continue;
                }

                category.DeepCopyTo(remoteCategory);
            }

            await _mainContext.SaveChangesAsync();

            return roundsIdsDictionary;

        }

        private async Task<Dictionary<int, int>> UploadRounds()
        {
            var localRounds = await _context.Rounds.ToListAsync();
            var remoteRounds = await _mainContext.Rounds.ToListAsync();
            Dictionary<int, int> roundsIdsDictionary = localRounds.ToDictionary(c => c.Id, c => c.Id);

            foreach (Round round in localRounds)
            {
                Round remoteRound = remoteRounds.FirstOrDefault(r => r.Id == round.Id);
                if (remoteRound == null)
                {
                    int roundId = round.Id;
                    round.Id = 0;
                    _mainContext.Rounds.Add(round);
                    roundsIdsDictionary[roundId] = round.Id;
                    continue;
                }

                if (_roundComparer.Equals(round, remoteRound))
                {
                    continue;
                }

                round.DeepCopyTo(remoteRound);
            }

            await _mainContext.SaveChangesAsync();

            return roundsIdsDictionary;
        }

        private async Task<Dictionary<int, int>> UploadContestPoints(Dictionary<int, int> contestTypesIdsDictionary, 
            Dictionary<int, int> contestRangesIdsDictionary)
        {
            var localContestTypePoints = await _context.ContestTypePoints.ToListAsync();
            var remoteContestTypePoints = await _mainContext.ContestTypePoints.ToListAsync();
            Dictionary<int, int> contestTypePointsIdsDictionary = localContestTypePoints.ToDictionary(c => c.Id, c => c.Id);

            foreach (ContestTypePoints contestPoints in localContestTypePoints)
            {
                contestPoints.ContestTypeId = contestTypesIdsDictionary[contestPoints.ContestTypeId];
                contestPoints.ContestRangeId = contestRangesIdsDictionary[contestPoints.ContestRangeId];

                ContestTypePoints remoteRange = remoteContestTypePoints.FirstOrDefault(points => points.Id == contestPoints.Id);
                if (remoteRange == null)
                {
                    int pointsId = contestPoints.Id;
                    contestPoints.Id = 0;
                    _mainContext.ContestTypePoints.Add(contestPoints);
                    contestTypePointsIdsDictionary[pointsId] = contestPoints.Id;
                    continue;
                }

                if (_contestTypePointsComparer.Equals(contestPoints, remoteRange))
                {
                    continue;
                }

                contestPoints.DeepCopyTo(remoteRange);
            }

            await _mainContext.SaveChangesAsync();

            return contestTypePointsIdsDictionary;
        }

        private async Task<Dictionary<int, int>> UploadContestRanges()
        {
            var localContestRanges = await _context.ContestRanges.ToListAsync();
            var remoteContestRanges = await _mainContext.ContestRanges.ToListAsync();
            Dictionary<int, int> contestRangesIdsDictionary = localContestRanges.ToDictionary(c => c.Id, c => c.Id);

            foreach (ContestRange contestRange in localContestRanges)
            {
                ContestRange remoteRange = remoteContestRanges.FirstOrDefault(range => range.Id == contestRange.Id);
                if (remoteRange == null)
                {
                    int rangeId = contestRange.Id;
                    contestRange.Id = 0;
                    _mainContext.ContestRanges.Add(contestRange);
                    contestRangesIdsDictionary[rangeId] = contestRange.Id;
                    continue;
                }

                if (_contestRangeComparer.Equals(contestRange, remoteRange))
                {
                    continue;
                }

                contestRange.DeepCopyTo(remoteRange);
            }

            await _mainContext.SaveChangesAsync();

            return contestRangesIdsDictionary;
        }

        private async Task<Dictionary<int, int>> UploadContestTypes()
        {
            var localContestTypes = await _context.ContestTypes.ToListAsync();
            var remoteContestTypes = await _mainContext.ContestTypes.ToListAsync();
            Dictionary<int, int> contestTypesIdsDictionary = localContestTypes.ToDictionary(c => c.Id, c => c.Id);

            foreach (ContestType localType in localContestTypes)
            {
                ContestType remoteType = remoteContestTypes.FirstOrDefault(type => type.Id == localType.Id);
                if (remoteType == null)
                {
                    int typeId = localType.Id;
                    localType.Id = 0;
                    _mainContext.ContestTypes.Add(localType);
                    contestTypesIdsDictionary[typeId] = localType.Id;
                    continue;
                }

                if (_contestTypeComparer.Equals(localType, remoteType))
                {
                    continue;
                }

                localType.DeepCopyTo(remoteType);
            }

            await _mainContext.SaveChangesAsync();

            return contestTypesIdsDictionary;
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
