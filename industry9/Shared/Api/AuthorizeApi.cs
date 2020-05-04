using System.Collections.Generic;
using System.Threading.Tasks;
using industry9.Shared.Dto.Account;
using StrawberryShake;

namespace industry9.Shared.Api
{
    public class AuthorizeApi : IAuthorizeApi
    {
        public Task<IOperationResult> Login(LoginData loginParameters)
        {
            throw new System.NotImplementedException();
        }

        public Task<IOperationResult> Logout()
        {
            throw new System.NotImplementedException();
        }

        public Task<IOperationResult> Create(RegisterData registerParameters)
        {
            throw new System.NotImplementedException();
        }

        public Task<IOperationResult> Register(RegisterData registerParameters)
        {
            throw new System.NotImplementedException();
        }

        public Task<IOperationResult> ForgotPassword(ForgotPasswordData forgotPasswordParameters)
        {
            throw new System.NotImplementedException();
        }

        public Task<IOperationResult> ResetPassword(ResetPasswordData resetPasswordParameters)
        {
            throw new System.NotImplementedException();
        }

        public Task<IOperationResult> ConfirmEmail(ConfirmEmailData confirmEmailParameters)
        {
            throw new System.NotImplementedException();
        }

        public Task<IOperationResult> UpdateUser(UserInfoData userInfo)
        {
            throw new System.NotImplementedException();
        }

        public Task<UserInfoData> GetUserInfo()
        {
            return Task.FromResult(new UserInfoData
            {
                Email = "asdf",
                FirstName = "asdf",
                LastName = "asdf",
                UserName = "asdf",
                ExposedClaims = new List<KeyValuePair<string, string>>()
            });
        }

        public Task<UserInfoData> GetUser()
        {
            return Task.FromResult(new UserInfoData
            {
                Email = "asdf",
                FirstName = "asdf",
                LastName = "asdf",
                UserName = "asdf",
                ExposedClaims = new List<KeyValuePair<string, string>>()
            });
        }
    }
}