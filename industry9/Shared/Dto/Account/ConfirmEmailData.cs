using System.ComponentModel.DataAnnotations;

namespace industry9.Shared.Dto.Account
{
    public class ConfirmEmailData
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public string Token { get; set; }
    }
}
