using MechanicsBank.IdentityServer.Domain.Dtos.Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MechanicsBank.IdentityServer.Domain.Services.Interfaces
{
    public interface IConfigurationService
    {
        #region Client Methods
        Task<PagedResultsDto<IdentityServer4.Models.Client>> SearchClient(string name, int page, int size);

        Task<IEnumerable<IdentityServer4.Models.Client>> AllClients(Expression<Func<IdentityServer4.EntityFramework.Entities.Client, bool>> where = null);

        Task CreateClient(IdentityServer4.Models.Client client);

        IdentityServer4.Models.Client GetClient(int id);

        void UpdateClient(IdentityServer4.Models.Client client);

        void DeleteClient(IdentityServer4.Models.Client client);

        #endregion
    }
}
