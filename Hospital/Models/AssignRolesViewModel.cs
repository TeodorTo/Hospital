using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Hospital.Models
{
    public class AssignRolesViewModel
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }
        public IEnumerable<IdentityUser> Users { get; set; }
        public IEnumerable<IdentityRole> Roles { get; set; }
    }
}