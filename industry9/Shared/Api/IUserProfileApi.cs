using System.Threading.Tasks;
using industry9.Shared.Dto.Account;
using StrawberryShake;

namespace industry9.Shared.Api
{
    /// <summary>
    /// Access to User Profile information
    /// </summary>
    public interface IUserProfileApi
    {
        Task<IOperationResult> Upsert(UserProfileData userProfile);
        Task<IOperationResult> Get();
    }
}
