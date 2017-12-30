using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using IMuaythai.Models.Institutions;

namespace IMuaythai.Institutions
{
    public interface IGymsService : IInstitutionsService
    {
        Task<IEnumerable<GymResponseModel>> GetGyms();
        Task<IEnumerable<GymResponseModel>> GetCountryGyms(int countryId);
    }
}
