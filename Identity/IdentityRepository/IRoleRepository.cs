using Pizzadmin.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pizzadmin.Identity
{
  public  interface IRoleRepository
    {
        IEnumerable<AppRole> FindAll();
        Task<IEnumerable<AppRole>> FindAllAsync();
        Task CreateRoleAsync(AppRole role);
    }
}
