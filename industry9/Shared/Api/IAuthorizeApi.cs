using System.Threading.Tasks;
using industry9.Shared.Dto;
using industry9.Shared.Dto.Account;

namespace industry9.Shared.Api
{
    public interface IAuthorizeApi
    {
        Task<ApiResponseData> Login(LoginData loginParameters);
        Task<ApiResponseData> Logout();
        Task<ApiResponseData> Create(RegisterData registerParameters);
        Task<ApiResponseData> Register(RegisterData registerParameters);
        Task<ApiResponseData> ForgotPassword(ForgotPasswordData forgotPasswordParameters);
        Task<ApiResponseData> ResetPassword(ResetPasswordData resetPasswordParameters);
        Task<ApiResponseData> ConfirmEmail(ConfirmEmailData confirmEmailParameters);
        Task<ApiResponseData> UpdateUser(UserInfoData userInfo);

        Task<UserInfoData> GetUserInfo();
        Task<UserInfoData> GetUser();
    }
}
