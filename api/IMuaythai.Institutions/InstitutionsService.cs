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

        public async Task<InstitutionModel> Get(int id)
        {
            var institution = await _repository.Get(id);
            return _mapper.Map<InstitutionModel>(institution);
        }

        public async Task<InstitutionModel> Save(InstitutionModel institution)
        {
            var entity = _mapper.Map<Institution>(institution);
            await _repository.Save(entity);

            institution.Id = entity.Id;
            
            return institution;
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