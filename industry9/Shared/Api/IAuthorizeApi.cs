using System.Threading.Tasks;
using industry9.Shared.Dto.Account;
using StrawberryShake;

namespace industry9.Shared.Api
{
    public interface IAuthorizeApi
    {
        Task<IOperationResult> Login(LoginData loginParameters);
        Task<IOperationResult> Logout();
        Task<IOperationResult> Create(RegisterData registerParameters);
        Task<IOperationResult> Register(RegisterData registerParameters);
        Task<IOperationResult> ForgotPassword(ForgotPasswordData forgotPasswordParameters);
        Task<IOperationResult> ResetPassword(ResetPasswordData resetPasswordParameters);
        Task<IOperationResult> ConfirmEmail(ConfirmEmailData confirmEmailParameters);
        Task<IOperationResult> UpdateUser(UserInfoData userInfo);

        Task<UserInfoData> GetUserInfo();
        Task<UserInfoData> GetUser();
    }
}
