using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        private readonly IRolesRepository _rolesRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public InstitutionsService(IInstitutionsRepository repository, IUsersRepository usersRepository, IRolesRepository rolesRepository, UserManager<ApplicationUser> userManager)
        {
            _repository = repository;
            _usersRepository = usersRepository;
            _userManager = userManager;
            _rolesRepository = rolesRepository;
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

        public async  Task<IEnumerable<UserModel>> GetMembers(int institutionId)
        {
            var members = await _usersRepository.GetInstitutionMembers(institutionId);
            return members.Select(member => (UserModel) member).ToList();
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
            return fighters
                .Where(fighter => fighter.InstitutionId == institutionId)
                .Select(fighter => (UserModel)fighter)
                .ToList();
        }
    }
}