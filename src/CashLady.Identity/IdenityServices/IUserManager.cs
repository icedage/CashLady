using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CashLady.Identity.Models;
using Microsoft.AspNet.Identity;

namespace CashLady.Identity.IdenityServices
{
    public interface IUserManager
    {
        Task<IdentityResult> CreateUserAsync();

        Task<IdentityResult> UpdateUserAsync();

        Task<IdentityResult> AssignRoleAsync(string userid, string role);

        Task<ApplicationUser> GetUserByIdAsync(string userId);
    }
}
