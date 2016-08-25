using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CashLady.Identity.Infrastructure;
using CashLady.Identity.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CashLady.Identity.IdenityServices
{
    public class UserManager : IUserManager
    {
        public async Task<IdentityResult> AssignRoleAsync(string userid, string role)
        {
            var context = new ApplicationDbContext();

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            return await userManager.AddToRoleAsync(userid, role);
        }

        public async Task<IdentityResult> CreateUserAsync()
        {
            var context = new ApplicationDbContext();

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            return await userManager.CreateAsync(new ApplicationUser());
        }

        public async Task<ApplicationUser> GetUserByIdAsync(string userId)
        {
            var context = new ApplicationDbContext();

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            return await userManager.FindByIdAsync(userId);
        }

        public async Task<IdentityResult> UpdateUserAsync()
        {

            var context = new ApplicationDbContext();

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            return await userManager.UpdateAsync(new ApplicationUser());
        }
    }
}
