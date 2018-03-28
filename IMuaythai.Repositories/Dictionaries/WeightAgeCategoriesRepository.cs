using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMuaythai.DataAccess.Contexts;
using IMuaythai.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace IMuaythai.Repositories.Dictionaries
{
    public class WeightAgeCategoriesRepository : IWeightAgeCategoriesRepository
    {
        private readonly ApplicationDbContext _context;

        public WeightAgeCategoriesRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task<WeightAgeCategory> Get(int id)
        {
            return _context.WeightAgeCategories.Where(category => !category.Deleted).FirstOrDefaultAsync(c => c.Id == id);
        }

        public Task<List<WeightAgeCategory>> GetAll()
        {
            return _context.WeightAgeCategories.Where(category => !category.Deleted).ToListAsync();
        }

        public Task<List<WeightAgeCategory>> Find(Func<WeightAgeCategory, bool> predicate)
        {
            return _context.WeightAgeCategories.Where(predicate).Where(category => !category.Deleted).AsQueryable().ToListAsync();
        }

        public Task Save(WeightAgeCategory category)
        {
            if (category.Id == 0)
            {
                _context.WeightAgeCategories.Add(category);
            }
            else
            {
                _context.Entry(category).State = EntityState.Modified;
            }

            return _context.SaveChangesAsync();
        }

        public Task Remove(int id)
        {
            var category = _context.WeightAgeCategories.FirstOrDefault(i => i.Id == id);
            if (category == null)
            {
                throw new Exception($"WeightAgeCategory with id={id} is not found");
            }

            category.Deleted = true;
            return _context.SaveChangesAsync();
        }
    }
}