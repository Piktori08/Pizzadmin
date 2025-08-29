using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pizzadmin.Identity
{
    public class AppRole : IdentityRole
    {
        [NotMapped]
        public bool IsSelected { get; set; }

        public ICollection<AppUserRole> UserRoles { get; set; }
    }
}
