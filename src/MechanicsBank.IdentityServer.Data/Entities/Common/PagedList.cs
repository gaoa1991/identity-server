using System;
using System.Collections.Generic;
using System.Text;

namespace MechanicsBank.IdentityServer.Data.Entities.Common
{
    public class PagedList<TBaseEntity> where TBaseEntity : class
    {
        public PagedList()
        {
            Data = new List<TBaseEntity>();
        }

        public List<TBaseEntity> Data { get; }

        public int CurrentPage { get; set; }

        public int TotalCount { get; set; }

        public int PageSize { get; set; }
    }
}
