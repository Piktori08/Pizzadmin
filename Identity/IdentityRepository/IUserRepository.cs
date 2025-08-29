using Pizzadmin.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pizzadmin.Identity
{
    public interface IUserRepository
    {
        IEnumerable<AppUser> FindAll();
        Task<IEnumerable<AppUser>> FindAllAsync();
        AppUser GetUser(string id);
        Task<AppUser> GetUserAsync(string id);
        AppUser GetUserRoles(string id);
        Task<AppUser> GetUserRolesAsync(string id);
        void UpdateUser(AppUser user);
        Task UpdateUserAsync(AppUser user);
        void DeleteUser(AppUser user);
        Task DeleteUserAsync(AppUser user);
        void SaveChanges();
        Task SaveChangesAsync();
    }
}


