using System.ComponentModel.DataAnnotations;
using AspNetCore.Identity.Mongo.Model;

namespace industry9.Server.Identity
{
    public class ApplicationUser : MongoUser
    {
        [MaxLength(64)]
        public string FirstName { get; set; }

        [MaxLength(64)]
        public string LastName { get; set; }

        [MaxLength(64)]
        public string FullName { get; set; }
    }
}
