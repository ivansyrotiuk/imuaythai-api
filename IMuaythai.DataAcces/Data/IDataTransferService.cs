using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using IMuaythai.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using MoreLinq;

namespace IMuaythai.DataAccess.Data
{
    public interface IDataTransferService
    {
        void DownloadDataFromMainDatabase();
        Task UploadDataToMainDatabase(int contestId);
    }

    public class DataTransferService : IDataTransferService
    {
        private readonly ApplicationDbContext _context;
        private readonly IEqualityComparer<ContestCategoriesMapping> _contestCategoryMappingComparer;
        private readonly IEqualityComparer<ContestCategory> _contestCategoriesComparer;
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
        private readonly IEqualityComparer<ContestRing> _contestRingComparer;

        public DataTransferService(ApplicationDbContext context, 
            IEqualityComparer<ContestCategoriesMapping> contestCategoryMappingComparer,
            IEqualityComparer<ContestCategory> contestCategoriesComparer,
            IEqualityComparer<Contest> contestComparer,
            IEqualityComparer<ContestRange> contestRangeComparer,
            IEqualityComparer<ContestRequest> contestRequestComparer,
            IEqualityComparer<ContestType> contestTypeComparer,
            IEqualityComparer<ContestTypePoints> contestTypePointsComparer,
            IEqualityComparer<Fight> fightComparer,
            IEqualityComparer<FightJudgesMapping> fightJudgesMappingComparer,
            IEqualityComparer<FightStructure> fightStructureComparer,
            IEqualityComparer<Round> roundComparer,
            IEqualityComparer<WeightAgeCategory> weightAgeCategoryComparer,
            IEqualityComparer<ContestRing> contestRingComparer)
        {
            _context = context;
            //mainContext = mainContext;
            _contestCategoryMappingComparer = contestCategoryMappingComparer;
            _contestCategoriesComparer = contestCategoriesComparer;
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
            _contestRingComparer = contestRingComparer;
        }
        
        public void DownloadDataFromMainDatabase()
        {
            if (_context.Contests.Any())
            {
                return;
            }

            using (var mainContext = new ApplicationDbContextFactory().CreateMainDbContext())
            {
                var countries = mainContext.Countries.ToList();
                var institutions = mainContext.Institutions.ToList();
                var khanLevels = mainContext.KhanLevels.ToList();
                var suspensionTypes = mainContext.SuspensionTypes.ToList();
                var suspensions = mainContext.Suspensions.ToList();
                var users = mainContext.Users.ToList().DistinctBy(u => u.Id).ToList();
                var contestTypes = mainContext.ContestTypes.ToList();
                var contestRanges = mainContext.ContestRanges.ToList();
                var contests = mainContext.Contests.ToList();

                var contestTypePoints = mainContext.ContestTypePoints.ToList();
                var contestCategory = mainContext.ContestCategories.ToList();
                var contestCategoryMappings = mainContext.ContestCategoriesMappings.ToList();
                var rings = mainContext.ContestRings.ToList();
                var rounds = mainContext.Rounds.ToList();
                var weightAgeCategories = mainContext.WeightAgeCategories.ToList();
                var fightStructures = mainContext.FightStructures.ToList();
                var contestRequests = mainContext.ContestRequests.ToList();
                var fights = mainContext.Fights.ToList();
                var fightJudgesMappings = mainContext.FightJudgesMappings.ToList();
                var roles = mainContext.Roles.ToList();
                var userRoles = mainContext.UserRoles.ToList();


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
                contestCategoryMappings.ForEach(NullReferencedPropeties);
                rings.ForEach(NullReferencedPropeties);

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
                        _context.Database.ExecuteSqlCommand("DELETE FROM [ContestCategoriesMappings]");
                        _context.Database.ExecuteSqlCommand("DELETE FROM [ContestRings]");

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

                        _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [ContestCategoriesMappings] ON");
                        _context.ContestCategoriesMappings.AddRange(contestCategoryMappings);
                        _context.SaveChanges();
                        _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [ContestCategoriesMappings] OFF");

                        _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [ContestRings] ON");
                        _context.ContestRings.AddRange(rings);
                        _context.SaveChanges();
                        _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [ContestRings] OFF");

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
                    catch
                    {
                        dbContextTransaction.Rollback();
                    }
                }
            }
        }

        public async Task UploadDataToMainDatabase(int contestId)
        {
            Dictionary<int, int> contestCategoriesIdsDictionary = new Dictionary<int, int>();
            Dictionary<string, string> usersIdsDictionary = new Dictionary<string, string>();
            Dictionary<int, int> fightsIdsDictionary = new Dictionary<int, int>();

            using (var mainContext = new ApplicationDbContextFactory().CreateMainDbContext())
            {
                using (var dbContextTransaction = mainContext.Database.BeginTransaction())
                {
                    try
                    {
                        Dictionary<int, int> contestTypesIdsDictionary = await UploadContestTypes(mainContext);
                        Dictionary<int, int> contestRangesIdsDictionary = await UploadContestRanges(mainContext);
                        Dictionary<int, int> contestTypePointsDictionary = await UploadContestPoints(mainContext, contestTypesIdsDictionary, contestRangesIdsDictionary);
                        Dictionary<int, int> roundsIdsDictionary = await UploadRounds(mainContext);
                        Dictionary<int, int> weightAgeCategoriesIdsDictionary = await UploadWeightAgeCategories(mainContext);
                        Dictionary<int, int> fightStructuresIdsDictionary = await UploadFightCategories(mainContext, roundsIdsDictionary, weightAgeCategoriesIdsDictionary);
                        contestCategoriesIdsDictionary =
                            await UploadContestCategories(mainContext, contestTypePointsDictionary, fightStructuresIdsDictionary);
                        Dictionary<int, int> contestIdsDictionary = await UploadContests(mainContext, contestTypesIdsDictionary, contestRangesIdsDictionary);
                        Dictionary<int, int> ringsIdsDictionary = await UploadRings(mainContext, contestIdsDictionary);
                        Dictionary<int, int> contestCategoryMappingsIdsDictionary = await UploadContestCategoryMappings(mainContext, contestIdsDictionary, contestCategoriesIdsDictionary);
                        usersIdsDictionary = await UploadUsers(mainContext);
                        fightsIdsDictionary = await UploadFights(mainContext, contestId, usersIdsDictionary);
                        Dictionary<int, int> judgeMappingsDictionary = await UploadJudgeMappings(mainContext, contestId, fightsIdsDictionary, usersIdsDictionary);
                        //Dictionary<int, int> requestsIdsDictionary = await UploadContestRequests(contestId,
                        //    contestCategoriesIdsDictionary, usersIdsDictionary);



                        dbContextTransaction.Commit();
                    }
                    catch
                    {
                        dbContextTransaction.Rollback();
                    }
                }
            }

            using (var mainContext = new ApplicationDbContextFactory().CreateMainDbContext())
            {
                using (var dbContextTransaction = mainContext.Database.BeginTransaction())
                {
                    try
                    {

                        await UploadContestRequests(mainContext, contestId,
                            contestCategoriesIdsDictionary, usersIdsDictionary);
                        await UploadFightPoints(mainContext, fightsIdsDictionary, usersIdsDictionary);
                        dbContextTransaction.Commit();
                    }
                    catch
                    {
                        dbContextTransaction.Rollback();
                    }
                }
            }
        }

        private async Task UploadFightPoints(ApplicationDbContext mainContext, Dictionary<int, int> fightsIdsDictionary, Dictionary<string, string> usersIdsDictionary)
        {
            var localFightsIds = fightsIdsDictionary.Select(fightId => fightId.Key).ToList();
            var remoteFightsIds = fightsIdsDictionary.Select(fightId => fightId.Value).ToList();

            var localPoints = _context.FightPoints.Where(point => localFightsIds.Contains(point.FightId)).ToList();
            mainContext.FightPoints.RemoveRange(mainContext.FightPoints.Where(point => remoteFightsIds.Contains(point.FightId)));
            localPoints.ForEach(NullReferencedPropeties);
            localPoints.ForEach(point =>
            {
                point.FightId = fightsIdsDictionary[point.FightId];
                point.FighterId = usersIdsDictionary[point.FighterId];
                point.JudgeId = usersIdsDictionary[point.JudgeId];
            });

            mainContext.FightPoints.AddRange(localPoints);
            await mainContext.SaveChangesAsync();
        }

        private async Task<Dictionary<int, int>> UploadContestRequests(ApplicationDbContext mainContext, int contestId,  Dictionary<int, int> contestCategoriesIdsDictionary, Dictionary<string, string> usersIdsDictionary)
        {
            var localRequests = await _context.ContestRequests.Where(request => request.ContestId == contestId).ToListAsync();
            var remoteRequests = await mainContext.ContestRequests.Where(request => request.ContestId == contestId).ToListAsync();
            Dictionary<int, int> requestsIdsDictionary = localRequests.ToDictionary(c => c.Id, c => c.Id);
            localRequests.ForEach(NullReferencedPropeties);
            remoteRequests.ForEach(NullReferencedPropeties);

            foreach (var request in localRequests)
            {
                request.UserId = usersIdsDictionary[request.UserId];
                request.ContestCategoryId = request.ContestCategoryId.HasValue ? contestCategoriesIdsDictionary[request.ContestCategoryId.Value] : default(int?);
           
                 var removeRequest = remoteRequests.FirstOrDefault(r => r.Id == request.Id);
                if (removeRequest == null)
                {
                    int requestId = request.Id;
                    request.Id = 0;
                    mainContext.ContestRequests.Add(request);
                    await mainContext.SaveChangesAsync();

                    requestsIdsDictionary[requestId] = request.Id;
                    continue;
                }

                if (_contestRequestComparer.Equals(request, removeRequest))
                {
                    continue;
                }

                request.DeepCopyTo(removeRequest);
            }

            await mainContext.SaveChangesAsync();

            return requestsIdsDictionary;
        }

        private async Task<Dictionary<int, int>> UploadJudgeMappings(ApplicationDbContext mainContext, int contestId, Dictionary<int, int> fightsIdsDictionary, Dictionary<string, string> usersIdsDictionary)
        {
            mainContext.SaveChanges();
            mainContext.FightJudgesMappings.RemoveRange(mainContext.FightJudgesMappings.Where(mapping => mapping.Fight.ContestId == contestId));
            mainContext.SaveChanges();
            var localMappings = await _context.FightJudgesMappings.ToListAsync();

            foreach (var mapping in localMappings)
            {

                //mainContext.FightJudgesMappings.Add(new FightJudgesMapping
                //{
                //    FightId = fightsIdsDictionary[mapping.FightId],
                //    JudgeId = usersIdsDictionary[mapping.JudgeId],
                //    Main = mapping.Main,
                //});

              


                mainContext.Database.ExecuteSqlCommand(
                    $"INSERT INTO FightJudgesMappings(FightId, JudgeId, Main) Values(@FightId, @JudgeId, @Main)",
                    new SqlParameter("@FightId", fightsIdsDictionary[mapping.FightId]),
                    new SqlParameter("@JudgeId", usersIdsDictionary[mapping.JudgeId]),
                    new SqlParameter("@Main", mapping.Main)
                );

            }


            return new Dictionary<int, int>();
        }

        private async Task<Dictionary<int, int>> UploadFights(ApplicationDbContext mainContext, int contestId, Dictionary<string, string> usersIdsDictionary)
        {
            var localFights = await _context.Fights.Where(fight => fight.ContestId == contestId).OrderBy(fight => fight.Id).ToListAsync();
            Dictionary<int, int> fightsIdsDictionary = localFights.ToDictionary(fight => fight.Id, fight => fight.Id);

            localFights.ForEach(NullReferencedPropeties);

            mainContext.Fights.RemoveRange(mainContext.Fights.Where(fight => fight.ContestId == contestId));
            await mainContext.SaveChangesAsync();
          

            foreach (var fight in localFights)
            {
                fight.NextFightId = fight.NextFightId.HasValue ? fightsIdsDictionary[fight.NextFightId.Value] : default(int?);
                fight.BlueAthleteId = !string.IsNullOrEmpty(fight.BlueAthleteId) ? usersIdsDictionary[fight.BlueAthleteId] : null;
                fight.RedAthleteId = !string.IsNullOrEmpty(fight.RedAthleteId) ? usersIdsDictionary[fight.RedAthleteId] : null;
                fight.RefereeId = !string.IsNullOrEmpty(fight.RefereeId) ? usersIdsDictionary[fight.RefereeId] : null;
                fight.TimeKeeperId = !string.IsNullOrEmpty(fight.TimeKeeperId) ? usersIdsDictionary[fight.TimeKeeperId] : null;
                fight.FightJudgesMappings = null;
                int fightId = fight.Id;
                fight.Id = 0;
                mainContext.Fights.Add(fight);
                await mainContext.SaveChangesAsync();
                fightsIdsDictionary[fightId] = fight.Id;
            }

            //mainContext.Fights.AddRange(localFights);
            //await mainContext.SaveChangesAsync();

            return fightsIdsDictionary;
        }

        private async Task<Dictionary<string, string>> UploadUsers(ApplicationDbContext mainContext)
        {
            var localUsers = await _context.Users.ToListAsync();
            var remoteUsers = await mainContext.Users.ToListAsync();
            localUsers.ForEach(NullReferencedPropeties);
           

            Dictionary<string, string> usersIdsDictionary = localUsers.ToDictionary(c => c.Id, c => c.Id);

            foreach (var user in localUsers)
            {
                var remoteMapping = remoteUsers.FirstOrDefault(r => r.Id == user.Id);
                if (remoteMapping == null)
                { 
                    user.FightJudgesMappings = null;
                    mainContext.Users.Add(user);
                }
            }
       
            await mainContext.SaveChangesAsync();
           
            return usersIdsDictionary;
        }

        private async Task<Dictionary<int, int>> UploadContestCategoryMappings(ApplicationDbContext mainContext, Dictionary<int, int> contestIdsDictionary, Dictionary<int, int> contestCategoriesIdsDictionary)
        {
            var localMappings = await _context.ContestCategoriesMappings.ToListAsync();
            var remoteMappings = await mainContext.ContestCategoriesMappings.ToListAsync();
            Dictionary<int, int> mappingsIdsDictionary = localMappings.ToDictionary(c => c.Id, c => c.Id);
            localMappings.ForEach(NullReferencedPropeties);
            remoteMappings.ForEach(NullReferencedPropeties);

            foreach (var mapping in localMappings)
            {
                mapping.ContestId = contestIdsDictionary[mapping.ContestId];
                mapping.ContestCategoryId = contestCategoriesIdsDictionary[mapping.ContestCategoryId];
                var remoteMapping = remoteMappings.FirstOrDefault(r => r.Id == mapping.Id);
                if (remoteMapping == null)
                {
                    int mappingId = mapping.Id;
                    mapping.Id = 0;
                    mainContext.ContestCategoriesMappings.Add(mapping);
                    await mainContext.SaveChangesAsync();

                    mappingsIdsDictionary[mappingId] = mapping.Id;
                    continue;
                }

                if (_contestCategoryMappingComparer.Equals(mapping, remoteMapping))
                {
                    continue;
                }

                mapping.DeepCopyTo(remoteMapping);
            }

            await mainContext.SaveChangesAsync();

            return mappingsIdsDictionary;
        }

        private async Task<Dictionary<int, int>> UploadRings(ApplicationDbContext mainContext, Dictionary<int, int> contestIdsDictionary)
        {
            var localRings = await _context.ContestRings.ToListAsync();
            var remoteRings = await mainContext.ContestRings.ToListAsync();
            Dictionary<int, int> ringsIdsDictionary = localRings.ToDictionary(c => c.Id, c => c.Id);
            localRings.ForEach(NullReferencedPropeties);
            remoteRings.ForEach(NullReferencedPropeties);

            foreach (ContestRing ring in localRings)
            {
                ring.ContestId = contestIdsDictionary[ring.ContestId];

                var remoteRing = remoteRings.FirstOrDefault(r => r.Id == ring.Id);
                if (remoteRing == null)
                {
                    int ringId = ring.Id;
                    ring.Id = 0;
                    mainContext.ContestRings.Add(ring);

                    await mainContext.SaveChangesAsync();

                    ringsIdsDictionary[ringId] = ring.Id;
                    continue;
                }

                if (_contestRingComparer.Equals(ring, remoteRing))
                {
                    continue;
                }

                ring.DeepCopyTo(remoteRing);
            }

            await mainContext.SaveChangesAsync();

            return ringsIdsDictionary;
        }

        private async Task<Dictionary<int, int>> UploadContests(ApplicationDbContext mainContext, Dictionary<int, int> contestTypesIdsDictionary, Dictionary<int, int> contestRangesIdsDictionary)
        {
            var localContests = await _context.Contests.ToListAsync();
            localContests.ForEach(NullReferencedPropeties);
            var remoteContests = await mainContext.Contests.ToListAsync();
            remoteContests.ForEach(NullReferencedPropeties);

            Dictionary<int, int> contestsIdsDictionary = localContests.ToDictionary(c => c.Id, c => c.Id);

            foreach (Contest contest in localContests)
            {
                contest.ContestTypeId = contest.ContestTypeId.HasValue ? contestTypesIdsDictionary[contest.ContestTypeId.Value] : default(int?);
                contest.ContestRangeId = contest.ContestRangeId.HasValue ? contestRangesIdsDictionary[contest.ContestRangeId.Value] : default(int?);

                var remoteContest = remoteContests.FirstOrDefault(r => r.Id == contest.Id);
                if (remoteContest == null)
                {
                    int contestId = contest.Id;
                    contest.Id = 0;
                    mainContext.Contests.Add(contest);
                    await mainContext.SaveChangesAsync();

                    contestsIdsDictionary[contestId] = contest.Id;
                    continue;
                }

                if (_contestComparer.Equals(contest, remoteContest))
                {
                    continue;
                }

                contest.DeepCopyTo(remoteContest);
            }

            await mainContext.SaveChangesAsync();

            return contestsIdsDictionary;
        }

        private async Task<Dictionary<int, int>> UploadContestCategories(ApplicationDbContext mainContext, Dictionary<int, int> contestTypePointsDictionary, Dictionary<int, int> fightStructuresIdsDictionary)
        {
            var localCategories = await _context.ContestCategories.ToListAsync();
            var remoteCategories = await mainContext.ContestCategories.ToListAsync();
            Dictionary<int, int> categorieIdsDictionary = localCategories.ToDictionary(c => c.Id, c => c.Id);
            localCategories.ForEach(NullReferencedPropeties);
            //remoteCategories.ForEach(NullReferencedPropeties);

            var needToSave = false;
            foreach (ContestCategory category in localCategories)
            {
                category.ContestTypePointsId = contestTypePointsDictionary[category.ContestTypePointsId];
                category.FightStructureId = fightStructuresIdsDictionary[category.FightStructureId];

                var remoteCategory = remoteCategories.FirstOrDefault(r => r.Id == category.Id);
                if (remoteCategory == null)
                {
                    int categoryId = category.Id;
                    category.Id = 0;
                    mainContext.ContestCategories.Add(category);
                    await mainContext.SaveChangesAsync();

                    categorieIdsDictionary[categoryId] = category.Id;
                    continue;
                }

                if (_contestCategoriesComparer.Equals(category, remoteCategory))
                {
                    continue;
                }

                needToSave = true;
                category.DeepCopyTo(remoteCategory);
            }

            if (needToSave)
            {
                await mainContext.SaveChangesAsync();
            }

            return categorieIdsDictionary;

        }

        private async Task<Dictionary<int, int>> UploadFightCategories(ApplicationDbContext mainContext, Dictionary<int, int> roundsIdsDictionary, Dictionary<int, int> weightAgeCategoriesIdsDictionary)
        {
            var localFightStructures = await _context.FightStructures.ToListAsync();
            var remoteFightStructures = await mainContext.FightStructures.ToListAsync();
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
                    mainContext.FightStructures.Add(fightStructure);
                    await mainContext.SaveChangesAsync();

                    fightStructuresIdsDictionary[fightStructureId] = fightStructure.Id;
                    continue;
                }

                if (_fightStructureComparer.Equals(fightStructure, remoteFightStructure))
                {
                    continue;
                }

                fightStructure.DeepCopyTo(remoteFightStructure);
            }
            
            await mainContext.SaveChangesAsync();
        

            return fightStructuresIdsDictionary;
        }

        private async Task<Dictionary<int, int>> UploadWeightAgeCategories(ApplicationDbContext mainContext)
        {
            var localCategories = await _context.WeightAgeCategories.ToListAsync();
            var remoteCategories = await mainContext.WeightAgeCategories.ToListAsync();
            Dictionary<int, int> roundsIdsDictionary = localCategories.ToDictionary(c => c.Id, c => c.Id);

            foreach (WeightAgeCategory category in localCategories)
            {
                WeightAgeCategory remoteCategory = remoteCategories.FirstOrDefault(r => r.Id == category.Id);
                if (remoteCategory == null)
                {
                    int categoryId = category.Id;
                    category.Id = 0;
                    mainContext.WeightAgeCategories.Add(category);
                    await mainContext.SaveChangesAsync();

                    roundsIdsDictionary[categoryId] = category.Id;
                    continue;
                }

                if (_weightAgeCategoryComparer.Equals(category, remoteCategory))
                {
                    continue;
                }

                category.DeepCopyTo(remoteCategory);
            }

            await mainContext.SaveChangesAsync();

            return roundsIdsDictionary;

        }

        private async Task<Dictionary<int, int>> UploadRounds(ApplicationDbContext mainContext)
        {
            var localRounds = await _context.Rounds.ToListAsync();
            var remoteRounds = await mainContext.Rounds.ToListAsync();
            Dictionary<int, int> roundsIdsDictionary = localRounds.ToDictionary(c => c.Id, c => c.Id);

            foreach (Round round in localRounds)
            {
                Round remoteRound = remoteRounds.FirstOrDefault(r => r.Id == round.Id);
                if (remoteRound == null)
                {
                    int roundId = round.Id;
                    round.Id = 0;
                    mainContext.Rounds.Add(round);
                    await mainContext.SaveChangesAsync();

                    roundsIdsDictionary[roundId] = round.Id;
                    continue;
                }

                if (_roundComparer.Equals(round, remoteRound))
                {
                    continue;
                }

                round.DeepCopyTo(remoteRound);
            }

            await mainContext.SaveChangesAsync();

            return roundsIdsDictionary;
        }

        private async Task<Dictionary<int, int>> UploadContestPoints(ApplicationDbContext mainContext, Dictionary<int, int> contestTypesIdsDictionary, 
            Dictionary<int, int> contestRangesIdsDictionary)
        {
            var localContestTypePoints = await _context.ContestTypePoints.ToListAsync();
            var remoteContestTypePoints = await mainContext.ContestTypePoints.ToListAsync();
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
                    mainContext.ContestTypePoints.Add(contestPoints);
                    await mainContext.SaveChangesAsync();

                    contestTypePointsIdsDictionary[pointsId] = contestPoints.Id;
                    continue;
                }

                if (_contestTypePointsComparer.Equals(contestPoints, remoteRange))
                {
                    continue;
                }

                contestPoints.DeepCopyTo(remoteRange);
            }

            await mainContext.SaveChangesAsync();

            return contestTypePointsIdsDictionary;
        }

        private async Task<Dictionary<int, int>> UploadContestRanges(ApplicationDbContext mainContext)
        {
            var localContestRanges = await _context.ContestRanges.ToListAsync();
            var remoteContestRanges = await mainContext.ContestRanges.ToListAsync();
            Dictionary<int, int> contestRangesIdsDictionary = localContestRanges.ToDictionary(c => c.Id, c => c.Id);

            foreach (ContestRange contestRange in localContestRanges)
            {
                ContestRange remoteRange = remoteContestRanges.FirstOrDefault(range => range.Id == contestRange.Id);
                if (remoteRange == null)
                {
                    int rangeId = contestRange.Id;
                    contestRange.Id = 0;
                    mainContext.ContestRanges.Add(contestRange);
                    await mainContext.SaveChangesAsync();

                    contestRangesIdsDictionary[rangeId] = contestRange.Id;
                    continue;
                }

                if (_contestRangeComparer.Equals(contestRange, remoteRange))
                {
                    continue;
                }

                contestRange.DeepCopyTo(remoteRange);
            }

            await mainContext.SaveChangesAsync();

            return contestRangesIdsDictionary;
        }

        private async Task<Dictionary<int, int>> UploadContestTypes(ApplicationDbContext mainContext)
        {
            var localContestTypes = await _context.ContestTypes.ToListAsync();
            var remoteContestTypes = await mainContext.ContestTypes.ToListAsync();
            Dictionary<int, int> contestTypesIdsDictionary = localContestTypes.ToDictionary(c => c.Id, c => c.Id);

            foreach (ContestType localType in localContestTypes)
            {
                ContestType remoteType = remoteContestTypes.FirstOrDefault(type => type.Id == localType.Id);
                if (remoteType == null)
                {
                    int typeId = localType.Id;
                    localType.Id = 0;
                    mainContext.ContestTypes.Add(localType);
                    await mainContext.SaveChangesAsync();

                    contestTypesIdsDictionary[typeId] = localType.Id;
                    continue;
                }

                if (_contestTypeComparer.Equals(localType, remoteType))
                {
                    continue;
                }

                localType.DeepCopyTo(remoteType);
            }

            await mainContext.SaveChangesAsync();

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
