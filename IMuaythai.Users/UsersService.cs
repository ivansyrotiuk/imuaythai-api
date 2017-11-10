using System;
using System.Threading.Tasks;
using AutoMapper;
using IMuaythai.DataAccess.Models;
using IMuaythai.Models.Users;
using Microsoft.AspNetCore.Identity;

namespace IMuaythai.Users
{
    public class UsersService : IUsersService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;

        public UsersService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IMapper mapper)
        {
            _userManager = userManager;    
            _roleManager = roleManager;
            _mapper = mapper;
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
    }
}
