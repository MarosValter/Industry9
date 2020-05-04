using System.Collections.Generic;
using System.Threading.Tasks;
using industry9.Shared.Dto.Account;
using StrawberryShake;

namespace industry9.Shared.Api
{
    public interface IMembershipApi
    {
        Task<IOperationResult<List<UserInfoData>>> GetUsers();
    }
}
