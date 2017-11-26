using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using IMuaythai.Auth;
using IMuaythai.DataAccess.Models;
using IMuaythai.Models.Users;
using IMuaythai.Repositories;

namespace IMuaythai.Users
{
    public class UserRolesService : IUserRolesService
    {
        private readonly IUserRoleRequestsRepository _userRoleRequestsRepository;
        private readonly IHttpUserContext _userContext;
        private readonly IUserRolesManager _userRolesManager;
        private readonly IMapper _mapper;

        public UserRolesService(IUserRoleRequestsRepository userRoleAcceptationsRepository, IHttpUserContext userContext,
            IUserRolesManager userRolesManager, IMapper mapper)
        {
            _userRoleRequestsRepository = userRoleAcceptationsRepository;
            _userRolesManager = userRolesManager;
            _userContext = userContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserRoleRequestModel>> GetUserRoleRequests(string userId)
        {
            var userRoleRequests = await _userRoleRequestsRepository.GetUserRequests(userId);
            return _mapper.Map<IEnumerable<UserRoleRequestModel>>(userRoleRequests);
        }

        public async Task<UserRoleRequestModel> AddUserRoleRequest(UserRoleRequestModel roleRequestModel)
        {
            var roleRequest = _mapper.Map<UserRoleRequest>(roleRequestModel);
            roleRequest.Status = UserRoleRequestStatus.Pending;
            await _userRoleRequestsRepository.Save(roleRequest);
            return _mapper.Map<UserRoleRequestModel>(roleRequest);
        }

        public async Task<IEnumerable<UserRoleRequestModel>> GetPendingRoleRequests()
        {
            var pendingRoleRequests = await _userRoleRequestsRepository.GetPendingRequests();
            return _mapper.Map<IEnumerable<UserRoleRequestModel>>(pendingRoleRequests);
        }

        public async Task<UserRoleRequestModel> AcceptRoleRequest(UserRoleRequestModel roleRequestModel)
        {
            var roleRequest = await _userRoleRequestsRepository.Get(roleRequestModel.Id);
            roleRequest.RoleId = roleRequestModel.RoleId;
            roleRequest.UserId = roleRequestModel.UserId;
            roleRequest.AcceptedByUserId = _userContext.GetUserId();
            roleRequest.AcceptationDate = DateTime.UtcNow;
            roleRequest.Status = UserRoleRequestStatus.Accepted;

            await _userRoleRequestsRepository.Save(roleRequest);
            await _userRolesManager.AddUserToRole(roleRequestModel.UserId, roleRequestModel.RoleName);

            return _mapper.Map<UserRoleRequestModel>(roleRequest);
        }

        public async Task<UserRoleRequestModel> RejectRoleRequest(UserRoleRequestModel roleRequestModel)
        {
            UserRoleRequest roleRequest = await _userRoleRequestsRepository.Get(roleRequestModel.Id);
            roleRequest.RoleId = roleRequestModel.RoleId;
            roleRequest.UserId = roleRequestModel.UserId;
            roleRequest.AcceptedByUserId = _userContext.GetUserId();
            roleRequest.AcceptationDate = DateTime.UtcNow;
            roleRequest.Status = UserRoleRequestStatus.Rejected;

            await _userRoleRequestsRepository.Save(roleRequest);
            await _userRolesManager.RemoveUserFromRole(roleRequestModel.UserId, roleRequestModel.RoleName);

            return _mapper.Map<UserRoleRequestModel>(roleRequest);
        }
    }
}