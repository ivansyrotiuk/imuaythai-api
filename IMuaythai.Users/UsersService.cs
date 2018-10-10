using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using IMuaythai.DataAccess.Models;
using IMuaythai.HttpServices;
using IMuaythai.Models.Users;
using IMuaythai.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace IMuaythai.Users
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        private readonly IHttpUserContext _userContext;
        private readonly ILogger _logger;

        public UsersService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IMapper mapper, IUsersRepository usersRepository, IHttpUserContext userContext, ILoggerFactory factory )
        {
            _userManager = userManager;    
            _roleManager = roleManager;
            _mapper = mapper;
            _usersRepository = usersRepository;
            _userContext = userContext;
            _logger = factory.CreateLogger<UsersService>();
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
            var fighters = await _userManager.GetUsersInRoleAsync("Fighter");
            return _mapper.Map<IEnumerable<FighterModel>>(fighters.Where(user => !user.Deleted));
        }

        public async Task<IEnumerable<JudgeModel>> GetJudges()
        {
            var judges = await _userManager.GetUsersInRoleAsync("Judge");
            return _mapper.Map<IEnumerable<JudgeModel>>(judges.Where(user => !user.Deleted));
        }

        public async Task<IEnumerable<JudgeModel>> GetCoaches()
        {
            var coaches = await _userManager.GetUsersInRoleAsync("Coach");
            return _mapper.Map<IEnumerable<JudgeModel>>(coaches.Where(user => !user.Deleted));
        }

        public async Task<IEnumerable<JudgeModel>> GetDoctors()
        {
            var doctors = await _userManager.GetUsersInRoleAsync("Doctor");
            return _mapper.Map<IEnumerable<JudgeModel>>(doctors.Where(user => !user.Deleted));
        }

        public async Task<UserModel> GetUser(string id)
        {
            var user = await _usersRepository.Get(id);
            var userRoles = await _userManager.GetRolesAsync(user);
            var userModel = _mapper.Map<UserModel>(user);
            userModel.Roles = userRoles.ToList();
            return userModel;
        }

        public async Task<UserModel> SaveUser(UserModel userModel)
        {
            var user = await _usersRepository.Get(userModel.Id);
             _mapper.Map(userModel, user);

            await _usersRepository.Save(user);

            return _mapper.Map<UserModel>(user);
        }

        public async Task RemoveUser(string userId)
        {
            var user = await _usersRepository.Get(userId);
            user.Deleted = true;
            user.UserName = $"[{Guid.NewGuid()}]{user.UserName}";
            user.NormalizedUserName = $"[{Guid.NewGuid()}]{user.NormalizedUserName}".ToUpper();
            user.Email = $"[{Guid.NewGuid()}]{user.Email}";
            user.NormalizedUserName = $"[{Guid.NewGuid()}]{user.NormalizedUserName}".ToUpper();
            await _usersRepository.Save(user);
            _logger.Log(LogLevel.Information, $"User {userId} has been removed. Trashed username: {user.UserName}");
        }

        public async Task<IEnumerable<UserModel>> GetUsers()
        {
            var users = await _usersRepository.GetAll();
            return _mapper.Map<IEnumerable<UserModel>>(users);
        }
    }
}
