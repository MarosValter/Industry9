using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using industry9.Server.Identity;
using industry9.Server.Middleware.Wrappers;
using industry9.Server.Services;
using industry9.Shared.Api;
using industry9.Shared.Dto.Account;
using industry9.Shared.Exception;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace industry9.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IAccountService _accountService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(
            ILogger<AccountController> logger,
            IConfiguration configuration,
            IAccountService accountService,
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _logger = logger;
            _configuration = configuration;
            _accountService = accountService;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        // POST: api/Account/Login
        [HttpPost("Login")]
        [AllowAnonymous]
        [ProducesResponseType(204)]
        [ProducesResponseType(401)]
        public async Task<ApiResponse> Login(LoginData parameters)
        {
            if (!ModelState.IsValid)
            {
                return new ApiResponse(400, "User Model is Invalid");
            }

            try
            {
                var result = await _signInManager.PasswordSignInAsync(parameters.UserName, parameters.Password, parameters.RememberMe, true);

                // If lock out activated and the max. amounts of attempts is reached.
                if (result.IsLockedOut)
                {
                    _logger.LogInformation("User Locked out: {0}", parameters.UserName);
                    return new ApiResponse(401, "User is locked out!");
                }

                // If your email is not confirmed but you require it in the settings for login.
                if (result.IsNotAllowed)
                {
                    _logger.LogInformation("User not allowed to log in: {0}", parameters.UserName);
                    return new ApiResponse(401, "Login not allowed!");
                }

                if (result.Succeeded)
                {
                    _logger.LogInformation("Logged In: {0}", parameters.UserName);
                    //var profile = _userProfileService.GetLastPageVisited(parameters.UserName);
                    return new ApiResponse(200);
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Login Failed: " + ex.Message);
            }

            _logger.LogInformation("Invalid Password for user {0}}", parameters.UserName);
            return new ApiResponse(401, "Login Failed");
        }

        // POST: api/Account/Register
        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<ApiResponse> Register(RegisterData parameters)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return new ApiResponse(400, "User Model is Invalid");
                }

                var requireConfirmEmail = Convert.ToBoolean(_configuration["industr9:RequireConfirmedEmail"] ?? "false");

                await _accountService.RegisterNewUserAsync(parameters.UserName, parameters.Email, parameters.Password, requireConfirmEmail);

                if (requireConfirmEmail)
                {
                    return new ApiResponse(200, "Register User Success");
                }

                return await Login(new LoginData
                {
                    UserName = parameters.UserName,
                    Password = parameters.Password
                });
            }
            catch (DomainException ex)
            {
                _logger.LogError("Register User Failed: {0}, {1}", ex.Description, ex.Message);
                return new ApiResponse(400, $"Register User Failed: {ex.Description} ");
            }
            catch (Exception ex)
            {
                _logger.LogError("Register User Failed: {0}", ex.Message);
                return new ApiResponse(400, "Register User Failed");
            }
        }

        // POST: api/Account/ConfirmEmail
        [HttpPost("ConfirmEmail")]
        [AllowAnonymous]
        public async Task<ApiResponse> ConfirmEmail(ConfirmEmailData parameters)
        {
            if (!ModelState.IsValid)
            {
                return new ApiResponse(400, "User Model is Invalid");
            }

            if (parameters.UserId == null || parameters.Token == null)
            {
                return new ApiResponse(404, "User does not exist");
            }

            var user = await _userManager.FindByIdAsync(parameters.UserId);
            if (user == null)
            {
                _logger.LogInformation("User does not exist: {0}", parameters.UserId);
                return new ApiResponse(404, "User does not exist");
            }

            string token = parameters.Token;
            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (!result.Succeeded)
            {
                _logger.LogInformation("User Email Confirmation Failed: {0}", result.Errors.FirstOrDefault()?.Description);
                return new ApiResponse(400, "User Email Confirmation Failed");
            }

            await _signInManager.SignInAsync(user, true);

            return new ApiResponse(200, "Success");
        }

        // POST: api/Account/ForgotPassword
        [HttpPost("ForgotPassword")]
        [AllowAnonymous]
        public async Task<ApiResponse> ForgotPassword(ForgotPasswordData parameters)
        {
            if (!ModelState.IsValid)
            {
                return new ApiResponse(400, "User Model is Invalid");
            }

            var user = await _userManager.FindByEmailAsync(parameters.Email);
            if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
            {
                _logger.LogInformation("Forgot Password with non-existent email / user: {0}", parameters.Email);
                // Don't reveal that the user does not exist or is not confirmed
                return new ApiResponse(200, "Success");
            }

            #region Forgot Password Email

            try
            {
                // TODO mail
                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=532713
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var appUrl = new Uri(_configuration["industry9:ApplicationUrl"]);
                var url = Url.Action("ResetPassword", "Account", new {userId = user.Id, token}, appUrl.Scheme, appUrl.Host);
                //string callbackUrl = string.Format("{0}/Account/ResetPassword/{1}?token={2}", _configuration["BlazorBoilerplate:ApplicationUrl"], user.Id, token); //token must be a query string parameter as it is very long

                //var email = new EmailMessageData();
                //email.ToAddresses.Add(new EmailAddressData(user.Email, user.Email));
                //email.BuildForgotPasswordEmail(user.UserName, callbackUrl, token); //Replace First UserName with Name if you want to add name to Registration Form

                //_logger.LogInformation("Forgot Password Email Sent: {0}", user.Email);
                //await _emailService.SendEmailAsync(email);
                return new ApiResponse(200, "Forgot Password Email Sent");
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Forgot Password email failed: {0}", ex.Message);
            }

            #endregion Forgot Password Email

            return new ApiResponse(200, "Success");
        }

        // PUT: api/Account/ResetPassword
        [HttpPost("ResetPassword")]
        [AllowAnonymous]
        public async Task<ApiResponse> ResetPassword(ResetPasswordData parameters)
        {
            if (!ModelState.IsValid)
            {
                return new ApiResponse(400, "User Model is Invalid");
            }

            var user = await _userManager.FindByIdAsync(parameters.UserId);
            if (user == null)
            {
                _logger.LogInformation("User does not exist: {0}", parameters.UserId);
                return new ApiResponse(404, "User does not exist");
            }

            #region Reset Password Successful Email

            try
            {
                var result = await _userManager.ResetPasswordAsync(user, parameters.Token, parameters.Password);
                if (result.Succeeded)
                {
                    #region Email Successful Password change
                    // TODO mail
                    //var email = new EmailMessageData();
                    //email.ToAddresses.Add(new EmailAddressData(user.Email, user.Email));
                    //email.BuildPasswordResetEmail(user.UserName); //Replace First UserName with Name if you want to add name to Registration Form

                    //_logger.LogInformation("Reset Password Successful Email Sent: {0}", user.Email);
                    //await _emailService.SendEmailAsync(email);

                    #endregion Email Successful Password change

                    return new ApiResponse(200, String.Format("Reset Password Successful Email Sent: {0}", user.Email));
                }
                else
                {
                    _logger.LogInformation("Error while resetting the password!: {0}", user.UserName);
                    return new ApiResponse(400, string.Format("Error while resetting the password!: {0}", user.UserName));
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Reset Password failed: {0}", ex.Message);
                return new ApiResponse(400, string.Format("Error while resetting the password!: {0}", ex.Message));
            }

            #endregion Reset Password Successful Email
        }

        // POST: api/Account/Logout
        [HttpPost("Logout")]
        [Authorize]
        public async Task<ApiResponse> Logout()
        {
            await _signInManager.SignOutAsync();
            return new ApiResponse(200, "Logout Successful");
        }

        // GET: api/Account/UserInfo
        [HttpGet("UserInfo")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        public async Task<ApiResponse> UserInfo()
        {
            var userInfo = await BuildUserInfo();
            return new ApiResponse(200, "Retrieved UserInfo", userInfo); ;
        }

        [HttpGet("GetUser")]
        public ApiResponse GetUser()
        {
            var userInfo = User != null && User.Identity.IsAuthenticated
                ? new UserInfoData { UserName = User.Identity.Name, IsAuthenticated = true }
                : AuthorizeApi.PublicUser;
            return new ApiResponse(200, "Get User Successful", userInfo);
        }

        [HttpGet("ListRoles")]
        [Authorize]
        public ApiResponse ListRoles()
        {
            var roleList = _roleManager.Roles.Select(x => x.Name).ToList();
            return new ApiResponse(200, "", roleList);
        }

        private async Task<UserInfoData> BuildUserInfo()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user != null)
            {
                try
                {
                    return new UserInfoData
                    {
                        IsAuthenticated = User.Identity.IsAuthenticated,
                        UserName = user.UserName,
                        Email = user.Email,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        UserId = user.Id.ToString(),
                        //Optionally: filter the claims you want to expose to the client
                        ExposedClaims = User.Claims.Select(c => new KeyValuePair<string, string>(c.Type, c.Value)).ToList(),
                        Roles = ((ClaimsIdentity)User.Identity).Claims
                            .Where(c => c.Type == ClaimTypes.Role)
                            .Select(c => c.Value).ToList()
                    };
                }
                catch (Exception ex)
                {
                    _logger.LogWarning("Could not build UserInfoDto: " + ex.Message);
                }
            }
            else
            {
                return new UserInfoData();
            }

            return null;
        }
    }
}
