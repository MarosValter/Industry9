using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using industry9.Shared.Dto.Account;
using StrawberryShake;

namespace industry9.Shared.Api
{
    public class UserProfileApi : IUserProfileApi
    {
        public Task<IOperationResult> Upsert(UserProfileData userProfile)
        {
            throw new System.NotImplementedException();
        }

        public Task<IOperationResult> Get()
        {
            return Task.FromResult<IOperationResult>(new OperationResult<UserProfileData>(new UserProfileData
                {
                    
                },
                new List<IError>(), new ReadOnlyDictionary<string, object>(new Dictionary<string, object>())));
        }
    }
}