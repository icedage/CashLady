using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CashLady.Identity.IdenityServices
{
    public interface IRoleManager
    {
        Task<IdentityResult> CreateRoleAsync();

        Task<IdentityRole> GetByNameAsync(string role);

        Task<IdentityResult> UpdateAsync();

        Task<IdentityResult> DeleteAsync();

    }
}
