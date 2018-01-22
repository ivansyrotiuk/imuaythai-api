﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMuaythai.DataAccess.Contexts;
using IMuaythai.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace IMuaythai.Repositories.Dictionaries
{
    public class ContestTypesRepository : IContestTypesRepository
    {
        private readonly ApplicationDbContext _context;

        public ContestTypesRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task<ContestType> Get(int id)
        {
            return _context.ContestTypes.FirstOrDefaultAsync(c => c.Id == id);
        }

        public Task<List<ContestType>> GetAll()
        {
            return _context.ContestTypes.ToListAsync(); 
        }

        public Task<List<ContestType>> Find(Func<ContestType, bool> predicate)
        {
            return _context.ContestTypes.Where(predicate).AsQueryable().ToListAsync();
        }

        public Task Save(ContestType contestType)
        {
            if (contestType.Id == 0)
            {
                _context.ContestTypes.Add(contestType);
            }
            else
            {
                _context.Entry(contestType).State = EntityState.Modified;
            }

            return _context.SaveChangesAsync();
        }

        public Task Remove(int id)
        {
            var contestType = _context.ContestTypes.FirstOrDefault(i => i.Id == id);
            _context.ContestTypes.Remove(contestType);
            return _context.SaveChangesAsync();
        }
    }
}
