using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MuaythaiSportManagementSystemApi.Models;

namespace MuaythaiSportManagementSystemApi.Repositories
{
    public interface IDocumentsRepository
    {
        Task<List<Document>> GetAll();
        Task<Document> Get(int id);
        Task Save(Document document);
        Task<List<Document>> Find(Func<Document, bool> predicate);
        Task Delete(int id);
        Task<List<Document>> GetAllForUser(string id);
        Task<List<Document>> GetAllForInstitution(int id);
        Task<List<Document>> GetAllForContest(int id);
    }
}