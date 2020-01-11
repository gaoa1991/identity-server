using MechanicsBank.IdentityServer.Domain.Dtos.Common;
using System.ComponentModel.DataAnnotations;

namespace MechanicsBank.IdentityServer.Domain.Dtos.Identity
{
    public class RoleDto
    {
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
