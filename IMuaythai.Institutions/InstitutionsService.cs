using System.Threading.Tasks;
using IMuaythai.DataAccess.Models;
using IMuaythai.Models.Institutions;
using IMuaythai.Repositories;

namespace IMuaythai.Institutions
{
    public class InstitutionsService : IInstitutionsService
    {
        private readonly IInstitutionsRepository _repository;

        public InstitutionsService(IInstitutionsRepository repository)
        {
            _repository = repository;
        }

        public async Task<InstitutionModel> Get(int id)
        {
            var institution = await _repository.Get(id);
            return (InstitutionModel) institution;
        }

        public async Task<InstitutionModel> Save(InstitutionModel institution)
        {
            Institution entity = institution.Id == 0 ? new Institution() : await _repository.Get(institution.Id);
            entity.Id = institution.Id;
            entity.Name = institution.Name;
            entity.Address = institution.Address;
            entity.ZipCode = institution.ZipCode;
            entity.City = institution.City;
            entity.CountryId = institution.CountryId;
            entity.Email = institution.Email;
            entity.Phone = institution.Phone;
            entity.Owner = institution.Owner;
            entity.ContactPerson = institution.ContactPerson;
            entity.MembersCount = institution.MembersCount;
            entity.InstitutionType = institution.InstitutionType;
            entity.Facebook = institution.Facebook;
            entity.Instagram = institution.Instagram;
            entity.Twitter = institution.Twitter;
            entity.VK = institution.VK;
            entity.Website = institution.Website;
            entity.Logo = institution.Logo;
            await _repository.Save(entity);

            institution.Id = entity.Id;
            
            return institution;
        }

        public async Task Remove(int institutionId)
        {
            await _repository.Remove(institutionId);
        }
    }
}