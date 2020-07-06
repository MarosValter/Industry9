using AspNetCore.Identity.Mongo.Model;

namespace industry9.Server.Identity
{
    public class ApplicationRole : MongoRole
    {
        public ApplicationRole(string name) : base(name)
        {
            
        }
    }
}
