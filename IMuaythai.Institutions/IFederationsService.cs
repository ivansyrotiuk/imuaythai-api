using System.Collections.Generic;
using System.Threading.Tasks;
using IMuaythai.Models.Institutions;

namespace IMuaythai.Institutions
{
    public interface IFederationsService : IInstitutionsService
    {
        Task<IEnumerable<InstitutionResponseModel>> GetNationalFederations();
        Task<IEnumerable<InstitutionResponseModel>> GetContinentalFederations();
        Task<IEnumerable<InstitutionResponseModel>> GetWorldFederations();
    }
}