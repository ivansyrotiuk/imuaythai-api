using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using IMuaythai.Auth;
using IMuaythai.DataAccess.Models;
using IMuaythai.Models.Users;
using IMuaythai.Repositories;
using Microsoft.AspNetCore.Identity;

namespace IMuaythai.Users
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        private readonly IHttpUserContext _userContext;

        public UsersService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IMapper mapper, IUsersRepository usersRepository, IHttpUserContext userContext )
        {
            _userManager = userManager;    
            _roleManager = roleManager;
            _mapper = mapper;
            _usersRepository = usersRepository;
            _userContext = userContext;
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
            return _mapper.Map<IEnumerable<FighterModel>>(fighters);
        }

        public async Task<IEnumerable<JudgeModel>> GetJudges()
        {
            var judges = await _userManager.GetUsersInRoleAsync("Judge");
            return _mapper.Map<IEnumerable<JudgeModel>>(judges);
        }

        public async Task<IEnumerable<JudgeModel>> GetCoaches()
        {
            var coaches = await _userManager.GetUsersInRoleAsync("Coach");
            return _mapper.Map<IEnumerable<JudgeModel>>(coaches);
        }

        public async Task<IEnumerable<JudgeModel>> GetDoctors()
        {
            var doctors = await _userManager.GetUsersInRoleAsync("Doctor");
            return _mapper.Map<IEnumerable<JudgeModel>>(doctors);
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
            ApplicationUser user = _mapper.Map<ApplicationUser>(userModel);
   
            //Refactor this brutal code
            if (userModel.AvatarImage != null)
            {
                var imageBase64 = userModel.AvatarImage.Split(',');
                var bytes = Convert.FromBase64String(imageBase64[1]);
                if (bytes.Length > 0)
                {
                    var context = _userContext.GetHttpContext();
                    var request = context.Request;
                    if (!string.IsNullOrEmpty(user.Photo))
                    {
                        var pathToImage = "./wwwroot" + user.Photo.Replace($"{request.Scheme}://{request.Host}", "");
                        System.IO.File.Delete(pathToImage);
                    }
                    var imageName = $"images/{Guid.NewGuid().ToString().Substring(0, 10)}.png";
                    System.IO.File.WriteAllBytes($"./wwwroot/{imageName}", bytes);
                    var location = new Uri($"{request.Scheme}://{request.Host}");

                    user.Photo = location.AbsoluteUri + imageName;
                }
            }

            await _usersRepository.Save(user);

            return _mapper.Map<UserModel>(user);
        }

        public async Task RemoveUser(UserModel user)
        {
            await _usersRepository.Remove(user.Id);
        }
    }
}
