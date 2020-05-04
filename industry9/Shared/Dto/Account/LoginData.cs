using System.ComponentModel.DataAnnotations;

namespace industry9.Shared.Dto.Account
{
    public class LoginData
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
