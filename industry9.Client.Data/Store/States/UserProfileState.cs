using System.Collections.Generic;
using System.Linq;

namespace industry9.Client.Data.Store.States
{
    public class UserProfileState
    {
        public bool IsLoading { get; }
        public IEnumerable<IDashboardLite> Dashboards { get; }
        public IDashboardLite SelectedDashboard { get; }

        public UserProfileState(bool isLoading, IEnumerable<IDashboardLite> dashboards, IDashboardLite selectedDashboard)
        {
            IsLoading = isLoading;
            Dashboards = dashboards ?? Enumerable.Empty<IDashboardLite>();
            SelectedDashboard = selectedDashboard;
        }
    }
}
