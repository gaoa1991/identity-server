using IdentityServer4.EntityFramework.Mappers;
using MechanicsBank.IdentityServer.Data.Repositories.Interfaces;
using MechanicsBank.IdentityServer.Domain.Dtos.Common;
using MechanicsBank.IdentityServer.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MechanicsBank.IdentityServer.Domain.Services
{
    public class ConfiggurationService: IConfigurationService
    {
        private readonly IConfigurationRepositoryWrapper repoWrapper;

        public ConfiggurationService(IConfigurationRepositoryWrapper RepoWrapper)
        {
            repoWrapper = RepoWrapper;
        }

        #region Client Methods
        public async Task<PagedResultsDto<IdentityServer4.Models.Client>> SearchClient(string name, int page, int size)
        {
            var pagedListDto = new PagedResultsDto<IdentityServer4.Models.Client>();

            Expression<Func<IdentityServer4.EntityFramework.Entities.Client, bool>> searchCondition = x => x.ClientName.Contains(name);

            var pagedList = await repoWrapper.Clients.GetSearchResults(searchCondition, name, page, size, true, x => x.ClientName, null).ConfigureAwait(true);

            pagedListDto.Data.AddRange(pagedList.Data.Select(e => e.ToModel()));

            pagedListDto.Count = pagedList.TotalCount;
            pagedListDto.PageSize = 10;

            return pagedListDto;
        }

        public async Task<IEnumerable<IdentityServer4.Models.Client>> AllClients(Expression<Func<IdentityServer4.EntityFramework.Entities.Client, bool>> where = null)
        {
            var data = await repoWrapper.Clients.GetAll(where, true, x => x.ClientName, null).ConfigureAwait(false);
            return data.Select(m => m.ToModel());
        }

        public async Task CreateClient(IdentityServer4.Models.Client client)
        {
            var newData = client.ToEntity();
            await repoWrapper.Clients.Add(newData).ConfigureAwait(false);
            repoWrapper.Save();
        }

        public IdentityServer4.Models.Client GetClient(int id)
        {
            var data = repoWrapper.Clients.FindById(id);
            return data.ToModel();
        }

        public void UpdateClient(IdentityServer4.Models.Client client)
        {
            var dbEntity = client.ToEntity();

            repoWrapper.Clients.Update(dbEntity);
            repoWrapper.Save();
        }

        public void DeleteClient(IdentityServer4.Models.Client client)
        {
            repoWrapper.Clients.Remove(client.ToEntity());
            repoWrapper.Save();
        }

        #endregion
    }
}
