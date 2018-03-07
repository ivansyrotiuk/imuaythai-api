using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using IMuaythai.Auth;
using IMuaythai.DataAccess.Models;
using IMuaythai.Models.Institutions;
using IMuaythai.Models.Users;
using IMuaythai.Repositories;
using Microsoft.AspNetCore.Identity;

namespace IMuaythai.Institutions
{
    public class InstitutionsService : IInstitutionsService
    {
        private readonly IInstitutionsRepository _repository;
        private readonly IUsersRepository _usersRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public InstitutionsService(IInstitutionsRepository repository, IUsersRepository usersRepository, UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _repository = repository;
            _usersRepository = usersRepository;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<InstitutionResponseModel> Get(int id)
        {
            var institution = await _repository.Get(id);
            return _mapper.Map<InstitutionResponseModel>(institution);
        }

        public async Task<InstitutionResponseModel> Save(InstitutionUpdateModel institutionUpdateModel)
        {
            var entity = _mapper.Map<Institution>(institutionUpdateModel);
            await _repository.Save(entity);

            institutionUpdateModel.Id = entity.Id;
            
            return _mapper.Map<InstitutionResponseModel>(entity);
        }

        public async Task Remove(int institutionId)
        {
            await _repository.Remove(institutionId);
        }

        public async  Task<IEnumerable<UserModel>> GetMembers(int institutionId)
        {
            var members = await _usersRepository.GetInstitutionMembers(institutionId);
            return _mapper.Map<IEnumerable<UserModel>>(members);
        }

        public async Task<IEnumerable<GymResponseModel>> GetGyms(int institutionId)
        {
            var gyms = await _repository.GetGymsByCountry(Get(institutionId).Result?.CountryId ?? 0);
            return _mapper.Map<IEnumerable<GymResponseModel>>(gyms.Where(i => i.Id != institutionId));
        }

        public async Task<IEnumerable<UserModel>> GetFighters(int institutionId)
        {
            var users = await _userManager.GetUsersInRoleAsync(RoleNames.Fighter);
            return GetInstitutionMembers(institutionId, users);
        }

        public async Task<IEnumerable<UserModel>> GetJudges(int institutionId)
        {
            var users = await _userManager.GetUsersInRoleAsync(RoleNames.Judge);
            return GetInstitutionMembers(institutionId, users);
        }

        public async Task<IEnumerable<UserModel>> GetCoaches(int institutionId)
        {
            var users = await _userManager.GetUsersInRoleAsync(RoleNames.Coach);
            return GetInstitutionMembers(institutionId, users);
        }

        public async Task<IEnumerable<UserModel>> GetDoctors(int institutionId)
        {
            var users = await _userManager.GetUsersInRoleAsync(RoleNames.Coach);
            return GetInstitutionMembers(institutionId, users);
        }

        private List<UserModel> GetInstitutionMembers(int institutionId, IList<ApplicationUser> fighters)
        {
            return _mapper.Map<List<UserModel>>(fighters.Where(fighter => fighter.InstitutionId == institutionId));
        }
    }
}