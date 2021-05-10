using System.Threading.Tasks;
using industry9.Shared.Dto;
using industry9.Shared.Dto.Account;

namespace industry9.Shared.Api
{
    /// <summary>
    /// Access to User Profile information
    /// </summary>
    public interface IUserProfileApi
    {
        Task<ApiResponseData> Upsert(UserProfileData userProfile);
        Task<ApiResponseData> Get();
    }
}
