using System.Threading.Tasks;
using industry9.Server.Identity;

namespace industry9.Server.Services
{
    public interface IAccountService
    {
        Task<ApplicationUser> RegisterNewUserAsync(string userName, string email, string password, bool requireConfirmEmail);
    }
}
