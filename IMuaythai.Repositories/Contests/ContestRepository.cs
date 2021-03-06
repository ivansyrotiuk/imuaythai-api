﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMuaythai.DataAccess.Contexts;
using IMuaythai.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace IMuaythai.Repositories.Contests
{
    public class ContestRepository : IContestRepository
    {
        private readonly ApplicationDbContext _context;

        public ContestRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<List<Contest>> Find(Func<Contest, bool> predicate)
        {
            var contests = _context.Contests.Where(predicate).Where(contest => !contest.Deleted).AsQueryable();
            return contests.ToListAsync();
        }

        public Task<Contest> Get(int id)
        {
            return _context.Contests
                .Where(contest => !contest.Deleted).Include(c => c.Country).Include(c => c.Institution)
                .Include(c => c.ContestCategoriesMappings).ThenInclude(c => c.ContestCategory).Include(c => c.Rings)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public Task<List<Contest>> GetAll()
        {
            return _context.Contests.Include(c => c.Country).Include(c => c.Institution)
                .Where(contest => !contest.Deleted).ToListAsync();
        }

        public Task Remove(int id)
        {
            var contest = _context.Contests.FirstOrDefault(i => i.Id == id);
            if (contest == null)
            {
                throw new Exception($"Contest with id={id} is not found");
            }

            contest.Deleted = true;
            return _context.SaveChangesAsync();
        }

        public Task Save(Contest contest)
        {
            if (contest.Id == 0)
            {
                _context.Contests.Add(contest);
            }
            else
            {
                _context.Entry(contest).State = EntityState.Modified;
            }

            return _context.SaveChangesAsync();
        }



    }
}
