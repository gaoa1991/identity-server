using System;
using System.Collections.Generic;
using System.Text;

namespace MechanicsBank.IdentityServer.Domain.Dtos.Identity
{
    public class UsersDto
    {
        public UsersDto()
        {
            Users = new List<UserDto>();
        }

        public int PageSize { get; set; }

        public int TotalCount { get; set; }

        public List<UserDto> Users { get; set; }
    }
}
