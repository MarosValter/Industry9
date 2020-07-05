using System;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using industry9.Shared.Api;
using industry9.Shared.Dto;
using industry9.Shared.Dto.Account;
using Microsoft.AspNetCore.Components.Authorization;

namespace industry9.Shared.Authorization.Implementation
{
    public class IdentityAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly IAuthorizeApi _authorizeApi;
        private readonly AppState _appState;

        public IdentityAuthenticationStateProvider(IAuthorizeApi authorizeApi, AppState appState)
        {
            _authorizeApi = authorizeApi;
            _appState = appState;
        }

        public async Task<ApiResponseData> Login(LoginData loginParameters)
        {
            var apiResponse = await _authorizeApi.Login(loginParameters);
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
            return apiResponse;
        }

        public async Task<ApiResponseData> Register(RegisterData registerParameters)
        {
            var apiResponse = await _authorizeApi.Register(registerParameters);
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
            return apiResponse;
        }

        public async Task<ApiResponseData> Create(RegisterData registerParameters)
        {
            var apiResponse = await _authorizeApi.Create(registerParameters);
            return apiResponse;
        }

        public async Task<ApiResponseData> Logout()
        {
            _appState.UserProfile = null;
            var apiResponse = await _authorizeApi.Logout();
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
            return apiResponse;
        }

        public async Task<ApiResponseData> ConfirmEmail(ConfirmEmailData confirmEmailParameters)
        {
            var apiResponse = await _authorizeApi.ConfirmEmail(confirmEmailParameters);
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
            return apiResponse;
        }

        public async Task<ApiResponseData> ResetPassword(ResetPasswordData resetPasswordParameters)
        {
            var apiResponse = await _authorizeApi.ResetPassword(resetPasswordParameters);
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
            return apiResponse;
        }

        public async Task<ApiResponseData> ForgotPassword(ForgotPasswordData forgotPasswordParameters)
        {
            var apiResponse = await _authorizeApi.ForgotPassword(forgotPasswordParameters);
            return apiResponse;
        }

        public async Task<ApiResponseData> UpdateUser(UserInfoData userInfo)
        {
            var apiResponse = await _authorizeApi.UpdateUser(userInfo);
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
            return apiResponse;
        }

        public async Task<UserInfoData> GetUserInfo()
        {
            var user = await _authorizeApi.GetUser();
            if (user.IsAuthenticated)
            {
                return await _authorizeApi.GetUserInfo();
            }

            return AuthorizeApi.PublicUser;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var identity = new ClaimsIdentity();
            try
            {
                var userInfo = await GetUserInfo();
                if (userInfo.IsAuthenticated)
                {
                    var claims = new[] { new Claim(ClaimTypes.Name, userInfo.UserName) }.Concat(userInfo.ExposedClaims.Select(c => new Claim(c.Key, c.Value)));
                    identity = new ClaimsIdentity(claims, "Server authentication");
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("Request failed: " + ex);
            }

            Console.WriteLine("Auth state changed");
            Console.WriteLine("Authenticated: {0}", identity.IsAuthenticated);
            Console.WriteLine("User: {0}", identity.Name);
            return new AuthenticationState(new ClaimsPrincipal(identity));
        }
    }
}
