using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MuaythaiSportManagementSystemApi.Data;
using MuaythaiSportManagementSystemApi.Models;

namespace MuaythaiSportManagementSystemApi.Repositories
{
    public class DocumentsRepository:IDocumentsRepository
    {
        private readonly ApplicationDbContext _context;

        public DocumentsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<List<Document>> GetAll()
        {
            return _context.Documents.ToListAsync();
        }

        public Task<Document> Get(int id)
        {
            return _context.Documents.FirstOrDefaultAsync(d => d.Id == id);
        }

        public Task Save(Document document)
        {
            if (document.Id == 0)
            {
                _context.Documents.Add(document);
            }

            return _context.SaveChangesAsync();
        }

        public Task<List<Document>> Find(Func<Document, bool> predicate)
        {
            var foundDocuments = _context.Documents.Where(predicate).AsQueryable();
            return foundDocuments.ToListAsync();
        }

        public Task Delete(int id)
        {
            var documentToRemove = _context.Documents.FirstOrDefault(d => d.Id == id);
            _context.Documents.Remove(documentToRemove);

            return _context.SaveChangesAsync();
        }
    }
}