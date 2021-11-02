using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace HardwareStoreAPI.ViewModels
{
    public class UserRolesViewModel
    {
        public List<IdentityRole> AllRolesList { get; set; }

        public List<UserAndTheirRole> UsersRolesList { get; set; } = new List<UserAndTheirRole>();
    }

    public class UserAndTheirRole
    {
        public IdentityUser User { get; set; }
        public string UserRoleName { get; set; }
    }
}
