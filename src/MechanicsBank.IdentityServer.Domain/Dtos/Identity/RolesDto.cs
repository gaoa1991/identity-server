using System;
using System.Collections.Generic;
using System.Text;

namespace MechanicsBank.IdentityServer.Domain.Dtos.Identity
{
    public class RolesDto
    {
        public RolesDto()
        {
            Roles = new List<RoleDto>();
        }

        public int PageSize { get; set; }

        public int TotalCount { get; set; }

        public List<RoleDto> Roles { get; set; }
    }
}
