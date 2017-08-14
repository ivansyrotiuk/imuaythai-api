using System;
using System.Collections.Generic;
using System.Linq;
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

        public Task<List<Fight>> Find(Func<Fight, bool> predicate)
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
            .Include(f=>f.Structure)
            .Include(f=>f.TimeKeeper)
            .Include(f=> f.FightJudgesMappings)
            .FirstOrDefaultAsync(f=> f.Id == id);
        }

        public Task<List<Fight>> GetAll()
        {
            return _context.Fights.ToListAsync();
        }

        public Task Save(Fight fight)
        {
            if (fight.Id == 0)
            {
                _context.Fights.Add(fight);
            }

            return _context.SaveChangesAsync();
        }
    }
}