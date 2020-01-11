using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IdentityServer4.EntityFramework.Entities;
using MechanicsBank.IdentityServer.Data.Entities.Common;
using MechanicsBank.IdentityServer.Data.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace MechanicsBank.IdentityServer.Data.Repositories.Interfaces
{
    public interface IIdentityRepository
    {
        #region
        Task<User> GetUserAsync(string userId);
        Task<(IdentityResult identityResult, string userId)> CreateUserAsync(User user);
        Task<(IdentityResult identityResult, string userId)> UpdateUserAsync(User user);
        Task<IdentityResult> DeleteUserAsync(string userId);
        Task<PagedList<User>> GetUsersAsync(string search, int page = 1, int pageSize = 10);

        #endregion

        #region
        Task<Role> GetRoleAsync(string roleId);
        Task<PagedList<Role>> GetRolesAsync(string search, int page = 1, int pageSize = 10);
        Task<(IdentityResult identityResult, string roleId)> CreateRoleAsync(Role user);
        Task<(IdentityResult identityResult, string roleId)> UpdateRoleAsync(Role user);
        Task<IdentityResult> DeleteRoleAsync(string roleId);

        #endregion
    }
}
