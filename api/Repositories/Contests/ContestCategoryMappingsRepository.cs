using MuaythaiSportManagementSystemApi.Data;
using MuaythaiSportManagementSystemApi.Dictionaries;
using MuaythaiSportManagementSystemApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuaythaiSportManagementSystemApi.Repositories
{
    public class ContestCategoryMappingsRepository: IContestCategoryMappingsRepository
    {
        private readonly ApplicationDbContext _context;

        public ContestCategoryMappingsRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task SaveCategoryMappings(int contestId, List<ContestCategoryDto> mappings)
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
