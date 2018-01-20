using System;
using System.Collections.Generic;
using System.Linq;
using IMuaythai.DataAccess.Contexts;
using IMuaythai.DataAccess.Models;
using IMuaythai.DataAccess.Services.Downloaders;
using IMuaythai.DataAccess.Services.Uploaders;
using Microsoft.EntityFrameworkCore;

namespace IMuaythai.DataAccess.Services
{
    public class DataTransferService : IDataTransferService
    {
        private readonly IContextFactoryFacade _contextFactory;
        private readonly IDataUploader _contestTypedUploader;
        private readonly IDataUploader _contestRangesUploader;
        private readonly IContestTypePointsUploader _contestTypePointsUploader;
        private readonly IDataUploader _roundsUploader;
        private readonly IDataUploader _weightAgeCategoryUploader;
        private readonly IFightStructureUploader _fightStructureUploader;
        private readonly IContestCategoriesUploader _contestCategoriesUploader;
        private readonly IContestsUploader _contestsUploader;
        private readonly IContestRingsUploader _contestRingsUploader;
        private readonly IContestCategoryMappingsUploader _contestCategoryMappingsUploader;
        private readonly IUsersUploader _usersUploader;
        private readonly IFightsUploader _fightsUploader;
        private readonly IFightJudgeMappingsUploader _fightJudgeMappingsUploader;
        private readonly IFightPointsUploader _fightPointsUploader;
        private readonly IContestRequestsUploader _contestRequestsUploader;

        public DataTransferService(IContextFactoryFacade contextFactory, 
            IEqualityComparer<ContestCategoriesMapping> contestCategoryMappingComparer,
            IEqualityComparer<ContestCategory> contestCategoriesComparer,
            IEqualityComparer<Contest> contestComparer,
            IEqualityComparer<ContestRange> contestRangeComparer,
            IEqualityComparer<ContestRequest> contestRequestComparer,
            IEqualityComparer<ContestType> contestTypeComparer,
            IEqualityComparer<ContestTypePoints> contestTypePointsComparer,
            IEqualityComparer<FightStructure> fightStructureComparer,
            IEqualityComparer<Round> roundComparer,
            IEqualityComparer<WeightAgeCategory> weightAgeCategoryComparer,
            IEqualityComparer<ContestRing> contestRingComparer)
        {
            _contextFactory = contextFactory;        
            _contestTypedUploader = new ContestTypedUploader(contestTypeComparer);
            _contestRangesUploader = new ContestRangesUploader(contestRangeComparer);
            _contestTypePointsUploader = new ContestTypePointsUploader(contestTypePointsComparer);
            _roundsUploader = new RoundsUploader(roundComparer);
            _weightAgeCategoryUploader = new WeightAgeCategoryUploader(weightAgeCategoryComparer);
            _fightStructureUploader = new FightStructureUploader(fightStructureComparer);
            _contestCategoriesUploader = new ContestCategoriesUploader(contestCategoriesComparer);
            _contestsUploader = new ContestsUploader(contestComparer);
            _contestRingsUploader = new ContestRingsUploader(contestRingComparer);
            _contestCategoryMappingsUploader = new ContestCategoryMappingsUploader(contestCategoryMappingComparer);
            _usersUploader = new UsersUploader();
            _fightsUploader = new FightsUploader();
            _fightJudgeMappingsUploader = new FightJudgeMappingsUploader();
            _fightPointsUploader = new FightPointsUploader();
            _contestRequestsUploader = new ContestRequestsUploader(contestRequestComparer);
        }
        
        public void DownloadDataFromMainDatabase()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                Console.WriteLine($"Drop local database");
                context.Database.EnsureDeleted();

                Console.WriteLine($"Migrating ...");
                context.Database.Migrate();

                if (context.Contests.Any())
                {
                    return;
                }

                using (var mainContext = _contextFactory.CreateMainDbContext())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            var dataDownloaders = new List<DataDownloader>
                            {
                                new CountriesDownloader(mainContext, context),
                                new InstitutionsDownloader(mainContext, context),
                                new KhanLevelsDownloader(mainContext, context),
                                new SuspensionTypesDownloader(mainContext, context),
                                new SuspensionsDownloader(mainContext, context),
                                new RolesDownloader(mainContext, context),
                                new UsersDownloader(mainContext, context),
                                new UserRolesDownloader(mainContext, context),
                                new ContestTypesDownloader(mainContext, context),
                                new ContestRangesDownloader(mainContext, context),
                                new ContestsDownloader(mainContext, context),
                                new ContestTypePointsDownloader(mainContext, context),
                                new RoundsDownloader(mainContext, context),
                                new WeightAgeCategoriesDownloader(mainContext, context),
                                new FightStructuresDownloader(mainContext, context),
                                new ContestRingsDownloader(mainContext, context),
                                new ContestCategoriesDownloader(mainContext, context),
                                new ContestCategoriesMappingsDownloader(mainContext, context),
                                new ContestRequestsDownloader(mainContext, context),
                                new FightsDownloader(mainContext, context),
                                new FightJudgesMappingsDownloader(mainContext, context)
                            };

                            foreach (var downloader in dataDownloaders)
                            {
                                Console.WriteLine($"Executing {downloader.GetType().FullName} ...");
                                downloader.Download();
                            }

                            transaction.Commit();
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex);
                            transaction.Rollback();
                        }
                    }
                }
            }
        }

        public void UploadDataToMainDatabase(int contestId)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var contestCategoriesIdsDictionary = new Dictionary<int, int>();
                var usersIdsDictionary = new Dictionary<string, string>();
                var fightsIdsDictionary = new Dictionary<int, int>();

                using (var mainContext = _contextFactory.CreateMainDbContext())
                {
                    using (var dbContextTransaction = mainContext.Database.BeginTransaction())
                    {
                        try
                        {
                            usersIdsDictionary = _usersUploader.Upload(context, mainContext);

                            var roundsIdsDictionary = _roundsUploader.Upload(context, mainContext);
                            var weightAgeCategoriesIdsDictionary = _weightAgeCategoryUploader.Upload(context, mainContext);
                            var contestTypesIdsDictionary = _contestTypedUploader.Upload(context, mainContext);
                            var contestRangesIdsDictionary = _contestRangesUploader.Upload(context, mainContext);
                            var contestTypePointsDictionary = _contestTypePointsUploader.Upload(context, mainContext,
                                contestTypesIdsDictionary, contestRangesIdsDictionary);
                            var fightStructuresIdsDictionary = _fightStructureUploader.Upload(context, mainContext,
                                roundsIdsDictionary, weightAgeCategoriesIdsDictionary);

                            contestCategoriesIdsDictionary = _contestCategoriesUploader.Upload(context, mainContext, contestTypePointsDictionary,
                                    fightStructuresIdsDictionary);

                            var contestIdsDictionary = _contestsUploader.Upload(context, mainContext,
                                contestTypesIdsDictionary, contestRangesIdsDictionary);

                            fightsIdsDictionary = _fightsUploader.Upload(context, mainContext, contestId, usersIdsDictionary);
                            _fightJudgeMappingsUploader.Upload(context, mainContext, contestId, fightsIdsDictionary, usersIdsDictionary);
                            
                            _contestRingsUploader.Upload(context, mainContext, contestIdsDictionary);
                            _contestCategoryMappingsUploader.Upload(context, mainContext, contestIdsDictionary, contestCategoriesIdsDictionary);

                            dbContextTransaction.Commit();
                        }
                        catch
                        {
                            dbContextTransaction.Rollback();
                        }
                    }
                }


                using (var mainContext = _contextFactory.CreateMainDbContext())
                {
                    using (var dbContextTransaction = mainContext.Database.BeginTransaction())
                    {
                        try
                        {

                            _contestRequestsUploader.Upload(context, mainContext, contestId,
                                contestCategoriesIdsDictionary, usersIdsDictionary);
                            _fightPointsUploader.Upload(context, mainContext, fightsIdsDictionary, usersIdsDictionary);
                            dbContextTransaction.Commit();
                        }
                        catch
                        {
                            dbContextTransaction.Rollback();
                        }
                    }
                }
            }
        }
    }
}