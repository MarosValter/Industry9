using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using industry9.Server.Authorization;
using industry9.Server.Identity;
using industry9.Shared.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace industry9.Server.Data
{
    public class DatabaseInitializer : IDatabaseInitializer
    {
        private readonly ILogger<DatabaseInitializer> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public DatabaseInitializer(ILogger<DatabaseInitializer> logger, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            _logger = logger;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task SeedAsync()
        {
            await SeedASPIdentityAsync();
        }

        private async Task SeedASPIdentityAsync()
        {
            if (_userManager.Users.Any())
            {
                return;
            }

            //Generating inbuilt accounts
            await EnsureRoleAsync(ApplicationRoleType.Administrator.ToName(), ApplicationPermissions.GetAllPermissionValues());
            await EnsureRoleAsync(ApplicationRoleType.User.ToName(), null);

            await CreateUserAsync("admin", "123", "Admin", "Blazor", "Administrator", "admin@industry9.com", "+1 (123) 456-7890", new [] { ApplicationRoleType.Administrator });
            await CreateUserAsync("user", "123", "User", "Blazor", "User Blazor", "user@industry9.com", "+1 (123) 456-7890`", new [] { ApplicationRoleType.User });

            _logger.LogInformation("Inbuilt account generation completed");
        }

        private async Task EnsureRoleAsync(string roleName, string[] claims)
        {
            if (await _roleManager.FindByNameAsync(roleName) != null)
            {
                return;
            }

            if (claims == null)
            {
                claims = new string[] { };
            }

            var invalidClaims = claims.Where(c => ApplicationPermissions.GetPermissionByValue(c) == null).ToArray();
            if (invalidClaims.Any())
            {
                throw new Exception("The following claim types are invalid: " + string.Join(", ", invalidClaims));
            }

            var appRole = new ApplicationRole(roleName);
            await _roleManager.CreateAsync(appRole);

            foreach (var claim in claims.Distinct())
            {
                var result = await _roleManager.AddClaimAsync(appRole, new Claim(ClaimConstants.Permission, ApplicationPermissions.GetPermissionByValue(claim)));
                if (!result.Succeeded)
                {
                    await _roleManager.DeleteAsync(appRole);
                    break;
                }
            }
        }

        private async Task CreateUserAsync(
            string userName, string password,
            string firstName, string fullName, string lastName,
            string email, string phoneNumber, ApplicationRoleType[] roles)
        {
            var applicationUser = await _userManager.FindByNameAsync(userName);
            if (applicationUser != null)
            {
                return;
            }

            applicationUser = new ApplicationUser
            {
                UserName = userName,
                Email = email,
                PhoneNumber = phoneNumber,
                FullName = fullName,
                FirstName = firstName,
                LastName = lastName
            };

            var result = _userManager.CreateAsync(applicationUser, password).Result;
            if (!result.Succeeded)
            {
                throw new Exception(result.Errors.First().Description);
            }

            result = await _userManager.AddClaimsAsync(applicationUser, new []{
                new Claim(ClaimTypes.Name, userName),
                new Claim(ClaimTypes.GivenName, firstName),
                new Claim(ClaimTypes.Surname, lastName),
                new Claim(ClaimTypes.Email, email),
                // TODO claim
                //new Claim(ClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                new Claim(ClaimTypes.MobilePhone, phoneNumber)


            });

            if (!result.Succeeded)
            {
                await _userManager.DeleteAsync(applicationUser);
                return;
            }

            //add claims version of roles
            foreach (var role in roles.Distinct())
            {
                result = await _userManager.AddClaimAsync(applicationUser, new Claim(role.ToClaim(), "true", ClaimValueTypes.Boolean));
                if (!result.Succeeded)
                {
                    await _userManager.DeleteAsync(applicationUser);
                    return;
                }
            }

            result = await _userManager.AddToRolesAsync(applicationUser, roles.Distinct().Select(x => x.ToName()));
            if (!result.Succeeded)
            {
                await _userManager.DeleteAsync(applicationUser);
                return;
            }
        }
    }
}