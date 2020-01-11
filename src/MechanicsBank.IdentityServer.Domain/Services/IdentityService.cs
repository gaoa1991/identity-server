using AutoMapper;
using MechanicsBank.IdentityServer.Data.Entities.Common;
using MechanicsBank.IdentityServer.Data.Entities.Identity;
using MechanicsBank.IdentityServer.Data.Repositories.Interfaces;
using MechanicsBank.IdentityServer.Domain.Dtos.Identity;
using MechanicsBank.IdentityServer.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MechanicsBank.IdentityServer.Domain.Services
{
    public class IdentityService: IIdentityService
    {
        protected readonly IIdentityRepository IdentityRepository;
        protected readonly IMapper Mapper;

        public IdentityService(IIdentityRepository identityRepository,
            IMapper mapper)
        {
            IdentityRepository = identityRepository;
            Mapper = mapper;
        }

        #region User Methods
        public async Task<UsersDto> GetUsersAsync(string search, int page = 1, int pageSize = 10)
        {
            var pagedList = await IdentityRepository.GetUsersAsync(search, page, pageSize);
            var usersDto = Mapper.Map<UsersDto>(pagedList);

            return usersDto;
        }
        public async Task<UserDto> GetUserAsync(string userId)
        {
            var identity = await IdentityRepository.GetUserAsync(userId);

            if (identity == null) return null; 

            var userDto = Mapper.Map<UserDto>(identity);

            return userDto;

        }
        public async Task<(IdentityResult identityResult, string userId)> CreateUserAsync(UserDto user)
        {
            var userIdentity = Mapper.Map<User>(user);
            return await IdentityRepository.CreateUserAsync(userIdentity);
        }
        public async Task<(IdentityResult identityResult, string userId)> UpdateUserAsync(UserDto user)
        {
            var userIdentity = Mapper.Map<User>(user);
            return await IdentityRepository.UpdateUserAsync(userIdentity);
        }
        public async Task<IdentityResult> DeleteRoleAsync(string roleId)
        {
            return await IdentityRepository.DeleteRoleAsync(roleId);
        }
        #endregion

        #region Role Methods
        public async Task<RolesDto> GetRolesAsync(string search, int page = 1, int pageSize = 10)
        {
            PagedList<Role> pagedList = await IdentityRepository.GetRolesAsync(search, page, pageSize);
            var rolesDto = Mapper.Map<RolesDto>(pagedList);

            return rolesDto;
        }
        public async Task<RoleDto> GetRoleAsync(string roleId)
        {
            var userIdentityRole = await IdentityRepository.GetRoleAsync(roleId);
            var roleDto = Mapper.Map<RoleDto>(userIdentityRole);

            return roleDto;
        }
        public async Task<(IdentityResult identityResult, string roleId)> CreateRoleAsync(RoleDto role)
        {
            var roleEntity = Mapper.Map<Role>(role);
            return await IdentityRepository.CreateRoleAsync(roleEntity);
        }
        public async Task<(IdentityResult identityResult, string roleId)> UpdateRoleAsync(RoleDto role)
        {
            var userIdentityRole = Mapper.Map<Role>(role);
            return await IdentityRepository.UpdateRoleAsync(userIdentityRole);
        }
        public async Task<IdentityResult> DeleteUserAsync(string userId)
        {
            return await IdentityRepository.DeleteUserAsync(userId);
        }
        #endregion
    }
}
