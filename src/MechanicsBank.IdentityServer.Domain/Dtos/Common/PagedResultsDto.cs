using System.Collections.Generic;

namespace MechanicsBank.IdentityServer.Domain.Dtos.Common
{
    public class PagedResultsDto<T>
    {
        public int Count { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public List<T> Data { get; }

        public PagedResultsDto()
        {
            Data = new List<T>();
        }
    }
}
