using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IdentityAdmin.Models
{
    public class UserRoleModel
    {
        public string UserId { get; set; }
        public string SelectedRole { get; set; }
        public List<SelectListItem> Roles { get; set; }
        public string Username { get; set; }
    }
}
