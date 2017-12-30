using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IMuaythai.Models.Institutions;
using IMuaythai.Models.Users;

namespace IMuaythai.Institutions
{
    public interface IInstitutionsService
    {
        Task<InstitutionResponseModel> Get(int id);
        Task<IEnumerable<UserModel>> GetMembers(int institutionId);
        Task<IEnumerable<UserModel>> GetFighters(int institutionId);
        Task<IEnumerable<UserModel>> GetJudges(int institutionId);
        Task<IEnumerable<UserModel>> GetCoaches(int institutionId);
        Task<IEnumerable<UserModel>> GetDoctors(int institutionId);
        Task<InstitutionResponseModel> Save(InstitutionUpdateModel institutionUpdateModel);
        Task Remove(int institutionId);
    }
}