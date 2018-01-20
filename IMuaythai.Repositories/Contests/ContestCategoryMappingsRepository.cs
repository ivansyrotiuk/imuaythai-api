using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMuaythai.DataAccess.Contexts;
using IMuaythai.DataAccess.Models;
using IMuaythai.Models.Dictionaries;
using IMuaythai.Repositories.Dictionaries;
using Microsoft.EntityFrameworkCore;

namespace IMuaythai.Repositories.Contests
{
    public class ContestCategoryMappingsRepository: IContestCategoryMappingsRepository
    {
        private readonly ApplicationDbContext _context;

        public ContestCategoryMappingsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<List<ContestCategoriesMapping>> GetByContest(int contestId)
        {
            return _context.ContestCategoriesMappings
                .Where(mapping => mapping.ContestId == contestId)
                .Include(mapping => mapping.ContestCategory)
                .ThenInclude(category => category.FightStructure)
                .ThenInclude(structure => structure.WeightAgeCategory)
                .Include(mapping => mapping.ContestCategory)
                .ThenInclude(category => category.FightStructure)
                .ThenInclude(structure => structure.Round)
                .ToListAsync();
        }

        public Task SaveCategoryMappings(int contestId, List<ContestCategoryModel> mappings)
        {
            _context.ContestCategoriesMappings.RemoveRange(_context.ContestCategoriesMappings.Where(m => m.ContestId == contestId));

            var contestCategoryMappings = mappings.Select(m => new ContestCategoriesMapping
            {
                ContestCategoryId = m.Id,
                ContestId = contestId
            }).ToList();

            _context.ContestCategoriesMappings.AddRange(contestCategoryMappings);
            return _context.SaveChangesAsync();
        }
    }
}
