using AutoMapper;
using MechanicsBank.IdentityServer.Data.Contexts;
using MechanicsBank.IdentityServer.Data.Entities.Common;
using MechanicsBank.IdentityServer.Data.Entities.Identity;
using MechanicsBank.IdentityServer.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MechanicsBank.IdentityServer.Data.Repositories
{
    public class IdentityRepository : IIdentityRepository
    {
        protected readonly IdentityServerContext DbContext;
        protected readonly UserManager<User> UserManager;
        protected readonly RoleManager<Role> RoleManager;
        protected readonly IMapper Mapper;

        public bool AutoSaveChanges { get; set; } = true;

        public IdentityRepository(IdentityServerContext dbContext,
            UserManager<User> userManager,
            RoleManager<Role> roleManager,
            IMapper mapper)
        {
            DbContext = dbContext;
            UserManager = userManager;
            RoleManager = roleManager;
            Mapper = mapper;
        }

        #region User Methods
        public async Task<User> GetUserAsync(string userId)
        {
            return await UserManager.FindByIdAsync(userId);
        }
        public async Task<PagedList<User>> GetUsersAsync(string search, int page = 1, int pageSize = 10)
        {
            var pagedList = new PagedList<User>();
            Expression<Func<User, bool>> searchCondition = x => x.UserName.Contains(search) || x.Email.Contains(search);

            var users = await UserManager.Users.WhereIf(!string.IsNullOrEmpty(search), searchCondition).PageBy(x => x.Id, page, pageSize).ToListAsync();

            pagedList.Data.AddRange(users);

            pagedList.TotalCount = await UserManager.Users.WhereIf(!string.IsNullOrEmpty(search), searchCondition).CountAsync();
            pagedList.PageSize = pageSize;

            return pagedList;
        }
        public async Task<(IdentityResult identityResult, string userId)> CreateUserAsync(User user)
        {
            var identityResult = await UserManager.CreateAsync(user);

            return (identityResult, user.Id);
        }
        public async Task<(IdentityResult identityResult, string userId)> UpdateUserAsync(User user)
        {
            var userIdentity = await UserManager.FindByIdAsync(user.Id.ToString());
            Mapper.Map(user, userIdentity);
            var identityResult = await UserManager.UpdateAsync(userIdentity);

            return (identityResult, user.Id);
        }
        public async Task<IdentityResult> DeleteUserAsync(string userId)
        {
            var userIdentity = await UserManager.FindByIdAsync(userId);

            return await UserManager.DeleteAsync(userIdentity);
        }
        #endregion

        #region Role Methods

        public async Task<Role> GetRoleAsync(string roleId)
        {
            return await RoleManager.Roles.Where(x => x.Id.Equals(roleId)).SingleOrDefaultAsync();
        }
        public async Task<PagedList<Role>> GetRolesAsync(string search, int page = 1, int pageSize = 10)
        {
            var pagedList = new PagedList<Role>();

            Expression<Func<Role, bool>> searchCondition = x => x.Name.Contains(search);
            var roles = await RoleManager.Roles.WhereIf(!string.IsNullOrEmpty(search), searchCondition).PageBy(x => x.Id, page, pageSize).ToListAsync();

            pagedList.Data.AddRange(roles);
            pagedList.TotalCount = await RoleManager.Roles.WhereIf(!string.IsNullOrEmpty(search), searchCondition).CountAsync();
            pagedList.PageSize = pageSize;

            return pagedList;
        }
        public async Task<(IdentityResult identityResult, string roleId)> CreateRoleAsync(Role role)
        {
            var identityResult = await RoleManager.CreateAsync(role);

            return (identityResult, role.Id);
        }
        public async Task<(IdentityResult identityResult, string roleId)> UpdateRoleAsync(Role user)
        {
            var userIdentity = await UserManager.FindByIdAsync(user.Id.ToString());
            Mapper.Map(user, userIdentity);
            var identityResult = await UserManager.UpdateAsync(userIdentity);

            return (identityResult, user.Id);
        }
        public async Task<IdentityResult> DeleteRoleAsync(string roleId)
        {
            var thisRole = await RoleManager.FindByIdAsync(roleId);

            return await RoleManager.DeleteAsync(thisRole);
        }
        #endregion
    }
}
