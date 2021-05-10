using System;
using System.Text.Json;
using System.Threading.Tasks;
using industry9.Shared.Api;
using industry9.Shared.Dto.Account;

namespace industry9.Shared
{
    public class AppState
    {
        public event Action OnChange;
        private readonly IUserProfileApi _userProfileApi;

        public UserProfileData UserProfile { get; set; }


        public AppState(IUserProfileApi userProfileApi)
        {
            _userProfileApi = userProfileApi;
        }

        public bool IsNavOpen
        {
            get
            {
                if (UserProfile == null)
                {
                    return true;
                }
                return UserProfile.IsNavOpen;
            }
            set
            {
                UserProfile.IsNavOpen = value;
            }
        }
        public bool IsNavMinified { get; set; }

        public async Task UpdateUserProfile()
        {
            await _userProfileApi.Upsert(UserProfile);
        }

        public async Task<UserProfileData> GetUserProfile()
        {
            if (UserProfile != null && UserProfile.UserId != Guid.Empty)
            {
                return UserProfile;
            }

            var apiResponse = await _userProfileApi.Get();

            //if (!apiResponse.HasErrors)
            //{
            //    return JsonSerializer.Deserialize<UserProfileData>(apiResponse.Data.ToString());
            //}

            return new UserProfileData();
        }

        //public async Task UpdateUserProfileCount(int count)
        //{
        //    UserProfile.Count = count;
        //    await UpdateUserProfile();
        //    NotifyStateChanged();
        //}

        //public async Task<int> GetUserProfileCount()
        //{
        //    if (UserProfile == null)
        //    {
        //        UserProfile = await GetUserProfile();
        //        return UserProfile.Count;
        //    }

        //    return UserProfile.Count;
        //}

        public async Task SaveLastVisitedUri(string uri)
        {
            if (UserProfile == null)
            {
                UserProfile = await GetUserProfile();
            }
            if (UserProfile != null)
            {
                UserProfile.LastPageVisited = uri;
                await UpdateUserProfile();
                NotifyStateChanged();
            }
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
