using System.Collections.Generic;

namespace industry9.Shared.Store.States
{
    public class UserProfileState
    {
        public bool IsLoading { get; }
        public IEnumerable<IDashboardLite> Dashboards { get; }
        public IDashboardLite SelectedDashboard { get; }

        public UserProfileState(bool isLoading, IEnumerable<IDashboardLite> dashboards, IDashboardLite selectedDashboard)
        {
            IsLoading = isLoading;
            Dashboards = dashboards;
            SelectedDashboard = selectedDashboard;
        }
    }
}
