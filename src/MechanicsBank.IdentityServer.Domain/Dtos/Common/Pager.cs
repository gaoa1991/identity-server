namespace MechanicsBank.IdentityServer.Domain.Dtos.Common
{
    public class Pager
    {
        public int TotalCount { get; set; }

        public int PageSize { get; set; }
        public int CurrentPageSize { get; set; }

        public string Action { get; set; }

        public string Search { get; set; }

        public int MaxPages { get; set; } = 10;
    }
}
