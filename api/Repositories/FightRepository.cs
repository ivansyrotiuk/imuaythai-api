using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MuaythaiSportManagementSystemApi.Data;
using MuaythaiSportManagementSystemApi.Models;

namespace MuaythaiSportManagementSystemApi.Repositories
{
    public class FightRepository : IFightRepository
    {
         private readonly ApplicationDbContext _context;

        public FightRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<List<Fight>> Find(Expression<Func<Fight, bool>> predicate)
        {
             var fights = _context.Fights.Include(f=> f.BlueAthlete)
            .Include(f=> f.RedAthlete).Where(predicate).AsQueryable();
            return fights.ToListAsync();
        }

        public Task<Fight> Get(int id)
        {
            return _context.Fights
            .Include(f=> f.BlueAthlete)
            .Include(f=> f.RedAthlete)
            .Include(f=>f.Referee)
            .Include(f=>f.Structure).ThenInclude(s => s.WeightAgeCategory)
            .Include(f=>f.Structure).ThenInclude(s => s.Round)
            .Include(f=>f.TimeKeeper)
            .Include(f=> f.FightJudgesMappings).ThenInclude(j => j.Judge)
            .FirstOrDefaultAsync(f=> f.Id == id);
        }

        public Task<List<Fight>> GetAll()
        {
            return _context.Fights.ToListAsync();
        }

        public Task Save(Fight fight)
        {

            return _context.SaveChangesAsync();
        }
    }
}