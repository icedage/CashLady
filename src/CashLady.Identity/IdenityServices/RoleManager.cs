using System.Threading.Tasks;
using CashLady.Identity.Infrastructure;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CashLady.Identity.IdenityServices
{
    public class RoleManager : IRoleManager
    {
        public async Task<IdentityResult> CreateRoleAsync()
        {
            var context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            
            return await roleManager.CreateAsync(new IdentityRole());
        }
        

        public async Task<IdentityResult> DeleteAsync()
        {
            var context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            return await roleManager.DeleteAsync(new IdentityRole());
        }

        public async Task<IdentityRole> GetByNameAsync(string role)
        {
            var context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            return await roleManager.FindByNameAsync(role);
        }

        public async Task<IdentityResult> UpdateAsync()
        {
            var context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            return await roleManager.UpdateAsync(new IdentityRole());
        }
    }
}
