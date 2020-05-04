using System;
using System.ComponentModel.DataAnnotations;

namespace industry9.Shared.Dto.Account
{
    public class UserProfileData
    {
        [Key]
        public Guid UserId { get; set; }
        public long Id { get; set; }
        [Required]
        public string LastPageVisited { get; set; } = "/";
        public bool IsNavOpen { get; set; } = true;
        public bool IsNavMinified { get; set; } = false;
        public int Count { get; set; } = 0;
    }
}
