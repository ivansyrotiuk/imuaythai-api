using System.Threading.Tasks;
using IMuaythai.Models.Institutions;

namespace IMuaythai.Institutions
{
    public interface IInstitutionsService
    {
        Task<InstitutionModel> Get(int id);
        Task<InstitutionModel> Save(InstitutionModel institution);
        Task Remove(int institutionId);

    }
}