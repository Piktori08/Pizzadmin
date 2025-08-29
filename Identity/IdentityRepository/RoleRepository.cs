using Microsoft.EntityFrameworkCore;
using Pizzadmin.Data;
using Pizzadmin.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pizzadmin.Identity
{
    public class RoleRepository : IRoleRepository
    {
        private readonly PizzadminContext context;
        public RoleRepository(PizzadminContext dbContext)
        {
            context = dbContext;
        }

        public IEnumerable<AppRole> FindAll()
        {
            return context.Roles;
        }

        public async Task<IEnumerable<AppRole>> FindAllAsync()
        {
            return await context.Roles.ToListAsync();
        }

        public async Task CreateRoleAsync(AppRole role)
        {
            await context.Roles.AddAsync(role);
            await context.SaveChangesAsync();
        }
    }
}
