using MechanicsBank.IdentityServer.Domain.Dtos.Identity;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace MechanicsBank.IdentityServer.Domain.Services.Interfaces
{
    public interface IIdentityService
    {
        #region User Methods
        Task<UsersDto> GetUsersAsync(string search, int page = 1, int pageSize = 10);
        Task<UserDto> GetUserAsync(string userId);
        Task<(IdentityResult identityResult, string userId)> CreateUserAsync(UserDto user);
        Task<(IdentityResult identityResult, string userId)> UpdateUserAsync(UserDto user);
        Task<IdentityResult> DeleteRoleAsync(string roleId);
        #endregion
        #region Role Methods
        Task<RolesDto> GetRolesAsync(string search, int page = 1, int pageSize = 10);
        Task<RoleDto> GetRoleAsync(string roleId);
        Task<(IdentityResult identityResult, string roleId)> CreateRoleAsync(RoleDto role);
        Task<(IdentityResult identityResult, string roleId)> UpdateRoleAsync(RoleDto role);
        Task<IdentityResult> DeleteUserAsync(string userId);
        #endregion
    }
}
