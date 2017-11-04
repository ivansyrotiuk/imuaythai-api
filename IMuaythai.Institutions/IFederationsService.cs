using System.Collections.Generic;
using System.Threading.Tasks;
using IMuaythai.Models.Institutions;

namespace IMuaythai.Institutions
{
    public interface IFederationsService : IInstitutionsService
    {
        Task<IEnumerable<InstitutionModel>> GetNationalFederations();
        Task<IEnumerable<InstitutionModel>> GetContinentalFederations();
        Task<IEnumerable<InstitutionModel>> GetWorldFederations();
    }
}