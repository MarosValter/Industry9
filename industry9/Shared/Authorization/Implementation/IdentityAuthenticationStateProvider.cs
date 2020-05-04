﻿using System;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using industry9.Shared.Api;
using industry9.Shared.Dto.Account;
using Microsoft.AspNetCore.Components.Authorization;
using StrawberryShake;

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

        public async Task<IOperationResult> Login(LoginData loginParameters)
        {
            var apiResponse = await _authorizeApi.Login(loginParameters);
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
            return apiResponse;
        }

        public async Task<IOperationResult> Register(RegisterData registerParameters)
        {
            var apiResponse = await _authorizeApi.Register(registerParameters);
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
            return apiResponse;
        }

        public async Task<IOperationResult> Create(RegisterData registerParameters)
        {
            var apiResponse = await _authorizeApi.Create(registerParameters);
            return apiResponse;
        }

        public async Task<IOperationResult> Logout()
        {
            _appState.UserProfile = null;
            var apiResponse = await _authorizeApi.Logout();
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
            return apiResponse;
        }

        public async Task<IOperationResult> ConfirmEmail(ConfirmEmailData confirmEmailParameters)
        {
            var apiResponse = await _authorizeApi.ConfirmEmail(confirmEmailParameters);
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
            return apiResponse;
        }

        public async Task<IOperationResult> ResetPassword(ResetPasswordData resetPasswordParameters)
        {
            var apiResponse = await _authorizeApi.ResetPassword(resetPasswordParameters);
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
            return apiResponse;
        }

        public async Task<IOperationResult> ForgotPassword(ForgotPasswordData forgotPasswordParameters)
        {
            var apiResponse = await _authorizeApi.ForgotPassword(forgotPasswordParameters);
            return apiResponse;
        }

        public async Task<UserInfoData> GetUserInfo()
        {
            var userInfo = await _authorizeApi.GetUser();
            // TODO auth
            //bool IsAuthenticated = userInfo.IsAuthenticated;
            //if (IsAuthenticated)
            //{
            //    userInfo = await _authorizeApi.GetUserInfo();
            //}
            //else
            //{
            //    userInfo = new UserInfoData { IsAuthenticated = false, Roles = new List<string>() };
            //}
            return userInfo;
        }

        public async Task<IOperationResult> UpdateUser(UserInfoData userInfo)
        {
            var apiResponse = await _authorizeApi.UpdateUser(userInfo);
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
            return apiResponse;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var identity = new ClaimsIdentity();
            try
            {
                var userInfo = await GetUserInfo();
                // TODO auth
                //if (userInfo.IsAuthenticated)
                //{
                //    var claims = new[] { new Claim(ClaimTypes.Name, userInfo.UserName) }.Concat(userInfo.ExposedClaims.Select(c => new Claim(c.Key, c.Value)));
                //    identity = new ClaimsIdentity(claims, "Server authentication");
                //}
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("Request failed:" + ex.ToString());
            }

            return new AuthenticationState(new ClaimsPrincipal(identity));
        }
    }
}
