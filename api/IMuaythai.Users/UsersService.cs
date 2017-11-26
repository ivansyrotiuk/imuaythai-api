using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using IMuaythai.DataAccess.Models;
using IMuaythai.Models.Users;
using IMuaythai.Repositories;
using Microsoft.AspNetCore.Identity;

namespace IMuaythai.Users
{
    public class UsersService : IUsersService
    {
        private IUsersRepository _usersRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;

        public UsersService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IMapper mapper, IUsersRepository usersRepository)
        {
            _userManager = userManager;    
            _roleManager = roleManager;
            _mapper = mapper;
            _usersRepository = usersRepository;
        }

        public async Task<ApplicationUser> CreateUser(CreateUserModel createUserModel)
        {
            var user = _mapper.Map<CreateUserModel, ApplicationUser>(createUserModel);
            user.UserName = user.Email;
            var result = await _userManager.CreateAsync(user);
            if (!result.Succeeded)
            {
                throw new Exception(result.ToString());
            }

            result = await _userManager.AddPasswordAsync(user, createUserModel.Password);
            if (!result.Succeeded)
            {
                throw new Exception(result.ToString());
            }

            var role = await _roleManager.FindByIdAsync(createUserModel.RoleId);
            result = await _userManager.AddToRoleAsync(user, role.Name);
            if (!result.Succeeded)
            {
                throw new Exception(result.ToString());
            }

            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            result = await _userManager.ConfirmEmailAsync(user, code);
            if (!result.Succeeded)
            {
                throw new Exception(result.ToString());
            }

            return user;
        }

        public async Task<IEnumerable<FighterModel>> GetFigthers()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<FighterModel>> GetJudges()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<FighterModel>> GetCoaches()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<FighterModel>> GetDoctors()
        {
            throw new NotImplementedException();
        }

        public async Task<FighterModel> GetUser(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<FighterModel> SaveUser(UserModel user)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveUser(UserModel user)
        {
            throw new NotImplementedException();
        }
    }
}
