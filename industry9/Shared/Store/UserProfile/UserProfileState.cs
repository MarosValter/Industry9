using System;
using System.Collections.Generic;
using System.Text;

namespace industry9.Shared.Store.UserProfile
{
    public class UserProfileState
    {
        public bool IsLoading { get; }
        public IEnumerable<IDashboard1> Dashboards { get; }
        public IDashboard1 SelectedDashboard { get; }

        public UserProfileState(bool isLoading, IEnumerable<IDashboard1> dashboards, IDashboard1 selectedDashboard)
        {
            IsLoading = isLoading;
            Dashboards = dashboards;
            SelectedDashboard = selectedDashboard;
        }
    }
}
