using System.Collections.Generic;

namespace industry9.Shared.Store.UserProfile
{
    public class FetchUserProfileResultAction
    {
        public IDashboard1 SelectedDashboard { get; }
        public IEnumerable<IDashboard1> Dashboards { get; }

        public FetchUserProfileResultAction(IDashboard1 selectedDashboard, IEnumerable<IDashboard1> dashboards)
        {
            SelectedDashboard = selectedDashboard;
            Dashboards = dashboards;
        }
    }
}
