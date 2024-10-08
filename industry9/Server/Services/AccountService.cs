﻿using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using industry9.Server.Authorization;
using industry9.Server.Identity;
using industry9.Shared.Authorization;
using industry9.Shared.Exception;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace industry9.Server.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<AccountService> _logger;
        //private readonly IEmailService _emailService;
        private readonly IConfiguration _configuration;

        public AccountService(ILogger<AccountService> logger, UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            _logger = logger;
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<ApplicationUser> RegisterNewUserAsync(string userName, string email, string password, bool requireConfirmEmail)
        {
            var user = new ApplicationUser
            {
                UserName = userName,
                Email = email
            };

            var createUserResult = password == null ?
                await _userManager.CreateAsync(user) :
                await _userManager.CreateAsync(user, password);

            if (!createUserResult.Succeeded)
            {
                throw new DomainException(createUserResult.Errors.FirstOrDefault()?.Description);
            }

            await _userManager.AddClaimsAsync(user, new []{
                    new Claim(ApplicationRoleType.User.ToClaim(),"true", ClaimValueTypes.Boolean),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Email, user.Email),
                    // TODO claim
                    //new Claim(JwtClaimTypes.EmailVerified, "false", ClaimValueTypes.Boolean)
                });

            //Role - Here we tie the new user to the "User" role
            await _userManager.AddToRoleAsync(user, ApplicationRoleType.User.ToName());

            _logger.LogInformation("New user registered: {0}", user);

            // TODO mail
            //var emailMessage = new EmailMessageData();

            //if (requireConfirmEmail)
            //{
            //    // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=532713
            //    var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            //    string callbackUrl = string.Format("{0}/Account/ConfirmEmail/{1}?token={2}", _configuration["BlazorBoilerplate:ApplicationUrl"], user.Id, token);

            //    emailMessage.BuildNewUserConfirmationEmail(user.UserName, user.Email, callbackUrl, user.Id.ToString(), token); //Replace First UserName with Name if you want to add name to Registration Form
            //}
            //else
            //{
            //    emailMessage.BuildNewUserEmail(user.FullName, user.UserName, user.Email, password);
            //}

            //emailMessage.ToAddresses.Add(new EmailAddressDto(user.Email, user.Email));
            //try
            //{
            //    await _emailService.SendEmailAsync(emailMessage);
            //}
            //catch (Exception ex)
            //{
            //    _logger.LogInformation("New user email failed: Body: {0}, Error: {1}", emailMessage.Body, ex.Message);
            //}

            return user;
        }
    }
}