using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using industry9.Shared.Dto;
using industry9.Shared.Dto.Account;
using Microsoft.AspNetCore.Components;

namespace industry9.Shared.Api
{
    public class AuthorizeApi : IAuthorizeApi
    {
        private readonly HttpClient _httpClient;
        private static readonly JsonSerializerOptions JsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        public static readonly UserInfoData PublicUser = new UserInfoData { IsAuthenticated = false, Roles = new List<string>() };

        public AuthorizeApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ApiResponseData> Login(LoginData loginParameters)
        {
            return await _httpClient.PostJsonAsync<ApiResponseData>("api/Account/Login", loginParameters);
        }

        public async Task<ApiResponseData> Logout()
        {
            return await _httpClient.PostJsonAsync<ApiResponseData>("api/Account/Logout", null);
        }

        public async Task<ApiResponseData> Create(RegisterData registerParameters)
        {
            return await _httpClient.PostJsonAsync<ApiResponseData>("api/Account/Create", registerParameters);

        }

        public async Task<ApiResponseData> Register(RegisterData registerParameters)
        {
            return await _httpClient.PostJsonAsync<ApiResponseData>("api/Account/Register", registerParameters);
        }

        public async Task<ApiResponseData> ForgotPassword(ForgotPasswordData forgotPasswordParameters)
        {
            return await _httpClient.PostJsonAsync<ApiResponseData>("api/Account/ForgotPassword", forgotPasswordParameters);
        }

        public async Task<ApiResponseData> ResetPassword(ResetPasswordData resetPasswordParameters)
        {
            return await _httpClient.PostJsonAsync<ApiResponseData>("api/Account/ResetPassword", resetPasswordParameters);
        }

        public async Task<ApiResponseData> ConfirmEmail(ConfirmEmailData confirmEmailParameters)
        {
            return await _httpClient.PostJsonAsync<ApiResponseData>("api/Account/ConfirmEmail", confirmEmailParameters);
        }

        public async Task<ApiResponseData> UpdateUser(UserInfoData userInfo)
        {
            return await _httpClient.PostJsonAsync<ApiResponseData>("api/Account/UpdateUser", userInfo);
        }

        public async Task<UserInfoData> GetUserInfo()
        {
            var apiResponse = await _httpClient.GetJsonAsync<ApiResponseData>("api/Account/UserInfo");
            return apiResponse.StatusCode == 200
                ? JsonSerializer.Deserialize<UserInfoData>(apiResponse.Result.ToString(), JsonOptions)
                : PublicUser;
        }

        public async Task<UserInfoData> GetUser()
        {
            var apiResponse = await _httpClient.GetJsonAsync<ApiResponseData>("api/Account/GetUser");
            var user = JsonSerializer.Deserialize<UserInfoData>(apiResponse.Result.ToString(), JsonOptions);
            return user;
        }
    }
}